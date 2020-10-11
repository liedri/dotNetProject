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
    /// Interaction logic for UpdateHostingUnit.xaml
    /// </summary>
    public partial class UpdateHostingUnit : Window
    {
        BE.HostingUnit hostingUnit;
        IBl bl;
        private List<string> errorMessages;
        public UpdateHostingUnit(BE.HostingUnit hu)
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            bl = FactoryBL.GetBl();
            hostingUnit = hu;

            this.HostingUnitKey.Text = hostingUnit.HostingUnitKey.ToString();
            //this.HostingUnitKey.ItemsSource = bl.GetHostingUnitList();
            //this.HostingUnitKey.DisplayMemberPath = "HostingUnitKey";
            //this.HostingUnitKey.SelectedValuePath = "HostingUnitKey";

            this.Area.ItemsSource = Enum.GetValues(typeof(Enums.Area));
            this.Type.ItemsSource = Enum.GetValues(typeof(Enums.HostingUnitType));
            this.Food.ItemsSource = Enum.GetValues(typeof(Enums.Food));

            setHostingUnitFields();

            errorMessages = new List<string>();
        }

        private void UpdateHostingUnit_Button_Click(object sender, RoutedEventArgs e)
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

                if (HostingUnitKey.ToString() == "" || Name.Text == "")
                {
                    MessageBox.Show($"you need to fill all details", "", MessageBoxButton.OK, MessageBoxImage.Error);
                }

                if (this.Pool.Text == "No")
                    hostingUnit.Pool = false;
                else
                    hostingUnit.Pool = true;

                if (this.Porch.Text == "No")
                    hostingUnit.Porch = false;
                else
                    hostingUnit.Porch = true;

                if (this.Jacuzzi.Text == "No")
                    hostingUnit.Jacuzzi = false;
                else
                    hostingUnit.Jacuzzi = true;

                if (this.ChildrenAttractions.Text == "No")
                    hostingUnit.ChildrenAttractions = false;
                else
                    hostingUnit.ChildrenAttractions = true;

                bl.UpdateHostingUnit(hostingUnit);
                this.DataContext = hostingUnit;
                this.Close();
                MessageBox.Show($"The hosting unit was updated by the system");
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

        //private void HostingUnitKey_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    hostingUnit = null;
        //    if (this.HostingUnitKey.SelectedItem is BE.HostingUnit)
        //    {
        //        this.hostingUnit = ((BE.HostingUnit)this.HostingUnitKey.SelectedItem);
        //        setHostingUnitFields();
        //    }
        //}

        private void setHostingUnitFields()
        {
            this.UpdateHostingUnitGrid.DataContext = hostingUnit;

            HostId.Text = hostingUnit.Owner.HostKey.ToString();
            Name.Text = hostingUnit.HostingUnitName;
            Area.SelectedItem = hostingUnit.Area;
            Type.SelectedItem = hostingUnit.HostingUnitType;
            Beds.Text = hostingUnit.Beds.ToString();
            Food.SelectedItem = hostingUnit.Food;
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
    }
}
