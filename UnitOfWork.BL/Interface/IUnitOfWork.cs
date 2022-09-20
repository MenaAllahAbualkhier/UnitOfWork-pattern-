using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork.DAL.Entity;

namespace UnitOfWork.BL.Interface
{
    public interface IUnitOfWork:IDisposable
    {
        IBookRepo Book { get; }
        IBaseRepo<Author> Author { get; }
        int Complete();
    }
}
