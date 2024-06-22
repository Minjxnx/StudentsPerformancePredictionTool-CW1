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
            InitializeCustomComponents();
        }

        private void InitializeCustomComponents()
        {
            btnAddStudySession.Enabled = false;
            btnAddBreakSession.Enabled = false;
            btnViewReport.Enabled = false;
            btnPredictGrades.Enabled = false;

            textName.TextChanged += textName_TextChanged;
        }

        private void btnAddStudySession_Click(object sender, EventArgs e)
        {
            if (user == null || string.IsNullOrWhiteSpace(user.Name))
            {
                MessageBox.Show("Please enter your name before proceeding.");
                return;
            }
            var addStudySessionForm = new AddStudySessionForm(user);
            addStudySessionForm.ShowDialog();
        }

        private void btnAddBreakSession_Click(object sender, EventArgs e)
        {
            if (user == null || string.IsNullOrWhiteSpace(user.Name))
            {
                MessageBox.Show("Please enter your name before proceeding.");
                return;
            }
            var addBreakSessionForm = new AddBreakSessionForm(user);
            addBreakSessionForm.ShowDialog();
        }

        private void btnViewReport_Click(object sender, EventArgs e)
        {
            if (user == null || string.IsNullOrWhiteSpace(user.Name))
            {
                MessageBox.Show("Please enter your name before proceeding.");
                return;
            }
            var reportForm = new ReportForm(user);
            reportForm.ShowDialog();
        }

        private void btnPredictGrades_Click(object sender, EventArgs e)
        {
            if (user == null || string.IsNullOrWhiteSpace(user.Name))
            {
                MessageBox.Show("Please enter your name before proceeding.");
                return;
            }
            var predictionForm = new PredictionForm(user);
            predictionForm.ShowDialog();
        }

        private void textName_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textName.Text))
            {
                user = new User { Name = textName.Text };
                btnAddStudySession.Enabled = true;
                btnAddBreakSession.Enabled = true;
                btnViewReport.Enabled = true;
                btnPredictGrades.Enabled = true;
            }
            else
            {
                user = null;
                btnAddStudySession.Enabled = false;
                btnAddBreakSession.Enabled = false;
                btnViewReport.Enabled = false;
                btnPredictGrades.Enabled = false;
            }
        }
    }
}
