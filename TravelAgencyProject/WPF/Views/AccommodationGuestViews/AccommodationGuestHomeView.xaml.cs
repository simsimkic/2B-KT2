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
using TravelAgencyProject.Domain.Model;
using TravelAgencyProject.Repository;
using TravelAgencyProject.Applications.Services;
using TravelAgencyProject.Applications.Util;

namespace TravelAgencyProject.View
{
    /// <summary>
    /// Interaction logic for SearchAccommodationsView.xaml
    /// </summary>
    public partial class AccommodationGuestHomeView : Window
    {
        private AccommodationController accommodationController = new AccommodationController();
        private RescheduleReservationRequestController rescheduleReservationRequestController = (RescheduleReservationRequestController)App.Services.GetService(typeof(RescheduleReservationRequestController));


        public AccommodationGuestHomeView()
        {
            InitializeComponent();
        }

        private void Functionality1Button_Click(object sender, RoutedEventArgs e)
        {
            SearchAccommodationsView searchAccommodationsView = new SearchAccommodationsView();
            searchAccommodationsView.Show();
            this.Close();
        }

        private void Functionality2Button_Click(object sender, RoutedEventArgs e)
        {
            OwnerReviewView ownerReviewView = new OwnerReviewView();
            ownerReviewView.Show();
            this.Close();
        }
        private void Functionality3Button_Click(object sender, RoutedEventArgs e)
        {
            RescheduleReservationView rescheduleReservationView = new RescheduleReservationView();
            rescheduleReservationView.Show();
            this.Close();
        }

        private void Functionality4Button_Click(object sender, RoutedEventArgs e)
        {
            CancelReservationView cancelReservationView = new CancelReservationView();
            cancelReservationView.Show();
            this.Close();
        }

        private void Functionality5Button_Click(object sender, RoutedEventArgs e)
        {
            UserSession.User = null;
            LoginView loginView = new LoginView();
            loginView.Show();
            this.Close();
        }
    }
}
