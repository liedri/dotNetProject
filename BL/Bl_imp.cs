using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using BE;
using DAL;
using System.Net.Mail;
using System.ComponentModel;
using System.Threading;

namespace BL
{
    class Bl_imp : IBl
    {
        IDal dal = FactoryDal.GetDal();
        #region Host Functions
        public void AddHost(Host host)
        {
            try
            {
                if (!CheackEmailAddress(host.Email))
                    throw new InvalidOperationException("The email Addresss is invalid");
                dal.AddHost(host);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public void UpdateHost(Host host)
        {
            try
            {
                if (!CheackEmailAddress(host.Email))
                    throw new InvalidOperationException("The email Addresss is invalid");
            }
            catch (Exception e)
            {
                throw e;
            }
            dal.UpdateHost(host);
        }
        public void DeleteHost(Host host)
        {
            try
            {
                var v = from item in GetHostingUnitList()
                        where item.Owner.HostKey == host.HostKey
                        select item;
                v.ToList();
                if(v.FirstOrDefault() != null)
                    throw new InvalidOperationException("Can not delete this Host because there is a connected Hosting Unit");
                dal.DeleteHost(host);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public List<Host> GetHostList()
        {
            return dal.GetHostList();
        }

        public Host GetHostById(int key)
        {
            return dal.GetHostById(key);
        }
        #endregion

        #region GuestRequest Functions

        /// <summary>
        /// adds a new guest request to the data
        /// </summary>
        /// <param name="guestRequest"></param>
        public void AddGuestRequest(GuestRequest guestRequest)
        {
            try
            {
                if (guestRequest.EntryDate >= guestRequest.ReleaseDate)
                    throw new InvalidOperationException("Entry Date Must Be At Least One Day Before Release Date");
                if (!CheackEmailAddress(guestRequest.Email))
                    throw new InvalidOperationException("The email Addresss is invalid");
                Order order = new Order();
                order.GuestRequestKey = Configuration.GuestRequestKey - 1;

                dal.AddGuestRequest(guestRequest);

                AddOrder(order);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// updates a guest request in the data
        /// </summary>
        /// <param name="guestRequest"></param>
        public void UpdateGuestRequest(GuestRequest guestRequest)
        {
            try
            {
                if (guestRequest.EntryDate >= guestRequest.ReleaseDate)
                    throw new InvalidOperationException("Entry Date Must Be At Least One Day Before Release Date");
                if (!CheackEmailAddress(guestRequest.Email))
                    throw new InvalidOperationException("The email Addresss is invalid");
            }
            catch (Exception e)
            {
                throw e;
            }
            dal.UpdateGuestRequest(guestRequest);
        }

        public GuestRequest GetGuestRequestByKey(int key)
        {
            return dal.GetGuestRequestByKey(key);
        }

        /// <summary>
        /// returns a list of all guest requests that expired
        /// </summary>
        /// <returns></returns>
        public List<GuestRequest> DealExpires()
        {
            List<GuestRequest> guestRequests = GetGuestRequestList();
            var v = from item in guestRequests
                    where item.RequirementStatus == Enums.RequirementStatus.DealExpires
                    select item;
            return v.ToList();
        }

        /// <summary>
        /// returns a list of guest requests from the data
        /// </summary>
        /// <returns></returns>
        public List<GuestRequest> GetGuestRequestList()
        {
            return dal.GetGuestRequestList();
        }

        /// <summary>
        /// returns all guest requests that have a specific condition
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public IEnumerable<GuestRequest> GetAllGuesstRequests(Func<GuestRequest, bool> predicate = null)
        {
            List<GuestRequest> guestRequests = GetGuestRequestList();
            if (predicate == null)
                return guestRequests.AsEnumerable().Select(t => t.Clone());
            return guestRequests.Where(predicate).Select(t => t.Clone());
        }
        #endregion

        #region HostingUnit Functions

        /// <summary>
        /// adds a new hosting unit to the data
        /// </summary>
        /// <param name="hostingUnit"></param>
        public void AddHostingUnit(HostingUnit hostingUnit)
        {
            try
            {
                dal.AddHostingUnit(hostingUnit);
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// deletes a hosting unit from the data
        /// </summary>
        /// <param name="hostingUnitkey"></param>
        public void DeleteHostingUnit(int hostingUnitkey)
        {
            try
            {
                List<Order> orders = GetOrderList();
                var myOrder = from item in orders
                              where item.HostingUnitKey == hostingUnitkey
                              select item;
                myOrder.ToList();

                for (int i = 0; i < myOrder.Count(); i++)
                {
                    if (myOrder.ElementAt(i).Status == Enums.OrderStatus.EmailSent || myOrder.ElementAt(i).Status == Enums.OrderStatus.NotYetAddressed)
                        throw new InvalidOperationException("Can not delete this Hosting unit because there is a connected order");
                }
                dal.DeleteHostingUnit(hostingUnitkey);
            }
            catch(Exception e)
            {
                throw e;
            }

        }

        /// <summary>
        /// updates a hosting unit in the data
        /// </summary>
        /// <param name="hostingUnit"></param>
        public void UpdateHostingUnit(HostingUnit hostingUnit)
        {
            try
            {
                dal.UpdateHostingUnit(hostingUnit);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// returns a list of hosting units that are available
        /// </summary>
        /// <param name="date"></param>
        /// <param name="numOfDays"></param>
        /// <returns></returns>
        public List<HostingUnit> GetAvailableHostingUnitList(DateTime date, int numOfDays)
        {
            List<HostingUnit> hostingUnits = GetHostingUnitList();
            List<HostingUnit> Answer = new List<HostingUnit>();
            bool flag;
            DateTime dateTime;
            foreach (HostingUnit v in hostingUnits)
            {
                dateTime = date;
                flag = true;//הנחה שהתאריכים פנויים
                for (int i = 0; i < numOfDays; i++)
                {
                    if (v.Diary[dateTime.Month, dateTime.Day] == true)
                        flag = false;//אם התאריכים לא פנויים יסומן בשלילה
                    dateTime.AddDays(1);
                }
                if (flag)
                    Answer.Add(v);
            }
            return Answer;
        }

        /// <summary>
        /// returns a list of hosting units
        /// </summary>
        /// <returns></returns>
        public List<HostingUnit> GetHostingUnitList()
        {
            return dal.GetHostingUnitList();
        }

        /// <summary>
        /// returns a list of 5 stars hosting units
        /// </summary>
        /// <returns></returns>
        public List<HostingUnit> FiveStars()
        {
            List<HostingUnit> hostingUnits = GetHostingUnitList();
            var v = from item in hostingUnits
                    where (item.Pool == true && item.Porch == true && item.Jacuzzi == true && item.Food == Enums.Food.All)
                    select item;
            return v.ToList();
        }

        /// <summary>
        /// returns a list of hosting units that are hotels
        /// </summary>
        /// <returns></returns>
        public List<HostingUnit> Hotels()
        {
            List<HostingUnit> hostingUnits = GetHostingUnitList();
            var v = from item in hostingUnits
                    where item.HostingUnitType == Enums.HostingUnitType.Hotel
                    select item;
            return v.ToList();
        }

        /// <summary>
        /// returns the number of hosting units up north
        /// </summary>
        /// <returns></returns>
        public int numOfHostingUnitsUpNorth()
        {
            List<HostingUnit> hostingUnits = GetHostingUnitList();
            var v = from item in hostingUnits
                    where item.Area == Enums.Area.North
                    select item;
            return v.ToList().Count();
        }

        /// <summary>
        /// returns a list of hosting units that have children attractions
        /// </summary>
        /// <returns></returns>
        public List<HostingUnit> HasChildrenAttractions()
        {
            List<HostingUnit> hostingUnits = GetHostingUnitList();
            var v = from item in hostingUnits
                    where item.ChildrenAttractions == true
                    select item;
            return v.ToList();
        }
        #endregion

        #region Order Functions

        Order orderEmail = new Order();

        /// <summary>
        /// adds a new order to the data
        /// </summary>
        /// <param name="order"></param>
        public void AddOrder(Order order)
        {
            try
            {
                GuestRequest g = GetGuestRequestByKey(order.GuestRequestKey); //מחזיר את הבקשה לפי הקוד

                List<HostingUnit> hostingUnits = checkMatch(g); //מחזיר רשימה של כל המתאימים
                if (hostingUnits.FirstOrDefault() == null)
                    throw new KeyNotFoundException("They are no available hosting unit for your request");

                foreach (HostingUnit item in hostingUnits) //עבור כל התאמה מוסיף הזמנה
                {
                    order.HostingUnitKey = item.HostingUnitKey;
                    dal.AddOrder(order);
                }
              
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// updates a order in the data
        /// </summary>
        /// <param name="order"></param>
        public void UpdateOrder(Order order)
        {
            try
            {
                List<Order> orders = GetOrderList();
                var myOrder = from item in orders
                              where item.OrderKey == order.OrderKey
                              select item;
                myOrder.ToList();
                if ((myOrder.First().Status == Enums.OrderStatus.CloseByClient))
                    throw new InvalidOperationException("This order is already closed");

                List<HostingUnit> hostingUnits = GetHostingUnitList();
                var MyHostingUnits = from item in hostingUnits
                                     where item.HostingUnitKey == order.HostingUnitKey
                                     select item;
                MyHostingUnits.ToList();
                if (order.Status == Enums.OrderStatus.NotYetAddressed)
                    throw new InvalidOperationException("You can not change the status");

                if (order.Status == Enums.OrderStatus.EmailSent)
                { 
                    if (((MyHostingUnits.First()).Owner).CollectionClearance)
                    {
                        order.OrderDate = DateTime.Today;
                        dal.UpdateOrder(order);
                        Console.WriteLine("Email send");

                        orderEmail.GuestRequestKey = order.GuestRequestKey;
                        orderEmail.HostingUnitKey = order.HostingUnitKey;
                        BackgroundWorker worker = new BackgroundWorker();
                        worker.DoWork += EmailWorker_DoWork;
                        worker.RunWorkerAsync();

                        return;
                    }
                    throw new InvalidOperationException("The host didnt sign a bank account debit authorization");
                }

                if (order.Status == Enums.OrderStatus.CloseByClient)
                {
                    //חישוב עמלה
                    float commission;
                    List<GuestRequest> guestRequests1 = GetGuestRequestList();
                    var orderDays = from item in guestRequests1
                                    where item.GuestRequestKey == order.GuestRequestKey
                                    select item;
                    orderDays.ToList();
                    if (orderDays.FirstOrDefault() == null)
                        throw new KeyNotFoundException("Guest Request Not Found");
                    double numOfDays = (orderDays.First().ReleaseDate - orderDays.First().EntryDate).TotalDays;
                    commission = (float)numOfDays * BE.Configuration.CommissionAmount;
                    BE.Configuration.AllCommissions = BE.Configuration.AllCommissions + commission;

                    List<GuestRequest> guestRequests = GetGuestRequestList();
                    var m = from item in guestRequests
                            where item.GuestRequestKey == order.GuestRequestKey
                            select item;
                    m.ToList();

                    HostingUnit h;

                    if (MyHostingUnits.First() == null)
                        throw new KeyNotFoundException("The Host unit didnt exist");
                    else
                    {
                        h = MyHostingUnits.First();
                        for (DateTime i = m.First().EntryDate; i < m.First().ReleaseDate; i = i.AddDays(1))
                        {
                            if (h.Diary[i.Month - 1, i.Day - 1] == true)
                                throw new InvalidOperationException("These dates are already taken");
                        }
                        for (DateTime i = m.First().EntryDate; i < m.First().ReleaseDate; i = i.AddDays(1))
                        {
                            h.Diary[i.Month - 1, i.Day - 1] = true;
                        }
                      
                    }
                    m.First().RequirementStatus = Enums.RequirementStatus.DealMade;
                    UpdateGuestRequest(m.FirstOrDefault());
                    UpdateHostingUnit(h);
                    // עדכון הזמנות האחרות של אותו לקוח
                    for (int i = 1; i < m.Count(); i++)
                    {
                        m.ElementAt(i).RequirementStatus = Enums.RequirementStatus.DealExpires;
                    }
                }
                dal.UpdateOrder(Cloning.Clone(order));
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// returns a list of orders
        /// </summary>
        /// <returns></returns>
        public List<Order> GetOrderList()
        {
                return dal.GetOrderList();
        }

        /// <summary>
        /// returns a list of orders that are pass
        /// </summary>
        /// <param name="numOfDays"></param>
        /// <returns></returns>
        public List<Order> GetPassOrdersList(int numOfDays)
        {
            List<Order> orders = GetOrderList();
            List<Order> Answer = new List<Order>();
            foreach (Order order in orders)
            {
                if ((DateTime.Today - order.CreateDate).TotalDays >= numOfDays || (DateTime.Today - order.OrderDate).TotalDays >= numOfDays)
                    Answer.Add(order);
            }
            return Answer;
        }

        /// <summary>
        /// returns the number of orders for a specific guest request
        /// </summary>
        /// <param name="guestRequest"></param>
        /// <returns></returns>
        public int NumOfOrders(GuestRequest guestRequest)
        {
            try
            {
                List<Order> orders = GetOrderList();
                var v = from item in orders
                        where item.GuestRequestKey == guestRequest.GuestRequestKey
                        select item;
                v.ToList();
                if (v.FirstOrDefault() == null)
                    throw new InvalidOperationException("This guest request has no orders");
                return v.Count();
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// returns the number of sent and closed orders
        /// </summary>
        /// <param name="hostingUnit"></param>
        /// <returns></returns>
        public int NumOfSendOrdersAndCloseOrders(HostingUnit hostingUnit)
        {
            try
            {
                List<Order> orders = GetOrderList();
                var v = from item in orders
                        where item.HostingUnitKey == hostingUnit.HostingUnitKey
                        select item;
                v.ToList();
                if (v.FirstOrDefault() == null)
                    throw new InvalidOperationException("This guest request has no orders");
                return v.Count();
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// returns a list of orders that are not yet addressed
        /// </summary>
        /// <returns></returns>
        public List<Order> NotYetAddressedOrders()
        {
            List<Order> orders = GetOrderList();
            var v = from item in orders
                    where item.Status == Enums.OrderStatus.NotYetAddressed
                    select item;
            return v.ToList();
        }
        #endregion

        #region Grouping Functions

        /// <summary>
        /// returns groups of guest requests by area
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IGrouping<Enums.Area, GuestRequest>> GetGuestRequestsByArea()
        {
            return from item in GetGuestRequestList()
                   group item by item.Area into list1
                   select list1;
        }

        /// <summary>
        /// returns groups of guest requests by number of people
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IGrouping<int, GuestRequest>> GetGuestRequestsByNumOfPeople()
        {
            return from item in GetGuestRequestList()
                   group item by (item.NumOfAdults + item.NumOfKids) into list1
                   select list1;
           
        }

        /// <summary>
        /// returns groups of hosts by number of hosting units 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IGrouping<int, Host>> GetHostsByNumOfHostingUnits()
        {
            var v = from item in GetHostingUnitList()
                    select item.Owner;
            v.ToList();

            var x = v.GroupBy(y => y.HostKey).Select(z => z.First());
            x.ToList();
            return from item in x
                   group item by numOfHostingUnits(item) into list
                   orderby list.Key
                   select list;
        }

        /// <summary>
        /// returns groups of hosting units by area
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IGrouping<Enums.Area, HostingUnit>> GetHostingUnitsByArea()
        {
            return from item in dal.GetHostingUnitList()
                   group item by item.Area into list1
                   select list1;
        }
        #endregion

        #region Other Functions

        





        /// <summary>
        /// returns a number of days between today and an input date
        /// </summary>
        /// <param name="d1"></param>
        /// <returns></returns>
        public double BetweenDays(DateTime d1)
        {
            if ((DateTime.Today - d1).TotalDays < 0)
                throw new InvalidOperationException("The date is incorrect");
            return (DateTime.Today - d1).TotalDays;
        }

        /// <summary>
        /// returns a number of days between two dates 
        /// </summary>
        /// <param name="d1"></param>
        /// <param name="d2"></param>
        /// <returns></returns>
        public double BetweenDays(DateTime d1, DateTime d2)
        {
            if ((d2 - d1).TotalDays < 0)
                throw new InvalidOperationException("The dates are incorrect");
            return (d2 - d1).TotalDays;
        }

        /// <summary>
        /// returns a list of bank accounts
        /// </summary>
        /// <returns></returns>
        public List<BankBranch> GetBankAccounts()
        {
            return dal.GetBankAccounts();
        }

        /// <summary>
        /// checks if the email address is valid
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        private bool CheackEmailAddress(string email)
        {
            var regex = @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";
            bool isValid = Regex.IsMatch(email, regex, RegexOptions.IgnoreCase);
            return isValid;
        }

        /// <summary>
        /// returns a number of hosting units for a specific host
        /// </summary>
        /// <param name="host"></param>
        /// <returns></returns>
        public int numOfHostingUnits(Host host)
        {
            int count = 0;
            foreach(HostingUnit item in GetHostingUnitList())
            {
                if (item.Owner.HostKey == host.HostKey)
                    count++;
            }
            return count;
        }

        public List<HostingUnit> checkMatch(GuestRequest guestRequest)
        {
            var v = from item in dal.GetHostingUnitList()
                    where checkMatchHelp(guestRequest, item) == true
                    select item;
            return v.ToList();
        }

        public bool checkMatchHelp(GuestRequest guestRequest,HostingUnit hostingUnit)
        {
            if (guestRequest.Area != Enums.Area.All && guestRequest.Area != hostingUnit.Area)
                return false;
            if (guestRequest.HostingUnitType != Enums.HostingUnitType.All && guestRequest.HostingUnitType != hostingUnit.HostingUnitType)
                return false;
            if (guestRequest.Pool != Enums.Options.Optional && (guestRequest.Pool == Enums.Options.Necessary) != hostingUnit.Pool && (guestRequest.Pool == Enums.Options.NotInterested) == hostingUnit.Pool)
                return false;
            if (guestRequest.Jacuzzi != Enums.Options.Optional && (guestRequest.Jacuzzi == Enums.Options.Necessary) != hostingUnit.Jacuzzi && (guestRequest.Jacuzzi == Enums.Options.NotInterested) == hostingUnit.Jacuzzi)
                return false;
            if (guestRequest.Porch != Enums.Options.Optional && (guestRequest.Porch == Enums.Options.Necessary) != hostingUnit.Porch && (guestRequest.Porch == Enums.Options.NotInterested) != hostingUnit.Porch)
                return false;
            if (guestRequest.ChildrenAttractions != Enums.Options.Optional && (guestRequest.ChildrenAttractions == Enums.Options.Necessary) != hostingUnit.ChildrenAttractions && (guestRequest.ChildrenAttractions == Enums.Options.NotInterested) != hostingUnit.ChildrenAttractions)
                return false;
            if (guestRequest.Food != hostingUnit.Food)
                return false;
            if (guestRequest.NumOfTotalPeople > hostingUnit.Beds)
                return false;
            for (DateTime i = guestRequest.EntryDate; i < guestRequest.ReleaseDate; i = i.AddDays(1))
            {
                if (hostingUnit.Diary[i.Month - 1, i.Day - 1] == true)
                    return false;
            }
            return true;
        }
        #endregion
        #region Threads
        private void closeOrders() //Thread function-Closes expired orders every 24 hours.
        {
            while (true)
            {
                foreach (Order item in GetPassOrdersList(Configuration.NumOfExpireDays))
                {
                    item.Status = BE.Enums.OrderStatus.ClientDidntRespond;
                    UpdateOrder(item);
                    foreach(GuestRequest g in GetGuestRequestList())
                    {
                        if(item.GuestRequestKey == g.GuestRequestKey)
                        {
                            g.RequirementStatus = Enums.RequirementStatus.DealExpires;
                            UpdateGuestRequest(g);
                        }
                    }
                }   
                Thread.Sleep(86400000);
            }

        }


        private void EmailWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            HostingUnit hostingUnit = GetHostingUnitList().Find(x => x.HostingUnitKey == orderEmail.HostingUnitKey);
            GuestRequest guestRequest = GetGuestRequestList().Find(x => x.GuestRequestKey == orderEmail.GuestRequestKey);

            MailMessage mail = new MailMessage();
            mail.To.Add(guestRequest.Email);
            mail.From = new MailAddress("michalliproject@gmail.com");
            mail.Subject = "Match Found";
            mail.Body = "Hi " + guestRequest.FirstName + "!<br>" + "we found you a match by: " + hostingUnit.Owner.FirstName + " in the hosting unit: " + hostingUnit.HostingUnitName + "<br> enjoy, Edri's Club";
            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Credentials = new System.Net.NetworkCredential("michalliproject@gmail.com", "michalli05656133");
            smtp.EnableSsl = true;
            try
            {
                smtp.Send(mail);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
