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
using TravelAgencyProject.Domain.Model;
using TravelAgencyProject.Applications.Services;

namespace TravelAgencyProject.View
{
    /// <summary>
    /// Interaction logic for AcceptTourAttendanceView.xaml
    /// </summary>
    public partial class AcceptTourAttendanceView : Window
    {
        TourAttendanceController tourAttendanceController = new TourAttendanceController();
        TourAttendance attendance = new TourAttendance();
        public AcceptTourAttendanceView(TourAttendance tourAttendance)
        {
            InitializeComponent();

            attendance = tourAttendance;
        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {

            attendance.IsConfirmed = true;
            tourAttendanceController.ChangeCheckPointCoordinate(attendance);
            this.Close();
        }
    }
}
