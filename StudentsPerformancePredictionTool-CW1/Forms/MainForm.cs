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
    public partial class MainForm : Form
    {
        private User user;
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnAddStudySession_Click(object sender, EventArgs e)
        {
            var addStudySessionForm = new AddStudySessionForm(user);
            addStudySessionForm.ShowDialog();
        }

        private void btnAddBreakSession_Click(object sender, EventArgs e)
        {
            var addBreakSessionForm = new AddBreakSessionForm(user);
            addBreakSessionForm.ShowDialog();
        }

        private void btnViewReport_Click(object sender, EventArgs e)
        {
            var reportForm = new ReportForm(user);
            reportForm.ShowDialog();
        }

        private void btnPredictGrades_Click(object sender, EventArgs e)
        {
            var predictionForm = new PredictionForm(user);
            predictionForm.ShowDialog();
        }

        private void textName_TextChanged(object sender, EventArgs e)
        {
            user = new User { Name = textName.Text };
        }
    }
}
