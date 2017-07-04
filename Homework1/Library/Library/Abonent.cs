using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Abonent
    {
        private String name;
        private String phone;
        private List<BookData> earnedBooks;

        public Abonent(String name, String phone)
        {
            this.name = name;
            this.phone = phone;
            this.earnedBooks = new List<BookData>();
        }

        public String GetName()
        {
            return name;
        }

        public String GetPhone()
        {
            return phone;
        }

        public List<BookData> GetEarnedBooks()
        {
            return earnedBooks;
        }

        public List<BookData> GetOldBooks()
        {
            List<BookData> oldBooks = new List<BookData>();
            for (int i = 0; i < earnedBooks.Count; i++)
            {
                if ((DateTime.Now - earnedBooks.ElementAt(i).DateOfEarning).Days > 14)
                {
                    oldBooks.Add(earnedBooks.ElementAt(i));
                }
            }
            return oldBooks;
        }

    }
}
