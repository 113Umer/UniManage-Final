using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace netproject2.Models
{
    public class Subject
    {
        public int SubjectId { get; set; }  // Added Id as the primary key
        public string SubjectName { get; set; }
        public string Description { get; set; }
        // Foreign key for User
        public int StudentID { get; set; }
        public Student Students { get; set; }  // Navigation property to User

        public ICollection<Assignment> Assignments { get; set; }       

        // Method to count assignments by type
        public int CountAssignmentsByType(string assignmentType)
        {
            // LINQ with lambda expression to count assignments of the specified type
            return Assignments.Count(a => a.AssignmentType == assignmentType);
        }

        //  Method to count assignments due soon
        public int CountAssignmentsDueBefore(DateTime dueDate)
        {
            return Assignments.Count(a => a.DueDate < dueDate);
        }
    }
}


