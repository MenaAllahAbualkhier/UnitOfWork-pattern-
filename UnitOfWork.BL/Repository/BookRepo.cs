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
    public class BookRepo : BaseRepo<Book>, IBookRepo
    {
        private readonly DemoContext demo;

        public BookRepo(DemoContext Demo) : base(Demo)
        {
            demo = Demo;
        }

        public IEnumerable<Book> test()
        {
           return demo.Book.ToList();

        }
    }
}
