using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DAL
{
    public static class Cloning
    {
        public static Host Clone(this Host original)
        {
            Host target = new Host();
            target.HostKey = original.HostKey;
            target.FirstName = original.FirstName;
            target.LastName = original.LastName;
            target.PhoneNumber = original.PhoneNumber;
            target.Email = original.Email;
            target.BankBranchDetails = original.BankBranchDetails;
            target.BankAccountNumber = original.BankAccountNumber;
            target.CollectionClearance = original.CollectionClearance;
            target.NumOfHostingUnits = original.NumOfHostingUnits;
            target.HostPassword = original.HostPassword;
            return target;
        }

        public static HostingUnit Clone(this HostingUnit original)
        {
            HostingUnit target = new HostingUnit();
            target.HostingUnitKey = original.HostingUnitKey;
            target.Owner = original.Owner.Clone();
            target.HostingUnitName = original.HostingUnitName;
            target.Diary = original.Diary;
            target.Area = original.Area;
            target.HostingUnitType = original.HostingUnitType;
            target.Pool = original.Pool;
            target.Jacuzzi = original.Jacuzzi;
            target.ChildrenAttractions = original.ChildrenAttractions;
            target.Porch = original.Porch;
            target.Food = original.Food;
            target.Beds = original.Beds;
            return target;
        }

        public static GuestRequest Clone(this GuestRequest original)
        {
            GuestRequest target = new GuestRequest();
            target.GuestRequestKey = original.GuestRequestKey;
            target.FirstName = original.FirstName;
            target.LastName = original.LastName;
            target.Email = original.Email;
            target.RequirementStatus = original.RequirementStatus;
            target.RegistrationDate = original.RegistrationDate;
            target.EntryDate = original.EntryDate;
            target.ReleaseDate = original.ReleaseDate;
            target.Area = original.Area;
            target.HostingUnitType = original.HostingUnitType;
            target.NumOfAdults = original.NumOfAdults;
            target.NumOfKids = original.NumOfKids;
            target.Pool = original.Pool;
            target.Jacuzzi = original.Jacuzzi;
            target.ChildrenAttractions = original.ChildrenAttractions;
            target.Porch = original.Porch;
            target.Food = original.Food;
            target.NumOfTotalPeople = original.NumOfTotalPeople;
            return target;
        }

        public static Order Clone(this Order original)
        {
            Order target = new Order();
            target.HostingUnitKey = original.HostingUnitKey;
            target.GuestRequestKey = original.GuestRequestKey;
            target.OrderKey = original.OrderKey;
            target.Status = original.Status;
            target.CreateDate = original.CreateDate;
            target.OrderDate = original.OrderDate;
            return target;
        }

        public static BankBranch Clone(this BankBranch original)
        {
            BankBranch target = new BankBranch();
            target.BankNumber = original.BankNumber;
            target.BankName = original.BankName;
            target.BranchNumber = original.BranchNumber;
            target.BranchAddress = original.BranchAddress;
            target.BranchCity = original.BranchCity;
            return target;
        }

    }
}
