using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http.Headers;
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
using TravelAgencyProject.Applications.DTOs;
using TravelAgencyProject.Applications.Services;

namespace TravelAgencyProject.View
{
    /// <summary>
    /// Interaction logic for TourReservationView.xaml
    /// </summary>
    public partial class TourReservationView : Window
    {
        Tour tour;
        TourController tourController = new TourController();
        TourArrangementController tourArrangementController;
        VoucherController voucherController = new VoucherController();
        List<Voucher> vouchers = new List<Voucher>();
        
        public Voucher selectedVoucher { get; set; }
        public TourReservationView(Tour bookedTour)
        {
            InitializeComponent();
            tourArrangementController = (TourArrangementController)App.Services.GetService(typeof(TourArrangementController));
            tour = bookedTour;
            this.DataContext = tour;
            List<Voucher> allVouchers = voucherController.GetAll();
            foreach (Voucher voucher in allVouchers)
            {
                if (voucher.GuestId == UserSession.User.Id)
                    vouchers.Add(voucher);
            }
            availableVouchers.ItemsSource = vouchers;

            

            Binding binding = new Binding("selectedVoucher")
            {
                Mode = BindingMode.TwoWay,
                Source = this
            };
            availableVouchers.SetBinding(ComboBox.SelectedValueProperty, binding);
            
        }

        private void BookingButton_Click(object sender, RoutedEventArgs e)
        {     
            bool isAssigned = tourArrangementController.IsUserAlreadyAssigned((UserSession.User).Id, tour.Id);
            
            if(isAssigned)
            {
                MessageBox.Show("Sorry. You have already made a reservation for this tour.");
            } 
            else
            {
                
                int reservation = tourArrangementController.CreateArrangement(new TourReservationDTO(tour.Id, Convert.ToInt32(GuestsNumberTextBox.Text)));
                
                if (reservation != -1)
                {
                    selectedVoucher = (Voucher)availableVouchers.SelectedItem;
                    MessageBox.Show("You booked a tour successfully. There are still " + reservation + " available seats.");

                    if(selectedVoucher != null)
                    {
                        voucherController.Use(selectedVoucher);
                        MessageBox.Show("You used the voucher " + selectedVoucher.Name);
                    }
                        
                    

                }
                else
                {
                    MessageBox.Show("Error while booking a tour. Try again.");
                }
            }

            
        }

        private void RedirectingButton_Click(object sender, RoutedEventArgs e)
        {
            TourGuestHome tourGuestHome = new TourGuestHome();
            tourGuestHome.Show();
            this.Close();

        }
        



    }
}
