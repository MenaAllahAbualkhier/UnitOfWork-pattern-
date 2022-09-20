using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitOfWork.DAL.Entity
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Collection<Book>Book{ get; set; }
    }
}
