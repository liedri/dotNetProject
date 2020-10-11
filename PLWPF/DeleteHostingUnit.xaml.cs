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
    /// Interaction logic for DeleteHostingUnit.xaml
    /// </summary>
    public partial class DeleteHostingUnit : Window
    {
        BE.HostingUnit hostingUnit;
        IBl bl;
        private List<string> errorMessages;

        public DeleteHostingUnit()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            bl = FactoryBL.GetBl();
            hostingUnit = null;

            this.HostingUnitKey.ItemsSource = bl.GetHostingUnitList();
            this.HostingUnitKey.DisplayMemberPath = "HostingUnitKey";
            this.HostingUnitKey.SelectedValuePath = "HostingUnitKey";

            errorMessages = new List<string>();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.HostingUnitKey.SelectedItem is BE.HostingUnit)
            {
                this.hostingUnit = ((BE.HostingUnit)this.HostingUnitKey.SelectedItem);
                setHostFields();
            }
        }
        private void setHostFields()
        {
            this.DeleteHostingUnitGrid.DataContext = hostingUnit;

            HostId.Text = hostingUnit.HostingUnitKey.ToString();
            Name.Text = hostingUnit.HostingUnitName;
            Area.Text = hostingUnit.Area.ToString();
            Type.Text = hostingUnit.HostingUnitType.ToString();
            Pool.Text = hostingUnit.Pool.ToString();
            Jacuzzi.Text = hostingUnit.Jacuzzi.ToString();
            Porch.Text = hostingUnit.Porch.ToString();
            ChildrenAttractions.Text = hostingUnit.ChildrenAttractions.ToString();
            Food.Text = hostingUnit.Food.ToString();
            Beds.Text = hostingUnit.Beds.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
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

                if (HostingUnitKey.SelectedItem.ToString() == null)
                {
                    MessageBox.Show($"you need to fill all details", "", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                bl.DeleteHostingUnit(hostingUnit.HostingUnitKey);
                this.DataContext = hostingUnit;
                this.Close();
                MessageBox.Show($"The Hosting Unit was Deleted by the system");
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
