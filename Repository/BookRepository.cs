using BookStore.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore
{
    public class BookRepository
    {
        private readonly BookStoreContext _context = null;

        public BookRepository(BookStoreContext context)
        {
            _context = context;
        }
        public async Task<List<BookModel>> GetAllBooks()
        {
            var books = new List<BookModel>();
            var allbooks = await _context.Books.ToListAsync();
            if (allbooks?.Any() == true)
            {
                foreach (var book in allbooks)
                {
                    books.Add(new BookModel() { 
                        Author = book.Author,
                        Category=book.Category,
                        Description=book.Description,
                        id=book.id,
                        Language=book.Language,
                        Title=book.Title,
                        Pages=book.Pages
                    });
                }
            }
            return books;
        }

        public async Task<BookModel> GetBook(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book != null)
            {
                var bookDetails = new BookModel() {
                    Author = book.Author,
                    Category = book.Category,
                    Description = book.Description,
                    id = book.id,
                    Language = book.Language,
                    Title = book.Title,
                    Pages = book.Pages
                };
                return bookDetails;
            }
            return null;
        }

        public async Task<int> AddBook(BookModel model)
        {
            var newBook = new Books()
            {
                Title = model.Title,
                Author = model.Author,
                Pages = model.Pages,
                CreatedOn = DateTime.UtcNow,
                Description = model.Description,
                UpdatedOn=DateTime.UtcNow
            };

            await _context.Books.AddAsync(newBook);
            await _context.SaveChangesAsync();
            return newBook.id;
        }

        public List<BookModel> SearchBooks(string title, string author)
        {
            return DataSource().FindAll(x => x.Title.Contains(title) && x.Author.Contains(author));
        }

        // Dummy data
        private List<BookModel> DataSource()
        {
            return new List<BookModel>(){
                new BookModel(){id=1, Title="Book1", Author="Author1", Description="Book description 1", Category="Action", Language= "English", Pages=823},
                new BookModel(){id=2, Title="Book2", Author="Author2", Description="Book description 2", Category="Programing", Language= "English", Pages=546},
                new BookModel(){id=3, Title="Book3", Author="Author3", Description="Book description 3", Category="Mystery", Language= "English", Pages=345},
                new BookModel(){id=4, Title="Book4", Author="Author4", Description="Book description 4", Category="Programing", Language= "English", Pages=1023},
                new BookModel(){id=5, Title="Book5", Author="Author5", Description="Book description 5", Category="Programing", Language= "English", Pages=768},
            };
        }
    }
}