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
using TravelAgencyProject.Applications.DTOs;
using TravelAgencyProject.Repository;
using TravelAgencyProject.Applications.Services;

namespace TravelAgencyProject.View
{
    /// <summary>
    /// Interaction logic for SearchAccommodationsView.xaml
    /// </summary>
    public partial class SearchAccommodationsView : Window
    {
        public List<Accommodation> accommodations = new List<Accommodation>();
        private AccommodationController accommodationController = new AccommodationController();
        private RescheduleReservationRequestController rescheduleReservationRequestController;

        public SearchAccommodationsView()
        {
            InitializeComponent();
            rescheduleReservationRequestController = (RescheduleReservationRequestController)App.Services.GetService(typeof(RescheduleReservationRequestController));
            listBox.ItemsSource = accommodations;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            accommodations = accommodationController.GetAll();

            listBox.ItemsSource = accommodations;
            listBox.Items.Refresh();
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {

            if (!string.IsNullOrEmpty(CityTextBox.Text))
            {
                accommodations = accommodationController.GetByCity(CityTextBox.Text);

            }

            if (!string.IsNullOrEmpty(StateTextBox.Text))
            {

                accommodations = accommodationController.GetByState(StateTextBox.Text);
            }

            if (!string.IsNullOrEmpty(NameTextBox.Text))
            {
                accommodations = accommodationController.GetByName(NameTextBox.Text);
            }
     
            if (!string.IsNullOrEmpty(GuestsNumberTextBox.Text))
            {
                accommodations = accommodationController.GetByGuestsNumber(Convert.ToInt32(GuestsNumberTextBox.Text));
            }

            if (!string.IsNullOrEmpty(ReservedDaysTextBox.Text))
            {
                accommodations = accommodationController.GetByReservedDaysNumber(Convert.ToInt32(ReservedDaysTextBox.Text));
            }

            if (!string.IsNullOrEmpty(TypeComboBox.Text))
            {
                Enum.TryParse<AccommodationType>(TypeComboBox.SelectedItem.ToString(), out AccommodationType accommodationType);
                accommodations = accommodationController.GetByType(ParseAccommodationType(TypeComboBox.SelectedIndex)
);
            }

            listBox.ItemsSource = accommodations;
            listBox.Items.Refresh();
        }

        private AccommodationType ParseAccommodationType(int selectedIndex)
        {
            if (selectedIndex == 0) return AccommodationType.Apartment;
            else if (selectedIndex == 1) return AccommodationType.House;
            else return AccommodationType.Cottage;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            CreateReservationView createReservationView = new CreateReservationView((Accommodation)listBox.SelectedItem);
            createReservationView.Show();
            this.Close();

        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            AccommodationGuestHomeView accommodationGuestHomeView = new AccommodationGuestHomeView();
            accommodationGuestHomeView.Show();
            this.Close();
        }
    }
}
