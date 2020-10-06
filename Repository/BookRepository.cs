using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore
{
    public class BookRepository
    {
        public List<BookModel> GetAllBooks()
        {
            return DataSource();
        }

        public BookModel GetBook(int id)
        {
            return DataSource().Find(x => x.id == id);
        }

        public List<BookModel> SearchBooks(string title, string author)
        {
            return DataSource().FindAll(x => x.Title.Contains(title) && x.Author.Contains(author));
        }

        // Dummy data
        private List<BookModel> DataSource()
        {
            return new List<BookModel>(){
                new BookModel(){id=1, Title="Book1", Author="Author1"},
                new BookModel(){id=2, Title="Book2", Author="Author2"},
                new BookModel(){id=3, Title="Book3", Author="Author3"},
                new BookModel(){id=4, Title="Book4", Author="Author4"},
                new BookModel(){id=5, Title="Book5", Author="Author5"},
            };
        }
    }
}