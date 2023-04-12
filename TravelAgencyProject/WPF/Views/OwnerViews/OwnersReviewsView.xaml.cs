using Microsoft.Identity.Client;
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
using TravelAgencyProject.Repository;

namespace TravelAgencyProject.View
{
    /// <summary>
    /// Interaction logic for OwnersReviewsView.xaml
    /// </summary>
    public partial class OwnersReviewsView : Window
    {
        List<OwnerReview> ownerReviews = new List<OwnerReview>();
        List<AccommodationGuestReview> accommodationGuestReviews = new List<AccommodationGuestReview>();

        public OwnersReviewsView()
        {
            InitializeComponent();
            OwnerReviewController ownerReviewController = new OwnerReviewController();
            AccommodationGuestReviewController accommodationGuestReviewController = new AccommodationGuestReviewController();
            List<OwnerReview> filteredOwnerReviews = new List<OwnerReview>();
            ownerReviews = ownerReviewController.GetByOwnerId(UserSession.User.Id);
            accommodationGuestReviews = accommodationGuestReviewController.GetByOwnerId(UserSession.User.Id);
            filteredOwnerReviews = FilterOwnerReviews(ownerReviews, accommodationGuestReviews);
            listBox.ItemsSource = filteredOwnerReviews;
        }

        private List<OwnerReview> FilterOwnerReviews(List<OwnerReview> ownerReviews, List<AccommodationGuestReview> accommodationGuestReviews)
        {
            List<OwnerReview> filteredOwnerReviews = new List<OwnerReview>();
            foreach(OwnerReview ownerReview in ownerReviews)
            {
                foreach(AccommodationGuestReview accommodationGuestReview in accommodationGuestReviews) 
                {
                    if (ownerReview.OwnerId == accommodationGuestReview.OwnerId && ownerReview.AccommodationGuestId == accommodationGuestReview.AccommodationGuestId)
                    {
                        filteredOwnerReviews.Add(ownerReview);
                        break;
                    }
                    
                }
            }
            return filteredOwnerReviews;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            OwnerHome ownerHome = new OwnerHome();
            ownerHome.Show();
            this.Close();
        }
    }
}
