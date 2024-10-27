using netproject2.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace netproject2.Views
{

    public partial class AssignmentsView : Window
    {
        private AppDbContext db = new AppDbContext();
        private int studentId; // Assume you pass the student ID when opening this form.

        public AssignmentsView(int studentId)
        {
            InitializeComponent();
            this.studentId = studentId;
            LoadAssignments();
        }

        private void LoadAssignments()
        {
            var assignments = (from a in db.Assignments
                               join s in db.Subjects on a.SubjectID equals s.SubjectId
                               where a.StudentID == studentId
                               select new
                               {
                                   a.Title,
                                   a.Description,
                                   a.AssignmentType,
                                   a.DueDate,
                                   a.AssignmentValue,
                                   a.AssignmentResult,
                                   s.SubjectName
                               })
            .ToList();

            // Check if any assignments were found
            if (assignments != null )
            {
                AssignmentsListView.ItemsSource = assignments;
            }
            else
            {
                MessageBox.Show("No assignments found for the specified student.");
            }
        }

        private void AssignmentsListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
