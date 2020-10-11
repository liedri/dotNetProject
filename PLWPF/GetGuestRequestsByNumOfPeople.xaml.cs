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
    /// Interaction logic for GetGuestRequestsByNumOfPeople.xaml
    /// </summary>
    public partial class GetGuestRequestsByNumOfPeople : Window
    {
        IBl bl;
        private List<string> errorMessages;
        public GetGuestRequestsByNumOfPeople()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            bl = FactoryBL.GetBl();
            int help = 1;

            IEnumerable<IGrouping<int, GuestRequest>> guestRequests;
            List <GuestRequest> guestRequestsList = new List<GuestRequest>();
            guestRequests = bl.GetGuestRequestsByNumOfPeople();

            foreach (var item in guestRequests)
            {
                foreach (var v in item)
                {
                    guestRequestsList.Add(v);
                }
            }

            //foreach (var item in guestRequests)
            //{
            //    GetGuestRequestsByNumOfPeople_Grouping.ItemsSource = item;
            //    help = item.First().NumOfAdults + item.First().NumOfKids;

            //    CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(GetGuestRequestsByNumOfPeople_Grouping.ItemsSource);
            //    PropertyGroupDescription groupDescription = new PropertyGroupDescription("help");
            //    view.GroupDescriptions.Add(groupDescription);
            //}
            guestRequestsList = guestRequestsList.OrderBy(g => g.NumOfTotalPeople).ToList();
            GetGuestRequestsByNumOfPeople_Grouping.ItemsSource = guestRequestsList;

            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(GetGuestRequestsByNumOfPeople_Grouping.ItemsSource);
            PropertyGroupDescription groupDescription = new PropertyGroupDescription("NumOfTotalPeople");
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
