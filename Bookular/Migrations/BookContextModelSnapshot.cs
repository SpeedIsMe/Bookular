﻿// <auto-generated />
using System;
using Bookular.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Bookular.Migrations
{
    [DbContext(typeof(BookContext))]
    partial class BookContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Bookular.Models.Author", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Bio")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Authors");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Bio = "Has pricey books",
                            FirstName = "Mark J.",
                            LastName = "Price"
                        },
                        new
                        {
                            Id = 2L,
                            Bio = "Robert Cecil Martin (born 5 December 1952), colloquially called",
                            FirstName = "Robert C.",
                            LastName = "Martin"
                        },
                        new
                        {
                            Id = 3L,
                            Bio = "Count Lev Nikolayevich Tolstoy, usually referred to in English as Leo Tolstoy, was a Russian writer who is regarded as one of the greatest authors of all time.",
                            FirstName = "Leo",
                            LastName = "Tolstoy"
                        },
                        new
                        {
                            Id = 4L,
                            Bio = "Francis Scott Key Fitzgerald was an American novelist, essayist, screenwriter, and short-story writer.",
                            FirstName = "F. Scott",
                            LastName = "Fitzgerald"
                        },
                        new
                        {
                            Id = 5L,
                            Bio = "Tess Gerritsen left a successful practice as an internist to raise her children and concentrate on her writing.",
                            FirstName = "Tess",
                            LastName = "Gerritsen"
                        },
                        new
                        {
                            Id = 6L,
                            Bio = "Nicole Fox is the New York Times bestselling author of numerous historical romances.",
                            FirstName = "Nicole",
                            LastName = "Fox"
                        });
                });

            modelBuilder.Entity("Bookular.Models.Book", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long?>("AuthorId")
                        .HasColumnType("bigint");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("Isbn")
                        .HasColumnType("bigint");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            Id = 55L,
                            AuthorId = 1L,
                            Description = "The epic tale of love and loss set during the war between Russia and France.",
                            Isbn = 9781435169876L,
                            Title = "War and Peace"
                        },
                        new
                        {
                            Id = 66L,
                            AuthorId = 2L,
                            Description = "Holden Caulfield's journey through New York City and the loss of his innocence.",
                            Isbn = 9780316769488L,
                            Title = "The Catcher in the Rye"
                        },
                        new
                        {
                            Id = 5757L,
                            AuthorId = 3L,
                            Description = "The story of the mysteriously wealthy Jay Gatsby and his love for the beautiful Daisy Buchanan.",
                            Isbn = 9780201633610L,
                            Title = "Design patterns"
                        },
                        new
                        {
                            Id = 322343L,
                            AuthorId = 4L,
                            Description = "An accessible guide for beginner-to-intermediate programmers to concepts, real-world applications, and latest features of C# 11 and .NET 7.",
                            Isbn = 9781484264143L,
                            Title = "C# 11 and .NET 7 – Modern Cross-Platform"
                        },
                        new
                        {
                            Id = 65433L,
                            AuthorId = 4L,
                            Description = "When you have questions about how to use C# 10, this highly acclaimed bestseller has precisely the answers you need. Uniquely organized around concepts and use cases, this updated sixth edition includes completely revised and updated information on all the new C# 10 language features.",
                            Isbn = 9781492081138L,
                            Title = "C# 10 in a Nutshell"
                        },
                        new
                        {
                            Id = 1L,
                            AuthorId = 5L,
                            Description = "A retired CIA operative in small-town Maine tackles the ghosts of her past in this fresh take on the spy thriller from New York Times bestselling author Tess Gerritsen.",
                            Isbn = 9781984824992L,
                            Title = "The Spy Coast: A Thriller"
                        },
                        new
                        {
                            Id = 2L,
                            AuthorId = 6L,
                            Description = "Jane Doe lives in the shadows under an assumed name. A once-promising anthropologist and an expert on shamanism, everyone thinks she’s dead. Or so she hopes.",
                            Isbn = 9780593197469L,
                            Title = "Cruel Paradise"
                        });
                });

            modelBuilder.Entity("Bookular.Models.Book", b =>
                {
                    b.HasOne("Bookular.Models.Author", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId");

                    b.Navigation("Author");
                });
#pragma warning restore 612, 618
        }
    }
}
