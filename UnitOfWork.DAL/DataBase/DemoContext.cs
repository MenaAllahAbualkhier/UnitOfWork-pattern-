using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork.DAL.Entity;

namespace UnitOfWork.DAL.DataBase
{
    public class DemoContext:DbContext
    {
        public DemoContext(DbContextOptions<DemoContext> opt) : base(opt)
        {

        }
        public DbSet<Author> Author { get; set; }
        public DbSet<Book> Book { get; set; }

    }
}
