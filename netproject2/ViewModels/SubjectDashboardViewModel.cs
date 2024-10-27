using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using global::netproject2.Commands;
using global::netproject2.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using System.Runtime.InteropServices.JavaScript;

namespace netproject2.ViewModels
{


    public class SubjectDashboardViewModel : INotifyPropertyChanged
    {
        public Subject SelectedSubject { get; set; } // The selected subject passed from the previous window

        public ICommand ModifyCommand { get; }
        public ICommand CalculateGradeCommand { get; }

        public SubjectDashboardViewModel(Subject selectedSubject)
        {
            SelectedSubject = selectedSubject;
          //  ModifyCommand = new RelayCommand(ModifySubjectDetails);
            CalculateGradeCommand = new RelayCommand(CalculateGrade);
        }

        // Modify the subject details (accepts object as parameter)
        /*
        private void ModifySubjectDetails(object parameter)
        {
            // Logic to modify the subject
        }
        */
       
        public void DisplayAssignmentCounts()
        {
            string assignmentType = "Homework"; // example assignment type
            int countByType = SelectedSubject.CountAssignmentsByType(assignmentType);
            Console.WriteLine($"Number of '{assignmentType}' assignments: {countByType}");

            DateTime upcomingDate = DateTime.Now.AddDays(7); // example upcoming date
            int countDueSoon = SelectedSubject.CountAssignmentsDueBefore(upcomingDate);
            Console.WriteLine($"Number of assignments due within 7 days: {countDueSoon}");
        }
        // Calculate final grade for the assignments (accepts object as parameter)
        private void CalculateGrade(object parameter)
        {
            // Logic to calculate final grade based on assignment grades
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}