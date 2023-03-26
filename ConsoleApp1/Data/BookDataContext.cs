using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Data
{
    public class BookDataContext : DbContext
    {
        public BookDataContext(DbContextOptions<BookDataContext> options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
    }


    public void InsertBook(Book book)
    {
        Books.Add(book);
        SaveChanges();
    }

    public void UpdateBook(Book book)
    {
        Books.Update(book);
        SaveChanges();
    }

    public Book GetBookById(int id)
    {
        return Books.Include(b => b.Publisher).FirstOrDefault(b => b.Id == id);
    }

    public IEnumerable<Book> GetAllBooks()
    {
        return Books.Include(b => b.Publisher).ToList();
    }
}
