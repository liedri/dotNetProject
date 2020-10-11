using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DS;

namespace DAL 
{
    public class Dal_imp : IDal
    {
        #region Host Functions

        void IDal.AddHost(Host host)
        {
            //בודק האם המארח קיים
            var v = from item in DataSource.HostsList
                    where item.HostKey == host.HostKey
                    select item;
            if(v.FirstOrDefault() != null)//אם המארח קיים תזרוק שגיאה
            {
                throw new InvalidOperationException("The Host Already Exist");
            }
            host.NumOfHostingUnits = 0;
            host.HostPassword = Configuration.HostPassword++;
            DS.DataSource.HostsList.Add(host.Clone());//אם המארח ךא קיים ניצור מארח חדש
        }
        void IDal.UpdateHost(Host host)
        {
            int Index = DataSource.HostsList.FindIndex(t => t.HostKey == host.HostKey);
            //מחפש את האינדקס של המארח עם אותו קוד
            if (Index == -1)//אם האינדקס = -1 כלומר, לא קיים מארח כזה אז המערכת תזרוק שגיאה
                throw new KeyNotFoundException("The Host Does Not Exist");
            DataSource.HostsList[Index] = host.Clone();//במידה והמארח קיים נעדכן אותו
        }
        void IDal.DeleteHost(Host host)
        {
            var v = from item in DataSource.HostsList
                    where item.HostKey == host.HostKey
                    select item;
            if (v.FirstOrDefault() == null)
            {
                throw new KeyNotFoundException("The Host Does Not Exist");
            }
            DataSource.HostsList.Remove(v.First());
        }
        public List<Host> GetHostList()
        {
            var v = from item in DataSource.HostsList
                    select item.Clone();
            return v.ToList();
        }

        public Host GetHostById(int key)
        {
            var v = from item in DataSource.HostsList
                    where item.HostKey == key
                    select item;
            if(v.FirstOrDefault() == null)
            {
                throw new KeyNotFoundException("The Host Does Not Exist");
            }
            return v.First().Clone();
        }
        #endregion
        #region GuestRequest Functions

        /// <summary>
        /// adds a new guest request to the data
        /// </summary>
        /// <param name="guestRequest"></param>
        void IDal.AddGuestRequest(GuestRequest guestRequest)
        {
            //בודק אם הבקשה קיימת כבר
            var v = from item in DataSource.GuestRequestsList
                    where item.GuestRequestKey == guestRequest.GuestRequestKey
                    select item;
            if (v.FirstOrDefault() != null)//אם הבקשה קיימת תזרוק שגיאה
            {
                throw new InvalidOperationException("The Guest Request Already Exist");
            }
            guestRequest.GuestRequestKey = Configuration.GuestRequestKey++;
            guestRequest.RequirementStatus = Enums.RequirementStatus.Open;
            guestRequest.NumOfTotalPeople = guestRequest.NumOfAdults + guestRequest.NumOfKids;
            DS.DataSource.GuestRequestsList.Add(guestRequest.Clone());//אם הבקשה לא קיימת ניצור בקשה חדשה
        }

        /// <summary>
        /// updates a guest request in the data
        /// </summary>
        /// <param name="guestRequest"></param>
        void IDal.UpdateGuestRequest(GuestRequest guestRequest)
        {
            int Index = DataSource.GuestRequestsList.FindIndex(t => t.GuestRequestKey == guestRequest.GuestRequestKey);
            //מחפש את האינדקס של הבקשה עם אותו קוד
            if (Index == -1)//אם האינדקס = -1 כלומר, לא קיימת בקשה כזו אז המערכת תזרוק שגיאה
                throw new KeyNotFoundException("The Guest Request Not Exist");
            guestRequest.NumOfTotalPeople = guestRequest.NumOfAdults + guestRequest.NumOfKids;
            DataSource.GuestRequestsList[Index] = guestRequest.Clone();//במידה והבקשה קיימת נעדכן אותה
        }

        public GuestRequest GetGuestRequestByKey(int key)
        {
            var v = from item in DataSource.GuestRequestsList
                    where item.GuestRequestKey == key
                    select item;
            if (v.FirstOrDefault() == null)
            {
                throw new KeyNotFoundException("The Guesr Request Does Not Exist");
            }
            return v.First().Clone();
        }

        /// <summary>
        /// returns list of guest requests from the data
        /// </summary>
        /// <returns></returns>
        public List<GuestRequest> GetGuestRequestList()
        {
            var v = from item in DataSource.GuestRequestsList
                    select item.Clone();
            return v.ToList();
        }

        #endregion

        #region HostingUnit Functions

