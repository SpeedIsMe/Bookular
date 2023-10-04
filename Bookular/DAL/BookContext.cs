using Bookular.Models;
using Microsoft.EntityFrameworkCore;

namespace Bookular.DAL;

public class BookContext : DbContext
{
    public BookContext()
    {
    }

    public BookContext(DbContextOptions options) : base(options)
    {
    }

    public virtual DbSet<Author> Authors { get; set; }

    public virtual DbSet<Book> Books { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Author>().HasKey(a => a.Id);
        modelBuilder.Entity<Book>().HasKey(a => a.Id);

        modelBuilder.Entity<Author>()
            .HasMany(c => c.Books)
            .WithOne(c => c.Author)
            .HasForeignKey(c => c.AuthorId)
            .OnDelete(DeleteBehavior.Cascade);

        var authors = new List<Author>
        {
            new()
            {
                Id = 1, FirstName = "Mark J.", LastName = "Price", Bio = "Has pricey books"
            },
            new()
            {
                Id = 2, FirstName = "Robert C.", LastName = "Martin",
                Bio = "Robert Cecil Martin (born 5 December 1952), colloquially called"
            },
            new()
            {
                Id = 3, FirstName = "Leo", LastName = "Tolstoy",
                Bio =
                    "Count Lev Nikolayevich Tolstoy, usually referred to in English as Leo Tolstoy, was a Russian writer who is regarded as one of the greatest authors of all time."
            },
            new()
            {
                Id = 4, FirstName = "F. Scott", LastName = "Fitzgerald",
                Bio =
                    "Francis Scott Key Fitzgerald was an American novelist, essayist, screenwriter, and short-story writer."
            },
            new()
            {
                Id = 5, FirstName = "Tess", LastName = "Gerritsen",
                Bio =
                    "Tess Gerritsen left a successful practice as an internist to raise her children and concentrate on her writing."
            },
            new()
            {
                Id = 6, FirstName = "Nicole", LastName = "Fox",
                Bio =
                    "Nicole Fox is the New York Times bestselling author of numerous historical romances."
            }
        };

        modelBuilder.Entity<Author>().Ignore(e => e.Books).HasData(authors);

        var books = new List<Book>
        {
            new()
            {
                Id = 55, Title = "War and Peace", AuthorId = 1,
                Description = "The epic tale of love and loss set during the war between Russia and France."
            },
            new()
            {
                Id = 66, Title = "The Catcher in the Rye", AuthorId = 2,
                Description = "Holden Caulfield's journey through New York City and the loss of his innocence."
            },
            new()
            {
                Id = 5757, Title = "Design patterns", AuthorId = 3,
                Description =
                    "The story of the mysteriously wealthy Jay Gatsby and his love for the beautiful Daisy Buchanan."
            },
            new()
            {
                Id = 322343, Title = "C# 11 and .NET 7 – Modern Cross-Platform", AuthorId = 4,
                Description =
                    "An accessible guide for beginner-to-intermediate programmers to concepts, real-world applications, and latest features of C# 11 and .NET 7."
            },
            new()
            {
                Id = 65433, Title = "C# 10 in a Nutshell", AuthorId = 4,
                Description =
                    "When you have questions about how to use C# 10, this highly acclaimed bestseller has precisely the answers you need. Uniquely organized around concepts and use cases, this updated sixth edition includes completely revised and updated information on all the new C# 10 language features."
            },
            new()
            {
                Id = 1, Title = "The Spy Coast: A Thriller", AuthorId = 5,
                Description =
                    "A retired CIA operative in small-town Maine tackles the ghosts of her past in this fresh take on the spy thriller from New York Times bestselling author Tess Gerritsen."
            },
            new()
            {
                Id = 2, Title = "Cruel Paradise", AuthorId = 6,
                Description =
                    "Jane Doe lives in the shadows under an assumed name. A once-promising anthropologist and an expert on shamanism, everyone thinks she’s dead. Or so she hopes."
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