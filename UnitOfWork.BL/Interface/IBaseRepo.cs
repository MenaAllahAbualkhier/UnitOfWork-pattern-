using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace UnitOfWork.BL.Interface
{
    public interface IBaseRepo<T> where T : class
    {
        T GetById(int id);
        IEnumerable<T> GetAll();
        T Find(Expression<Func<T,bool>>match,string ?include=null);
        IEnumerable<T> FindAll(Expression<Func<T, bool>> match, string? include = null);
        T Add(T model);
        IEnumerable<T> AddRange(IEnumerable<T> models);
        void Delete(T model);
        void DeleteRange(IEnumerable<T> models);
        
        T Update(T model);
        int Count(Expression<Func<T,bool>>?match=null);   
        


    }
}
