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
using TravelAgencyProject.Applications.DTOs;
using TravelAgencyProject.Applications.Util;
using TravelAgencyProject.Domain.Model;
using TravelAgencyProject.Repository;
using TravelAgencyProject.Applications.Services;

namespace TravelAgencyProject.View
{
    /// <summary>
    /// Interaction logic for AccommodationGuestHome.xaml
    /// </summary>
    public partial class RescheduleReservationView : Window
    {
        private List<RescheduleReservationRequest> requests = new List<RescheduleReservationRequest>();
        private List<AccommodationReservation> reservations = new List<AccommodationReservation>();

        private RescheduleReservationRequestController rescheduleReservationRequestController;
        private AccommodationReservationController accommodationReservationController;




        public RescheduleReservationView()
        {
           
            InitializeComponent();
            accommodationReservationController = (AccommodationReservationController)App.Services.GetService(typeof(AccommodationReservationController));
            rescheduleReservationRequestController = (RescheduleReservationRequestController)App.Services.GetService(typeof(RescheduleReservationRequestController));


            reservations = accommodationReservationController.GetByGuestId(UserSession.User.Id);
            listBox.ItemsSource = reservations;
            listBox.Items.Refresh();

        }

        private void GetAll_Click(object sender, RoutedEventArgs e)
        {
            requests = rescheduleReservationRequestController.GetByAccommodationGuestId(UserSession.User.Id);
            ShowReschedulingRequestsView showReschedulingRequestsView = new ShowReschedulingRequestsView(requests);
            showReschedulingRequestsView.Show();

        }

        private void SeeNotifications_Click(object sender, RoutedEventArgs e)
        {
            requests = rescheduleReservationRequestController.GetApprovedRequests(UserSession.User.Id);
            ShowReschedulingRequestsView showReschedulingRequestsView = new ShowReschedulingRequestsView(requests);
            showReschedulingRequestsView.Show();
        }

        private void RescheduleButton_Click(object sender, RoutedEventArgs e)
        {
            AccommodationReservation selectedReservation = listBox.SelectedItem as AccommodationReservation;
            RescheduleReservationRequestDTO rescheduleReservationRequestDTO = new RescheduleReservationRequestDTO(Convert.ToInt32(selectedReservation.Id), (DateTime)NewDatePicker.SelectedDate);
            rescheduleReservationRequestController.Create(rescheduleReservationRequestDTO);
            MessageBox.Show("You created a reschedule request");
            var itemInCollection = reservations.FirstOrDefault(reservation => reservation.Id == selectedReservation.Id);
            if (itemInCollection != null)
            {
                itemInCollection.Status = AccommodationReservationStatus.Rescheduled;
                listBox.Items.Refresh();
            }

        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            AccommodationGuestHomeView accommodationGuestHomeView = new AccommodationGuestHomeView();
            accommodationGuestHomeView.Show();
            this.Close();

        }
    }
}
