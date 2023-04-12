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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TravelAgencyProject.Applications.Controller;
using TravelAgencyProject.Applications.DTOs;
using TravelAgencyProject.Applications.Services;
using TravelAgencyProject.Domain.Model;
using TravelAgencyProject.View;

namespace TravelAgencyProject
{
    /// <summary>
    /// Interaction logic for CreateTourView.xaml
    /// </summary>
    public partial class CreateTourView : Window
    {
        private CreateTourDTO createTourDto;
        private TourController tourController;

        public CreateTourView()
        {
            InitializeComponent();
            inputDate.DisplayDateStart = DateTime.Today; 
        }

        private void checkPointData_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                checkPointsComboBox.Items.Add(checkPointData.Text);
            }
        }

        private void imageData_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                imagesComboBox.Items.Add(imageData.Text);
            }
        }

        private void CreateTourButton_Click(object sender, RoutedEventArgs e)
        {
            tourController = new TourController();

            int maxNumberOfGuests = NumberValidation(txtMaxNumberOfGuests.Text);
            int duration = NumberValidation(txtDuration.Text);

            createTourDto = new CreateTourDTO(
                txtName.Text, txtCity.Text, txtState.Text, txtDescription.Text, txtLanguage.Text, maxNumberOfGuests, checkPointsComboBox.Items.Cast<string>().ToList(), inputDate.Text, txtTime.Text, duration, imagesComboBox.Items.Cast<string>().ToList());

            tourController.Create(createTourDto);

            MessageBox.Show("Successfully created tour!");
        }

        private int NumberValidation(string inputText)
        {        
            if(!int.TryParse(inputText, out var validNumber))
            {
                throw new Exception("Input must be a valid number.");
            }

            return validNumber;
        }

        private void AllTodaysTour_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            TourGuideToursView tourGuideToursView = new TourGuideToursView();
            this.Close();
            tourGuideToursView.Show();
        }

    }
}
