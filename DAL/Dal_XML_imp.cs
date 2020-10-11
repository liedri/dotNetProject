using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Net;
using BE;
using DS;

namespace DAL
{
    [Serializable]
    public class Dal_XML_imp : IDal
    {
        List<BankBranch> branches = new List<BankBranch>();
        BackgroundWorker worker = new BackgroundWorker();

        private XElement configFile;
        private string configPath = @"ConfigFile.xml";

        private XElement guestRequestFile;
        private string guestRequestPath = @"GuestRequestFile.xml";

        private XElement hostFile;
        private string hostPath = @"HostFile.xml";

        private XElement orderFile;
        private string orderPath = @"OrderFile.xml";

        //private XElement hostingUnitFile;
        private string hostingUnitPath = @"HostingUnitFile.xml";


        private XElement bankBranchFile;
        const string bankBranchPath = @"BankBranchFile.xml";

        public Dal_XML_imp()
        {
            if (!File.Exists(configPath))
                CreateConfig();
            LoadConfig();
            

            if (!File.Exists(guestRequestPath))
                CreateFileGuestRequest();
            loadGuestRequests();

            if (!File.Exists(hostPath))
                CreateFileHost();
            loadHost();

            if (!File.Exists(orderPath))
                CreateFileOrders();
            loadOrders();

           

            if (!File.Exists(hostingUnitPath))
                CreateFileHostingUnit();
            loadHostingUnit();



            if (!File.Exists(bankBranchPath))
            {
                bankBranchFile = new XElement("BankBranch");
                bankBranchFile.Save(bankBranchPath);
            }
            else
            {
                bankBranchFile = XElement.Load(bankBranchPath);
            }

            worker.DoWork += workerDoWork;
            worker.RunWorkerAsync();

        }

        #region Configuration
        private void CreateConfig()
        {
            configFile = new XElement("config");
            XElement GuestRequestKey = new XElement("GuestRequestKey", 10000000);
            XElement HostUnitKey = new XElement("HostUnitKey", 10000000);
            XElement OrderKey = new XElement("OrderKey", 10000000);
            XElement CommissionAmount = new XElement("CommissionAmount", 10);
            XElement NumOfExpireDays = new XElement("NumOfExpireDays" , 14);
            XElement AllCommissions = new XElement("AllCommissions", 0);
            XElement EmailAddress = new XElement("EmailAddress", "michalli@gmail.com");
            XElement EmailPassword = new XElement("EmailPassword", "michalli05656133");
            XElement HostPassword = new XElement("HostPassword", 1000);
            XElement ManagerPassword = new XElement("ManagerPassword", 1111);
            configFile = new XElement("config", GuestRequestKey, HostUnitKey, OrderKey, CommissionAmount, NumOfExpireDays, AllCommissions, EmailAddress, EmailPassword, HostPassword, ManagerPassword);
            configFile.Save(configPath);
        }

        private void LoadConfig()
        {
            configFile = XElement.Load(configPath);
            Configuration.GuestRequestKey = int.Parse(configFile.Element("GuestRequestKey").Value.ToString());
            Configuration.HostUnitKey = int.Parse(configFile.Element("HostUnitKey").Value.ToString());
            Configuration.OrderKey = int.Parse(configFile.Element("OrderKey").Value.ToString());
            Configuration.CommissionAmount = float.Parse(configFile.Element("CommissionAmount").Value.ToString());
            Configuration.NumOfExpireDays = int.Parse(configFile.Element("NumOfExpireDays").Value.ToString());
            Configuration.AllCommissions = float.Parse(configFile.Element("AllCommissions").Value.ToString());
            Configuration.EmailAddress = configFile.Element("EmailAddress").Value;
            Configuration.EmailPassword = configFile.Element("EmailPassword").Value;
            Configuration.HostPassword = int.Parse(configFile.Element("HostPassword").Value.ToString());
            Configuration.ManagerPassword = int.Parse(configFile.Element("ManagerPassword").Value.ToString());

        }
        #endregion

