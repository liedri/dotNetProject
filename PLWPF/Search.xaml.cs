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

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for Search.xaml
    /// </summary>
    public partial class Search : Window
    {
        public Search()
        {
            InitializeComponent();
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
