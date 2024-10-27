using NUnit.Framework;
using netproject2.Data;
using netproject2.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace netproject2.Tests
{
    [TestFixture]
    public class SubjectsDBTests
    {

        

        private SubjectsDB _subjectsDB;
        private AppDbContext _context;

        [SetUp]
        public void Setup()
        {
            // In-memory database setup for testing
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDb")
                .Options;

            _context = new AppDbContext(options);
            _subjectsDB = new SubjectsDB(_context);
        }

        [Test]
        public void AddSubject_ShouldAddNewSubjectToDatabase()
        {
            // Arrange
            var userId = 1;
            var subjectName = "Test Subject";
            var description = "Test Description";

            // Act
            _subjectsDB.AddSubject(userId, subjectName, description);

            // Assert
            var addedSubject = _context.Subjects.FirstOrDefault(s => s.SubjectName == subjectName);
            Assert.IsNotNull(addedSubject);
            Assert.AreEqual(subjectName, addedSubject.SubjectName);
        }

        [TearDown]
        public void TearDown()
        {
            _context.Database.EnsureDeleted(); // Clean up after each test
        }
    }
}
