using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Library
    {

        private List<Book> allBooksInLibrary = new List<Book>();
        private Dictionary<Book, int> currentBooksInLibrary = new Dictionary<Book, int>();
        private Dictionary<Book, int> currentBooksEarned = new Dictionary<Book, int>();
        private List<Abonent> allAbonents = new List<Abonent>();

        public void AddAbonentToLibrary(Abonent abonent)
        {
            allAbonents.Add(abonent);
        }

        public List<Abonent> GetAllAbonents()
        {
            return allAbonents;
        }
        
        public List<Book> GetAllBooksInLibrary()
        {
            return allBooksInLibrary;
        }

        public Dictionary<Book, int> GetEarnedBooks()
        {
            return currentBooksEarned;
        }

        public Dictionary<Book, int> GetCurrentBooksInLibrary()
        {
            return currentBooksInLibrary;
        }

        public void AddBookToLibrary(Book newBook, int numberOfBooks)
        {
            if (!allBooksInLibrary.Contains(newBook))
            {
                allBooksInLibrary.Add(newBook);
                currentBooksInLibrary.Add(newBook, numberOfBooks);
            }
            else
            {
                currentBooksInLibrary[newBook] = currentBooksInLibrary[newBook] + numberOfBooks;
            }
        }

        public Book FindBook(String fieldOfSearch, String nameOfField)
        {
            List<Book> allBooks = new List<Book>();
            allBooks = this.allBooksInLibrary;
            for (int i = 0; i < allBooks.Count; i++)
            {
                if ((nameOfField == "author") && (fieldOfSearch == allBooks[i].Author))
                {
                    return allBooks[i];
                }
                if ((nameOfField == "name") && (fieldOfSearch == allBooks[i].Name))
                {
                    return allBooks[i];
                }
            }
            return null;
        }

        public void GiveBookToAbonent(Abonent earner, Book earnedBook)
        {
           
            for (int i = 0; i < allAbonents.Count; i++)
            {
                if ((earner.GetName() == allAbonents[i].GetName()) && (earner.GetPhone() == allAbonents[i].GetPhone()))
                {
                    if (allAbonents[i].GetEarnedBooks().Count < 5)
                    {
                        int numOfBooks;
                        numOfBooks = allAbonents[i].GetEarnedBooks().Count;
                        for (int j = 0; i < numOfBooks; i++)
                        {
                            if ((allAbonents[i].GetEarnedBooks().ElementAt(j).DateOfEarning - DateTime.Now).Days > 14)
                            {
                                return;
                            }
                        }
                        BookData newBookData = new BookData(earnedBook, DateTime.Now);

                        allAbonents[i].GetEarnedBooks().Add(newBookData);
                        
                        if (currentBooksInLibrary[earnedBook] > 1)
                        {
                            currentBooksInLibrary[earnedBook] = currentBooksInLibrary[earnedBook] - 1;
                        }

                        if (currentBooksInLibrary[earnedBook] == 1)
                        {
                            currentBooksInLibrary.Remove(earnedBook);
                        }

                        if (currentBooksEarned.ContainsKey(earnedBook))
                        {
                            currentBooksEarned[earnedBook] = currentBooksEarned[earnedBook] + 1;
                        }
                        else
                        {
                            currentBooksEarned.Add(earnedBook, 1);
                        }

                        return;
                    }
                }
            }
        }

        public void ReturnBook(Abonent returner, Book book)
        {

            for (int i = 0; i < returner.GetEarnedBooks().Count; i++)
            {
                if ((book.Name == returner.GetEarnedBooks().ElementAt(i).Book.Name)
                    && (book.Author == returner.GetEarnedBooks().ElementAt(i).Book.Author))
                {
                    returner.GetEarnedBooks().RemoveAt(i);

                    if (currentBooksInLibrary.ContainsKey(book))
                    {
                        currentBooksInLibrary[book] = currentBooksInLibrary[book] + 1;
                    }
                    else
                    {
                        currentBooksInLibrary.Add(book, 1);
                    }

                    if (currentBooksEarned[book] > 1)
                    {
                        currentBooksEarned[book] = currentBooksEarned[book] - 1;
                    }
                    else
                    {
                        currentBooksEarned.Remove(book);
                    }
                }
            }
        }
    }
}
