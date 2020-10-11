using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DAL
{
    public interface IDal
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
    }
}