        #region Bank Branch
        private void CreateFileBankBranch()
        {
            bankBranchFile = new XElement("BankBranch");
            bankBranchFile.Save(bankBranchPath);
        }
        private void LoadBankBranchs()
        {
            bankBranchFile = XElement.Load(bankBranchPath);
        }
        public List<BankBranch> GetBankAccounts()
        {
            return branches;
        }

        private void workerDoWork(object sender, DoWorkEventArgs e)
        {
            if (bankBranchFile.IsEmpty)
            {
                const string xmlLocalPath = bankBranchPath;
                WebClient wc = new WebClient();
                try
                {
                    string xmlServerPath =
                        @"https://www.boi.org.il/en/BankingSupervision/BanksAndBranchLocations/Lists/BoiBankBranchesDocs/snifim_en.xml";
                    wc.DownloadFile(xmlServerPath, xmlLocalPath);
                }
                catch (Exception)
                {
                    string xmlSeverPath = @"http://www.jct.ac.il/~coshri/atm.xml";
                    wc.DownloadFile(xmlSeverPath, xmlLocalPath);
                }
                finally
                {
                    wc.Dispose();
                }
                if (!File.Exists(xmlLocalPath))
                {
                    throw new FileLoadException("File upload problem");
                }
                bankBranchFile = XElement.Load(bankBranchPath);
                foreach (var item in bankBranchFile.Elements())
                {
                    branches.Add(new BankBranch()
                    {
                        BranchAddress = item.Element("Address").Value,
                        BankNumber = int.Parse(item.Element("Bank_Code").Value),
                        BankName = item.Element("Bank_Name").Value,
                        BranchCity = item.Element("City").Value,
                        BranchNumber = int.Parse(item.Element("Branch_Code").Value)
                    });
                }
            }
            else
            {
                foreach (var item in bankBranchFile.Elements())
                {
                    branches.Add(new BankBranch()
                    {
                        BranchAddress = item.Element("Address").Value,
                        BankNumber = int.Parse(item.Element("Bank_Code").Value),
                        BankName = item.Element("Bank_Name").Value,
                        BranchCity = item.Element("City").Value,
                        BranchNumber = int.Parse(item.Element("Branch_Code").Value)
                    });
                }
            }
            branches = branches.GroupBy(x => x.BranchNumber).Select(y => y.FirstOrDefault()).ToList();
        }

        #endregion

        #region Host Functions
        private void loadHost()
        {
         
            LoadFromXML<List<Host>>(hostPath);

        }

        private void CreateFileHost()
        {
            
            List<Host> hosts = new List<Host>();
            SaveToXML<List<Host>>(hosts, hostPath);
        }


        public void AddHost(Host host)
        {
          
            List<Host> list = LoadFromXML<List<Host>>(hostPath);
            LoadConfig();
            var v = from item in list
                    where item.HostKey == host.HostKey
                    select item;
            if (v.FirstOrDefault() != null)
                throw new InvalidOperationException("The Host With key: {0} Already Exist" + host.HostKey);
            host.HostPassword = Configuration.HostPassword++;
            list.Add(host);
            SaveToXML<List<Host>>(list, hostPath);
            configFile.Element("HostPassword").Value = Configuration.HostPassword.ToString();
            configFile.Save(configPath);
            //configFile.Element("HostKey").Value = Configuration.HostUnitKey.ToString();
            //configFile.Save(configPath);
        }
       
        public void UpdateHost(Host host)
        {
            
            List<Host> list = LoadFromXML<List<Host>>(hostPath);
            var temp = (from item in list
                        where item.HostKey == host.HostKey
                        select item);
            if (temp.Count() == 0)
                throw new InvalidOperationException("The Host Does Not Exist");
            bool flag = false;
            foreach (var item in list)
            {
                if (item.HostKey == host.HostKey)
                {
                    list.Remove(item);
                    flag = true;
                    break;
                }
            }
            if (!flag)
                throw new InvalidOperationException("The Host Does Not Exist");
            else
            {
                list.Add(host);
                SaveToXML<List<Host>>(list, hostPath);
                //SaveToXML<List<Host>>(list, hostPath);
                //AddUpdate(host);
            }
            
        }

