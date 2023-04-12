using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencyProject.Domain.Model;

namespace TravelAgencyProject.Resources.DBAcces
{
    public class VoucherDataHandler : IDataHandler<Voucher>
    {
        private DataContext dataContext = new DataContext();

        public void Delete(Voucher entity)
        {
            dataContext.Vouchers.Remove(entity);

            dataContext.SaveChanges();
        }

        public IEnumerable<Voucher> GetAll()
        {
            return dataContext.Vouchers.ToList();
        }

        public void Save(IEnumerable<Voucher> entities)
        {
            dataContext.Vouchers.AddRange(entities);

            dataContext.SaveChanges();
        }

        public Voucher SaveOneEntity(Voucher entity)
        {
            dataContext.Vouchers.Add(entity);

            dataContext.SaveChanges();

            return entity;
        }

        public void Update(Voucher entity)
        {
            throw new NotImplementedException();
        }
    }
}
