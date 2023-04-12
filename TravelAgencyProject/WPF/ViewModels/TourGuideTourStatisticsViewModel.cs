using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using TravelAgencyProject.Applications.Controller;
using TravelAgencyProject.Applications.DTOs;
using TravelAgencyProject.Applications.Util;
using TravelAgencyProject.Domain.Model;

namespace TravelAgencyProject.WPF.ViewModels
{
    public class TourGuideTourStatisticsViewModel : INotifyPropertyChanged
    {
        private readonly TourArrangementController tourArrangementController;

        private TourGuestStatisticsDTO _guestStatistics;
        public TourGuestStatisticsDTO GuestStatistics
        {
            get { return _guestStatistics; }
            set
            {
                _guestStatistics = value;
                OnPropertyChanged(nameof(GuestStatistics));
            }
        }

        private string _selectedYear;
        public string SelectedYear
        {
            get { return _selectedYear; }
            set
            {
                _selectedYear = value;
                OnPropertyChanged(nameof(SelectedYear));
                OnSelectedYearChanged();
            }
        }

        private TourStatisticsDTO _mostVisitedTour;

        public TourStatisticsDTO MostVisitedTour
        {
            get { return _mostVisitedTour; }
            set
            {
                if (_mostVisitedTour != value)
                {
                    _mostVisitedTour = value;
                    OnPropertyChanged(nameof(MostVisitedTour));
                }
            }
        }

        private TourArrangement _selectedTour;

        public TourArrangement SelectedTour
        {
            get { return _selectedTour; }
            set
            {
                if (_selectedTour != value)
                {
                    _selectedTour = value;
                    OnPropertyChanged(nameof(SelectedTour));
                    OnSelectedTourChanged();
                }
            }
        }

        private List<TourArrangement> _tours;

        public List<TourArrangement> Tours
        {
            get { return _tours; }
            set
            {
                if (_tours != value)
                {
                    _tours = value;
                    OnPropertyChanged(nameof(Tours));
                }
            }
        }

        public TourGuestStatisticsDTO tourGuestStatisticsDTO { get; set; }
        public ObservableCollection<string> ImageUrls { get; set; }

        private List<string> _years;
        public List<string> Years
        {
            get { return _years; }
            set
            {
                _years = value;
                OnPropertyChanged(nameof(Years));
            }
        }

        public TourGuideTourStatisticsViewModel()
        {
            tourArrangementController = (TourArrangementController)App.Services.GetService(typeof(TourArrangementController));
            Tours = tourArrangementController.GetFinishedTours().Where(tour => tour.TourGuideId == UserSession.User.Id).ToList();
            SelectedTour = Tours[0];

            GuestStatistics = tourArrangementController.GetTourGuestStatistics(SelectedTour.TourId);
            Years = tourArrangementController.GetYearsFromTourDates();
            Years.Insert(0, "All time");
            SelectedYear = "All time";

            MostVisitedTour = new TourStatisticsDTO(tourArrangementController.GetMostVisitedTour(SelectedYear));
        }

        private void OnSelectedYearChanged()
        {
            MostVisitedTour = new TourStatisticsDTO(tourArrangementController.GetMostVisitedTour(SelectedYear));
        }

        private void OnSelectedTourChanged()
        {
            GuestStatistics = tourArrangementController.GetTourGuestStatistics(SelectedTour.TourId);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
