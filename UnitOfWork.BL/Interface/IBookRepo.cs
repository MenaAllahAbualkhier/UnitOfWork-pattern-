using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork.DAL.Entity;

namespace UnitOfWork.BL.Interface
{
    public interface IBookRepo:IBaseRepo<Book>
    {
        IEnumerable<Book> test();
    }
}
