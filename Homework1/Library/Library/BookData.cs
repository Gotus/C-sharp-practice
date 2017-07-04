using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class BookData
    {
        public Book Book { get; private set; }
        public DateTime DateOfEarning { get; private set; }

        public BookData(Book book, DateTime dateOfEarning)
        {
            this.Book = book;
            this.DateOfEarning = DateTime.Now;
        }
    }
}
