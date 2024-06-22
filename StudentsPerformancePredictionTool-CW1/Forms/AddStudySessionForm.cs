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
    public partial class AddStudySessionForm : Form
    {
        private User user;
        public AddStudySessionForm(User user)
        {
            InitializeComponent();
            this.user = user;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (dateTimePicker.Value == null)
            {
                MessageBox.Show("Please add the date!");
            }
            else if (string.IsNullOrWhiteSpace(txtHours.Text))
            {
                MessageBox.Show("Please add the hours!");
            }
            else if (string.IsNullOrWhiteSpace(txtSubject.Text))
            {
                MessageBox.Show("Please add the Subject!");
            }
            else
            {
                double hours;
                if (!double.TryParse(txtHours.Text, out hours))
                {
                    MessageBox.Show("Please enter a valid number for hours!");
                    return;
                }

                var studySession = new StudySession
                {
                    Date = dateTimePicker.Value,
                    Hours = hours,
                    Subject = txtSubject.Text
                };

                user.StudySessions.Add(studySession);
                MessageBox.Show("Study session added successfully!");
                this.Close();
            }

        }
    }
}
