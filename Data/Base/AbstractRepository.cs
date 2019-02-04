using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data.Base
{
    public abstract class AbstractRepository <T> 
    {
        private static List<T> storage = new List<T>();  //TODO: Replace for some persitent storage
        
        public void Add(T entity)
        {
            storage.Add(entity);
        }

        public void Delete(T entity)
        {
            storage.Remove(entity);
        }

        public IList<T> GetAll()
        {
            return storage;
        }
        
        public T GetSingle(Func<T, bool> criteria)
        {
            return storage.Where(criteria).SingleOrDefault();
        }

        public IList<T> GetList(Func<T, bool> criteria)
        {
            return storage.Where(criteria).ToList();
        }

        public void ClearStorage()
        {
            storage.Clear();
        }
    }
}
