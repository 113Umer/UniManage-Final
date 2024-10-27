using netproject2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace netproject2.Data
{
    public interface ISubjectService
    {
        void AddSubject(int userId, string subjectName, string description);
        List<Subject> GetSubjectsByUserId(int userId);
        Subject GetSubjectByIdAndUserId(int id, int userId);
        void UpdateSubject(int id, int userId, string newSubjectName, string newDescription);
        void DeleteSubject(int id, int userId);
    }
}
