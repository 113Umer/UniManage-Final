using netproject2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace netproject2.ViewModels
{
    public class CalendarViewModel
    {
        public List<CalendarDay> Days { get; set; }
        public List<Assignment> Assignments { get; set; }

        public CalendarViewModel(List<Assignment> assignments)
        {
            Assignments = assignments;
            GenerateDays(DateTime.Now.Year, DateTime.Now.Month);
        }

        private void GenerateDays(int year, int month)
        {
            Days = new List<CalendarDay>();
            var firstDayOfMonth = new DateTime(year, month, 1);
            var daysInMonth = DateTime.DaysInMonth(year, month);

            // Create calendar days
            for (int i = 1; i <= daysInMonth; i++)
            {
                var currentDate = new DateTime(year, month, i);
                Days.Add(new CalendarDay
                {
                    Date = currentDate,
                    Assignments = Assignments.Where(a => a.DueDate.Date == currentDate.Date).ToList()
                });
            }
        }
    }

    public class CalendarDay
    {
        public DateTime Date { get; set; }
        public List<Assignment> Assignments { get; set; }
    }

}
