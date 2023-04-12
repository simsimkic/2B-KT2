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

namespace TravelAgencyProject.View
{
    /// <summary>
    /// Interaction logic for RejectionSummaryView.xaml
    /// </summary>
    public partial class RejectionSummaryView : Window
    {
        private RescheduleReservationRequest rescheduleReservationRequest;
        private RescheduleReservationRequestController rescheduleReservationRequestController;
        public RejectionSummaryView(RescheduleReservationRequest rescheduleReservationRequest, RescheduleReservationRequestController rescheduleReservationRequestController)
        {
            InitializeComponent();
            this.rescheduleReservationRequest = rescheduleReservationRequest;
            this.rescheduleReservationRequestController = rescheduleReservationRequestController;
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            
            rescheduleReservationRequest.RejectionSummary = rejectionSummaryTextBox.Text;
            rescheduleReservationRequest.Status = RescheduleReservationStatus.Denied;
            rescheduleReservationRequestController.Update(rescheduleReservationRequest);
            MessageBox.Show("Request denied.");
            RescheduleRequestsView rescheduleRequestView = new RescheduleRequestsView();
            rescheduleRequestView.Show();
            this.Close();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            RescheduleRequestsView rescheduleRequestsView = new RescheduleRequestsView();
            rescheduleRequestsView.Show();
            this.Close();
        }
    }
}
