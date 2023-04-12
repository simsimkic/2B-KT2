using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Data;
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
using TravelAgencyProject.Repository;

namespace TravelAgencyProject.View
{
    /// <summary>
    /// Interaction logic for CreateAccommodationView.xaml
    /// </summary>
    public partial class CreateAccommodationView : Window
    {
        private AccommodationController accommodationController = new AccommodationController();
        private LocationController locationController = new LocationController();
        private UserController userController = new UserController();

        public CreateAccommodationView()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            AccommodationController accommodationController = new AccommodationController();
            LocationRepository locationRepository = new LocationRepository();
            
            Location existingLocation;
        

            if ((existingLocation = locationRepository.GetByCity(txtCity.Text)) != null)
            {
                Accommodation accommodation = new Accommodation(txtName.Text, existingLocation.Id, ParseAccommodationType(cmbType.SelectedIndex), int.Parse(txtMaxGuestNumber.Text), int.Parse(txtMinDayNumber.Text), int.Parse(txtMinCancelationDays.Text), txtImages.Text, UserSession.User.Id);
                accommodationController.Save(accommodation);
            }
            else
            {
                Accommodation accommodation = new Accommodation(txtName.Text, new Location(txtCity.Text, txtState.Text), ParseAccommodationType(cmbType.SelectedIndex), int.Parse(txtMaxGuestNumber.Text), int.Parse(txtMinDayNumber.Text), int.Parse(txtMinCancelationDays.Text), txtImages.Text, UserSession.User.Id);
                accommodationController.Save(accommodation);
            }
            MessageBox.Show("Accommodation successfully created.");
            OwnerHome ownerHome = new OwnerHome();
            ownerHome.Show();
            this.Close();
        }
        
        private AccommodationType ParseAccommodationType(int selectedIndex)
        {
            if (selectedIndex == 0) return AccommodationType.Apartment;
            else if (selectedIndex == 1) return AccommodationType.House;
            else return AccommodationType.Cottage;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            OwnerHome ownerHome = new OwnerHome();
            ownerHome.Show();
            this.Close();
        }
    }
}
