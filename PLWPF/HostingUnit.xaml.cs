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
    /// Interaction logic for HostingUnit.xaml
    /// </summary>
    public partial class HostingUnit : Window
    {
        IBl bl;
        BE.HostingUnit hostingUnit = new BE.HostingUnit();
        
        public HostingUnit(BE.HostingUnit hu)
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            bl = FactoryBL.GetBl();
            hostingUnit = hu;
            setHostingUnitFields();

            List<BE.Order> orders = bl.GetOrderList();
            var v = from item in orders
                    where item.HostingUnitKey == hostingUnit.HostingUnitKey
                    select item;
            //if (v.FirstOrDefault() == null)
            //    MessageBox.Show("No available orders");
            orders = v.ToList();
            OrderList.ItemsSource = orders;
            
        }


        private void DeleteHostingUnit_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //new DeleteHostingUnit().ShowDialog();
                bl.DeleteHostingUnit(hostingUnit.HostingUnitKey);
                MessageBox.Show($"The Hosting Unit was Deleted by the system");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.Close();

        }

        private void UpdateHostingUnit_Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
            new UpdateHostingUnit(hostingUnit).ShowDialog();
            var v = from item in bl.GetHostingUnitList()
                    where item.HostingUnitKey == hostingUnit.HostingUnitKey
                    select item;
            if (v.FirstOrDefault() == null)
                MessageBox.Show("The HostingUnit Does Not Exist");

            hostingUnit = v.First();

            new HostingUnit(hostingUnit).ShowDialog();
        }

        private void setHostingUnitFields()
        {
            this.HostingUnitGrid.DataContext = hostingUnit;

            HostId.Text = hostingUnit.Owner.HostKey.ToString();
            HostingUnitKey.Text = hostingUnit.HostingUnitKey.ToString();
            Name.Text = hostingUnit.HostingUnitName;
            Area.Text = hostingUnit.Area.ToString();
            Type.Text = hostingUnit.HostingUnitType.ToString();
            Beds.Text = hostingUnit.Beds.ToString();
            Food.Text = hostingUnit.Food.ToString();

            if (hostingUnit.Pool == false)
                this.Pool.Text = "No";
            else
                this.Pool.Text = "Yes";
            if (hostingUnit.Porch == false)
                this.Porch.Text = "No";
            else
                this.Porch.Text = "Yes";
            if (hostingUnit.Jacuzzi == false)
                this.Jacuzzi.Text = "No";
            else
                this.Jacuzzi.Text = "Yes";
            if (hostingUnit.ChildrenAttractions == false)
                this.ChildrenAttractions.Text = "No";
            else
                this.ChildrenAttractions.Text = "Yes";
        }

        private void OrderList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateOrder.IsEnabled = true;
        }

        private void UpdateOrder_Click(object sender, RoutedEventArgs e)
        {
            //BE.Order order = (BE.Order)OrderList.SelectedItem;
            this.Close();

            var v = from item in bl.GetHostingUnitList()
                    where item.HostingUnitKey == hostingUnit.HostingUnitKey
                    select item;

            if (v.FirstOrDefault() == null)
                MessageBox.Show("The Hosting Unit Does Not Exist");

            hostingUnit = v.First();

            BE.Order order = (BE.Order)OrderList.SelectedItem;
            new UpdateOrder(order).ShowDialog();
            new HostingUnit(hostingUnit).ShowDialog();

        }
    }
}
