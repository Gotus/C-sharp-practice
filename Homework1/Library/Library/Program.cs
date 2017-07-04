using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Library
{
    class Program
    {
        static void Main(string[] args)
        {
            Book myBook = new Book("Kirill", "Console log", true);
            Abonent anotherAbonent = new Abonent("Gotus", "+79082203022");
            Library lib = new Library();
            
            Console.Read();
        }
    }
}
