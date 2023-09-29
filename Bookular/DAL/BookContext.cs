﻿using Bookular.Models;
using Microsoft.EntityFrameworkCore;

namespace Bookular.DAL
{
    public class BookContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }

        public DbSet<Book> Books { get; set; }

        public BookContext()
        {
        }

        public BookContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>()
                .HasMany(e => e.Books)
                .WithOne(e => e.Author)
                .HasForeignKey(e => e.AuthorId)
                .IsRequired();

            var authors = new List<Author>() {
                new Author { Id = 1, FirstName = "Mark J.", LastName = "Price", Bio = "Has pricey books" },
                new Author { Id = 2, FirstName = "Robert C.", LastName = "Martin", Bio = "Robert Cecil Martin (born 5 December 1952), colloquially called" },
                new Author { Id = 3, FirstName = "Leo", LastName = "Tolstoy", Bio = "Count Lev Nikolayevich Tolstoy, usually referred to in English as Leo Tolstoy, was a Russian writer who is regarded as one of the greatest authors of all time." },
                new Author { Id = 4, FirstName = "J.D.", LastName = "Salinger", Bio = "Jerome David Salinger was an American writer best known for his novel The Catcher in the Rye." },
                new Author { Id = 5, FirstName = "F. Scott", LastName = "Fitzgerald", Bio = "Francis Scott Key Fitzgerald was an American novelist, essayist, screenwriter, and short-story writer." }
            };

            modelBuilder.Entity<Author>().HasData(authors);

            var books = new List<Book>() {
               new Book() { Id = 55, Title = "War and Peace", AuthorId = 1, Description = "The epic tale of love and loss set during the war between Russia and France.", AuthorName = "" },
               new Book() { Id = 66, Title = "The Catcher in the Rye", AuthorId = 2, Description = "Holden Caulfield's journey through New York City and the loss of his innocence.", AuthorName = "" },
               new Book() { Id = 5757, Title = "Design patterns", AuthorId = 3, Description = "The story of the mysteriously wealthy Jay Gatsby and his love for the beautiful Daisy Buchanan.", AuthorName = "" },
               new Book() { Id = 322343, Title = "C# 11 and .NET 7 – Modern Cross-Platform", AuthorId = 4, Description = "Count Lev Nikolayevich Tolstoy, usually referred to in English as Leo Tolstoy, was a Russian writer who is regarded as one of the greatest authors of all time.", AuthorName = "" },
               new Book() { Id = 65433, Title = "C# 10 in a Nutshell", AuthorId = 5, Description = "The story of the mysteriously wealthy Jay Gatsby and his love for the beautiful Daisy Buchanan", AuthorName = "" }
            };

            for (int i = 1; i <= authors.Count; i++)
            {
                if (books[i - 1].AuthorId == i)
                {
                    books[i - 1].AuthorName = $"{authors[i - 1].FirstName} {authors[i - 1].LastName}";
                }
            }

            modelBuilder.Entity<Book>().HasData(books);

            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
