using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace BL
{
    public interface IBl
    {
        void AddHost(Host host);
        void UpdateHost(Host host);
        void DeleteHost(Host host);
        Host GetHostById(int key);

        void AddGuestRequest(GuestRequest guestRequest);
        void UpdateGuestRequest(GuestRequest guestRequest);
        GuestRequest GetGuestRequestByKey(int key);

        void AddHostingUnit(HostingUnit hostingUnit);
        void DeleteHostingUnit(int hostingUnitkey);
        void UpdateHostingUnit(HostingUnit hostingUnit);

        void AddOrder(Order order);
        void UpdateOrder(Order order);

        List<Host> GetHostList();
        List<HostingUnit> GetHostingUnitList();
        List<GuestRequest> GetGuestRequestList();
        List<Order> GetOrderList();
        List<BankBranch> GetBankAccounts();

        List<HostingUnit> GetAvailableHostingUnitList(DateTime date, int numOfDays);
        double BetweenDays(DateTime d1);
        double BetweenDays(DateTime d1, DateTime d2);
        List<Order> GetPassOrdersList(int numOfDays);
        IEnumerable<GuestRequest> GetAllGuesstRequests(Func<GuestRequest, bool> predicate = null);
        int NumOfOrders(GuestRequest guestRequest);
        int NumOfSendOrdersAndCloseOrders(HostingUnit hostingUnit);

        IEnumerable<IGrouping<Enums.Area, GuestRequest>> GetGuestRequestsByArea();
        IEnumerable<IGrouping<int, GuestRequest>> GetGuestRequestsByNumOfPeople();
        IEnumerable<IGrouping<int, Host>> GetHostsByNumOfHostingUnits();
        IEnumerable<IGrouping<Enums.Area, HostingUnit>> GetHostingUnitsByArea();

        List<HostingUnit> FiveStars();
        List<HostingUnit> Hotels();
        List<Order> NotYetAddressedOrders();
        List<HostingUnit> HasChildrenAttractions();
        List<GuestRequest> DealExpires();
        int numOfHostingUnitsUpNorth();

    }
}
