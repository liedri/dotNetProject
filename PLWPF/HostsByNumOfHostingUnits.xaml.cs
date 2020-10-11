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
    /// Interaction logic for GetHostsByNumOfHostingUnits.xaml
    /// </summary>
    public partial class HostsByNumOfHostingUnits : Window
    {
        IBl bl;
        private List<string> errorMessages;
        public HostsByNumOfHostingUnits()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            bl = FactoryBL.GetBl();

            //IEnumerable<IGrouping<int, BE.Host>> hosts;
            //List<BE.Host> hostList = new List<BE.Host>();
            //hosts = bl.GetHostsByNumOfHostingUnits();

            //foreach (var item in hosts)
            //{
            //    foreach (var v in item)
            //    {
            //        hostList.Add(v);
            //    }
            //}

            List<BE.Host> hostList = bl.GetHostList();


            HostsByNumOfHostingUnits_Grouping.ItemsSource = hostList;

            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(HostsByNumOfHostingUnits_Grouping.ItemsSource);
            PropertyGroupDescription groupDescription = new PropertyGroupDescription("NumOfHostingUnits");
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
