using BookStore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore
{
    internal class Book
    {
        [Key]
        public int Id { get; set; } 
        public string NameBook { get; set; }    
        public string NamePublishing { get; set; }
        public int ID_Authors{ get; set; }
        [ForeignKey("ID_Authors")]
        public Author Authors { get; set; }
        public float Money { get; set; }    
        public DateTime Created { get; set; }
        public int  Pages { get; set; }
        public int CoutSalery { get; set; }
        public ICollection<UserBook> UserBooks { get; set; }
     
        public Book()
        {
            UserBooks = new List<UserBook>();
        }
    }

  
    class Author
    {
        [Key]
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; } 
        public Author()
        {
       
        }
    }
    internal class UserBook
    {
        [Key]
        public int ID { get; set; }

        public int UserID { get; set; }
        [ForeignKey("UserID")]
        public User User { get; set; }

        public int BookID { get; set; }
        [ForeignKey("BookID")]
        public Book Book { get; set; }
    }
    internal class User
{
    [Key]
    public int ID { get; set; }
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public string MiddleName { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
    public ICollection<UserBook> UserBooks { get; set; }

    public User()
    {
        UserBooks = new List<UserBook>();
    }
}

   

class StoreBookDB : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<UserBook> UserBooks { get; set; }
        public DbSet<User> Users { get; set; }
      

        public StoreBookDB()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-HTRTTSR\SQLEXPRESS;Initial Catalog=BookStore;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
    }
}
