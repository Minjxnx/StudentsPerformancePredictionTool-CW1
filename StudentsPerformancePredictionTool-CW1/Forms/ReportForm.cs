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
            InitializeCustomComponents();
            LoadInitialReport();
        }

        private void InitializeCustomComponents()
        {
            // Initialize the DataGridView columns
            dataGridViewReport.Columns.Add("Date", "Date");
            dataGridViewReport.Columns.Add("StudyHours", "Study Hours");
            dataGridViewReport.Columns.Add("StudySessions", "Study Sessions");
            dataGridViewReport.Columns.Add("BreakHours", "Break Hours");
            dataGridViewReport.Columns.Add("BreakSessions", "Break Sessions");

            // Set default date range to the last 7 days
            dateTimePickerTo.Value = DateTime.Today;
            dateTimePickerFrom.Value = DateTime.Today.AddDays(-6);

            // Add event handler for the button click
            dateTimePickerFrom.ValueChanged += dateTimePickerFrom_ValueChanged;
            dateTimePickerTo.ValueChanged += dateTimePickerTo_ValueChanged;
        }

        private void LoadInitialReport()
        {
            var endDate = DateTime.Today;
            var startDate = DateTime.Today.AddDays(-6);
            GenerateReport(startDate, endDate);
        }

        private void dateTimePickerFrom_ValueChanged(object sender, EventArgs e)
        {
            var startDate = dateTimePickerFrom.Value.Date;
            var endDate = dateTimePickerTo.Value.Date;
            GenerateReport(startDate, endDate);
        }

        private void dateTimePickerTo_ValueChanged(object sender, EventArgs e)
        {
            var startDate = dateTimePickerFrom.Value.Date;
            var endDate = dateTimePickerTo.Value.Date;
            GenerateReport(startDate, endDate);
        }

        private void GenerateReport(DateTime startDate, DateTime endDate)
        {
            // Clear the existing rows
            dataGridViewReport.Rows.Clear();

            // Get study and break sessions grouped by date
            var groupedStudySessions = user.StudySessions
                .Where(s => s.Date.Date >= startDate && s.Date.Date <= endDate)
                .GroupBy(s => s.Date.Date)
                .ToDictionary(g => g.Key, g => new { Hours = g.Sum(s => s.Hours), Count = g.Count() });

            var groupedBreakSessions = user.BreakSessions
                .Where(b => b.Date.Date >= startDate && b.Date.Date <= endDate)
                .GroupBy(b => b.Date.Date)
                .ToDictionary(g => g.Key, g => new { Hours = g.Sum(b => b.Hours), Count = g.Count() });

            // Populate the DataGridView with data
            foreach (var day in EachDay(startDate, endDate))
            {
                double studyHours = 0;
                int studySessions = 0;
                if (groupedStudySessions.TryGetValue(day, out var studyData))
                {
                    studyHours = studyData.Hours;
                    studySessions = studyData.Count;
                }

                double breakHours = 0;
                int breakSessions = 0;
                if (groupedBreakSessions.TryGetValue(day, out var breakData))
                {
                    breakHours = breakData.Hours;
                    breakSessions = breakData.Count;
                }

                dataGridViewReport.Rows.Add(day.ToShortDateString(), studyHours, studySessions, breakHours, breakSessions);
            }
        }

        private IEnumerable<DateTime> EachDay(DateTime from, DateTime to)
        {
            for (var day = from.Date; day.Date <= to.Date; day = day.AddDays(1))
                yield return day;
        }
    }
}
