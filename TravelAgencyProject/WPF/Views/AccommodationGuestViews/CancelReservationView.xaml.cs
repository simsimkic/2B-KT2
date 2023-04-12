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
    /// Interaction logic for CancelReservationView.xaml
    /// </summary>
    public partial class CancelReservationView : Window
    {

        List<AccommodationReservation> reservations = new List<AccommodationReservation>();
        AccommodationReservationController accommodationReservationController;

        public CancelReservationView()
        {
           
            InitializeComponent();
            accommodationReservationController = (AccommodationReservationController)App.Services.GetService(typeof(AccommodationReservationController));
            reservations = accommodationReservationController.GetByGuestId(UserSession.User.Id);
            listBox.ItemsSource = reservations;
            listBox.Items.Refresh();

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            AccommodationReservation selectedReservation = listBox.SelectedItem as AccommodationReservation;
            if (accommodationReservationController.Cancel(selectedReservation.Id))
                MessageBox.Show("Reservation cancelled");
            else
                MessageBox.Show("Unable to cancel reservation");

            reservations = accommodationReservationController.GetByGuestId(UserSession.User.Id);
            listBox.ItemsSource = reservations;
            listBox.Items.Refresh();

        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            AccommodationGuestHomeView accommodationGuestHomeView = new AccommodationGuestHomeView();
            accommodationGuestHomeView.Show();
            this.Close();

        }
    }
}
