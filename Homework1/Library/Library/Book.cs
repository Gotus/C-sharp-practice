using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Book
    {

        public String Author { get; private set; }
        public String Name { get; private set; }
        public bool IsRare { get; private set; }


        public Book(String author, String name, bool isRare)
        {
            this.Author = author;
            this.Name = name;
            this.IsRare = isRare;
        }

        public bool IsEarned(Library library)
        {
            return library.GetEarnedBooks().ContainsKey(this);
        }
    }
}
