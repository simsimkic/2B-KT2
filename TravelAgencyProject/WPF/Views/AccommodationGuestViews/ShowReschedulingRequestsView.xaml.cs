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
using TravelAgencyProject.Applications.Controller;
using TravelAgencyProject.Domain.Model;
using TravelAgencyProject.Applications.Services;
using TravelAgencyProject.Repository;

namespace TravelAgencyProject.View
{
    /// <summary>
    /// Interaction logic for ShowReschedulingRequestsView.xaml
    /// </summary>
    public partial class ShowReschedulingRequestsView : Window
    {
        private AccommodationController accommodationController = new AccommodationController();
        private RescheduleReservationRequestController rescheduleReservationRequestController;

        public ShowReschedulingRequestsView(List<RescheduleReservationRequest> requests)
        {
            InitializeComponent();
            rescheduleReservationRequestController = (RescheduleReservationRequestController)App.Services.GetService(typeof(RescheduleReservationRequestController));
            listBox.ItemsSource = requests;
            listBox.Items.Refresh();
        }
    }
}
