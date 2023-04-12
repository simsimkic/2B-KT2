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
    /// Interaction logic for TourReviewView.xaml
    /// </summary>
    public partial class TourGuideReviewView : Window
    {

        TourAttendance attendance = new TourAttendance();


        public TourGuideReviewView(TourAttendance tourAttendance)
        {
            InitializeComponent();
            attendance = tourAttendance;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TourGuideReviewController tourGuideReviewController = new TourGuideReviewController();
            TourGuideReview tourGuideReview = new TourGuideReview((int)knowledgeSlider.Value, (int)languageSlider.Value, (int)interestingnessSlider.Value,commentTextBox.Text, commentTextBox.Text, attendance.TourArrangementId, UserSession.User.Id);
            tourGuideReviewController.Save(tourGuideReview);
            
           
            MessageBox.Show("Review successful");
            this.Close();

        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
