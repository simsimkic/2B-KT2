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
using TravelAgencyProject.WPF.ViewModels;

namespace TravelAgencyProject.View
{
    /// <summary>
    /// Interaction logic for TourGuideTourStatistics.xaml
    /// </summary>
    public partial class TourGuideTourStatistics : Window
    {
        private TourGuideTourStatisticsViewModel viewModel;

        public TourGuideTourStatistics()
        {
            InitializeComponent();
            viewModel = new TourGuideTourStatisticsViewModel();
            DataContext = viewModel;

        }

        private void userProfile_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            TourGuideProfileView tourGuideProfileView = new TourGuideProfileView();
            this.Close();
            tourGuideProfileView.Show();
        }

        private void allTodaysTour_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            TourGuideToursView tourGuideToursView = new TourGuideToursView();
            this.Close();
            tourGuideToursView.Show();
        }
    }
}
