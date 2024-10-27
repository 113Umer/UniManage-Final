using netproject2.Data;
using netproject2.Models;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace netproject2.Views
{
    public partial class NewAssignmentWindow : Window
    {
        private AppDbContext db = new AppDbContext();
        private Student _loggedInUser;

        public NewAssignmentWindow(Student loggedInUser)
        {
            InitializeComponent();
            LoadSubjects();
            _loggedInUser = loggedInUser;
        }

        private void LoadSubjects()
        {
            // Retrieve all subjects from the database and populate the combo box
            var subjects = db.Subjects.Select(s => s.SubjectName).ToList();
            SubjectComboBox.ItemsSource = subjects;
        }

        private void RemoveText(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox.Text == "Title" || textBox.Text == "Description" || textBox.Text == "Assignment Type"
                || textBox.Text == "Assignment Value" || textBox.Text == "Assignment Result")
            {
                textBox.Text = "";
                textBox.Foreground = Brushes.Black;
            }
        }

        private void AddText(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                if (textBox == TitleTextBox) textBox.Text = "Title";
                else if (textBox == DescriptionTextBox) textBox.Text = "Description";
                else if (textBox == AssignmentTypeTextBox) textBox.Text = "Assignment Type";
                else if (textBox == AssignmentValueTextBox) textBox.Text = "Assignment Value";
                else if (textBox == AssignmentResultTextBox) textBox.Text = "Assignment Result";

                textBox.Foreground = Brushes.Gray;
            }
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            // Collect data from the text boxes and combo box
            string title = TitleTextBox.Text;
            string description = DescriptionTextBox.Text;
            string assignmentType = AssignmentTypeTextBox.Text;
            DateTime? dueDate = DueDatePicker.SelectedDate;
            string assignmentValueText = AssignmentValueTextBox.Text;
            string assignmentResultText = AssignmentResultTextBox.Text;
            string selectedSubjectName = SubjectComboBox.SelectedItem as string;

            // Validate input data
            if (title == "Title" || description == "Description" || assignmentType == "Assignment Type"
                || string.IsNullOrWhiteSpace(selectedSubjectName) || dueDate == null)
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            // Attempt to parse assignment value and result
            if (!decimal.TryParse(assignmentValueText, out decimal assignmentValue) ||
                !decimal.TryParse(assignmentResultText, out decimal assignmentResult))
            {
                MessageBox.Show("Please enter valid numbers for Assignment Value and Assignment Result.");
                return;
            }

            // Find the Subject ID based on the selected Subject Name
            var subject = db.Subjects.FirstOrDefault(s => s.SubjectName == selectedSubjectName);
            if (subject == null)
            {
                MessageBox.Show("Selected subject not found. Please select a valid subject.");
                return;
            }

            // Create a new Assignment object
            Assignment newAssignment = new Assignment
            {
                Title = title,
                Description = description,
                AssignmentType = assignmentType,
                DueDate = dueDate.Value,
                AssignmentValue = assignmentValue,
                AssignmentResult = assignmentResult,
                SubjectID = subject.SubjectId,
                StudentID = _loggedInUser.StudentID  // Set the StudentID here
            };

            // Insert new assignment into the database
            db.Assignments.Add(newAssignment);
            db.SaveChanges();

            MessageBox.Show("Assignment added successfully!");

            // Close the window or reset the fields as needed
            this.Close();
        }
    }
}
