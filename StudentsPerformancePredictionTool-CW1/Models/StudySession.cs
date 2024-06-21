using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsPerformancePredictionTool_CW1.Models
{
    public class StudySession
    {
        public DateTime Date { get; set; }
        public double Hours { get; set; }
        public string Subject { get; set; }

        public StudySession(DateTime date, double hours, string subject)
        {
            Date = date;
            Hours = hours;
            Subject = subject;
        }

    }
}
