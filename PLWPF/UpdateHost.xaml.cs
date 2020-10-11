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
    /// Interaction logic for UpdateHost.xaml
    /// </summary>
    public partial class UpdateHost : Window
    {
        BE.Host host;
        IBl bl;
        private List<string> errorMessages;
        public UpdateHost(BE.Host ho)
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            bl = FactoryBL.GetBl();
            host = ho;

            this.BankBranchDetails.ItemsSource = bl.GetBankAccounts();
            setHostFields();


            errorMessages = new List<string>();
        }

        private void UpdateHost_Button_Click(object sender, RoutedEventArgs e)
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

                if (/*HostKey.SelectedItem.ToString() == "" || */Name.Text == "" || LastName.Text == "" || Email.Text == "" || PhoneNumber.Text == "" || BankBranchDetails.SelectedItem == null)
                {
                    MessageBox.Show($"you need to fill all details", "", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                if (this.CollectionClearance.Text == "No")
                    host.CollectionClearance = false;
                else
                    host.CollectionClearance = true;

                BankBranch bankBranch = this.BankBranchDetails.SelectedItem as BankBranch;
                host.BankBranchDetails = bankBranch;

                bl.UpdateHost(host);
                this.DataContext = host;
                this.Close();
                MessageBox.Show($"The Host was updated by the system");
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

        //private void HostKey_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    host = null;
        //    if(this.HostKey.SelectedItem is BE.Host)
        //    {
        //        this.host = ((BE.Host)this.HostKey.SelectedItem);
        //        setHostFields();
        //    }
        //}

        private void setHostFields()
        {
            this.UpdateHostGrid.DataContext = host;

            Name.Text = host.FirstName;
            LastName.Text = host.LastName;
            PhoneNumber.Text = host.PhoneNumber;
            Email.Text = host.Email;
            BankBranchDetails.Text = host.BankBranchDetails.ToString();
            BankNumber.Text = host.BankAccountNumber.ToString();
            if (host.CollectionClearance == true)
                CollectionClearance.Text = "Yes";
            else
                CollectionClearance.Text = "No";
        }
    }
}
