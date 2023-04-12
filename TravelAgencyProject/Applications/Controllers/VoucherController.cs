using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencyProject.Applications.Services;
using TravelAgencyProject.Domain.Model;
using TravelAgencyProject.Repository;

namespace TravelAgencyProject.Applications.Controller
{
    public class VoucherController
    {
        VoucherService voucherService = new VoucherService();

        public List<Voucher> GetAll()
        {
            return voucherService.GetAll();
        }

        public Voucher GetById(int id)
        {
            return voucherService.GetById(id);
        }

        public Voucher Save(Voucher voucher)
        {
            return voucherService.Save(voucher);
        }

        public void Use(Voucher voucher)
        {
            voucherService.Use(voucher);
        }
    }
}
