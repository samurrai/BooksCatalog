namespace BooksCatalaog
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class BooksContext : DbContext
    {
        
        public BooksContext()
            : base("name=BooksContext")
        {
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }
        public Administrator Administrator { get; set; } = new Administrator { Login = "admin", Password = "admin"};
    }
}