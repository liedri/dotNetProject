using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL;
using BE;

namespace PL
{
    class Program
    {
       
        static void Main(string[] args)
        {
           
            IBl bl = FactoryBL.GetBl();
            try
            {
                #region GuestRequset
                GuestRequest g1 = new GuestRequest()
                {
                    GuestRequestKey = Configuration.GuestRequestKey++,
                    FirstName = "li",
                    LastName = "edri",
                    Email = "lib6130@gmail.com",
                    RequirementStatus = Enums.RequirementStatus.DealMade,
                    RegistrationDate = DateTime.Today,
                    EntryDate = new DateTime(2020, 1, 3),
                    ReleaseDate = new DateTime(2020, 1, 8),
                    Area = Enums.Area.Jerusalem,
                    HostingUnitType = Enums.HostingUnitType.Hotel,
                    NumOfAdults = 2,
                    NumOfKids = 0,
                    Pool = Enums.Options.Necessary,
                    Jacuzzi = Enums.Options.Optional,
                    Porch = Enums.Options.Optional,
                    ChildrenAttractions = Enums.Options.NotInterested,
                    Food = Enums.Food.All,
                };
                GuestRequest g2 = new GuestRequest()
                {
                    GuestRequestKey = Configuration.GuestRequestKey++,
                    FirstName = "Michal",
                    LastName = "edry",
                    Email = "Michaledry1@gmail.com",
                    RequirementStatus = Enums.RequirementStatus.Open,
                    RegistrationDate = DateTime.Today,
                    EntryDate = new DateTime(2020, 1, 24),
                    ReleaseDate = new DateTime(2020, 1, 29),
                    Area = Enums.Area.North,
                    HostingUnitType = Enums.HostingUnitType.Zimmer,
                    NumOfAdults = 4,
                    NumOfKids = 3,
                    Pool = Enums.Options.Necessary,
                    Jacuzzi = Enums.Options.Necessary,
                    Porch = Enums.Options.NotInterested,
                    ChildrenAttractions = Enums.Options.Optional,
                    Food = Enums.Food.Breakfast,
                };
                GuestRequest g3 = new GuestRequest()
                {
                    GuestRequestKey = Configuration.GuestRequestKey++,
                    FirstName = "shlomo",
                    LastName = "bokris",
                    Email = "shlomo30@gmail.com",
                    RequirementStatus = Enums.RequirementStatus.DealExpires,
                    RegistrationDate = DateTime.Today,
                    EntryDate = new DateTime(2020, 2, 15),
                    ReleaseDate = new DateTime(2020, 3, 1),
                    Area = Enums.Area.All,
                    HostingUnitType = Enums.HostingUnitType.Camp,
                    NumOfAdults = 5,
                    NumOfKids = 1,
                    Pool = Enums.Options.NotInterested,
                    Jacuzzi = Enums.Options.NotInterested,
                    Porch = Enums.Options.NotInterested,
                    ChildrenAttractions = Enums.Options.Necessary,
                    Food = Enums.Food.All,
                };

                bl.AddGuestRequest(g1);
                bl.AddGuestRequest(g2);
                bl.AddGuestRequest(g3);
                //foreach (var item in bl.GetGuestRequestList())
                //{
                //    Console.WriteLine(item);
                //}

                //g1.Area = Enums.Area.Center;
                //bl.UpdateGuestRequest(g1);
                //foreach (var item in bl.GetGuestRequestList())
                //{
                //    Console.WriteLine(item);
                //}

                //List<GuestRequest> l1 = bl.DealExpires();
                //foreach(var item in l1)
                //{
                //    Console.WriteLine(item);
                //}

                //var v = bl.GetAllGuesstRequests(t => t.Area == Enums.Area.Jerusalem);
                //v.ToList();
                //foreach (var item in v)
                //{
                //    Console.WriteLine(item);
                //}
                #endregion
                #region HostingUnits
                //HostingUnit h1 = new HostingUnit()
                //{
                //    HostingUnitKey = Configuration.HostUnitKey++,
                //    Owner = new Host()
                //    {
                //        HostKey = 209146133,
                //        FirstName = "li",
                //        LastName = "bokris",
                //        PhoneNumber = "050-3680202",
                //        Email = "lib613@walla.com",
                //        BankBranchDetails = new BankBranch()
                //        {
                //            BankNumber = 20,
                //            BankName = "mizrahi",
                //            BranchNumber = 416,
                //            BranchAddress = "habad 1/2",
                //            BranchCity = "hifa"
                //        },
                //        BankAccountNumber = 926833,
                //        CollectionClearance = true
                //    },
                //    HostingUnitName = "patal",
                //    Area = Enums.Area.Jerusalem,
                //    HostingUnitType = Enums.HostingUnitType.Hotel,
                //    Pool = true,
                //    Jacuzzi = true,
                //    ChildrenAttractions = true,
                //    Porch = true,
                //    Food = Enums.Food.All,
                //    Beds = 4
                //};
                //h1.Diary[4, 12] = true;
                //h1.Diary[4, 13] = true;
                //h1.Diary[4, 14] = true;
                //h1.Diary[4, 15] = true;

                //HostingUnit h2 = new HostingUnit()
                //{
                //    HostingUnitKey = Configuration.HostUnitKey++,
                //    Owner = new Host()
                //    {
                //        HostKey = 210030565,
                //        FirstName = "Michal",
                //        LastName = "Chen",
                //        PhoneNumber = "058-6334444",
                //        Email = "Michal100@yahoo.com",
                //        BankBranchDetails = new BankBranch()
                //        {
                //            BankNumber = 11,
                //            BankName = "Leumi",
                //            BranchNumber = 916,
                //            BranchAddress = "Zohar 1/2",
                //            BranchCity = "Biet Shemesh"
                //        },
                //        BankAccountNumber = 1235555,
                //        CollectionClearance = true
                //    },
                //    HostingUnitName = "Plaza",
                //    Area = Enums.Area.South,
                //    HostingUnitType = Enums.HostingUnitType.Apartment,
                //    Pool = false,
                //    Jacuzzi = true,
                //    ChildrenAttractions = false,
                //    Porch = true,
                //    Food = Enums.Food.Breakfast,
                //    Beds = 8
                //};
                //h2.Diary[2, 12] = true;
                //h2.Diary[2, 13] = true;
                //h2.Diary[2, 14] = true;
                //h2.Diary[2, 15] = true;
                //h2.Diary[2, 16] = true;
                //h2.Diary[2, 17] = true;

                //HostingUnit h3 = new HostingUnit()
                //{
                //    HostingUnitKey = Configuration.HostUnitKey++,
                //    Owner = new Host()
                //    {
                //        HostKey = 209146133,
                //        FirstName = "li",
                //        LastName = "bokris",
                //        PhoneNumber = "050-3680202",
                //        Email = "lib613@walla.com",
                //        BankBranchDetails = new BankBranch()
                //        {
                //            BankNumber = 20,
                //            BankName = "mizrahi",
                //            BranchNumber = 416,
                //            BranchAddress = "habad 1/2",
                //            BranchCity = "hifa"
                //        },
                //        BankAccountNumber = 926833,
                //        CollectionClearance = true
                //    },
                //    HostingUnitName = "lila",
                //    Area = Enums.Area.North,
                //    HostingUnitType = Enums.HostingUnitType.Zimmer,
                //    Pool = true,
                //    Jacuzzi = true,
                //    ChildrenAttractions = false,
                //    Porch = false,
                //    Food = Enums.Food.Dinner,
                //    Beds = 6
                //};
                //h2.Diary[6, 3] = true;
                //h2.Diary[6, 4] = true;
                //h2.Diary[8, 12] = true;
                //h2.Diary[8, 13] = true;
                //h2.Diary[3, 10] = true;
                //h2.Diary[2, 17] = true;

                //bl.AddHostingUnit(h1);
                //bl.AddHostingUnit(h2);
                //bl.AddHostingUnit(h3);
                ////foreach(var item in bl.GetHostingUnitList())
                ////{
                ////    Console.WriteLine(item);
                ////}

                ////bl.DeleteHostingUnit(10000002);
                ////foreach (var item in bl.GetHostingUnitList())
                ////{
                ////    Console.WriteLine(item);
                ////}

                ////h2.Owner.FirstName = "Yael";
                ////bl.UpdateHostingUnit(h2);
                ////foreach (var item in bl.GetHostingUnitList())
                ////{
                ////    Console.WriteLine(item);
                ////}

                ////List<HostingUnit> l2 = bl.GetAvailableHostingUnitList(new DateTime(2020, 6, 3), 4);
                ////foreach(var item in l2)
                ////{
                ////    Console.WriteLine(item);
                ////}

                ////List<HostingUnit> l3 = bl.FiveStars();
                ////foreach (var item in l3)
                ////{
                ////    Console.WriteLine(item);
                ////}

                ////List<HostingUnit> l4 = bl.Hotels();
                ////foreach (var item in l4)
                ////{
                ////    Console.WriteLine(item);
                ////} 

                ////Console.WriteLine(bl.numOfHostingUnitsUpNorth());

                ////List<HostingUnit> l5 = bl.HasChildrenAttractions();
                ////foreach (var item in l5)
                ////{
                ////    Console.WriteLine(item);
                ////}
                #endregion
                #region Order
                Order o1 = new Order()
                {
                    HostingUnitKey = 10000001,
                    GuestRequestKey = 10000000,
                    OrderKey = Configuration.OrderKey++,
                    Status = Enums.OrderStatus.EmailSent,
                    CreateDate = new DateTime(2019, 12, 12),
                    OrderDate = new DateTime(2019, 12, 25)
                };
                Order o2 = new Order()
                {
                    HostingUnitKey = 10000002,
                    GuestRequestKey = 10000001,
                    OrderKey = Configuration.OrderKey++,
                    Status = Enums.OrderStatus.NotYetAddressed,
                    CreateDate = new DateTime(2020, 7, 10),
                    OrderDate = new DateTime(2020, 7, 14)
                };
                Order o3 = new Order()
                {
                    HostingUnitKey = 10000000,
                    GuestRequestKey = 10000001,
                    OrderKey = Configuration.OrderKey++,
                    Status = Enums.OrderStatus.CloseByClient,
                    CreateDate = new DateTime(2020, 6, 8),
                    OrderDate = new DateTime(2020, 6, 11)
                };

                bl.AddOrder(o1);
                bl.AddOrder(o2);
                bl.AddOrder(o3);

                //foreach(var item in bl.GetOrderList())
                //{
                //    Console.WriteLine(item);
                //}

                //o2.Status = Enums.OrderStatus.EmailSent;
                //bl.UpdateOrder(o2);
                //foreach (var item in bl.GetOrderList())
                //{
                //    Console.WriteLine(item);
                //}

                //List<Order> l1 = bl.GetPassOrdersList(1);
                //foreach (var item in l1)
                //{
                //    Console.WriteLine(item);
                //}

                //Console.WriteLine(bl.NumOfOrders(g1));

                //Console.WriteLine(bl.NumOfSendOrdersAndCloseOrders(h1));

                //List<Order> l2 = bl.NotYetAddressedOrders();
                //foreach (var item in l2)
                //{
                //    Console.WriteLine(item);
                //}
                #endregion
                #region Grouping

                ////g3.Area = Enums.Area.Jerusalem;
                ////bl.UpdateGuestRequest(g3);
                //int i = 1;
                //var v = bl.GetGuestRequestsByArea();
                //foreach (var item in v)
                //{
                //    Console.WriteLine("Group number " + i++);
                //    foreach(var w in item)
                //    {
                //        Console.WriteLine(w);
                //    }
                //    Console.WriteLine();
                //}

                ////g3.NumOfKids = 2;
                ////bl.UpdateGuestRequest(g3);
                //int i = 1;
                //var v = bl.GetGuestRequestsByNumOfPeople();
                //foreach(var item in v)
                //{
                //    Console.WriteLine("Group number " + i++);
                //    foreach (var w in item)
                //    {
                //        Console.WriteLine(w);
                //    }
                //    Console.WriteLine();
                //}


                //int i = 1;
                //var v = bl.GetHostsByNumOfHostingUnits();
                //foreach (var item in v)
                //{
                //    Console.WriteLine("Group number " + i++);
                //    foreach (var w in item)
                //    {
                //        Console.WriteLine(w);
                //    }
                //    Console.WriteLine();
                //}


                ////g3.Area = Enums.Area.Jerusalem;
                ////bl.UpdateGuestRequest(g3);
                //int i = 1;
                //var v = bl.GetHostingUnitsByArea();
                //foreach (var item in v)
                //{
                //    Console.WriteLine("Group number " + i++);
                //    foreach (var w in item)
                //    {
                //        Console.WriteLine(w);
                //    }
                //    Console.WriteLine();
                //}
                #endregion
                #region Other Function
                //Console.WriteLine(bl.BetweenDays(new DateTime(2019, 12, 10)));
                //Console.WriteLine(bl.BetweenDays(new DateTime(2020, 3, 10), new DateTime(2020,3,20)));
                ////Console.WriteLine(bl.BetweenDays(new DateTime(2020, 3, 10)));
                #endregion
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            Console.ReadKey();
        }

    }
}
