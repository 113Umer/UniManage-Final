using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace netproject2.Models
{
    public class Assignment
    {
        public int AssignmentID { get; set; }
        public int StudentID { get; set; }
        public int SubjectID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string AssignmentType { get; set; }
        public DateTime DueDate { get; set; }
        public decimal AssignmentValue { get; set; }
        public decimal AssignmentResult { get; set; }
        public Subject Subject { get; set; }
    }
}