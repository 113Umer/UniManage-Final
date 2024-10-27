using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using netproject2.Commands;

namespace netproject2.Models
{
    public class Student
    {
        public int StudentID { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        // A user can have multiple subjects
        public ICollection<Subject> Subjects { get; set; }
    }
}
