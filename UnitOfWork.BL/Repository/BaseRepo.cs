using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork.BL.Interface;
using UnitOfWork.DAL.DataBase;

namespace UnitOfWork.BL.Repository
{
    public class BaseRepo<T> : IBaseRepo<T> where T : class
    {
        private readonly DemoContext demo;

        public BaseRepo(DemoContext Demo)
        {
            demo = Demo;
        }

        public T Add(T model)
        {
            demo.Set<T>().Add(model);
            return model;
   
        }

        public IEnumerable<T> AddRange(IEnumerable<T> models)
        {
            demo.Set<T>().AddRange(models);
            return models;
        }

        public int Count(Expression<Func<T, bool>> ?match = null)
        {
            if (match == null)
            {
                return demo.Set<T>().Count();
            }
            else
            {
                return demo.Set<T>().Count(match);
            }
        }

        public void Delete(T model)
        {
            demo.Set<T>().Remove(model);
        }

        public void DeleteRange(IEnumerable<T> models)
        {
            demo.Set<T>().RemoveRange(models);

        }

        public T Find(Expression<Func<T, bool>> match, string? include = null)
        {
            if(include == null)
            {
                return demo.Set<T>().SingleOrDefault(match);
            }
            else
            {
                return demo.Set<T>().Include(include).SingleOrDefault(match);
            }
        }

        public IEnumerable<T> FindAll(Expression<Func<T, bool>> match, string ?include = null)
        {
            if (include == null)
            {
                return demo.Set<T>().Where(match);
            }
            else
            {
                return demo.Set<T>().Include(include).Where(match);
            }
        }

        public IEnumerable<T> GetAll()
        {
            return demo.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return demo.Set<T>().Find(id);
        }

        public T Update(T model)
        {
            demo.Set<T>().Update(model);
            return model;
        }
    }
}
