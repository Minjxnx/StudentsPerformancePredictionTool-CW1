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
            PredictGrades();
        }

        private void PredictGrades()
        {
           
            var predictedGrades = new Dictionary<string, double>();

            foreach (var session in user.StudySessions)
            {
                if (!predictedGrades.ContainsKey(session.Subject))
                    predictedGrades[session.Subject] = 0;

                predictedGrades[session.Subject] += session.Hours * 0.1;
            }

            var predictionReport = new StringBuilder();
            foreach (var subject in predictedGrades.Keys)
            {
                predictionReport.AppendLine($"{subject}: {predictedGrades[subject]:F2}");
            }

            txtPrediction.Text = predictionReport.ToString();
        }
    }
}
