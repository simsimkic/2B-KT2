using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using TravelAgencyProject.Applications.Util;
using TravelAgencyProject.Domain.Model;

namespace TravelAgencyProject.View
{
    /// <summary>
    /// Interaction logic for TourGuideProfile.xaml
    /// </summary>
    public partial class TourGuideProfileView : Window
    {
        private TourGuideReviewController tourGuideReviewController { get; }
        public TourGuideDTO LoggedTourGuideDTO { get; }

        public ObservableCollection<TourGuideReviewDTO> TourGuideReviews { get; }
        public TourGuideProfileView()
        {
            InitializeComponent();
            LoggedTourGuideDTO = new TourGuideDTO(UserSession.User);
            tourGuideReviewController = new TourGuideReviewController();
            TourGuideReviews = new ObservableCollection<TourGuideReviewDTO>(tourGuideReviewController.GetAllDTOs());
            myReviews.ItemsSource = TourGuideReviews;
            myStackPanel.DataContext = LoggedTourGuideDTO;
        }

        private void LogOut_Click(object sender, RoutedEventArgs e)
        {
            LoginView loginView = new LoginView();
            this.Close();
            loginView.Show();
            UserSession.User = null;
        }
        private void allTodaysTour_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            TourGuideToursView tourGuideToursView = new TourGuideToursView();
            this.Close();
            tourGuideToursView.Show();
        }

        private void tourStatistics_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            TourGuideTourStatistics tourGuideTourStatistics = new TourGuideTourStatistics();
            this.Close();
            tourGuideTourStatistics.Show();
        }

        private void reportReviewButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = myReviews.SelectedItem; 

            var selectedDataItem = selectedItem as TourGuideReviewDTO;


            if (selectedDataItem != null)
            {

                var selectedElement = myReviews.ItemContainerGenerator.ContainerFromItem(selectedDataItem) as ListViewItem;
                if (selectedElement != null)
                {
                    selectedElement.IsEnabled = false; 
                }
            }
        }
    }
}
