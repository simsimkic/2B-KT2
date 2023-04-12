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

namespace TravelAgencyProject.View
{
    /// <summary>
    /// Interaction logic for AccommodationGuestReviewView.xaml
    /// </summary>
    public partial class AccommodationGuestReviewView : Window
    {
        AccommodationGuest accommodationGuest = new AccommodationGuest();
        
        public AccommodationGuestReviewView(AccommodationGuest accommodationGuest)
        {
            InitializeComponent();
            this.accommodationGuest = accommodationGuest;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AccommodationGuestReviewController accommodationGuestReviewController = new AccommodationGuestReviewController();
            AccommodationGuestReview accommodationGuestReview = new AccommodationGuestReview((int)cleannessSlider.Value, (int)obeyingRulesSlider.Value, commentTextBox.Text, UserSession.User.Id, accommodationGuest.Id);
            accommodationGuestReviewController.Save(accommodationGuestReview);
            MessageBox.Show("Review successful");
            OwnerHome ownerHome = new OwnerHome();
            ownerHome.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ClientListView clientListView = new ClientListView();
            clientListView.Show();
            this.Close();
        }
    }
}
