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
    /// Interaction logic for UpdateOrder.xaml
    /// </summary>
    public partial class UpdateOrder : Window
    {
        BE.Order order;
        BE.GuestRequest guestRequest;
        IBl bl;
        private List<string> errorMessages;
        public UpdateOrder(BE.Order or)
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            bl = FactoryBL.GetBl();
            order = or;

            //this.OrderKey.ItemsSource = bl.GetOrderList();
            //this.OrderKey.DisplayMemberPath = "OrderKey";
            //this.OrderKey.SelectedValuePath = "OrderKey";

            this.OrderKey.Text = order.OrderKey.ToString();

            setOrderFields();

            //this.Area.Text = order.ToString();
            //this.Type.ItemsSource = Enum.GetValues(typeof(Enums.HostingUnitType));
            //this.Pool.ItemsSource = Enum.GetValues(typeof(Enums.Options));
            //this.Jaccuzzi.ItemsSource = Enum.GetValues(typeof(Enums.Options));
            //this.Porch.ItemsSource = Enum.GetValues(typeof(Enums.Options));
            //this.Food.ItemsSource = Enum.GetValues(typeof(Enums.Food));
            //this.ChildrenAttractions.ItemsSource = Enum.GetValues(typeof(Enums.Options));
            //this.EntryDate.DisplayDate = DateTime.Now;
            //this.ReleaseDate.DisplayDateEnd = DateTime.Now;
            this.Status.ItemsSource = Enum.GetValues(typeof(Enums.OrderStatus));

            errorMessages = new List<string>();
        }

        private void UpdateOrder_Button_Click(object sender, RoutedEventArgs e)
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

                if (OrderKey.Text == "")
                {
                    MessageBox.Show($"you need to fill all details", "", MessageBoxButton.OK, MessageBoxImage.Error);
                }

                bl.UpdateOrder(order);
                this.DataContext = order;
                this.Close();
                MessageBox.Show($"The order was updated by the system");
                
                if(order.Status == Enums.OrderStatus.EmailSent)
                    MessageBox.Show($"An email was sent to the client");
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

        //private void OrderKey_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    order = null;
        //    if (this.OrderKey.SelectedItem is BE.Order)
        //    {
        //        this.order = ((BE.Order)this.OrderKey.SelectedItem);
        //        setOrderFields();
        //    }
        //}

        private void setOrderFields()
        {
            guestRequest = bl.GetGuestRequestByKey(order.GuestRequestKey);
            this.UpdateOrderGrid.DataContext = order;
            //this.UpdateOrderGrid.DataContext = guestRequest;
            Name.Text = guestRequest.FirstName;
            LastName.Text = guestRequest.LastName;
            Email.Text = guestRequest.Email;
            EntryDate.SelectedDate = guestRequest.EntryDate;
            ReleaseDate.SelectedDate = guestRequest.ReleaseDate;
            Area.Text = guestRequest.Area.ToString();
            Type.Text = guestRequest.HostingUnitType.ToString();
            NumOfAdults.Text = guestRequest.NumOfAdults.ToString();
            NumOfKids.Text = guestRequest.NumOfKids.ToString();
            Jaccuzzi.Text = guestRequest.Jacuzzi.ToString();
            Porch.Text = guestRequest.Porch.ToString();
            Pool.Text = guestRequest.Pool.ToString();
            ChildrenAttractions.Text = guestRequest.ChildrenAttractions.ToString();
            Food.Text = guestRequest.Food.ToString();
            GuestRequestKey.Text = guestRequest.GuestRequestKey.ToString();
            HostingUnitKey.Text = order.HostingUnitKey.ToString();
            CreateDate.SelectedDate = order.CreateDate;
        }
    }
}
