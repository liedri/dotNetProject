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
using BL;
using BE;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for Host.xaml
    /// </summary>
    public partial class Host : Window
    {
        IBl bl;
        BE.Host host = new BE.Host();
        public Host(BE.Host ho)
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            bl = FactoryBL.GetBl();
            host = ho;

            setHostFields();
            //this.BankBranch.ItemsSource = bl.GetBankAccounts();

            //errorMessages = new List<string>();

            List<BE.HostingUnit> hostingUnits = (from item in bl.GetHostingUnitList()
                                                 where host.HostKey == item.Owner.HostKey
                                                 select item).ToList();

            //List < BE.HostingUnit > hostingUnits = bl.GetHostingUnitList();
            HostingUnitsList.ItemsSource = hostingUnits;

            this.HostingUnitsList.ItemsSource = hostingUnits;

        }

        private void UpdateHost_Button_Click(object sender, RoutedEventArgs e)
        {
            //this.Close();
            new UpdateHost(host).ShowDialog();
            //var v = from item in bl.GetHostList()
            //        where item.HostKey == host.HostKey
            //        select item;
            //if (v.FirstOrDefault() == null)
            //    MessageBox.Show("The Host Does Not Exist");

            //host = v.First();

            //new Host(host).ShowDialog();
        }

        private void ShowHostingUnit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

            var v = from item in bl.GetHostList()
                    where item.HostKey == host.HostKey
                    select item;

            if (v.FirstOrDefault() == null)
                MessageBox.Show("The Host Does Not Exist");

            host = v.First();

            BE.HostingUnit hostingUnit = (BE.HostingUnit)HostingUnitsList.SelectedItem;
            new HostingUnit(hostingUnit).ShowDialog();
            new Host(host).ShowDialog();


        }

        private void HostingUnit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

            var v = from item in bl.GetHostList()
                    where item.HostKey == host.HostKey
                    select item;

            if (v.FirstOrDefault() == null)
                MessageBox.Show("The Host Does Not Exist");

            host = v.First();

            BE.HostingUnit hostingUnit = (BE.HostingUnit)HostingUnitsList.SelectedItem;

            new AddHostingUnit(host).ShowDialog();

            new Host(host).ShowDialog();
        }

        private void setHostFields()
        {
            this.HostGrid.DataContext = host;
            HostKey.Text = host.HostKey.ToString();
            Name.Text = host.FirstName;
            LastName.Text = host.LastName;
            PhoneNumber.Text = host.PhoneNumber;
            Email.Text = host.Email;
            BankBrachBox.Text = host.BankBranchDetails.ToString();
            BankNunberBox.Text = host.BankAccountNumber.ToString();
            if (host.CollectionClearance == true)
                CollectionclearanceBox.Text = "Yes";
            else
                CollectionclearanceBox.Text = "No";
        }

        private void HostingUnitsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ShowHostingUnit.IsEnabled = true;
        }
    }


}
