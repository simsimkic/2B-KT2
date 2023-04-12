using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencyProject.Resources.DBAcces;
using TravelAgencyProject.Domain.Model;
using TravelAgencyProject.Repository;

namespace TravelAgencyProject.Applications.Services
{
    public class VoucherService
    {
        VoucherRepository voucherRepository = new VoucherRepository();

        public List<Voucher> GetAll()
        {
            return voucherRepository.GetAll();
        }

        public Voucher GetById(int id)
        {
            return voucherRepository.GetById(id);
        }

        public Voucher Save(Voucher voucher)
        {
            return voucherRepository.Save(voucher);
        }

        public void Use(Voucher voucher)
        {
            voucherRepository.Delete(voucher);
        }
    }
}
