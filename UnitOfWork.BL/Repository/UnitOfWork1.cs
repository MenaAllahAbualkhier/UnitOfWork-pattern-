using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork.BL.Interface;
using UnitOfWork.DAL.DataBase;
using UnitOfWork.DAL.Entity;

namespace UnitOfWork.BL.Repository
{
    public class UnitOfWork1:IUnitOfWork
    {
        private readonly DemoContext demo;
        public IBookRepo Book { get; private set; }
        public IBaseRepo<Author> Author { get; private set; }

        public UnitOfWork1(DemoContext Demo)
        {
            demo = Demo;
            Book = new BookRepo(Demo);
            Author = new BaseRepo<Author>(Demo);
        }

        public int Complete()
        {
            return demo.SaveChanges();
        }
        public void Dispose()
        {
            demo.Dispose();
        }
    }
}
