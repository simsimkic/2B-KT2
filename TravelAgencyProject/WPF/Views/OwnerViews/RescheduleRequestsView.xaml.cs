using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

namespace TravelAgencyProject.View
{
    /// <summary>
    /// Interaction logic for RescheduleRequestsView.xaml
    /// </summary>
    public partial class RescheduleRequestsView : Window
    {
        RescheduleReservationRequestController rescheduleReservationRequestController;
        AccommodationReservationController accommodationReservationController;
        List<RescheduleReservationRequest> rescheduleReservationRequests = new List<RescheduleReservationRequest>();
        List<AccommodationReservation> accommodationReservations = new List<AccommodationReservation>();
        List<ApprovedReservationRequestDTO> allApprovedReservationRequestDTOs = new List<ApprovedReservationRequestDTO>();
        List<ApprovedReservationRequestDTO> approvedReservationRequestDTOs = new List<ApprovedReservationRequestDTO>();
        
        public RescheduleRequestsView()
        {
            InitializeComponent();
            rescheduleReservationRequestController = (RescheduleReservationRequestController)App.Services.GetService(typeof(RescheduleReservationRequestController));
            accommodationReservationController = (AccommodationReservationController)App.Services.GetService(typeof(AccommodationReservationController));
            listBox.SelectedIndex = 0;
            rescheduleReservationRequests = rescheduleReservationRequestController.GetByStatus(RescheduleReservationStatus.Pending);
            accommodationReservations = accommodationReservationController.GetAll();
            allApprovedReservationRequestDTOs = convertToDto(rescheduleReservationRequests);
            foreach(ApprovedReservationRequestDTO ap in allApprovedReservationRequestDTOs){
                if (ap.Reservation.Accommodation.OwnerId == UserSession.User.Id && ap.Reservation.Date > DateTime.Now)
                    approvedReservationRequestDTOs.Add(ap);
            }
            listBox.ItemsSource = approvedReservationRequestDTOs;    
        }

        private void AcceptButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            ApprovedReservationRequestDTO approvedReservationRequestDTO = button.DataContext as ApprovedReservationRequestDTO;
            RescheduleReservationRequest rescheduleReservationRequest = rescheduleReservationRequestController.GetById(approvedReservationRequestDTO.RescheduleReservationRequestId);
            foreach (AccommodationReservation accommodationReservation in accommodationReservations)
            {
                if (accommodationReservation.Id == rescheduleReservationRequest.ReservationId)
                {
                    accommodationReservation.Date = rescheduleReservationRequest.NewDate;
                    accommodationReservation.Status = AccommodationReservationStatus.Rescheduled;
                    rescheduleReservationRequest.Status = RescheduleReservationStatus.Approved;
                    accommodationReservationController.Update(accommodationReservation);
                    rescheduleReservationRequestController.Update(rescheduleReservationRequest);
                    approvedReservationRequestDTOs.Remove(approvedReservationRequestDTO);
                    listBox.ItemsSource = approvedReservationRequestDTOs;
                    listBox.Items.Refresh();
                    MessageBox.Show("Reservation date changed to " + rescheduleReservationRequest.NewDate.ToString());
                    break;
                }
            }

        }

        private void DeclineButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            ApprovedReservationRequestDTO approvedReservationRequestDTO = button.DataContext as ApprovedReservationRequestDTO;
            RescheduleReservationRequest rescheduleReservationRequest = rescheduleReservationRequestController.GetById(approvedReservationRequestDTO.RescheduleReservationRequestId);
            RejectionSummaryView rejectionSummaryView = new RejectionSummaryView(rescheduleReservationRequest, rescheduleReservationRequestController);
            rejectionSummaryView.Show();
            approvedReservationRequestDTOs.Remove(approvedReservationRequestDTO);
            listBox.ItemsSource = approvedReservationRequestDTOs;
            listBox.Items.Refresh();
            this.Close();
        }

        private List<ApprovedReservationRequestDTO> convertToDto(List<RescheduleReservationRequest> rescheduleReservationRequests)
        {
            List<ApprovedReservationRequestDTO> approvedRequests = new List<ApprovedReservationRequestDTO>();

            foreach (RescheduleReservationRequest request in rescheduleReservationRequests)
            {
                ApprovedReservationRequestDTO dto = new ApprovedReservationRequestDTO(request.Reservation, request.NewDate, request.Id);
                approvedRequests.Add(dto);
            }
            return approvedRequests;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            OwnerHome ownerHome = new OwnerHome();
            ownerHome.Show();
            this.Close();
        }
    }


}
