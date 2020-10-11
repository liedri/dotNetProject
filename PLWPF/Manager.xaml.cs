using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using BE;
using BL;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for Manager.xaml
    /// </summary>
    public partial class Manager : Window
    {
        IBl bl;
        private List<string> errorMessages;

        public Manager()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            bl = FactoryBL.GetBl();

            List<GuestRequest> guestRequests = bl.GetGuestRequestList();
            GuestRequests.ItemsSource = guestRequests;

            List<BE.Host> hosts = bl.GetHostList();
            Hosts.ItemsSource = hosts;

            List<BE.HostingUnit> hostingUnits = bl.GetHostingUnitList();
            HostingUnits.ItemsSource = hostingUnits;

            List<BE.Order> orders = bl.GetOrderList();
            Orders.ItemsSource = orders;

           
        }
        private void validation_Error(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added)
                errorMessages.Add(e.Error.Exception.Message);
            else
                errorMessages.Remove(e.Error.Exception.Message);
        }

        private void Commissions_Click(object sender, RoutedEventArgs e)
        {
            string s = "Your Commissions is: " + BE.Configuration.AllCommissions.ToString();
            MessageBox.Show(s);
        }

        private void GuestRequestByArea_Click(object sender, RoutedEventArgs e)
        {
            new GuestRequestsByArea().ShowDialog();
        }

        private void GuestRequestByNumOfGuests_Click(object sender, RoutedEventArgs e)
        {
            new GetGuestRequestsByNumOfPeople().ShowDialog();
        }

        private void HostingUnitsByArea_Click(object sender, RoutedEventArgs e)
        {
            new HostingUnitByArea().ShowDialog();
        }

        private void HostsByNumOfHostingUnits_Click(object sender, RoutedEventArgs e)
        {
            new HostsByNumOfHostingUnits().ShowDialog();
        }
    }

}
