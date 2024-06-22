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

            // Initialize DataGridView
            InitializeDataGridView();
            LoadStudySessions();
            UpdateButtonStates();
        }

        private void InitializeDataGridView()
        {
            dataGridViewBreaks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewBreaks.MultiSelect = false;
            dataGridViewBreaks.AutoGenerateColumns = false;

            dataGridViewBreaks.Columns.Add(new DataGridViewTextBoxColumn { Name = "Date", DataPropertyName = "Date", HeaderText = "Date" });
            dataGridViewBreaks.Columns.Add(new DataGridViewTextBoxColumn { Name = "Hours", DataPropertyName = "Hours", HeaderText = "Hours" });

            dataGridViewBreaks.DataSource = new BindingList<BreakSession>(user.BreakSessions);

            // Handle row selection manually
            dataGridViewBreaks.ClearSelection();
            dataGridViewBreaks.CellClick += dataGridViewBreaks_CellClick;
            dataGridViewBreaks.SelectionChanged += dataGridViewBreaks_SelectionChanged;
        }

        private void LoadStudySessions()
        {
            dataGridViewBreaks.DataSource = new BindingList<BreakSession>(user.BreakSessions);
            dataGridViewBreaks.ClearSelection();
            UpdateButtonStates();
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
                LoadStudySessions();
                MessageBox.Show("Break session added successfully!");

                ClearFields();
            }
            
        }

        private void dataGridViewBreaks_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewBreaks.SelectedRows.Count > 0)
            {
                var selectedSession = dataGridViewBreaks.SelectedRows[0].DataBoundItem as StudySession;
                if (selectedSession != null)
                {
                    dateTimePicker.Value = selectedSession.Date;
                    txtHours.Text = selectedSession.Hours.ToString();
                }
            }
            UpdateButtonStates();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridViewBreaks.SelectedRows.Count > 0)
            {
                var selectedSession = dataGridViewBreaks.SelectedRows[0].DataBoundItem as BreakSession;
                if (selectedSession != null)
                {
                    double hours;
                    if (!double.TryParse(txtHours.Text, out hours))
                    {
                        MessageBox.Show("Please enter a valid number for hours!");
                        return;
                    }

                    selectedSession.Date = dateTimePicker.Value;
                    selectedSession.Hours = hours;

                    dataGridViewBreaks.Refresh();
                    MessageBox.Show("Break session updated successfully!");

                    ClearFields();
                    dataGridViewBreaks.ClearSelection();
                }
            }
            UpdateButtonStates();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewBreaks.SelectedRows.Count > 0)
            {
                var selectedSession = dataGridViewBreaks.SelectedRows[0].DataBoundItem as BreakSession;
                if (selectedSession != null)
                {
                    user.BreakSessions.Remove(selectedSession);
                    LoadStudySessions();
                    MessageBox.Show("Study session deleted successfully!");

                    // Clear the input fields
                    ClearFields();
                    dataGridViewBreaks.ClearSelection();
                }
            }
            else
            {
                MessageBox.Show("Please select a study session to delete.");
            }
            UpdateButtonStates();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridViewBreaks_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Ensure a valid row is clicked
            {
                var selectedSession = dataGridViewBreaks.Rows[e.RowIndex].DataBoundItem as BreakSession;
                if (selectedSession != null)
                {
                    dateTimePicker.Value = selectedSession.Date;
                    txtHours.Text = selectedSession.Hours.ToString();
                }
            }
            UpdateButtonStates();
        }

        private void ClearFields()
        {
            dateTimePicker.Value = DateTime.Now;
            txtHours.Clear();
            UpdateButtonStates();
        }

        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            ClearFields();
            dataGridViewBreaks.ClearSelection();
            UpdateButtonStates();
        }

        private void txtHours_TextChanged(object sender, EventArgs e)
        {
            UpdateButtonStates();
        }

        private void UpdateButtonStates()
        {
            bool rowSelected = dataGridViewBreaks.SelectedRows.Count > 0;
            bool fieldsFilled = !string.IsNullOrWhiteSpace(txtHours.Text);

            btnSave.Enabled = !rowSelected && fieldsFilled;
            btnEdit.Enabled = rowSelected && fieldsFilled;
            btnDelete.Enabled = rowSelected;
            btnBack.Enabled = true;
        }
    }
}
