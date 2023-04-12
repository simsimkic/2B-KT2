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
using TravelAgencyProject.Applications.DTOs;
using TravelAgencyProject.Applications.Services;
using TravelAgencyProject.Domain.Model;

namespace TravelAgencyProject.View
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : Window
    {
        private LoginService loginService = new LoginService();
        public LoginView()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            UserType userType = loginService.Login(new UserDTO(usernameBox.Text, passwordBox.Password));

            if(userType.Equals(UserType.Owner))
            {
                OwnerHome ownerHome = new OwnerHome();
                ownerHome.Show();
                this.Close();
            }

            if (userType.Equals(UserType.TourGuide))
            {
                TourGuideToursView tourGuideToursView = new TourGuideToursView();
                tourGuideToursView.Show();
                this.Close();
            }

            if (userType.Equals(UserType.TourGuest))
            { 
                TourGuestHome tourGuest = new TourGuestHome();
                tourGuest.Show();
                this.Close();
            }

            if (userType.Equals(UserType.AccommodationGuest))
            {
                AccommodationGuestHomeView accommodationGuestHomeView = new AccommodationGuestHomeView();
                accommodationGuestHomeView.Show();
                this.Close();
            }
        }
    }
}
