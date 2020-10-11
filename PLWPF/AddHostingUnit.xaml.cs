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
    /// Interaction logic for AddHostingUnit.xaml
    /// </summary>
    public partial class AddHostingUnit : Window
    {
        BE.HostingUnit hostingUnit;
        IBl bl;
        private List<string> errorMessages;
        public AddHostingUnit(BE.Host ho)
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            bl = FactoryBL.GetBl();
            hostingUnit = new BE.HostingUnit();
            BE.Host host = ho;
            this.DataContext = hostingUnit;

            errorMessages = new List<string>();

            //this.HostId.ItemsSource = bl.GetHostList();
            //this.HostId.DisplayMemberPath = "HostKey";
            //this.HostId.SelectedValuePath = "HostKey";

            this.HostId.Text = host.HostKey.ToString();

            this.Area.ItemsSource = Enum.GetValues(typeof(Enums.Area));
            this.Type.ItemsSource = Enum.GetValues(typeof(Enums.HostingUnitType));
            this.Food.ItemsSource = Enum.GetValues(typeof(Enums.Food));

            this.Pool.Text = "No";
            this.Jacuzzi.Text = "No";
            this.Porch.Text = "No";
            this.ChildrenAttractions.Text = "No";

        }

        private void Add_Button_Click(object sender, RoutedEventArgs e)
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

                if (Name.Text == "" || this.HostId.Text == "")
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

                hostingUnit.Owner = bl.GetHostById(int.Parse(this.HostId.Text));
                bl.AddHostingUnit(hostingUnit);
                hostingUnit = new BE.HostingUnit();
                this.DataContext = hostingUnit;
                this.Close();
                MessageBox.Show($"The Hosting Unit was received by the system");
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
    }
}
