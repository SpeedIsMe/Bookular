using Bookular.DAL.Repositories;
using Bookular.DAL;
using Bookular.Models;
using Microsoft.EntityFrameworkCore;
using Moq;
using FluentAssertions;


namespace BookularTest
{
    [TestFixture]
    public class BookRepositoryTests
    {
        private Mock<DbSet<Book>> _mockSet;
        private Mock<BookContext> _mockContext;
        private BookRepository _repository;

        [SetUp]
        public void SetUp()
        {
            var data = new List<Book>
            {
                new Book { Id = 1, Title = "Book1", Author = new Author() },
                new Book { Id = 2, Title = "SuperBook2", Author = new Author() },
                new Book { Id = 3, Title = "AnotherBook", Author = new Author() }
            }.AsQueryable();

            _mockSet = new Mock<DbSet<Book>>();
            _mockSet.As<IQueryable<Book>>().Setup(m => m.Provider).Returns(data.Provider);
            _mockSet.As<IQueryable<Book>>().Setup(m => m.Expression).Returns(data.Expression);
            _mockSet.As<IQueryable<Book>>().Setup(m => m.ElementType).Returns(data.ElementType);
            _mockSet.As<IQueryable<Book>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            _mockContext = new Mock<BookContext>();
            _mockContext.Setup(m => m.Books).Returns(_mockSet.Object);

            _repository = new BookRepository(_mockContext.Object);
        }

        [Test]
        public void GetBooks_ReturnsAllBooks()
        {
            var result = _repository.GetBooks();

            result.Should().Be(3);
        }

        [Test]
        public void GetBook_ReturnsBooksMatchingTitle()
        {
            var result = _repository.GetBook("Super");

            result.Should().Be(1);
        }
    }
}