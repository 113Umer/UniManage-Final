using netproject2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace netproject2.Data
{
    public interface IAssignmentService
    {
        void AddAssignment(int studentId, int subjectId, string title, string description, string assignmentType, DateTime dueDate, decimal assignmentValue);
        List<Assignment> GetAssignmentsByStudentId(int studentId);
        Assignment GetAssignmentByIdAndStudentId(int id, int studentId);
        void UpdateAssignment(int id, int studentId, string newTitle, string newDescription, string newAssignmentType, DateTime newDueDate, decimal newAssignmentValue, decimal newAssignmentResult);
        void DeleteAssignment(int id, int studentId);
    }
}
