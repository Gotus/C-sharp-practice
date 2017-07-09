using NUnit.Framework;
using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Tests
{
    [TestFixture()]
    public class LibraryClass
    {
        private Library testLibrary;
        private Abonent[] someAbonents;
        private Book[] someBooks;

    [SetUp()]
        public void SetUp()
        {
            testLibrary = new Library();
            someAbonents = new Abonent[] {
                new Abonent("Gotus", "+79082203022"),
                new Abonent("Swifty", "+75396012605")
            };
            someBooks = new Book[] {

                new Book("Somebody", "Chaos", true),
                new Book("Author", "Method of mechanical theorems", false)
            };
            testLibrary.AddAbonentToLibrary(someAbonents[0]);
            testLibrary.AddAbonentToLibrary(someAbonents[1]);
            testLibrary.AddBookToLibrary(someBooks[0], 1);
            testLibrary.AddBookToLibrary(someBooks[1], 1);
        }

        [Test()]
        public void AddBookToLibraryTest()
        {
            Book anotherBook = new Book("Author4", "Name4", false);
            testLibrary.AddBookToLibrary(anotherBook, 1);
            Assert.Contains(anotherBook, testLibrary.GetAllBooksInLibrary());
        }

        [Test()]
        public void AddAbonentToLibraryTest()
        {
            Abonent newAbonent = new Abonent("qwerty", "95014459805");
            testLibrary.AddAbonentToLibrary(newAbonent);
            Assert.Contains(newAbonent, testLibrary.GetAllAbonents());
        }

        [Test()]
        public void GetAllBooksInLibraryTest()
        {
            foreach (Book book in someBooks)
            {
                Assert.Contains(book, testLibrary.GetAllBooksInLibrary());
            }
        }

        [Test()]
        public void GetCurrentBooksInLibraryTest()
        {
            Book book = new Book("Author7", "Name7", false);
            Dictionary<Book, int> books = new Dictionary<Book, int>();
            testLibrary.AddBookToLibrary(book, 10);
            testLibrary.GiveBookToAbonent(someAbonents[0], book);
            books = testLibrary.GetCurrentBooksInLibrary();
            Assert.AreEqual(9, books[book]);
        }

        [Test()]
        public void GetCurrentAbonentBooksTest()
        {
            Book book = new Book("Author5", "Name5", false);
            testLibrary.AddBookToLibrary(book, 1);
            Assert.IsTrue(testLibrary.GetAllBooksInLibrary().Contains(book));
        }

        [Test()]
        public void FindBookTest()
        {
            Book book = new Book("Author4", "Name4", true);
            testLibrary.AddBookToLibrary(book, 1);
            Assert.AreEqual(book, testLibrary.FindBook("Author4", "author"));
            Assert.AreEqual(book, testLibrary.FindBook("Name4", "name"));
        }

        [Test()]
        public void GiveBookToAbonentTest()
        {
            testLibrary.GiveBookToAbonent(someAbonents[0], someBooks[0]);
            Assert.IsFalse(testLibrary.GetCurrentBooksInLibrary().ContainsKey(someBooks[0]));
            Assert.AreEqual(1, someAbonents[0].GetEarnedBooks().Count);
        }

        [Test()]
        public void ReturnBookTest()
        {
            testLibrary.GiveBookToAbonent(someAbonents[0], someBooks[0]);
            testLibrary.ReturnBook(someAbonents[0], someBooks[0]);
            Assert.IsTrue(testLibrary.GetCurrentBooksInLibrary().ContainsKey(someBooks[0]));
            Assert.AreEqual(0, someAbonents[0].GetEarnedBooks().Count);
        }
    }
}