        public void AddUpdate(Host host)
        {
            List<Host> list = LoadFromXML<List<Host>>(hostPath);
            list.Add(host);
            SaveToXML<List<Host>>(list, hostPath);
        }

        public void DeleteHost(Host host)
        {
            
            List<Host> list = LoadFromXML<List<Host>>(hostPath);
            var temp = (from item in list
                        where item.HostKey == host.HostKey
                        select item);
            if (temp.Count() == 0)
                throw new InvalidOperationException("The Host Does Not Exist");

            foreach (var item in list)
            {
                if (item.HostKey == host.HostKey)
                {
                    list.Remove(item);
                    break;
                }
            }
            SaveToXML<List<Host>>(list, hostPath);
        }


        public Host GetHostById(int hostKey)
        {
           
            List<Host> list = LoadFromXML<List<Host>>(hostPath);
            var temp = (from item in list
                        where item.HostKey == hostKey
                        select item);
            if (temp.Count() == 0)
                throw new InvalidOperationException("The Host Does Not Exist");
            return temp.FirstOrDefault();
        }

        public List<Host> GetHostList()
        {
            
            return LoadFromXML<List<Host>>(hostPath);

        }

        #endregion

        #region GuestRequest Functions
        private void loadGuestRequests()
        {
            guestRequestFile = XElement.Load(guestRequestPath);
        }

        private void CreateFileGuestRequest()
        {
            guestRequestFile = new XElement("guestRequest");
            guestRequestFile.Save(guestRequestPath);
        }

        public void AddGuestRequest(GuestRequest guestRequest)
        {
            XElement temp = (from item in guestRequestFile.Elements()
                             where int.Parse(item.Element("key").Value) == guestRequest.GuestRequestKey
                             select item).FirstOrDefault();
            if (temp != null)
                throw new InvalidOperationException("The Guest Request With Key: {0} Already Exist" + temp.Element("key").Value);
            guestRequestFile.Add(new XElement("guestRequest",
                                       new XElement("key", Configuration.GuestRequestKey++),
                                       new XElement("firstName", guestRequest.FirstName),
                                       new XElement("lastName", guestRequest.LastName),
                                       new XElement("email", guestRequest.Email),
                                       new XElement("requirementStatus", Enums.RequirementStatus.Open),
                                       new XElement("registrationDate", guestRequest.RegistrationDate),
                                       new XElement("entryDate", guestRequest.EntryDate),
                                       new XElement("releaseDate", guestRequest.ReleaseDate),
                                       new XElement("area", guestRequest.Area),
                                       new XElement("type", guestRequest.HostingUnitType),
                                       new XElement("numOfAdults", guestRequest.NumOfAdults),
                                       new XElement("numOfKids", guestRequest.NumOfKids),
                                       new XElement("pool", guestRequest.Pool),
                                       new XElement("jacuzzi", guestRequest.Jacuzzi),
                                       new XElement("childrenAttractions", guestRequest.ChildrenAttractions),
                                       new XElement("porch", guestRequest.Porch),
                                       new XElement("food", guestRequest.Food),
                                       new XElement("numOfTotalPeople", guestRequest.NumOfAdults + guestRequest.NumOfKids)
                                      )
                         );
            guestRequestFile.Save(guestRequestPath);
            configFile.Element("GuestRequestKey").Value = Configuration.GuestRequestKey.ToString();
            configFile.Save(configPath);
        }

