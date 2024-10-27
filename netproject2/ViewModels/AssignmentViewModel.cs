using netproject2.Commands;
using netproject2.Data;
using netproject2.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace netproject2.ViewModels
{
    public class AssignmentsViewModel : BaseViewModel
    {
        // Collection to store assignments
        public ObservableCollection<Assignment> Assignments { get; set; }
        private readonly AssignmentsDB _assignmentDB;
        // Selected assignment property
        private Assignment _selectedAssignment;
        public Assignment SelectedAssignment
        {
            get => _selectedAssignment;
            set
            {
                _selectedAssignment = value;
                OnPropertyChanged(nameof(SelectedAssignment));
            }
        }

        // Commands for managing assignments
        public ICommand AddAssignmentCommand { get; }
        public ICommand EditAssignmentCommand { get; }
        public ICommand DeleteAssignmentCommand { get; }
        private Student _loggedInUser;
        // Constructor
        public AssignmentsViewModel(Student loggedInUser)
        {
            _loggedInUser = loggedInUser;
            _assignmentDB = new AssignmentsDB(new AppDbContext());
            

            LoadAssignmentsForUser();

            // Initialize commands with appropriate methods
            AddAssignmentCommand = new RelayCommand(AddAssignment);
            EditAssignmentCommand = new RelayCommand(EditAssignment, CanEditOrDeleteAssignment);
            DeleteAssignmentCommand = new RelayCommand(DeleteAssignment, CanEditOrDeleteAssignment);
        }

        private void LoadAssignmentsForUser()
        {
            var assignmenst = _assignmentDB.GetAssignmentsByStudentId(_loggedInUser.StudentID);
            Assignments = new ObservableCollection<Assignment>();
        }

        // Method to add a new assignment
        private void AddAssignment(object parameter)
        {
            // Example logic to add a new assignment with default values
            var newAssignment = new Assignment
            {
                AssignmentID = Assignments.Count + 1,
                StudentID = 0,
                SubjectID = 0,
                Title = "New Assignment",
                Description = "Description here",
                AssignmentType = "Type here",
                DueDate = DateTime.Now.AddDays(7),
                AssignmentValue = 100m,
                AssignmentResult = 0m,
                Subject = new Subject() // Initialize with default Subject if needed
            };
            Assignments.Add(newAssignment);
        }

        // Method to edit the selected assignment
        private void EditAssignment(object parameter)
        {
            if (SelectedAssignment != null)
            {
                // Logic for editing the selected assignment
                // Modify assignment fields here if necessary
            }
        }

        // Method to delete the selected assignment
        private void DeleteAssignment(object parameter)
        {
            if (SelectedAssignment != null)
            {
                Assignments.Remove(SelectedAssignment);
            }
        }

        // Can execute for edit and delete commands
        private bool CanEditOrDeleteAssignment(object parameter)
        {
            return SelectedAssignment != null;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
