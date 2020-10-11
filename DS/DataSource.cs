using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
namespace DS
{
    public class DataSource
    {
        public static List<GuestRequest> GuestRequestsList = new List<GuestRequest>()
        {
             new GuestRequest()
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
                    NumOfTotalPeople = 2
                },
        new GuestRequest()
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
            NumOfTotalPeople = 7
        },
        new GuestRequest()
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
            NumOfTotalPeople = 6
        }
    };

        public static List<Host> HostsList = new List<Host>()
        {
            new Host()
            {
                HostKey = 209146133,
                FirstName = "li",
                LastName = "bokris",
                PhoneNumber = "050-3680202",
                Email = "lib613@walla.com",
                BankBranchDetails = new BankBranch()
                {
                    BankNumber = 20,
                    BankName = "mizrahi",
                    BranchNumber = 416,
                    BranchAddress = "habad 1/2",
                    BranchCity = "hifa"
                },
                BankAccountNumber = 926833,
                CollectionClearance = false,
                NumOfHostingUnits = 2
            },
            new Host()
            {
                        HostKey = 210030565,
                        FirstName = "Michal",
                        LastName = "Chen",
                        PhoneNumber = "058-6334444",
                        Email = "Michal100@yahoo.com",
                        BankBranchDetails = new BankBranch()
                        {
                            BankNumber = 11,
                            BankName = "Leumi",
                            BranchNumber = 916,
                            BranchAddress = "Zohar 1/2",
                            BranchCity = "Biet Shemesh"
                        },
                        BankAccountNumber = 1235555,
                        CollectionClearance = true,
                        NumOfHostingUnits = 1,
                        HostPassword = 1000
                    },
            new Host()
                                {
                        HostKey = 123456789,
                        FirstName = "shlomo",
                        LastName = "aaa",
                        PhoneNumber = "050-3680202",
                        Email = "aaa@walla.com",
                        BankBranchDetails = new BankBranch()
                        {
                            BankNumber = 20,
                            BankName = "mizrahi",
                            BranchNumber = 416,
                            BranchAddress = "habad 1/2",
                            BranchCity = "hifa"
                        },
                        BankAccountNumber = 123456,
                        CollectionClearance = true,
                        NumOfHostingUnits = 0
                    }

        };

        public static List<HostingUnit> HostingUnitsList = new List<HostingUnit>()
        {
            new HostingUnit()
                {
                    HostingUnitKey = Configuration.HostUnitKey++,
                    Owner = new Host()
                    {
                        HostKey = 209146133,
                        FirstName = "li",
                        LastName = "bokris",
                        PhoneNumber = "050-3680202",
                        Email = "lib613@walla.com",
                        BankBranchDetails = new BankBranch()
                        {
                            BankNumber = 20,
                            BankName = "mizrahi",
                            BranchNumber = 416,
                            BranchAddress = "habad 1/2",
                            BranchCity = "hifa"
                        },
                        BankAccountNumber = 926833,
                        CollectionClearance = false,
                        NumOfHostingUnits = 2
                    },
                    HostingUnitName = "patal",
                    Area = Enums.Area.Jerusalem,
                    HostingUnitType = Enums.HostingUnitType.Hotel,
                    Pool = true,
                    Jacuzzi = true,
                    ChildrenAttractions = true,
                    Porch = true,
                    Food = Enums.Food.All,
                    Beds = 4,
                    Diary=new bool[12,31]
                },
                new HostingUnit()
                {
                    HostingUnitKey = Configuration.HostUnitKey++,
                    Owner = new Host()
                    {
                        HostKey = 210030565,
                        FirstName = "Michal",
                        LastName = "Chen",
                        PhoneNumber = "058-6334444",
                        Email = "Michal100@yahoo.com",
                        BankBranchDetails = new BankBranch()
                        {
                            BankNumber = 11,
                            BankName = "Leumi",
                            BranchNumber = 916,
                            BranchAddress = "Zohar 1/2",
                            BranchCity = "Biet Shemesh"
                        },
                        BankAccountNumber = 1235555,
                        CollectionClearance = true,
                        NumOfHostingUnits = 1
                    },
                    HostingUnitName = "Plaza",
                    Area = Enums.Area.South,
                    HostingUnitType = Enums.HostingUnitType.Apartment,
                    Pool = false,
                    Jacuzzi = true,
                    ChildrenAttractions = false,
                    Porch = true,
                    Food = Enums.Food.Breakfast,
                    Beds = 8,
                    Diary=new bool[12,31]
                },
                new HostingUnit()
                {
                    HostingUnitKey = Configuration.HostUnitKey++,
                    Owner = new Host()
                    {
                        HostKey = 209146133,
                        FirstName = "li",
                        LastName = "bokris",
                        PhoneNumber = "050-3680202",
                        Email = "lib613@walla.com",
                        BankBranchDetails = new BankBranch()
                        {
                            BankNumber = 20,
                            BankName = "mizrahi",
                            BranchNumber = 416,
                            BranchAddress = "habad 1/2",
                            BranchCity = "hifa"
                        },
                        BankAccountNumber = 926833,
                        CollectionClearance = true,
                        NumOfHostingUnits = 2
                    },
                    HostingUnitName = "lila",
                    Area = Enums.Area.North,
                    HostingUnitType = Enums.HostingUnitType.Zimmer,
                    Pool = true,
                    Jacuzzi = true,
                    ChildrenAttractions = false,
                    Porch = false,
                    Food = Enums.Food.Dinner,
                    Beds = 6,
                    Diary=new bool[12,31]
                }
    };

        public static List<Order> OrdersList = new List<Order>()
        {
            new Order()
            {
                    HostingUnitKey = 10000001,
                    GuestRequestKey = 10000000,
                    OrderKey = Configuration.OrderKey++,
                    Status = Enums.OrderStatus.EmailSent,
                    CreateDate = new DateTime(2019, 12, 12),
                    OrderDate = new DateTime(2019, 12, 25)
            },
            new Order()
            {
                    HostingUnitKey = 10000002,
                    GuestRequestKey = 10000001,
                    OrderKey = Configuration.OrderKey++,
                    Status = Enums.OrderStatus.NotYetAddressed,
                    CreateDate = new DateTime(2020, 7, 10),
                    OrderDate = new DateTime(2020, 7, 14)
            },
            new Order()
            {
                    HostingUnitKey = 10000000,
                    GuestRequestKey = 10000001,
                    OrderKey = Configuration.OrderKey++,
                    Status = Enums.OrderStatus.CloseByClient,
                    CreateDate = new DateTime(2020, 6, 8),
                    OrderDate = new DateTime(2020, 6, 11)
            }
        };

    }
}