        public void UpdateGuestRequest(GuestRequest guestRequest)
        {
            XElement temp = (from item in guestRequestFile.Elements()
                             where int.Parse(item.Element("key").Value) == guestRequest.GuestRequestKey
                             select item).FirstOrDefault();

            temp.Element("key").Value = guestRequest.GuestRequestKey.ToString();
            temp.Element("firstName").Value = guestRequest.FirstName;
            temp.Element("lastName").Value = guestRequest.LastName;
            temp.Element("email").Value = guestRequest.Email;
            temp.Element("requirementStatus").Value = guestRequest.RequirementStatus.ToString();
            temp.Element("registrationDate").Value = guestRequest.RegistrationDate.ToString();
            temp.Element("entryDate").Value = guestRequest.EntryDate.ToString();
            temp.Element("releaseDate").Value = guestRequest.ReleaseDate.ToString();
            temp.Element("area").Value = guestRequest.Area.ToString();
            temp.Element("type").Value = guestRequest.HostingUnitType.ToString();
            temp.Element("numOfAdults").Value = guestRequest.NumOfAdults.ToString();
            temp.Element("numOfKids").Value = guestRequest.NumOfKids.ToString();
            temp.Element("pool").Value = guestRequest.Pool.ToString();
            temp.Element("jacuzzi").Value = guestRequest.Jacuzzi.ToString();
            temp.Element("childrenAttractions").Value = guestRequest.ChildrenAttractions.ToString();
            temp.Element("porch").Value = guestRequest.Porch.ToString();
            temp.Element("food").Value = guestRequest.Food.ToString();
            temp.Element("numOfTotalPeople").Value = (guestRequest.NumOfAdults + guestRequest.NumOfKids).ToString();

            guestRequestFile.Save(guestRequestPath);
        }


        public GuestRequest GetGuestRequestByKey(int guestrequestkey)
        {
            loadGuestRequests();
            GuestRequest temp = (from item in guestRequestFile.Elements()
                             where int.Parse(item.Element("key").Value) == guestrequestkey
                             select new GuestRequest()
                             {
                                 GuestRequestKey = int.Parse(item.Element("key").Value),
                                 FirstName = item.Element("firstName").Value,
                                 LastName = item.Element("lastName").Value,
                                 Email = item.Element("email").Value,
                                 RequirementStatus = (Enums.RequirementStatus)Enum.Parse(typeof(Enums.RequirementStatus), item.Element("requirementStatus").Value),
                                 EntryDate = DateTime.Parse(item.Element("entryDate").Value),
                                 ReleaseDate = DateTime.Parse(item.Element("releaseDate").Value),
                                 Area = (Enums.Area)Enum.Parse(typeof(Enums.Area), item.Element("area").Value),
                                 HostingUnitType = (Enums.HostingUnitType)Enum.Parse(typeof(Enums.HostingUnitType), item.Element("type").Value),
                                 NumOfAdults = int.Parse(item.Element("numOfAdults").Value),
                                 NumOfKids = int.Parse(item.Element("numOfKids").Value),
                                 Pool = (Enums.Options)Enum.Parse(typeof(Enums.Options), item.Element("pool").Value),
                                 Jacuzzi = (Enums.Options)Enum.Parse(typeof(Enums.Options), item.Element("jacuzzi").Value),
                                 ChildrenAttractions = (Enums.Options)Enum.Parse(typeof(Enums.Options), item.Element("childrenAttractions").Value),
                                 Porch = (Enums.Options)Enum.Parse(typeof(Enums.Options), item.Element("porch").Value),
                                 Food = (Enums.Food)Enum.Parse(typeof(Enums.Food), item.Element("food").Value),
                                 NumOfTotalPeople = int.Parse(item.Element("numOfTotalPeople").Value)
                             }).FirstOrDefault();
            if (temp == null)
                throw new KeyNotFoundException("The Guest Request whit key: {0} Does Not Exist" + guestrequestkey);
            return temp;
        }

