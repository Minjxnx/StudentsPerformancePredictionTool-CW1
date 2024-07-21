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
        private StudySessionService.StudySessionSoapClient service;

        public AddStudySessionForm(User user)
        {
            InitializeComponent();
            this.user = user;
            service = new StudySessionService.StudySessionSoapClient();

            // Initialize DataGridView
            InitializeDataGridView();
            LoadStudySessions();
            UpdateButtonStates();
        }

        private void InitializeDataGridView()
        {
            dataGridViewSessions.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewSessions.MultiSelect = false;
            dataGridViewSessions.AutoGenerateColumns = false;

            dataGridViewSessions.Columns.Add(new DataGridViewTextBoxColumn { Name = "Date", DataPropertyName = "Date", HeaderText = "Date" });
            dataGridViewSessions.Columns.Add(new DataGridViewTextBoxColumn { Name = "Hours", DataPropertyName = "Hours", HeaderText = "Hours" });
            dataGridViewSessions.Columns.Add(new DataGridViewTextBoxColumn { Name = "Subject", DataPropertyName = "Subject", HeaderText = "Subject" });

            LoadStudySessions();
        }

        private void LoadStudySessions()
        {
            var serviceSessions = service.GetStudySessions(user.Name);

            // Check if serviceSessions is null
            if (serviceSessions == null)
            {
                // If it's null, initialize it as an empty list
                serviceSessions = new StudySessionService.StudySessionModel[0];
            }

            // Map the service model to the local model
            var localSessions = serviceSessions.Select(s => MapToLocalStudySession(s)).ToList();

            // Bind the localSessions to the DataGridView
            dataGridViewSessions.DataSource = new BindingList<StudySession>(localSessions);
            dataGridViewSessions.ClearSelection();
            UpdateButtonStates();
        }

        private StudySession MapToLocalStudySession(StudySessionService.StudySessionModel serviceModel)
        {
            return new StudySession
            {
                Id = serviceModel.Id,
                Date = serviceModel.Date,
                Hours = serviceModel.Hours,
                Subject = serviceModel.Subject
            };
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

                service.AddStudySession(user.Name, dateTimePicker.Value, hours, txtSubject.Text);
                LoadStudySessions();
                MessageBox.Show("Study session added successfully!");

                ClearFields();
            }

        }

        private void dataGridViewSessions_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewSessions.SelectedRows.Count > 0)
            {
                var selectedSession = dataGridViewSessions.SelectedRows[0].DataBoundItem as StudySession;
                if (selectedSession != null)
                {
                    dateTimePicker.Value = selectedSession.Date;
                    txtHours.Text = selectedSession.Hours.ToString();
                    txtSubject.Text = selectedSession.Subject;
                }
            }
            UpdateButtonStates();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridViewSessions.SelectedRows.Count > 0)
            {
                var selectedSession = dataGridViewSessions.SelectedRows[0].DataBoundItem as StudySession;
                if (selectedSession != null)
                {
                    double hours;
                    if (!double.TryParse(txtHours.Text, out hours))
                    {
                        MessageBox.Show("Please enter a valid number for hours!");
                        return;
                    }

                    service.UpdateStudySession(user.Name, selectedSession.Id, dateTimePicker.Value, hours, txtSubject.Text);
                    LoadStudySessions();
                    MessageBox.Show("Study session updated successfully!");

                    ClearFields();
                    dataGridViewSessions.ClearSelection();
                }
            }
            UpdateButtonStates();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewSessions.SelectedRows.Count > 0)
            {
                var selectedSession = dataGridViewSessions.SelectedRows[0].DataBoundItem as StudySession;
                if (selectedSession != null)
                {
                    service.DeleteStudySession(user.Name, selectedSession.Id);
                    LoadStudySessions();
                    MessageBox.Show("Study session deleted successfully!");

                    // Clear the input fields
                    ClearFields();
                    dataGridViewSessions.ClearSelection();
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

        private void UpdateButtonStates()
        {
            bool rowSelected = dataGridViewSessions.SelectedRows.Count > 0;
            bool fieldsFilled = !string.IsNullOrWhiteSpace(txtHours.Text) && !string.IsNullOrWhiteSpace(txtSubject.Text);

            btnSave.Enabled = !rowSelected && fieldsFilled;
            btnEdit.Enabled = rowSelected && fieldsFilled;
            btnDelete.Enabled = rowSelected;
            btnBack.Enabled = true;
        }

        private void txtHours_TextChanged(object sender, EventArgs e)
        {
            UpdateButtonStates();
        }

        private void ClearFields()
        {
            dateTimePicker.Value = DateTime.Now;
            txtHours.Clear();
            txtSubject.Clear();
            UpdateButtonStates();
        }
        //private User user;
        //public AddStudySessionForm(User user)
        //{
        //    InitializeComponent();
        //    this.user = user;

        //    // Initialize DataGridView
        //    InitializeDataGridView();
        //    LoadStudySessions();
        //    UpdateButtonStates();
        //}

        //private void InitializeDataGridView()
        //{
        //    dataGridViewSessions.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        //    dataGridViewSessions.MultiSelect = false;
        //    dataGridViewSessions.AutoGenerateColumns = false;

        //    dataGridViewSessions.Columns.Add(new DataGridViewTextBoxColumn { Name = "Date", DataPropertyName = "Date", HeaderText = "Date" });
        //    dataGridViewSessions.Columns.Add(new DataGridViewTextBoxColumn { Name = "Hours", DataPropertyName = "Hours", HeaderText = "Hours" });
        //    dataGridViewSessions.Columns.Add(new DataGridViewTextBoxColumn { Name = "Subject", DataPropertyName = "Subject", HeaderText = "Subject" });

        //    dataGridViewSessions.DataSource = new BindingList<StudySession>(user.StudySessions);

        //    // Handle row selection manually
        //    dataGridViewSessions.ClearSelection();
        //    dataGridViewSessions.CellClick += dataGridViewSessions_CellClick;
        //    dataGridViewSessions.SelectionChanged += dataGridViewSessions_SelectionChanged;
        //}

        //private void LoadStudySessions()
        //{
        //    dataGridViewSessions.DataSource = new BindingList<StudySession>(user.StudySessions);
        //    dataGridViewSessions.ClearSelection();
        //    UpdateButtonStates();
        //}

        //private void btnSave_Click(object sender, EventArgs e)
        //{
        //    if (dateTimePicker.Value == null)
        //    {
        //        MessageBox.Show("Please add the date!");
        //    }
        //    else if (string.IsNullOrWhiteSpace(txtHours.Text))
        //    {
        //        MessageBox.Show("Please add the hours!");
        //    }
        //    else if (string.IsNullOrWhiteSpace(txtSubject.Text))
        //    {
        //        MessageBox.Show("Please add the Subject!");
        //    }
        //    else
        //    {
        //        double hours;
        //        if (!double.TryParse(txtHours.Text, out hours))
        //        {
        //            MessageBox.Show("Please enter a valid number for hours!");
        //            return;
        //        }

        //        var studySession = new StudySession
        //        {
        //            Date = dateTimePicker.Value,
        //            Hours = hours,
        //            Subject = txtSubject.Text
        //        };

        //        user.StudySessions.Add(studySession);
        //        LoadStudySessions();
        //        MessageBox.Show("Study session added successfully!");

        //        ClearFields();
        //    }

        //}

        //private void dataGridViewSessions_SelectionChanged(object sender, EventArgs e)
        //{
        //    if (dataGridViewSessions.SelectedRows.Count > 0)
        //    {
        //        var selectedSession = dataGridViewSessions.SelectedRows[0].DataBoundItem as StudySession;
        //        if (selectedSession != null)
        //        {
        //            dateTimePicker.Value = selectedSession.Date;
        //            txtHours.Text = selectedSession.Hours.ToString();
        //            txtSubject.Text = selectedSession.Subject;
        //        }
        //    }
        //    UpdateButtonStates();
        //}

        //private void btnEdit_Click(object sender, EventArgs e)
        //{
        //    if (dataGridViewSessions.SelectedRows.Count > 0)
        //    {
        //        var selectedSession = dataGridViewSessions.SelectedRows[0].DataBoundItem as StudySession;
        //        if (selectedSession != null)
        //        {
        //            double hours;
        //            if (!double.TryParse(txtHours.Text, out hours))
        //            {
        //                MessageBox.Show("Please enter a valid number for hours!");
        //                return;
        //            }

        //            selectedSession.Date = dateTimePicker.Value;
        //            selectedSession.Hours = hours;
        //            selectedSession.Subject = txtSubject.Text;

        //            dataGridViewSessions.Refresh();
        //            MessageBox.Show("Study session updated successfully!");

        //            ClearFields();
        //            dataGridViewSessions.ClearSelection();
        //        }
        //    }
        //    UpdateButtonStates();
        //}

        //private void dataGridViewSessions_CellClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    if (e.RowIndex >= 0) // Ensure a valid row is clicked
        //    {
        //        var selectedSession = dataGridViewSessions.Rows[e.RowIndex].DataBoundItem as StudySession;
        //        if (selectedSession != null)
        //        {
        //            dateTimePicker.Value = selectedSession.Date;
        //            txtHours.Text = selectedSession.Hours.ToString();
        //            txtSubject.Text = selectedSession.Subject;
        //        }
        //    }
        //    UpdateButtonStates();
        //}

        //private void ClearFields()
        //{
        //    dateTimePicker.Value = DateTime.Now;
        //    txtHours.Clear();
        //    txtSubject.Clear();
        //    UpdateButtonStates();
        //}

        //protected override void OnActivated(EventArgs e)
        //{
        //    base.OnActivated(e);
        //    ClearFields();
        //    dataGridViewSessions.ClearSelection();
        //    UpdateButtonStates();
        //}

        //private void btnDelete_Click(object sender, EventArgs e)
        //{
        //    if (dataGridViewSessions.SelectedRows.Count > 0)
        //    {
        //        var selectedSession = dataGridViewSessions.SelectedRows[0].DataBoundItem as StudySession;
        //        if (selectedSession != null)
        //        {
        //            user.StudySessions.Remove(selectedSession);
        //            LoadStudySessions();
        //            MessageBox.Show("Study session deleted successfully!");

        //            // Clear the input fields
        //            ClearFields();
        //            dataGridViewSessions.ClearSelection();
        //        }
        //    }
        //    else
        //    {
        //        MessageBox.Show("Please select a study session to delete.");
        //    }
        //    UpdateButtonStates();
        //}

        //private void btnBack_Click(object sender, EventArgs e)
        //{
        //    this.Close();
        //}

        //private void UpdateButtonStates()
        //{
        //    bool rowSelected = dataGridViewSessions.SelectedRows.Count > 0;
        //    bool fieldsFilled = !string.IsNullOrWhiteSpace(txtHours.Text) && !string.IsNullOrWhiteSpace(txtSubject.Text);

        //    btnSave.Enabled = !rowSelected && fieldsFilled;
        //    btnEdit.Enabled = rowSelected && fieldsFilled;
        //    btnDelete.Enabled = rowSelected;
        //    btnBack.Enabled = true;
        //}

        //private void txtHours_TextChanged(object sender, EventArgs e)
        //{
        //    UpdateButtonStates();
        //}
    }
}
