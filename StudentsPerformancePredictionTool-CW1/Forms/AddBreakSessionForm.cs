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
    public partial class AddBreakSessionForm : Form
    {
        private User user;
        public AddBreakSessionForm(User user)
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
            else
            {
                double hours;
                if (!double.TryParse(txtHours.Text, out hours))
                {
                    MessageBox.Show("Please enter a valid number for hours!");
                    return;
                }

                var breakSession = new BreakSession
                {
                    Date = dateTimePicker.Value,
                    Hours = hours
                };

                user.BreakSessions.Add(breakSession);
                MessageBox.Show("Break session added successfully!");
                this.Close();
            }
            
        }
    }
}
