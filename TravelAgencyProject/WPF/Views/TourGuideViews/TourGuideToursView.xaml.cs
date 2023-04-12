using Castle.Components.DictionaryAdapter.Xml;
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
using TravelAgencyProject.Domain.Model;
using TravelAgencyProject.Applications.DTOs;

namespace TravelAgencyProject.View
{
    /// <summary>
    /// Interaction logic for TourGuideToursView.xaml
    /// </summary>

    public partial class TourGuideToursView : Window
    {
        public List<TourArrangement> Tours { get; set; }

        public List<TourAttendance> TourAttendances { get; set; }

        public List<CheckPoint> CheckPoints { get; set; }
        public TourArrangement SelectedTour { get; set; }

        public CheckPoint SelectedCheckPoint { get; set; }

        public TourAttendance SelectedAttendance { get; set; }

        private readonly TourArrangementController tourArrangementController;

        private TourAttendanceController tourAttendanceController = new TourAttendanceController();

        private CheckPointController checkPointController = new CheckPointController();

        public TourGuideToursView()
        {
            InitializeComponent();
            tourArrangementController = (TourArrangementController)App.Services.GetService(typeof(TourArrangementController));
            CheckPointsStackPanel.Visibility = Visibility.Collapsed;
            AttendanceStackPanel.Visibility = Visibility.Collapsed;
            Tours = tourArrangementController.GetAll();

            toursGrid.ItemsSource = Tours;

        }

        public void StartTourButton_Click(object sender, RoutedEventArgs e)
        {
            SelectedTour = (TourArrangement)toursGrid.SelectedItem;

            if (SelectedTour.State.Equals(TourState.Finished))
            {
                MessageBox.Show("Tour already finished!");
                return;
            }

            if (SelectedTour.Tour.DateTime.Date != DateTime.Today)
            {
                MessageBox.Show("You can only start today tours!");
                return;
            }
            AttendanceStackPanel.Visibility = Visibility.Visible;
            CheckPointsStackPanel.Visibility = Visibility.Visible;

            SelectedTour.State = TourState.Started;
            tourArrangementController.Update(SelectedTour);

            InitializeCheckPoints();
            InitializeTourAttendances();
        }

        private void InitializeTourAttendances()
        {
            TourAttendances = SelectedTour.Attendances.ToList();
          
            guestInformationGrid.ItemsSource = TourAttendances;
        }

        private void InitializeCheckPoints()
        {
            CheckPoints = checkPointController.GetByTourId(SelectedTour.Id);

            SelectedCheckPoint = CheckPoints[0];
            SelectedCheckPoint.IsTagged = true;
            checkPointController.Update(SelectedCheckPoint);
            CheckPointsBoxZone.ItemsSource = CheckPoints;
        }

        private void IsActive_Checked(object sender, RoutedEventArgs e)
        {
            SelectedCheckPoint = (CheckPoint) ((CheckBox) sender).DataContext;
            ((CheckBox)sender).IsEnabled = false;
            SelectedCheckPoint.IsTagged = true;

            checkPointController.Update(SelectedCheckPoint);
            if (SelectedCheckPoint.Type.Equals(CheckPointType.End))
            {
                FinishTour();
            }
        }

        private void FinishTour()
        {
            SelectedTour.State = TourState.Finished;
            tourArrangementController.Update(SelectedTour);
            MessageBox.Show("Tour Finished!");

            AttendanceStackPanel.Visibility = Visibility.Collapsed;
            CheckPointsStackPanel.Visibility = Visibility.Collapsed;

            Tours.Remove(SelectedTour);
            toursGrid.ItemsSource = Tours;
            toursGrid.Items.Refresh();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            SelectedAttendance = (TourAttendance)((CheckBox)sender).DataContext;
            SelectedAttendance.CheckPointCoordinate = SelectedCheckPoint.Coordinates;
            SelectedAttendance.IsPresent = true;
            
            tourAttendanceController.ChangeCheckPointCoordinate(SelectedAttendance);
            
        }

        private void userProfile_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            TourGuideProfileView tourGuideProfileView = new TourGuideProfileView();
            this.Close();
            tourGuideProfileView.Show();
        }

        private void tourStatistics_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            TourGuideTourStatistics tourGuideTourStatistics = new TourGuideTourStatistics();
            this.Close();
            tourGuideTourStatistics.Show();
        }

        private void TodayTours_Click(object sender, RoutedEventArgs e)
        {
            toursGrid.ItemsSource = tourArrangementController.GetTodaysTours();
        }

        private void CancelTourButton_Click(object sender, RoutedEventArgs e)
        {
            SelectedTour = (TourArrangement)toursGrid.SelectedItem;
            TimeSpan timeRemaining = SelectedTour.Tour.DateTime - DateTime.Now;

            if(timeRemaining.TotalHours < 48)
            {
                MessageBox.Show("You can't cancel this tour!");
                return;
            } 
            tourArrangementController.CancelTour(SelectedTour);
            Tours.Remove(SelectedTour);
            toursGrid.Items.Refresh();
        }

        private void CreateTour_Click(object sender, RoutedEventArgs e)
        {
            CreateTourView createTourView = new CreateTourView();
            this.Close();
            createTourView.Show();
        }
    }
}
