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
    /// Interaction logic for TourGuestProfileView.xaml
    /// </summary>
    public partial class TourGuestProfileView : Window
    {
        List<Voucher> vouchers = new List<Voucher>();
        
        public TourGuestProfileView()
        {
            InitializeComponent();

            fullNameTextBlock.Text = UserSession.User.FirstName + " " + UserSession.User.LastName;
            usernameTextBlock.Text = UserSession.User.Username;
            datebirthTextBlock.Text = UserSession.User.BirthDate.ToString("MM/dd/yyyy HH:mm:ss");
            ageTextBlock.Text = UserSession.User.Age.ToString();

            VoucherController voucherController = new VoucherController();
            List<Voucher> allVouchers = voucherController.GetAll();

            foreach (Voucher voucher in allVouchers)
            {
                if (voucher.GuestId == UserSession.User.Id)
                    vouchers.Add(voucher);
            }

            listBox.ItemsSource = vouchers;


        }
    }
}
