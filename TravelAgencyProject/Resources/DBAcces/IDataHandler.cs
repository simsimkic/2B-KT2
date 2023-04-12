using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencyProject.Domain.Model;

namespace TravelAgencyProject.Resources.DBAcces
{
    public interface IDataHandler<T>
    {
        public IEnumerable<T> GetAll();
        public void Save(IEnumerable<T> entities);

        public T SaveOneEntity(T entity);

        public void Delete(T entity);
        public void Update(T entity);
    }
}
