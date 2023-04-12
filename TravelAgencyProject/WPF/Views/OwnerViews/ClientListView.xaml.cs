using Castle.Core.Logging;
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
using TravelAgencyProject.Applications.Services;
using TravelAgencyProject.Domain.Model;
using TravelAgencyProject.Repository;
using TravelAgencyProject.Applications.Util;

namespace TravelAgencyProject.View
{

    public partial class ClientListView : Window
    {
        List<AccommodationReservation> accommodationReservations = new List<AccommodationReservation>();
        List<AccommodationGuest> accommodationGuests = new List<AccommodationGuest>();
        OwnerHome ownerHome = new OwnerHome();
        public ClientListView()
        {
            InitializeComponent();

            AccommodationReservationRepository accommodationReservationRepo = new AccommodationReservationRepository();
            
            accommodationReservations = accommodationReservationRepo.GetAll();
            List<AccommodationReservation> filteredAccommodationReservations = FilterAccommodationReservation(accommodationReservations);
            
            foreach (AccommodationReservation accommodationReservation in filteredAccommodationReservations) {
                accommodationGuests.Add(accommodationReservation.Guest);
            }
            listBox.ItemsSource = accommodationGuests;
            
        }

        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AccommodationGuest accommodationGuest = listBox.SelectedItem as AccommodationGuest;
            AccommodationGuestReviewView accommodationGuestReviewView = new AccommodationGuestReviewView(accommodationGuest);
            accommodationGuestReviewView.Show();
            this.Close();

        }
        private List<AccommodationReservation> FilterAccommodationReservation(List<AccommodationReservation> accommodationReservations)
        {
            List<AccommodationReservation> filtered = new List<AccommodationReservation>();
            AccommodationGuestReviewService accommodationGuestReviewService = new AccommodationGuestReviewService();
            foreach(AccommodationReservation accommodationReservation in accommodationReservations)
            {
                DateTime CheckoutDay = accommodationReservation.Date.AddDays(accommodationReservation.ReservedDayNumber);
                TimeSpan reviewDeadline = DateTime.Now - CheckoutDay; 
                if (ownerHome.isReviewEligible(accommodationReservation, reviewDeadline, accommodationGuestReviewService)) { 
                filtered.Add(accommodationReservation);
                } 
            }
            return filtered;
        }

        

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            OwnerHome ownerHome = new OwnerHome();
            ownerHome.Show();
            this.Close();
        }
    }
}
