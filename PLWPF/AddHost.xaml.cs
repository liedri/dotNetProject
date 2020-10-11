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
    /// Interaction logic for AddHost.xaml
    /// </summary>
    public partial class AddHost : Window
    {
        BE.Host host;
        IBl bl;
        private List<string> errorMessages;
        public AddHost()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            bl = FactoryBL.GetBl();
            host = new BE.Host();
            this.DataContext = host;

            this.BankBranch.ItemsSource = bl.GetBankAccounts();
            

            errorMessages = new List<string>();
        }

        private void AddHost_Button_Click(object sender, RoutedEventArgs e)
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

                if (ID.Text == "" || Name.Text == "" || LastName.Text == "" || Email.Text == "")
                {
                    MessageBox.Show($"you need to fill all details", "", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                if (this.CollectionClearance.Text == "No")
                    host.CollectionClearance = false;
                else
                    host.CollectionClearance = true;

                BankBranch bankBranch = this.BankBranch.SelectedItem as BankBranch;
                host.BankBranchDetails = bankBranch;
                int hh = host.HostKey;
                bl.AddHost(host);
                host = new BE.Host();
                this.DataContext = host;
                this.Close();
                MessageBox.Show($"The Host was received by the system");

                BE.Host h = bl.GetHostById(hh);
                MessageBox.Show("Your password is: " + h.HostPassword.ToString());
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
    }
}
