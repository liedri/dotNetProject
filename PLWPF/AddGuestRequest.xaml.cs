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
    /// Interaction logic for AddGuestRequest.xaml
    /// </summary>
    public partial class AddGuestRequest : Window
    {
        GuestRequest guestRequest;
        IBl bl;
        private List<string> errorMessages;
        public AddGuestRequest()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            bl = FactoryBL.GetBl();
            guestRequest = new GuestRequest();
            this.DataContext = guestRequest;

            this.Area.ItemsSource = Enum.GetValues(typeof(Enums.Area));
            this.Type.ItemsSource = Enum.GetValues(typeof(Enums.HostingUnitType));
            this.Pool.ItemsSource = Enum.GetValues(typeof(Enums.Options));
            this.Jaccuzzi.ItemsSource = Enum.GetValues(typeof(Enums.Options));
            this.Porch.ItemsSource = Enum.GetValues(typeof(Enums.Options));
            this.Food.ItemsSource = Enum.GetValues(typeof(Enums.Food));
            this.ChildrenAttractions.ItemsSource = Enum.GetValues(typeof(Enums.Options));
            this.EntryDate.DisplayDateStart = DateTime.Now;
            this.ReleaseDate.DisplayDateStart = DateTime.Now;

            errorMessages = new List<string>();
        }
        private void AddGuestRequest_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(errorMessages.Any())
                {
                    string err = "Exception: ";
                    foreach (var item in errorMessages)
                        err += "\n" + item;

                    MessageBox.Show(err);
                    return;
                }

                if (Name.Text == "" || LastName.Text == "" || Email.Text == "")
                {
                    MessageBox.Show($"you need to fill all details", "", MessageBoxButton.OK, MessageBoxImage.Error);
                }

                guestRequest.EntryDate = this.EntryDate.SelectedDate.Value;
                guestRequest.ReleaseDate = this.ReleaseDate.SelectedDate.Value;

                bl.AddGuestRequest(guestRequest);
                guestRequest = new GuestRequest();
                this.DataContext = guestRequest;
                this.Close();
                MessageBox.Show($"The guest request was received by the system");
            }
            catch(FormatException)
            {
                MessageBox.Show("check your input and try again");
            }
            catch(Exception ex)
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

    }
}
