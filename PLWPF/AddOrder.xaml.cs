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
    /// Interaction logic for AddOrder.xaml
    /// </summary>
    public partial class AddOrder : Window
    {
        BE.Order order;
        BE.GuestRequest guestRequest;
        BE.HostingUnit hostingUnit;
        IBl bl;
        private List<string> errorMessages;

        public AddOrder()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            bl = FactoryBL.GetBl();
            order = new BE.Order();
            this.DataContext = order;

            this.GuestRequestKey.ItemsSource = bl.GetGuestRequestList();
            this.GuestRequestKey.DisplayMemberPath = "GuestRequestKey";
            this.GuestRequestKey.SelectedValuePath = "GuestRequestKey";

            this.HostingUnitKey.ItemsSource = bl.GetHostingUnitList();
            this.HostingUnitKey.DisplayMemberPath = "HostingUnitKey";
            this.HostingUnitKey.SelectedValuePath = "HostingUnitKey";

            this.Area.ItemsSource = Enum.GetValues(typeof(Enums.Area));
            this.Type.ItemsSource = Enum.GetValues(typeof(Enums.HostingUnitType));
            this.Pool.ItemsSource = Enum.GetValues(typeof(Enums.Options));
            this.Jaccuzzi.ItemsSource = Enum.GetValues(typeof(Enums.Options));
            this.Porch.ItemsSource = Enum.GetValues(typeof(Enums.Options));
            this.Food.ItemsSource = Enum.GetValues(typeof(Enums.Food));
            this.ChildrenAttractions.ItemsSource = Enum.GetValues(typeof(Enums.Options));
            this.EntryDate.DisplayDate = DateTime.Now;
            this.ReleaseDate.DisplayDateEnd = DateTime.Now;

            errorMessages = new List<string>();
        }

        private void AddOrder_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (errorMessages.Any())
                {
                    string err = "Exception: ";
                    foreach (var item in errorMessages)
                        err += "\n" + item;

                    MessageBox.Show(err);
                    return;
                }

                if (this.GuestRequestKey.Text == "" || this.HostingUnitKey.Text == "")
                    MessageBox.Show($"you need to fill all details", "", MessageBoxButton.OK, MessageBoxImage.Error);

                order.GuestRequestKey = int.Parse(this.GuestRequestKey.Text);
                order.HostingUnitKey = int.Parse(this.HostingUnitKey.Text);

                bl.AddOrder(order);
                order = new BE.Order();
                this.DataContext = order;
                this.Close();
                MessageBox.Show($"The order was received by the system");
            }
            catch (FormatException)
            {
                MessageBox.Show("check your input and try again");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void validation_Error(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added)
                errorMessages.Add(e.Error.Exception.Message);
            else
                errorMessages.Remove(e.Error.Exception.Message);
        }

        private void GuestRequestKey_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.GuestRequestKey.SelectedItem is GuestRequest)
            {
                this.guestRequest = ((GuestRequest)this.GuestRequestKey.SelectedItem);
                //setGuestRequestFields();
            }
        }

        private void HostingUnitKey_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.HostingUnitKey.SelectedItem is BE.HostingUnit)
            {
                this.hostingUnit = ((BE.HostingUnit)this.HostingUnitKey.SelectedItem);
                //setHostingUnitFields();
            }
        }

        //private void setGuestRequestFields()
        //{
        //    this.AddOrderGrid.DataContext = guestRequest;

        //    Name.Text = guestRequest.FirstName;
        //    LastName.Text = guestRequest.LastName;
        //    Email.Text = guestRequest.Email;
        //    EntryDate.SelectedDate = guestRequest.EntryDate;
        //    ReleaseDate.SelectedDate = guestRequest.ReleaseDate;
        //    Area.SelectedItem = guestRequest.Area;
        //    Type.SelectedItem = guestRequest.HostingUnitType;
        //    NumOfAdults.Text = guestRequest.NumOfAdults.ToString();
        //    NumOfKids.Text = guestRequest.NumOfKids.ToString();
        //    Jaccuzzi.SelectedItem = guestRequest.Jacuzzi;
        //    Porch.SelectedItem = guestRequest.Porch;
        //    Pool.SelectedItem = guestRequest.Pool;
        //    ChildrenAttractions.SelectedItem = guestRequest.ChildrenAttractions;
        //    Food.SelectedItem = guestRequest.Food;
        //}

        //private void setHostingUnitFields()
        //{
        //    this.AddOrderGrid.DataContext = hostingUnit;

        //    HostId.Text = hostingUnit.Owner.HostKey.ToString();
        //    HostingName.Text = hostingUnit.HostingUnitName;
        //    HostingArea.SelectedItem = hostingUnit.Area;
        //    HostingType.SelectedItem = hostingUnit.HostingUnitType;
        //    Beds.Text = hostingUnit.Beds.ToString();
        //    HostingFood.SelectedItem = hostingUnit.Food;
        //    if (hostingUnit.Pool == false)
        //        this.HostingPool.Text = "No";
        //    else
        //        this.HostingPool.Text = "Yes";
        //    if (hostingUnit.Porch == false)
        //        this.HostingPorch.Text = "No";
        //    else
        //        this.HostingPorch.Text = "Yes";
        //    if (hostingUnit.Jacuzzi == false)
        //        this.HostingJacuzzi.Text = "No";
        //    else
        //        this.HostingJacuzzi.Text = "Yes";
        //    if (hostingUnit.ChildrenAttractions == false)
        //        this.HostingChildrenAttractions.Text = "No";
        //    else
        //        this.HostingChildrenAttractions.Text = "Yes";
        //}
    }
}
