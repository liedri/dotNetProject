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
    /// Interaction logic for GuestRequestsByArea.xaml
    /// </summary>
    public partial class GuestRequestsByArea : Window
    {
        //GuestRequest guestRequest;
        IBl bl;
        private List<string> errorMessages;
        public GuestRequestsByArea()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            bl = FactoryBL.GetBl();
            //guestRequest = new GuestRequest();
            //this.DataContext = guestRequest;

            IEnumerable<IGrouping<Enums.Area, GuestRequest>> guestRequests;
            List<GuestRequest> guestRequestsList = new List<GuestRequest>();
            guestRequests = bl.GetGuestRequestsByArea();

            foreach(var item in guestRequests)
            {
                foreach (var v in item)
                {
                    guestRequestsList.Add(v);
                }
            }

            GuestRequestsByArea_Grouping.ItemsSource = guestRequestsList;

            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(GuestRequestsByArea_Grouping.ItemsSource);
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
