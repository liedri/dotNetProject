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
    /// Interaction logic for UpdateGuestRequest.xaml
    /// </summary>
    public partial class UpdateGuestRequest : Window
    {
        GuestRequest guestRequest;
        IBl bl;
        private List<string> errorMessages;
        public UpdateGuestRequest()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            bl = FactoryBL.GetBl();
            guestRequest = null;

            this.GuestRequestKey.ItemsSource = bl.GetGuestRequestList();
            this.GuestRequestKey.DisplayMemberPath = "GuestRequestKey";
            this.GuestRequestKey.SelectedValuePath = "GuestRequestKey";

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

        private void UpdateGuestRequest_Button_Click(object sender, RoutedEventArgs e)
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

                if (GuestRequestKey.SelectedItem.ToString()=="" || Name.Text == "" || LastName.Text == "" || Email.Text == "")
                {
                    MessageBox.Show($"you need to fill all details", "", MessageBoxButton.OK, MessageBoxImage.Error);
                }

                this.DataContext = guestRequest;
                bl.UpdateGuestRequest(guestRequest);
                
                this.Close();
                MessageBox.Show($"The guest request was updated by the system");
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
            guestRequest = null;
            if (this.GuestRequestKey.SelectedItem is GuestRequest)
            {
                this.guestRequest = ((GuestRequest)this.GuestRequestKey.SelectedItem);
                setGuestRequestFields();
            }
        }

        private void setGuestRequestFields()
        {
            this.UpdateGuestRequestGrid.DataContext = guestRequest;

            Name.Text = guestRequest.FirstName;
            LastName.Text = guestRequest.LastName;
            Email.Text = guestRequest.Email;
            EntryDate.SelectedDate = guestRequest.EntryDate;
            ReleaseDate.SelectedDate = guestRequest.ReleaseDate;
            Area.SelectedItem = guestRequest.Area;
            Type.SelectedItem = guestRequest.HostingUnitType;
            NumOfAdults.Text = guestRequest.NumOfAdults.ToString();
            NumOfKids.Text = guestRequest.NumOfKids.ToString();
            Jaccuzzi.SelectedItem = guestRequest.Jacuzzi;
            Porch.SelectedItem = guestRequest.Porch;
            Pool.SelectedItem = guestRequest.Pool;
            ChildrenAttractions.SelectedItem = guestRequest.ChildrenAttractions;
            Food.SelectedItem = guestRequest.Food;
        }
    }
}
