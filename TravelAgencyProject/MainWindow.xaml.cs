using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using TravelAgencyProject.Domain.Model;
using TravelAgencyProject.Repository;
using TravelAgencyProject.View;

namespace TravelAgencyProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<User> users = new List<User>();
        public MainWindow()
        {
            InitializeComponent();

            //CreateTourView createTourView = new CreateTourView();
            //CreateAccommodationView createAccommodationView = new CreateAccommodationView();
            //TourGuestHome tourGuestHome = new TourGuestHome();
            //ClientListView clientListView = new ClientListView();


            //createTourView.Show();
            //createAccommodationView.Show();
            //tourGuestHome.Show();
            //clientListView.Show();

            LoginView loginView = new LoginView();
            loginView.Show();
            listBox.ItemsSource = users;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            UserRepository userRepo = new UserRepository();

            users = userRepo.GetAll();
            

            listBox.ItemsSource = users;
            listBox.DisplayMemberPath = "PrintInfo";
            listBox.Items.Refresh();

        }
    }
}