        public List<GuestRequest> GetGuestRequestList()
        {
            loadGuestRequests();
            List<GuestRequest> list = new List<GuestRequest>();
            list = (from item in guestRequestFile.Elements()
                    select new GuestRequest()
                    {
                        GuestRequestKey = int.Parse(item.Element("key").Value),
                        FirstName = item.Element("firstName").Value,
                        LastName = item.Element("lastName").Value,
                        Email = item.Element("email").Value,
                        RequirementStatus = (Enums.RequirementStatus)Enum.Parse(typeof(Enums.RequirementStatus), item.Element("requirementStatus").Value),
                        EntryDate = DateTime.Parse(item.Element("entryDate").Value),
                        ReleaseDate = DateTime.Parse(item.Element("releaseDate").Value),
                        Area = (Enums.Area)Enum.Parse(typeof(Enums.Area), item.Element("area").Value),
                        HostingUnitType = (Enums.HostingUnitType)Enum.Parse(typeof(Enums.HostingUnitType), item.Element("type").Value),
                        NumOfAdults = int.Parse(item.Element("numOfAdults").Value),
                        NumOfKids = int.Parse(item.Element("numOfKids").Value),
                        Pool = (Enums.Options)Enum.Parse(typeof(Enums.Options) , item.Element("pool").Value),
                        Jacuzzi = (Enums.Options)Enum.Parse(typeof(Enums.Options), item.Element("jacuzzi").Value),
                        ChildrenAttractions = (Enums.Options)Enum.Parse(typeof(Enums.Options), item.Element("childrenAttractions").Value),
                        Porch = (Enums.Options)Enum.Parse(typeof(Enums.Options), item.Element("porch").Value),
                        Food = (Enums.Food)Enum.Parse(typeof(Enums.Food), item.Element("food").Value),
                        NumOfTotalPeople = int.Parse(item.Element("numOfTotalPeople").Value)
                    }
                   ).ToList();
            return list;
        }
        

        public void AddGuestRequstList()
        {
            foreach (GuestRequest item in DataSource.GuestRequestsList)
            {
                AddGuestRequest(item);
            }
        }
        #endregion

        #region HostingUnit Functions  

        private void loadHostingUnit()
        {
            LoadFromXML<List<HostingUnit>>(hostingUnitPath);
        }
        private void CreateFileHostingUnit()
        {
            List<HostingUnit> hostingUnits = new List<HostingUnit>();
            SaveToXML<List<HostingUnit>>(hostingUnits, hostingUnitPath);
        }

        public void AddHostingUnit(HostingUnit hostingUnit)
        {
            List<HostingUnit> list = LoadFromXML<List<HostingUnit>>(hostingUnitPath);
            var v = from item in list
                    where item.HostingUnitKey == hostingUnit.HostingUnitKey
                    select item;
            if (v.FirstOrDefault() != null)
                throw new InvalidOperationException("The Hosting Unit With key: {0} Already Exist" + hostingUnit.HostingUnitKey);
            configFile = XElement.Load(configPath);
            hostingUnit.HostingUnitKey = Configuration.HostUnitKey++;
            hostingUnit.Diary = new bool[12, 31];
            list.Add(hostingUnit);
            SaveToXML<List<HostingUnit>>(list, hostingUnitPath);
            configFile.Element("HostUnitKey").Value = Configuration.HostUnitKey.ToString();
            configFile.Save(configPath);

            List<Host> h = LoadFromXML<List<Host>>(hostPath);
            var temp = (from item in h
                        where item.HostKey == hostingUnit.Owner.HostKey
                        select item);
            Host host = temp.FirstOrDefault();
            DeleteHost(host);
            List<Host> hh = LoadFromXML<List<Host>>(hostPath);
            host.NumOfHostingUnits++;
            hh.Add(host);
            SaveToXML<List<Host>>(hh, hostPath);


        }

        public void UpdateHostingUnit(HostingUnit hostingUnit)
        {
            List<HostingUnit> list = LoadFromXML<List<HostingUnit>>(hostingUnitPath);
            var temp = (from item in list
                        where item.HostingUnitKey == hostingUnit.HostingUnitKey
                        select item);
            if (temp.Count() == 0)
                throw new InvalidOperationException("The HostingUnit Does Not Exist");
            bool flag = false;
            foreach (var item in list)
            {
                if (item.HostingUnitKey == hostingUnit.HostingUnitKey)
                {
                    list.Remove(item);
                    SaveToXML<List<HostingUnit>>(list, hostingUnitPath);
                    flag = true;
                    break;
                }
            }
            if (!flag)
                throw new InvalidOperationException("The HostingUnit Does Not Exist");
            else
                AddUpdate(hostingUnit);
            //SaveToXML<List<HostingUnit>>(list, hostingUnitPath);
        }

        public void AddUpdate(HostingUnit hostingUnit)
        {
            List<HostingUnit> list = LoadFromXML<List<HostingUnit>>(hostingUnitPath);
            list.Add(hostingUnit);
            SaveToXML<List<HostingUnit>>(list, hostingUnitPath);
        }

