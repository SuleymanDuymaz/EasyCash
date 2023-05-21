using DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.EFCore
{
    public class EfGenericDal<T> : IGenericDal<T> where T : class
    {
        public void Add(T t)
        {
            using(Context context=new Context())
            {
                context.Add(t);
                context.SaveChanges();
            }
        }

        public void Delete(T t)
        {
            using(Context context=new Context())
            {
                context.Remove(t);
                context.SaveChanges();
            }
        }

        public List<T> GetAll()
        {
            using (Context context=new Context())
            {
                return context.Set<T>().ToList();
            }
        }

        public T GetById(int id)
        {
           using var context = new Context();
            return context.Set<T>().Find(id);
           
        }

        public void Update(T t)
        {
            using(Context context=new Context())
            {
                context.Update(t);
                context.SaveChanges();
            }
        }
    }
}
