using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencyProject.Domain.Model;
using TravelAgencyProject.Resources.DBAcces;

namespace TravelAgencyProject.Repository
{
    public class VoucherRepository
    {
        private List<Voucher> vouchers;
        private readonly IDataHandler<Voucher> voucherDataHandler;

        public VoucherRepository()
        {
            voucherDataHandler = new VoucherDataHandler();
            vouchers = voucherDataHandler.GetAll().ToList();
        }
        public List<Voucher> GetAll()
        {
            return vouchers;
        }

        public Voucher GetById(int id)
        {
            return vouchers.FirstOrDefault(voucher => voucher.Equals(id));
        }
        public List<Voucher> GetByTourId(int tourId)
        {
            return vouchers.Where(voucher => voucher.TourId == tourId).ToList();
        }

        public void Delete(Voucher voucher)
        {
            voucherDataHandler.Delete(voucher);
        }
        

        public Voucher Save(Voucher voucher)
        {

            vouchers.Add(voucher);
            return voucherDataHandler.SaveOneEntity(voucher);
        }
    }
}
