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
    public partial class PredictionForm : Form
    {
        private User user;
        public PredictionForm(User user)
        {
            InitializeComponent();
            this.user = user;
            InitializeCustomComponents();
            PredictGrades();
        }

        private void InitializeCustomComponents()
        {
            // Initialize the DataGridView columns
            dataGridViewPredictions.Columns.Add("Subject", "Subject");
            dataGridViewPredictions.Columns.Add("PredictedGrade", "Predicted Grade");
            dataGridViewPredictions.Columns.Add("HoursToPass", "Hours to Pass");
            dataGridViewPredictions.Columns.Add("HoursToDistinction", "Hours to Distinction");
        }

        private void PredictGrades()
        {

            var predictedGrades = new Dictionary<string, double>();

            foreach (var session in user.StudySessions)
            {
                if (!predictedGrades.ContainsKey(session.Subject))
                    predictedGrades[session.Subject] = 0;

                // Assuming each hour contributes 0.1 to the grade with diminishing returns after 10 hours
                if (session.Hours <= 10)
                {
                    predictedGrades[session.Subject] += session.Hours * 0.1;
                }
                else
                {
                    predictedGrades[session.Subject] += 10 * 0.1 + (session.Hours - 10) * 0.05;
                }
            }

            // Cap grades at 100
            foreach (var subject in predictedGrades.Keys.ToList())
            {
                predictedGrades[subject] = Math.Min(predictedGrades[subject], 100);
            }

            // Populate the DataGridView with data
            foreach (var subject in predictedGrades.Keys)
            {
                double predictedGrade = predictedGrades[subject];
                double hoursToPass = CalculateRequiredHours(predictedGrade, 50);
                double hoursToDistinction = CalculateRequiredHours(predictedGrade, 75);

                dataGridViewPredictions.Rows.Add(subject, predictedGrade.ToString("F2"), hoursToPass, hoursToDistinction);
            }
        }

        private double CalculateRequiredHours(double currentGrade, double targetGrade)
        {
            if (currentGrade >= targetGrade)
            {
                return 0;
            }

            double additionalGradeNeeded = targetGrade - currentGrade;
            double additionalHours;

            if (currentGrade < 10)
            {
                additionalHours = additionalGradeNeeded / 0.1;
            }
            else
            {
                additionalHours = (10 - currentGrade) / 0.1;
                additionalGradeNeeded -= (10 - currentGrade);
                additionalHours += additionalGradeNeeded / 0.05;
            }

            return additionalHours;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
