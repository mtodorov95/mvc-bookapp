using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Data
{
    public class BookStoreContext : DbContext
    {

        public BookStoreContext(DbContextOptions<BookStoreContext> options)
            : base(options)
        {

        }

        // Entity class - corresponds to a table in the DB
        public DbSet<Books> Books { get; set; }

    }
}
