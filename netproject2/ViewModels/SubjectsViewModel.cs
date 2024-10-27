using netproject2.Commands;
using netproject2.Models;
using System.ComponentModel;
using System.Windows.Input;
using System.Windows;
using netproject2.Views;
using System.Collections.ObjectModel;
using netproject2.ViewModels;
using netproject2.Data;
using netproject2.Views;



namespace netproject2.ViewModels
{

    public class SubjectsViewModel : INotifyPropertyChanged
    {
        // ObservableCollection to hold the list of subjects
        private ObservableCollection<Subject> _subjects;
        private readonly SubjectsDB _subjectsDB; // Reference to SubjectsDB for data handling

        private readonly AppDbContext _dbContext;

        public ObservableCollection<Subject> Subjects
        {
            get => _subjects;
            set
            {
                _subjects = value;
                OnPropertyChanged(nameof(Subjects));
            }
        }

        // Make _selectedSubject a public property for binding
        private Subject _selectedSubject;
        public Subject SelectedSubject
        {
            get => _selectedSubject;
            set
            {
                _selectedSubject = value;
                OnPropertyChanged(nameof(SelectedSubject));
            }
        }
        // Commands
        public ICommand AddCommand { get; }
        public ICommand EditCommand { get; }
        public ICommand DeleteCommand { get; }
        public ICommand ModifyCommand { get; }
        public ICommand CancelCommand { get; }

        private Student _loggedInUser;

        public SubjectsViewModel(Student loggedInUser)
        {
            _loggedInUser = loggedInUser;
            _subjectsDB = new SubjectsDB(new AppDbContext());
            // Retrieve the subjects associated with the logged-in user
            LoadSubjectsForUser();

            AddCommand = new RelayCommand(OpenAddSubjectWindow);
            EditCommand = new RelayCommand(EditSubject);
            DeleteCommand = new RelayCommand(DeleteSubject);
            ModifyCommand = new RelayCommand(ModifySubject);
            CancelCommand = new RelayCommand(CancelEditSubject);
        }

        private void LoadSubjectsForUser()
        {
            var subjects = _subjectsDB.GetSubjectsByUserId(_loggedInUser.StudentID);
            Subjects = new ObservableCollection<Subject>(subjects);
        }
        // Edit an existing subject

        private void EditSubject(object subject)
        {
            if (subject is Subject selected)
            {
                SelectedSubject = selected;  // Store selected subject

                var editSubjectWindow = new EditSubjectView();
                editSubjectWindow.DataContext = this;  // Set ViewModel as DataContext
                editSubjectWindow.ShowDialog();
            }
        }

        private void ModifySubject(object parameter)
        {
            if (SelectedSubject != null)
            {
                _subjectsDB.UpdateSubject(SelectedSubject.SubjectId, _loggedInUser.StudentID, SelectedSubject.SubjectName, SelectedSubject.Description);
                LoadSubjectsForUser();  // Reload subjects after modification

                // Close the window after modifying
                Window window = parameter as Window;
                if (window != null)
                {
                    window.Close();
                }
            }
        }

        // Close the edit window when Cancel button is clicked
        private void CancelEditSubject(object parameter)
        {
            Window window = parameter as Window;
            if (window != null)
            {
                window.Close();  // Close the window
            }
        }


        // Delete an existing subject
        private void DeleteSubject(object subject)
        {
            if (subject is Subject selected)
            {
                // Show confirmation dialog with subject name
                var result = MessageBox.Show($"Are you sure you want to delete '{selected.SubjectName}'?",
                                             "Confirm Delete",
                                             MessageBoxButton.YesNo,
                                             MessageBoxImage.Warning);

                // Check if the user clicked 'Yes' (delete)
                if (result == MessageBoxResult.Yes)
                {
                    // Proceed with deletion
                    _subjectsDB.DeleteSubject(selected.SubjectId, _loggedInUser.StudentID); // Use SubjectsDB to delete
                    Subjects.Remove(selected);
                }
                // Otherwise, do nothing (cancelled)
            }
        }

        // Add a new subject

        private void OpenAddSubjectWindow(object parameter)
        {
            var addSubjectWindow = new AddSubjectsView();
            var addSubjectViewModel = new AddSubjectViewModel();

            addSubjectViewModel.CloseAction = addSubjectWindow.Close;

            // Subscribe to the SubjectAdded event
            addSubjectViewModel.SubjectAdded += (sender, args) =>
            {
                _subjectsDB.AddSubject(_loggedInUser.StudentID, args.SubjectName, args.Description); // Add to DB
                LoadSubjectsForUser(); // Reload the subjects list after adding
            };

            addSubjectWindow.DataContext = addSubjectViewModel;
            addSubjectWindow.ShowDialog();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}