using netproject2.Data;
using netproject2.Models;
using netproject2.ViewModels;
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
    /// Interaction logic for SubjectsView.xaml
    /// </summary>
    public partial class SubjectsView : Window
    {
        private Student _loggedInUser;
        private AppDbContext db = new AppDbContext();
        public SubjectsView(Student loggedInUser)
        {
            InitializeComponent();
            _loggedInUser = loggedInUser;

            // Pass the logged-in user to the ViewModel
            DataContext = new SubjectsViewModel(_loggedInUser);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Create a new instance of the LoginView
            var loginView = new LoginView();

            // Set the LoginView as the new MainWindow
            Application.Current.MainWindow = loginView;

            // Show the LoginView
            loginView.Show();

            // Close the current window (SubjectsView in this case)
            this.Close();
        }


        private void lstSubjects_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (lstSubjects.SelectedItem is Subject selectedSubject)
            {
                // Open the SubjectDashboard window and pass the selected subject
                var subjectDashboard = new SubjectDashboard
                {
                    DataContext = new SubjectDashboardViewModel(selectedSubject) // Pass the selected subject
                };
                subjectDashboard.Show();
            }
        }


        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            // Check if the Assignments tab is selected
            if (MainTabControl.SelectedItem is TabItem selectedTab)
            {
                if (selectedTab.Header.ToString() == "Assignments")
                {
                    LoadAssignments();
                }

                if (selectedTab.Header.ToString() == "To-Do List")
                {
                    LoadToDoList();
                }
            }



        }

        private void LoadToDoList()
        {
            var assignments = (from a in db.Assignments
                               join s in db.Subjects on a.SubjectID equals s.SubjectId
                               where a.StudentID == _loggedInUser.StudentID
                               orderby a.DueDate // Order assignments by due date
                               select new
                               {
                                   a.Title,           // Assignment Name
                                   a.Description,
                                   a.AssignmentType,
                                   a.DueDate,        // Due Date
                                   a.AssignmentValue, // Assignment Value (add this if it's part of your model)
                                   a.AssignmentResult, // Assignment Result (add this if it's part of your model)
                                   s.SubjectName      // Subject Name
                               })
            .ToList();

            // Bind assignments to the ListView
            if (assignments.Any())
            {
                ToDoAssignmentsListView.ItemsSource = assignments;
            }
            else
            {
                MessageBox.Show("No assignments found for the specified student.");
            }
        }

        private void LoadAssignments()
        {
            var assignments = (from a in db.Assignments
                               join s in db.Subjects on a.SubjectID equals s.SubjectId
                               where a.StudentID == _loggedInUser.StudentID
                               select new
                               {
                                   a.Title,           // Assignment Name
                                   a.DueDate,         // Due Date
                                   s.SubjectName      // Subject Name
                               })
            .ToList();
            // Bind assignments to the ListView
            AssignmentsListView.ItemsSource = assignments;
            // Bind assignments to the ListView if there are results, else show a message
            if (assignments.Any())
            {
                AssignmentsListView.ItemsSource = assignments;
            }
            else
            {
                MessageBox.Show("No assignments found for the specified student.");
            }
        }

        private void AssignmentsListView_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            AssignmentsView assignment = new AssignmentsView(_loggedInUser.StudentID);
            assignment.Show();
        }

        private void AssignmentsListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (AssignmentsListView.SelectedItem is Assignment selectedAssignment)
            {

            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NewAssignmentWindow newAssignmentWindow = new NewAssignmentWindow(_loggedInUser);
            newAssignmentWindow.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            // Get the selected assignment from the ListView
            var selectedAssignment = AssignmentsListView.SelectedItem;

            // Check if an assignment was selected
            if (selectedAssignment == null)
            {
                MessageBox.Show("Please select an assignment to edit.");
                return;
            }

            // Convert selectedAssignment to string and extract assignment name
            string temp = selectedAssignment.ToString();
            string assignmentName = "";
            for (int i = 10; temp[i] != ','; i++)
            {
                assignmentName += temp[i];
            }

            var assignment = (from a in db.Assignments
                              where a.Title == assignmentName
                              select a).FirstOrDefault();



            // Check if the assignment was found
            if (assignment == null)
            {
                MessageBox.Show("Assignment not found in the database.");
                return;
            }

            // Pass the full assignment object to the EditAssignmentWindow constructor
            EditAssignmentWindow editAssignmentWindow = new EditAssignmentWindow(assignment);
            // editAssignmentWindow.ShowDialog();
            bool? result = editAssignmentWindow.ShowDialog();

            // Check if the edit was successful
            if (result == true)
            {
                // Reload assignments to reflect changes in the database
                LoadAssignments();
            }

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            // Get the selected assignment from the ListView
            var selectedAssignment = AssignmentsListView.SelectedItem;

            // Check if an assignment was selected
            if (selectedAssignment == null)
            {
                MessageBox.Show("Please select an assignment to delete.");
                return;
            }

            // Convert selectedAssignment to string and extract assignment name
            string temp = selectedAssignment.ToString();
            string assignmentName = "";
            for (int i = 10; temp[i] != ','; i++)
            {
                assignmentName += temp[i];
            }

            // Find the assignment in the database
            var assignmentToDelete = (from a in db.Assignments
                                      where a.Title == assignmentName
                                      select a).FirstOrDefault();

            // Check if the assignment was found
            if (assignmentToDelete == null)
            {
                MessageBox.Show("Assignment not found in the database.");
                return;
            }

            // Confirm deletion
            var result = MessageBox.Show($"Are you sure you want to delete the assignment '{assignmentToDelete.Title}'?",
                                          "Confirm Deletion",
                                          MessageBoxButton.YesNo,
                                          MessageBoxImage.Warning);

            // Proceed if the user confirmed
            if (result == MessageBoxResult.Yes)
            {
                // Remove the assignment from the database
                db.Assignments.Remove(assignmentToDelete);
                db.SaveChanges(); // Save changes to the database

                // Reload assignments to reflect changes in the database
                LoadAssignments();

                // Inform the user
                MessageBox.Show("Assignment deleted successfully.");
            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {

        }
    }
}
