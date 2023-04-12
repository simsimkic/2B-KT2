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
    /// Interaction logic for OwnerProfileView.xaml
    /// </summary>
    public partial class OwnerProfileView : Window
    {
        UserController userController = new UserController();
        public OwnerProfileView()
        {
            InitializeComponent();
            LoadOwnerProfile();
        }

        private void LoadOwnerProfile()
        {
            Owner owner = new Owner();
            owner = (Owner)userController.GetById(UserSession.User.Id);
            usernameTextBlock.Text = owner.Username;
            firstNameTextBlock.Text = owner.FirstName;
            lastNameTextBlock.Text = owner.LastName;
            genderTextBlock.Text = owner.Gender.ToString();
            birthDateTextBlock.Text = owner.BirthDate.ToString("dd/MM/yyyy");
            ageTextBlock.Text = owner.Age.ToString();
            statusTextBlock.Text = owner.Status.ToString();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            OwnerHome ownerHome = new OwnerHome();
            ownerHome.Show();
            this.Close();
        }
    }
}
