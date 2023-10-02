using Bookular.Models;
using Microsoft.EntityFrameworkCore;

namespace Bookular.DAL
{
    public class BookContext : DbContext
    {
        public DbSet<Author> Authors
        {
            get;
            set;
        }

        public DbSet<Book> Books
        {
            get;
            set;
        }

        public BookContext() { }

        public BookContext(DbContextOptions options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>().HasKey(a => a.Id);
            modelBuilder.Entity<Book>().HasKey(a => a.Id);

            modelBuilder.Entity<Author>()
               .HasMany(c => c.Books)
               .WithOne(c => c.Author)
               .HasForeignKey(c => c.AuthorId)
               .OnDelete(DeleteBehavior.Cascade);

            var authors = new List<Author>() {
            new Author {
               Id = 1, FirstName = "Mark J.", LastName = "Price", Bio = "Has pricey books",
            },
            new Author {
               Id = 2, FirstName = "Robert C.", LastName = "Martin", Bio = "Robert Cecil Martin (born 5 December 1952), colloquially called",
            },
            new Author {
               Id = 3, FirstName = "Leo", LastName = "Tolstoy", Bio = "Count Lev Nikolayevich Tolstoy, usually referred to in English as Leo Tolstoy, was a Russian writer who is regarded as one of the greatest authors of all time.",
            },
            new Author {
               Id = 4, FirstName = "F. Scott", LastName = "Fitzgerald", Bio = "Francis Scott Key Fitzgerald was an American novelist, essayist, screenwriter, and short-story writer.",
            }
         };

            modelBuilder.Entity<Author>().Ignore(e => e.Books).HasData(authors);

            var books = new List<Book>() {
            new Book() {
                  Id = 55, Title = "War and Peace", AuthorId = 1, Description = "The epic tale of love and loss set during the war between Russia and France."
               },
               new Book() {
                  Id = 66, Title = "The Catcher in the Rye", AuthorId = 2, Description = "Holden Caulfield's journey through New York City and the loss of his innocence."
               },
               new Book() {
                  Id = 5757, Title = "Design patterns", AuthorId = 3, Description = "The story of the mysteriously wealthy Jay Gatsby and his love for the beautiful Daisy Buchanan."
               },
               new Book() {
                  Id = 322343, Title = "C# 11 and .NET 7 – Modern Cross-Platform", AuthorId = 4, Description = "Count Lev Nikolayevich Tolstoy, usually referred to in English as Leo Tolstoy, was a Russian writer who is regarded as one of the greatest authors of all time."
               },
               new Book() {
                  Id = 65433, Title = "C# 10 in a Nutshell", AuthorId = 4, Description = "The story of the mysteriously wealthy Jay Gatsby and his love for the beautiful Daisy Buchanan"
               },
               new Book {
                  Id = 1, AuthorId = 1, Title = "Hamlet", Description = "Hamlet book"
               },
               new Book {
                  Id = 2, AuthorId = 1, Title = "King Lear", Description = "King lear book"
               },
               new Book {
                  Id = 3, AuthorId = 1, Title = "Othello", Description = "Othello book"
               }
         };

            modelBuilder.Entity<Book>().HasData(books);

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();

            base.OnConfiguring(optionsBuilder);
        }
    }
}