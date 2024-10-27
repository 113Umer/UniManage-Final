using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using global::netproject2.Commands;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;



    namespace netproject2.ViewModels
    {
        public class AddSubjectViewModel : INotifyPropertyChanged
        {
            private string _subjectName;
            private string _description;

            public string SubjectName
            {
                get { return _subjectName; }
                set
                {
                    _subjectName = value;
                    OnPropertyChanged(nameof(SubjectName));
                }
            }

            public string Description
            {
                get { return _description; }
                set
                {
                    _description = value;
                    OnPropertyChanged(nameof(Description));
                }
            }

            public ICommand SubmitCommand { get; }
            public ICommand CancelCommand { get; }

            public Action CloseAction { get; set; }
            public event EventHandler<SubjectAddedEventArgs> SubjectAdded; // To notify SubjectsViewModel about the new subject

            public AddSubjectViewModel()
            {
                SubmitCommand = new RelayCommand(Submit);
                CancelCommand = new RelayCommand(Cancel);
            }

            private void Submit(object parameter)
            {
                // Check if fields are empty
                if (string.IsNullOrWhiteSpace(SubjectName) || string.IsNullOrWhiteSpace(Description))
                {
                    // Show an error message
                    MessageBox.Show("Subject Name and Description cannot be empty.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                // Raise the event to notify the SubjectsViewModel
                SubjectAdded?.Invoke(this, new SubjectAddedEventArgs(SubjectName, Description));

                // Close the window after adding the subject
                CloseAction?.Invoke();
            }


            private void Cancel(object parameter)
            {
                CloseAction?.Invoke(); // Just close the window without adding
            }

            public event PropertyChangedEventHandler PropertyChanged;
            protected void OnPropertyChanged(string propertyName)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public class SubjectAddedEventArgs : EventArgs
        {
            public string SubjectName { get; }
            public string Description { get; }

            public SubjectAddedEventArgs(string subjectName, string description)
            {
                SubjectName = subjectName;
                Description = description;
            }
        }
    }

