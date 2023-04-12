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
using TravelAgencyProject.Applications.Util;
using TravelAgencyProject.Domain.Model;
using TravelAgencyProject.Applications.DTOs;
using TravelAgencyProject.Repository;
using TravelAgencyProject.Applications.Services;

namespace TravelAgencyProject.View
{
    /// <summary>
    /// Interaction logic for OwnerReviewView.xaml
    /// </summary>
    public partial class OwnerReviewView : Window
    {

        List<AccommodationReservation> reservations = new List<AccommodationReservation>();
        AccommodationReservationController accommodationReservationController;
        OwnerReviewController ownerReviewController = new OwnerReviewController();

        public OwnerReviewView()
        {
           
            InitializeComponent();
            accommodationReservationController = (AccommodationReservationController)App.Services.GetService(typeof(AccommodationReservationController));
            reservations = accommodationReservationController.GetReservationsForReviewing(UserSession.User.Id);
            listBox.ItemsSource = reservations;
            listBox.Items.Refresh();

        }

        private void ReviewOwner_Click(object sender, RoutedEventArgs e)
        {
            AccommodationReservation selectedReservation = (AccommodationReservation)listBox.SelectedItem;
            String parsedString = ImagesTextBox.Text.Replace(" ","");
            ownerReviewController.Create(selectedReservation.Accommodation.OwnerId, selectedReservation.AccommodationId, selectedReservation.AccommodationGuestId, (int)CleannessSlider.Value, (int)OwnerFarinessSlider.Value, CommentTextBox.Text, parsedString);
            MessageBox.Show("Review saved");

        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            AccommodationGuestHomeView accommodationGuestHomeView = new AccommodationGuestHomeView();
            accommodationGuestHomeView.Show();
            this.Close();

        }
    }
}
