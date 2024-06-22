using StudentsPerformancePredictionTool_CW1.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentsPerformancePredictionTool_CW1.Forms
{
    public partial class ReportForm : Form
    {
        private User user;
        public ReportForm(User user)
        {
            InitializeComponent();
            this.user = user;
            GenerateReport();
        }

        private void GenerateReport()
        {
            var report = new StringBuilder();
            var groupedStudySessions = user.StudySessions
                .GroupBy(s => s.Date.Date)
                .ToDictionary(g => g.Key, g => g.Sum(s => s.Hours));

            var groupedBreakSessions = user.BreakSessions
                .GroupBy(b => b.Date.Date)
                .ToDictionary(g => g.Key, g => g.Sum(b => b.Hours));

            foreach (var day in Enumerable.Range(0, 7))
            {
                var date = DateTime.Today.AddDays(-day);
                report.AppendLine($"{date.ToShortDateString()}:");

                double studyHours;
                if (groupedStudySessions.TryGetValue(date.Date, out studyHours))
                {
                    report.AppendLine($"  Study: {studyHours} hours");
                }
                else
                {
                    report.AppendLine("  Study: 0 hours");
                }

                double breakHours;
                if (groupedBreakSessions.TryGetValue(date.Date, out breakHours))
                {
                    report.AppendLine($"  Break: {breakHours} hours");
                }
                else
                {
                    report.AppendLine("  Break: 0 hours");
                }
            }

            txtReport.Text = report.ToString();
        }
    }
}
