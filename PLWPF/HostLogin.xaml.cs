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
    /// Interaction logic for HostLogin.xaml
    /// </summary>
    public partial class HostLogin : Window
    {
        BE.Host host;
        IBl bl;
        private List<string> errorMessages;
        public HostLogin()
        {
            InitializeComponent();
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            bl = FactoryBL.GetBl();
            host = new BE.Host();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                List<BE.Host> hosts = bl.GetHostList();
                var v = from item in hosts
                        where item.HostKey == int.Parse(UserName.Text)
                        select item;
                v.ToList();
                if (v.FirstOrDefault() == null)
                {
                    MessageBox.Show($"Host does not exist", "" , MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                if (v.FirstOrDefault().HostPassword != int.Parse(HostPassword.Password))
                {
                    MessageBox.Show($"Incorrect password", "", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                host = bl.GetHostById(int.Parse(UserName.Text));
                new Host(host).ShowDialog();
                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            new AddHost().ShowDialog();
            this.Close();
        }
    }
}
