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
    /// Interaction logic for TourGuestReservationsView.xaml
    /// </summary>
    public partial class TourGuestReservationsView : Window
    {
        TourAttendanceController tourAttendanceController = new TourAttendanceController();


        public TourGuestReservationsView()
        {
            InitializeComponent();

            List<TourAttendance> attendancesFromStartedTours = tourAttendanceController.GetAttendancesFromStartedTours(UserSession.User.Id);

            listBox.ItemsSource = attendancesFromStartedTours;

            

        }

        private void TourGuestReservations_Loaded(object sender, RoutedEventArgs e)
        {
            PendingAttendances();
            
        }


        public void PendingAttendances()
        {
            List<TourAttendance> attendancesFromStartedTours = tourAttendanceController.GetAttendancesFromStartedTours(UserSession.User.Id);

            foreach (TourAttendance tourAttendance in attendancesFromStartedTours)
            {
                if(tourAttendance.IsPresent == true && tourAttendance.IsConfirmed == false)
                {
                    AcceptTourAttendanceView acceptTourAttendanceView = new AcceptTourAttendanceView(tourAttendance);
                    acceptTourAttendanceView.Show();
                }
            }
        }
    }
}