        /// <summary>
        /// adds a new hosting unit to the data
        /// </summary>
        /// <param name="hostingUnit"></param>
        void IDal.AddHostingUnit(HostingUnit hostingUnit)
        {
            var v = from item in DataSource.HostingUnitsList
                    where item.HostingUnitKey == hostingUnit.HostingUnitKey
                    select item;
            if (v.FirstOrDefault() != null)
            {
                throw new InvalidOperationException("The Hosting Unit Already Exist");
            }
            hostingUnit.HostingUnitKey = Configuration.HostUnitKey++;
            
            foreach(var item in DataSource.HostsList) //adds 1 to num of hosting units of owner in hosts list
            {
                if (item.HostKey == hostingUnit.Owner.HostKey)
                    item.NumOfHostingUnits++;
            }
            foreach(var item in DataSource.HostingUnitsList)
            {
                if (item.Owner.HostKey == hostingUnit.Owner.HostKey)
                    item.Owner.NumOfHostingUnits++;
            }
            //hostingUnit.Owner.NumOfHostingUnits++;

            hostingUnit.Diary = new bool[12, 31];

            DataSource.HostingUnitsList.Add(hostingUnit.Clone());
        }

        /// <summary>
        /// updates a hosting unit in the data
        /// </summary>
        /// <param name="hostingUnit"></param>
        void IDal.UpdateHostingUnit(HostingUnit hostingUnit)
        {
            int Index = DataSource.HostingUnitsList.FindIndex(t => t.HostingUnitKey == hostingUnit.HostingUnitKey);
            if (Index == -1)
                throw new KeyNotFoundException("The Hosting Unit Not Exist");
            DataSource.HostingUnitsList[Index] = hostingUnit.Clone();
        }

        /// <summary>
        /// deletes a hosting unit from the data
        /// </summary>
        /// <param name="hostingUnitkey"></param>
        void IDal.DeleteHostingUnit(int hostingUnitkey)
        {
            var v = from item in DataSource.HostingUnitsList
                    where item.HostingUnitKey == hostingUnitkey
                    select item;
            if (v.FirstOrDefault() == null)
            {
                throw new KeyNotFoundException("The Hosting Unit Not Exist");
            }
            DataSource.HostingUnitsList.Remove(v.First());
        }

        /// <summary>
        /// returns a hosting unit list from the data
        /// </summary>
        /// <returns></returns>
        public List<HostingUnit> GetHostingUnitList()
        {
            var v = from item in DataSource.HostingUnitsList
                    select item.Clone();
            return v.ToList();
        }
        
        #endregion

        #region Order Functions

        /// <summary>
        /// adds a new order to the data
        /// </summary>
        /// <param name="order"></param>
        void IDal.AddOrder(Order order)
        {
            var v = from item in DataSource.OrdersList
                    where item.OrderKey == order.OrderKey
                    select item;
            if (v.FirstOrDefault() != null)
            {
                throw new InvalidOperationException("The Order Already Exist");
            }
            order.OrderKey = Configuration.OrderKey++;
            order.Status = Enums.OrderStatus.NotYetAddressed;
            order.CreateDate = DateTime.Today;
            DataSource.OrdersList.Add(order.Clone());
        }

        /// <summary>
        /// updates a order in the data
        /// </summary>
        /// <param name="order"></param>
        void IDal.UpdateOrder(Order order)
        {
            int Index = DataSource.OrdersList.FindIndex(t => t.OrderKey == order.OrderKey);
            if (Index == -1)
                throw new KeyNotFoundException("The Order Not Exist");
            DataSource.OrdersList[Index] = order.Clone();
        }

        /// <summary>
        /// returns a order list from the data
        /// </summary>
        /// <returns></returns>
        public List<Order> GetOrderList()
        {
            var v = from item in DataSource.OrdersList
                    select item.Clone();
            return v.ToList();
        }
        #endregion



        /// <summary>
        /// returns a list of all bank accounts
        /// </summary>
        /// <returns></returns>
        List<BankBranch> IDal.GetBankAccounts()
        {
            List<BankBranch> bankList = new List<BankBranch>()
            {
                new BankBranch()
                {
                    BankNumber = 20,
                    BankName = "Mizrahi",
                    BranchNumber = 446,
                    BranchAddress = "23 Yaffo",
                    BranchCity = "Hifa"
                },
                new BankBranch()
                {
                    BankNumber = 20,
                    BankName = "Mizrahi",
                    BranchNumber = 684,
                    BranchAddress = "20 yasmin",
                    BranchCity = "Beit Shemesh"
                },
                new BankBranch()
                {
                    BankNumber = 11,
                    BankName = "Diacont",
                    BranchNumber = 786,
                    BranchAddress = "5 King- Gorge",
                    BranchCity = "Jerusalem"
                },
                new BankBranch()
                {
                    BankNumber = 10,
                    BankName = "Leumi",
                    BranchNumber = 123,
                    BranchAddress = "1 Habad",
                    BranchCity = "Tel- Aviv"
                },
                new BankBranch()
                {
                    BankNumber = 10,
                    BankName = "Leumi",
                    BranchNumber = 916,
                    BranchAddress = "12 Arlozorov",
                    BranchCity = "Tel- Aviv"
                },
            };
            return bankList;
        }
    }
}
