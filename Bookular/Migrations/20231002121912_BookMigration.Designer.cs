﻿// <auto-generated />
using System;
using Bookular.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Bookular.Migrations
{
    [DbContext(typeof(BookContext))]
    [Migration("20231002121912_BookMigration")]
    partial class BookMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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
                            Title = "War and Peace"
                        },
                        new
                        {
                            Id = 66L,
                            AuthorId = 2L,
                            Description = "Holden Caulfield's journey through New York City and the loss of his innocence.",
                            Title = "The Catcher in the Rye"
                        },
                        new
                        {
                            Id = 5757L,
                            AuthorId = 3L,
                            Description = "The story of the mysteriously wealthy Jay Gatsby and his love for the beautiful Daisy Buchanan.",
                            Title = "Design patterns"
                        },
                        new
                        {
                            Id = 322343L,
                            AuthorId = 4L,
                            Description = "Count Lev Nikolayevich Tolstoy, usually referred to in English as Leo Tolstoy, was a Russian writer who is regarded as one of the greatest authors of all time.",
                            Title = "C# 11 and .NET 7 – Modern Cross-Platform"
                        },
                        new
                        {
                            Id = 65433L,
                            AuthorId = 4L,
                            Description = "The story of the mysteriously wealthy Jay Gatsby and his love for the beautiful Daisy Buchanan",
                            Title = "C# 10 in a Nutshell"
                        },
                        new
                        {
                            Id = 1L,
                            AuthorId = 1L,
                            Description = "Hamlet book",
                            Title = "Hamlet"
                        },
                        new
                        {
                            Id = 2L,
                            AuthorId = 1L,
                            Description = "King lear book",
                            Title = "King Lear"
                        },
                        new
                        {
                            Id = 3L,
                            AuthorId = 1L,
                            Description = "Othello book",
                            Title = "Othello"
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
