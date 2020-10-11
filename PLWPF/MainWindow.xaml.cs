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
using System.Windows.Navigation;
using System.Windows.Shapes;
using BE;
using BL;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IBl MyBl = FactoryBL.GetBl();
        public MainWindow()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }
        
        private void Guest_Click(object sender, RoutedEventArgs e)
        {
            if (AddGuest.Visibility == Visibility.Hidden)
            {
                AddGuest.Visibility = Visibility.Visible;
            }
            else
            {
                AddGuest.Visibility = Visibility.Hidden;
            }
            //new Guest().ShowDialog();
        }


        private void Host_Click(object sender, RoutedEventArgs e)
        {
            new HostLogin().ShowDialog();
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            new Search().ShowDialog();
        }

        private void Manager_Click(object sender, RoutedEventArgs e)
        {
            new managerLogin().ShowDialog();
        }

        private void AddGuest_Click(object sender, RoutedEventArgs e)
        {
            AddGuest.Visibility = Visibility.Hidden;
            new AddGuestRequest().ShowDialog();
        }

    }
}
