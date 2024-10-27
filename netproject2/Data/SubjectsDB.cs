using Microsoft.EntityFrameworkCore;
using netproject2.Models;
using System.Collections.Generic;
using System.Linq;

namespace netproject2.Data
{
    public class SubjectsDB : ISubjectService
    {
        private readonly AppDbContext _context;

        public SubjectsDB(AppDbContext context)
        {
            _context = context;
        }

        // Create a new subject associated with a user using Entity Framework
        public void AddSubject(int userId, string subjectName, string description)
        {
            var subject = new Subject
            {
                StudentID = userId,  // Associate subject with a specific user
                SubjectName = subjectName,
                Description = description
            };
            _context.Subjects.Add(subject);
            _context.SaveChanges(); // This will send an INSERT statement to the SQL DB
        }

        // Retrieve all subjects for a specific user using LINQ and Entity Framework
        public List<Subject> GetSubjectsByUserId(int userId)
        {
            // LINQ query to get all subjects for a specific user from the database
            return _context.Subjects
                           .Where(s => s.StudentID == userId)
                           .ToList();  // SELECT * FROM Subjects WHERE UserId = @userId
        }

        // Retrieve a subject by Id and UserId using LINQ
        public Subject GetSubjectByIdAndUserId(int id, int userId)
        {
            // LINQ query to find the subject by its Id and UserId
            return _context.Subjects
                           .FirstOrDefault(s => s.SubjectId == id && s.StudentID == userId);  // SELECT * FROM Subjects WHERE Id = @id AND UserId = @userId
        }

        // Update a subject by Id and UserId using Entity Framework and LINQ
        public void UpdateSubject(int id, int userId, string newSubjectName, string newDescription)
        {
            // LINQ query to get the subject by Id and UserId
            var subject = _context.Subjects.FirstOrDefault(s => s.SubjectId == id && s.StudentID == userId);  // SELECT * FROM Subjects WHERE Id = @id AND UserId = @userId
            if (subject != null)
            {
                subject.SubjectName = newSubjectName;
                subject.Description = newDescription;
                _context.SaveChanges(); // This will send an UPDATE statement to the SQL DB
            }
        }

        // Delete a subject by Id and UserId using Entity Framework and LINQ
        public void DeleteSubject(int id, int userId)
        {
            // LINQ query to get the subject by Id and UserId
            var subject = _context.Subjects.FirstOrDefault(s => s.SubjectId == id && s.StudentID == userId);  // SELECT * FROM Subjects WHERE Id = @id AND UserId = @userId
            if (subject != null)
            {
                _context.Subjects.Remove(subject);
                _context.SaveChanges(); // This will send a DELETE statement to the SQL DB
            }
        }
    }
}
