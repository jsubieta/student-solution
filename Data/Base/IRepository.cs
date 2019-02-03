using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data.Base
{
    public interface IRepository <T>  where T : class
    {
        void Add(T entity);
        void Delete(T entity);
        IList<T> GetAll();  
        T GetSingle(Func<T, bool> criteria);
        IList<T> GetList(Func<T, bool> criteria);
        void ClearStorage();
    }
}
