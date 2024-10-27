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
    /// <summary>
    /// Interaction logic for StudentInfoView.xaml
    /// </summary>
    
    public partial class StudentInfoView : Window
    {
        private AppDbContext db = new AppDbContext();
        private int studentId;

        public StudentInfoView(int studentId)
        {
            InitializeComponent();
            this.studentId = studentId;
            LoadStudentInfo();
        }

        private void LoadStudentInfo()
        {
            var student = db.Students.FirstOrDefault(s => s.StudentID == studentId);

            if (student != null)
            {
                FullNameTextBox.Text = student.FullName;
                EmailTextBox.Text = student.Email;
                PasswordTextBox.Text = student.Password;
            }
            else
            {
                MessageBox.Show("Student not found.");
            }
        }

        private void FullNameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void EmailTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void PasswordTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
