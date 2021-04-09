using EFCore.Repositories;
using EFCore.Data;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Linq;

namespace EFCore.Repositories.Tests
{
    [TestFixture()]
    public class AuthorRepositoryTests
    {
        private static readonly DbContextOptions<EFCoreDbContext> _options = new DbContextOptionsBuilder<EFCoreDbContext>()
            .UseInMemoryDatabase(databaseName: "EFCoreInMemoryDatabase")
            .Options;
        private static readonly AuthorRepository _repository = new AuthorRepository(new EFCoreDbContext(_options));

        [SetUp]
        public void NUnitSetUp()
        {
            // Insert seed data into the database using one instance of the context
            _repository.Insert(new Models.Author { Id = 1, FirstName = "Trong", LastName = "Duong", CreatedDate = DateTime.Now });
            _repository.Insert(new Models.Author { Id = 2, FirstName = "Huy", LastName = "Hung", CreatedDate = DateTime.Now });
            _repository.Insert(new Models.Author { Id = 3, FirstName = "Anh", LastName = "Duc", CreatedDate = DateTime.Now });
        }

        [Test()]
        public void GetAll_Author_ReturnAuthorsList()
        {
            //Act
            var authors = _repository.GetAll();

            //Assert
            Assert.IsNotNull(authors);
            Assert.AreEqual(3, authors.Count());
        }

        [Test()]
        public void GetByID_ID_ReturnAuthorFullName()
        {
            //Arrange
            const long id = 1;
            const string expected = "Trong Duong";

            //Act
            var author = _repository.Get(id);
            var result = $"{author.FirstName} {author.LastName}";

            //Assert
            Assert.IsNotNull(result);          
            Assert.AreEqual(expected, result); 
        }
    }
}