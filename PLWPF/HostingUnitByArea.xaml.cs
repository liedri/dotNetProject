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
    /// Interaction logic for HostingUnitByArea.xaml
    /// </summary>
    public partial class HostingUnitByArea : Window
    {
        IBl bl;
        private List<string> errorMessages;

        public HostingUnitByArea()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            bl = FactoryBL.GetBl();

            IEnumerable<IGrouping<Enums.Area, BE.HostingUnit>> hostingUnits;
            List<BE.HostingUnit> hostingUnitsList = new List<BE.HostingUnit>();
            hostingUnits = bl.GetHostingUnitsByArea();

            foreach (var item in hostingUnits)
            {
                foreach (var v in item)
                {
                    hostingUnitsList.Add(v);
                }
            }

            HostingUnitByArea_Grouping.ItemsSource = hostingUnitsList;

            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(HostingUnitByArea_Grouping.ItemsSource);
            PropertyGroupDescription groupDescription = new PropertyGroupDescription("Area");
            view.GroupDescriptions.Add(groupDescription);
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
