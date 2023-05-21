using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IGenericDal<T> where T : class
    {
        public void Add(T t);
        public void Delete(T t);
        public void Update(T t);
        List<T> GetAll();
        T GetById(int id);
    }
}
