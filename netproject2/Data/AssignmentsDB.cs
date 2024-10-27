using Microsoft.EntityFrameworkCore;
using netproject2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace netproject2.Data
{
    public class AssignmentsDB : IAssignmentService
    {
        private readonly AppDbContext _context;

        public AssignmentsDB(AppDbContext context)
        {
            _context = context;
        }

        // Create a new assignment associated with a specific student and subject
        public void AddAssignment(int studentId, int subjectId, string title, string description, string assignmentType, DateTime dueDate, decimal assignmentValue)
        {
            var assignment = new Assignment
            {
                StudentID = studentId,
                SubjectID = subjectId,
                Title = title,
                Description = description,
                AssignmentType = assignmentType,
                DueDate = dueDate,
                AssignmentValue = assignmentValue,
                AssignmentResult = 0 // Initialize result to 0
            };
            _context.Assignments.Add(assignment);
            _context.SaveChanges(); // This will send an INSERT statement to the SQL DB
        }

        // Retrieve all assignments for a specific student using LINQ and Entity Framework
        public List<Assignment> GetAssignmentsByStudentId(int studentId)
        {
            // LINQ query to get all assignments for a specific student from the database
            return _context.Assignments
                           .Where(a => a.StudentID == studentId)
                           .Include(a => a.Subject) // Optionally include related Subject data
                           .ToList();  // SELECT * FROM Assignments WHERE StudentID = @studentId
        }

        // Retrieve a specific assignment by its ID and student ID using LINQ
        public Assignment GetAssignmentByIdAndStudentId(int id, int studentId)
        {
            // LINQ query to find the assignment by its Id and student ID
            return _context.Assignments
                           .Include(a => a.Subject) // Optionally include related Subject data
                           .FirstOrDefault(a => a.AssignmentID == id && a.StudentID == studentId); // SELECT * FROM Assignments WHERE AssignmentID = @id AND StudentID = @studentId
        }

        // Update an assignment by its ID and student ID using Entity Framework and LINQ
        public void UpdateAssignment(int id, int studentId, string newTitle, string newDescription, string newAssignmentType, DateTime newDueDate, decimal newAssignmentValue, decimal newAssignmentResult)
        {
            // LINQ query to get the assignment by ID and student ID
            var assignment = _context.Assignments.FirstOrDefault(a => a.AssignmentID == id && a.StudentID == studentId); // SELECT * FROM Assignments WHERE AssignmentID = @id AND StudentID = @studentId
            if (assignment != null)
            {
                assignment.Title = newTitle;
                assignment.Description = newDescription;
                assignment.AssignmentType = newAssignmentType;
                assignment.DueDate = newDueDate;
                assignment.AssignmentValue = newAssignmentValue;
                assignment.AssignmentResult = newAssignmentResult;
                _context.SaveChanges(); // This will send an UPDATE statement to the SQL DB
            }
        }

        // Delete an assignment by ID and student ID using Entity Framework and LINQ
        public void DeleteAssignment(int id, int studentId)
        {
            // LINQ query to get the assignment by ID and student ID
            var assignment = _context.Assignments.FirstOrDefault(a => a.AssignmentID == id && a.StudentID == studentId); // SELECT * FROM Assignments WHERE AssignmentID = @id AND StudentID = @studentId
            if (assignment != null)
            {
                _context.Assignments.Remove(assignment);
                _context.SaveChanges(); // This will send a DELETE statement to the SQL DB
            }
        }
    }
}
