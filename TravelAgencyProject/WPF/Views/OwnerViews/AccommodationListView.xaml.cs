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
using TravelAgencyProject.Applications.Services;

namespace TravelAgencyProject.View
{
    /// <summary>
    /// Interaction logic for AccommodationListView.xaml
    /// </summary>
    public partial class AccommodationListView : Window
    {
        AccommodationController accommodationController = new AccommodationController();

        public string SuperRole { get; set; }
        public AccommodationListView()
        {
            InitializeComponent();
            List<Accommodation> accommodations = new List<Accommodation>();
            List<Accommodation> sortedAccommodations = new List<Accommodation>();
            List<AccommodationDTO> accommodationDTOs = new List<AccommodationDTO>();
            accommodations = accommodationController.GetAll(); 
            sortedAccommodations = SortAccommodationsBySuperOwner(accommodations);
            accommodationDTOs = convertToDto(sortedAccommodations);
            listBox.ItemsSource = accommodationDTOs;
        }
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            OwnerHome ownerHome = new OwnerHome();
            ownerHome.Show();
            this.Close();
        }

        private List<Accommodation> SortAccommodationsBySuperOwner(List<Accommodation> accommodations)
        {
            UserController userController = new UserController();
            List<Owner> owners = new List<Owner>();
            List<Accommodation> superOwnerAccommodations = new List<Accommodation>();
            List<Accommodation> sortedAccommodations = new List<Accommodation>();
            owners = userController.GetOwners();
            foreach(Owner owner in owners)
            {
                if (owner.Status.Equals(Status.Super))
                    superOwnerAccommodations.AddRange(accommodationController.GetByOwnerId(owner.Id));
            }
            accommodations.RemoveAll(x => superOwnerAccommodations.Contains(x));
            sortedAccommodations.AddRange(superOwnerAccommodations);
            sortedAccommodations.AddRange(accommodations);
            return sortedAccommodations;    
        }

        private List<AccommodationDTO> convertToDto(List<Accommodation> accommodations)
        {
            List<AccommodationDTO> accommodationDTOs = new List<AccommodationDTO>();

            foreach (Accommodation accommodation in accommodations)
            {
                AccommodationDTO dto = new AccommodationDTO(accommodation.Name, accommodation.Location, accommodation.Owner);
                accommodationDTOs.Add(dto);
            }
            return accommodationDTOs;
        }
    }
}
