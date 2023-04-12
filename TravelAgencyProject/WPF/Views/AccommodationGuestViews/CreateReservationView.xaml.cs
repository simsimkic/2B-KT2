using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace TravelAgencyProject.View
{
    /// <summary>
    /// Interaction logic for CreateReservationView.xaml
    /// </summary>
    public partial class CreateReservationView : Window
    {

        List<String> avalibleDates = new List<String>();
        AccommodationController accommodationController = new AccommodationController();
        AccommodationReservationController accommodationReservationController;
        Accommodation bookedAccommodation;
         

        public CreateReservationView(Accommodation accommodation)
        {
            InitializeComponent();
            accommodationReservationController = accommodationReservationController = (AccommodationReservationController)App.Services.GetService(typeof(AccommodationReservationController));

            bookedAccommodation = accommodation;
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            AccommodationReservationDto reservationRequest = new AccommodationReservationDto(bookedAccommodation.Id, (DateTime)StartDatePicker.SelectedDate, (DateTime)EndDatePicker.SelectedDate, Convert.ToInt32(ReservedDaysNumberTextBox.Text));

            if(!accommodationReservationController.CheckReservedDays(reservationRequest.AccommodationId, reservationRequest.ReservedDaysNumber))
            {
                MessageBox.Show("You put less days than minimal number of days for booking this accommodation");

            }
            else
            {
                avalibleDates = accommodationReservationController.CheckAvalibleDates(reservationRequest);

                if(avalibleDates.Count > 0)
                {
                    listBox.ItemsSource = avalibleDates;
                    listBox.Items.Refresh();
                }
                else
                {
                    MessageBox.Show("There isn't any avalible days for this accommodation in that range of dates, here are some dates you can choose");
                    avalibleDates = accommodationReservationController.FindNewAvalibleDates(reservationRequest);
                    listBox.ItemsSource = avalibleDates;
                    listBox.Items.Refresh();
                }
            }

        }

        private void BookButton_Click(object sender, RoutedEventArgs e)
        {

            if (accommodationReservationController.CheckGuestNumber(bookedAccommodation.Id, Convert.ToInt32(GuestNumberTextBox.Text))){
                AccommodationReservationDto reservationRequest = new AccommodationReservationDto(bookedAccommodation.Id, (DateTime)StartDatePicker.SelectedDate, (DateTime)EndDatePicker.SelectedDate, Convert.ToInt32(ReservedDaysNumberTextBox.Text));
                string chosenDate = listBox.SelectedItem.ToString();
                string[] parts = chosenDate.Split('-');

                accommodationReservationController.Create(reservationRequest, DateTime.Parse(parts[0]),Convert.ToInt32(GuestNumberTextBox.Text));
                MessageBox.Show("You successfully created a reservation");
                AccommodationGuestHomeView accommodationGuestHomeView = new AccommodationGuestHomeView();
                accommodationGuestHomeView.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("The guest capacity for this accommodation is impaired");

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
