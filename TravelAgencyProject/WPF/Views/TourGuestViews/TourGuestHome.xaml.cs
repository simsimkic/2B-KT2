using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using TravelAgencyProject.Applications.Controller;
using TravelAgencyProject.Applications.Util;
using TravelAgencyProject.Domain.Model;
using TravelAgencyProject.Repository;
using TravelAgencyProject.Applications.Services;
using TravelAgencyProject.View;

namespace TravelAgencyProject.View
{
    /// <summary>
    /// Interaction logic for TourGuestHome.xaml
    /// </summary>
    public partial class TourGuestHome : Window
    {
        List<Tour> tours = new List<Tour>();
        public TourGuestHome()
        {
            InitializeComponent();

            listBox.ItemsSource = tours;
            
        }

        private void TourGuestHome_Loaded(object sender, RoutedEventArgs e)
        {
            ShowPendingReviews();
            //MessageBox.Show("Hello, world!");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TourController tourController = new TourController();

            tours = tourController.GetAll();


            listBox.ItemsSource = tours;
            //listBox.DisplayMemberPath = "Language";
            listBox.Items.Refresh();

        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            TourController tourController = new TourController();

            if (!string.IsNullOrEmpty(CityTextBox.Text)) 
            {
                tours = tourController.GetByCity(CityTextBox.Text);
                
            }

            if(!string.IsNullOrEmpty(StateTextBox.Text))
            {
                
                tours = tourController.GetByState(StateTextBox.Text);
            }
            
            if (!string.IsNullOrEmpty(DurationTextBox.Text)) 
            {
                tours = tourController.GetByDuration(Convert.ToInt32(DurationTextBox.Text));
            }
            if (!string.IsNullOrEmpty(LanguageTextBox.Text)) 
            {
                tours = tourController.GetByLanguage(LanguageTextBox.Text);
            }
            if (!string.IsNullOrEmpty(GuestsNumberTextBox.Text)) 
            {
                tours = tourController.GetByGuestsNumber(Convert.ToInt32(GuestsNumberTextBox.Text));
            }

            listBox.ItemsSource = tours;
            
            listBox.Items.Refresh();
        }

        private void BookTour(object sender, RoutedEventArgs e)
        {
            TourReservationView tourReservationView = new TourReservationView((Tour)listBox.SelectedItem);
            tourReservationView.Show();
            this.Close();

        }

        private void ShowPendingReviews()
        {
            TourGuideReviewController tourGuideReviewController = new TourGuideReviewController();
            TourAttendanceController tourAttendanceController = new TourAttendanceController();

            List<TourGuideReview> tourGuideReviews = tourGuideReviewController.GetAll();
            List<TourAttendance> tourAttendances = tourAttendanceController.GetAttendancesFromFinishedTours(UserSession.User.Id);
            

            foreach (TourAttendance tourAttendance in tourAttendances)
            {
                if (!tourGuideReviewController.IsReviewed(tourAttendance.TourArrangement.TourId, tourAttendance.GuestId))
                {
                    TourGuideReviewView tourGuideReviewView = new TourGuideReviewView(tourAttendance);
                    tourGuideReviewView.Show();
                }
            }

        }

        private void Button_Click_MyProfile(object sender, RoutedEventArgs e)
        {
            TourGuestProfileView tourGuestProfileView = new TourGuestProfileView();
            tourGuestProfileView.Show();

        }

        private void Button_Click_ReservedTours(object sender, RoutedEventArgs e)
        {
            TourGuestReservationsView tourGuestReservationsView = new TourGuestReservationsView();
            tourGuestReservationsView.Show();
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            LoginView loginView = new LoginView();
            this.Close();
            loginView.Show();
            UserSession.User = null;
        }
    }
}
