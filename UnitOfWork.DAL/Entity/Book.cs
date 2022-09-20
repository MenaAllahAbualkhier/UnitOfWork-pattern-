using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitOfWork.DAL.Entity
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Author Author { get; set; }
        public int AuthorId { get; set; }
    }
}
