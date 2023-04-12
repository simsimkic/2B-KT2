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
using TravelAgencyProject.Applications.Services;
using TravelAgencyProject.Applications.Util;
using TravelAgencyProject.Domain.Model;
using TravelAgencyProject.Repository;

namespace TravelAgencyProject.View
{
    /// <summary>
    /// Interaction logic for OwnerHome.xaml
    /// </summary>
    public partial class OwnerHome : Window
    {
        
        public OwnerHome()
        {
            AccommodationReservationRepository accommodationReservationRepository = new AccommodationReservationRepository();
            UserController userController = new UserController();
            InitializeComponent();
            List<AccommodationReservation> accommodationReservations = accommodationReservationRepository.GetAll();
            List<Owner> owners = new List<Owner>();
            owners = userController.GetOwners();
            UpdateOwnersStatus(owners, userController);
            
            if (PendingReviewsNumber(accommodationReservations) > 0)
            {
                MessageBox.Show("You have " + PendingReviewsNumber(accommodationReservations) + " available guests to review.");
            }
            
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = (Button)sender;

            switch (clickedButton.Tag.ToString())
            {
                case "Functionality1Button":
                    CreateAccommodationView createAccommodationView = new CreateAccommodationView();
                    createAccommodationView.Show();
                    this.Close();
                    break;
                case "Functionality2Button":
                    ClientListView clientListView = new ClientListView();
                    clientListView.Show();
                    this.Close();
                    break;
                case "Functionality3Button":
                    OwnersReviewsView ownersReviewsView = new OwnersReviewsView();
                    ownersReviewsView.Show();
                    this.Close();
                    break;
                case "Functionality4Button":
                    RescheduleRequestsView rescheduleRequestsView = new RescheduleRequestsView();
                    rescheduleRequestsView.Show();
                    this.Close();
                    break;
                case "Functionality5Button":
                    OwnerProfileView ownerProfileView = new OwnerProfileView();
                    ownerProfileView.Show();
                    this.Close();
                    break;
                case "Functionality6Button":
                    AccommodationListView accommodationListView = new AccommodationListView();
                    accommodationListView.Show();
                    this.Close();
                    break;
                case "LogOutButton":
                    LoginView loginView = new LoginView();
                    this.Close();
                    loginView.Show();
                    UserSession.User = null;
                    break;
                default:
                    break;
            }
        }

        private int PendingReviewsNumber(List<AccommodationReservation> accommodationReservations)
        {
            AccommodationGuestReviewService accommodationGuestReviewService = new AccommodationGuestReviewService();
            int reviewsCounter = 0;

            foreach (AccommodationReservation accommodationReservation in accommodationReservations)
            {
                DateTime CheckoutDay = accommodationReservation.Date.AddDays(accommodationReservation.ReservedDayNumber);
                TimeSpan reviewDeadline = DateTime.Now - CheckoutDay;
                if (isReviewEligible(accommodationReservation, reviewDeadline, accommodationGuestReviewService))
                {
                    reviewsCounter++;
                }
            }
            return reviewsCounter;
        }

        public bool isReviewEligible(AccommodationReservation accommodationReservation, TimeSpan reviewDeadline, AccommodationGuestReviewService accommodationGuestReviewService)
        {
            bool isOwner = accommodationReservation.Accommodation.OwnerId == UserSession.User.Id;
            bool withinReviewPeriod = reviewDeadline.TotalDays < 5 && reviewDeadline.TotalDays > 0;
            bool notReviewed = !accommodationGuestReviewService.IsReviewed(UserSession.User.Id, accommodationReservation.Guest.Id);

            return isOwner && withinReviewPeriod && notReviewed;
        }

        private bool IsSuperOwner(Owner owner)
        {
            OwnerReviewController ownerReviewController = new OwnerReviewController();
            List<OwnerReview> ownerReviews = ownerReviewController.GetByOwnerId(owner.Id);
            int reviewNumber = ownerReviews.Count();
            if (reviewNumber < 5) //Za sad sam za granicu uzeo 5 umesto 50 ocena
                return false;
            int sumOfReviews = 0;
            foreach( OwnerReview ownerReview in ownerReviews )
                sumOfReviews += ownerReview.Cleanness + ownerReview.OwnerFairness;
            if(sumOfReviews / (double)reviewNumber < 9.5)
                return false;
            return true;
        }

        private void UpdateOwnersStatus(List<Owner> owners, UserController userController)
        {
            foreach(Owner owner in owners)
            {
                Status newStatus = IsSuperOwner(owner) ? Status.Super : Status.Regular;
                if (newStatus != owner.Status)
                {
                    owner.Status = newStatus;
                    userController.Update(owner);
                }
            }
        }

        
    }
}
