using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace netproject2.ViewModels
{
    public class MiniAssignment
    {
        public string Title { get; set; }
        public DateTime DueDate { get; set; }
    }

    public class ToDoListViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<MiniAssignment> assignments;

        public ObservableCollection<MiniAssignment> Assignments
        {
            get { return assignments; }
            set
            {
                assignments = value;
                OnPropertyChanged(nameof(Assignments));
            }
        }

        public ToDoListViewModel()
        {
            // Load assignments here (could be from a database or other sources)
            Assignments = new ObservableCollection<MiniAssignment>
        {
            new MiniAssignment { Title = "Math Homework", DueDate = DateTime.Now.AddDays(1) },
            new MiniAssignment { Title = "Science Project", DueDate = DateTime.Now.AddDays(3) },
            // Add more assignments as needed
        };
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