        public void DeleteHostingUnit(int hostingUnitkey)
        {
            List<HostingUnit> list = LoadFromXML<List<HostingUnit>>(hostingUnitPath);
            var temp = (from item in list
                        where item.HostingUnitKey == hostingUnitkey
                        select item);
            if (temp.Count() == 0)
                throw new InvalidOperationException("The HostingUnit Does Not Exist");

            foreach (var item in list)
            {
                if (item.HostingUnitKey == hostingUnitkey)
                {
                    list.Remove(item);
                    break;
                }
            }
            SaveToXML<List<HostingUnit>>(list, hostingUnitPath);
        }

        public List<HostingUnit> GetHostingUnitList()
        {
            return LoadFromXML<List<HostingUnit>>(hostingUnitPath);
        }
        #endregion

        #region Order Functions

        private void loadOrders()
        {
            orderFile = XElement.Load(orderPath);
        }

        private void CreateFileOrders()
        {
            orderFile = new XElement("order");
            orderFile.Save(orderPath);
        }

        public void AddOrder(Order order)
        {
            XElement temp = (from item in orderFile.Elements()
                             where int.Parse(item.Element("key").Value) == order.OrderKey
                             select item).FirstOrDefault();
            if (temp != null)
                throw new InvalidOperationException("The Order Already Exist");

            orderFile.Add(new XElement("order",
                                       new XElement("key", Configuration.OrderKey++),
                                       new XElement("hostingUnitKey", order.HostingUnitKey),
                                       new XElement("guestRequestKey", order.GuestRequestKey),
                                       new XElement("status", Enums.OrderStatus.NotYetAddressed),
                                       new XElement("createDate", DateTime.Today),
                                       new XElement("orderDate", DateTime.Today)
                                      )
                         );
            orderFile.Save(orderPath);
            configFile.Element("OrderKey").Value = Configuration.OrderKey.ToString();
            configFile.Save(configPath);
        }

        public void UpdateOrder(Order order)
        {
            XElement temp = (from item in orderFile.Elements()
                             where int.Parse(item.Element("key").Value) == order.OrderKey
                             select item).FirstOrDefault();

            temp.Element("key").Value = order.OrderKey.ToString();
            temp.Element("hostingUnitKey").Value = order.HostingUnitKey.ToString();
            temp.Element("guestRequestKey").Value = order.GuestRequestKey.ToString();
            temp.Element("status").Value = order.Status.ToString();
            temp.Element("createDate").Value = order.CreateDate.ToString();
            temp.Element("orderDate").Value = order.OrderDate.ToString();

            orderFile.Save(orderPath);
            configFile.Element("AllCommissions").Value = Configuration.AllCommissions.ToString();
            configFile.Save(configPath);
        }


        public List<Order> GetOrderList()
        {
            loadOrders();
            List<Order> list = new List<Order>();
            list = (from item in orderFile.Elements()
                    select new Order()
                    {
                        OrderKey = int.Parse(item.Element("key").Value),
                        HostingUnitKey = int.Parse(item.Element("hostingUnitKey").Value),
                        GuestRequestKey = int.Parse(item.Element("guestRequestKey").Value),
                        Status = (Enums.OrderStatus)Enum.Parse(typeof(Enums.OrderStatus), item.Element("status").Value),
                        //CreateDate = DateTime.Parse(item.Element("createDate").Value),
                        //OrderDate = DateTime.Parse(item.Element("orderDate").Value)
                    }
                   ).ToList();
            return list;
        }

        #endregion

        public static void SaveToXML<T>(T source, string path)
        {
            FileStream file = new FileStream(path, FileMode.Create);
            XmlSerializer xmlSer = new XmlSerializer(source.GetType());
            xmlSer.Serialize(file, source);
            file.Close();
        }
        public static T LoadFromXML<T>(string path)
        {
            
            FileStream file = new FileStream(path, FileMode.Open);
            XmlSerializer xmlSer = new XmlSerializer(typeof(T));
            T result = (T)xmlSer.Deserialize(file);
            file.Close();
            return result;
        }
    }
}
