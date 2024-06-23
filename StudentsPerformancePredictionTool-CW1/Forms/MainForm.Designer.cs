namespace StudentsPerformancePredictionTool_CW1.Forms
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnAddStudySession = new System.Windows.Forms.Button();
            this.btnAddBreakSession = new System.Windows.Forms.Button();
            this.btnViewReport = new System.Windows.Forms.Button();
            this.btnPredictGrades = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnAddStudySession
            // 
            this.btnAddStudySession.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnAddStudySession.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddStudySession.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAddStudySession.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddStudySession.ForeColor = System.Drawing.Color.Black;
            this.btnAddStudySession.Location = new System.Drawing.Point(376, 184);
            this.btnAddStudySession.Name = "btnAddStudySession";
            this.btnAddStudySession.Size = new System.Drawing.Size(212, 44);
            this.btnAddStudySession.TabIndex = 0;
            this.btnAddStudySession.Text = "Add Study Sessions";
            this.btnAddStudySession.UseVisualStyleBackColor = false;
            this.btnAddStudySession.Click += new System.EventHandler(this.btnAddStudySession_Click);
            // 
            // btnAddBreakSession
            // 
            this.btnAddBreakSession.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnAddBreakSession.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddBreakSession.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAddBreakSession.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddBreakSession.Location = new System.Drawing.Point(376, 234);
            this.btnAddBreakSession.Name = "btnAddBreakSession";
            this.btnAddBreakSession.Size = new System.Drawing.Size(212, 39);
            this.btnAddBreakSession.TabIndex = 1;
            this.btnAddBreakSession.Text = "Add Break Sessions";
            this.btnAddBreakSession.UseVisualStyleBackColor = false;
            this.btnAddBreakSession.Click += new System.EventHandler(this.btnAddBreakSession_Click);
            // 
            // btnViewReport
            // 
            this.btnViewReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnViewReport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnViewReport.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnViewReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewReport.Location = new System.Drawing.Point(376, 279);
            this.btnViewReport.Name = "btnViewReport";
            this.btnViewReport.Size = new System.Drawing.Size(212, 34);
            this.btnViewReport.TabIndex = 2;
            this.btnViewReport.Text = "View Report";
            this.btnViewReport.UseVisualStyleBackColor = false;
            this.btnViewReport.Click += new System.EventHandler(this.btnViewReport_Click);
            // 
            // btnPredictGrades
            // 
            this.btnPredictGrades.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnPredictGrades.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPredictGrades.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPredictGrades.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPredictGrades.Location = new System.Drawing.Point(376, 319);
            this.btnPredictGrades.Name = "btnPredictGrades";
            this.btnPredictGrades.Size = new System.Drawing.Size(212, 35);
            this.btnPredictGrades.TabIndex = 3;
            this.btnPredictGrades.Text = "Predict Grades";
            this.btnPredictGrades.UseVisualStyleBackColor = false;
            this.btnPredictGrades.Click += new System.EventHandler(this.btnPredictGrades_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Nirmala UI", 27.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(588, 50);
            this.label1.TabIndex = 4;
            this.label1.Text = "University Student performance ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Nirmala UI", 27.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Navy;
            this.label2.Location = new System.Drawing.Point(41, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(512, 50);
            this.label2.TabIndex = 5;
            this.label2.Text = "tracking and prediction tool";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(17, 184);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 24);
            this.label3.TabIndex = 6;
            this.label3.Text = "Enter Name";
            // 
            // textName
            // 
            this.textName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textName.Location = new System.Drawing.Point(143, 184);
            this.textName.Name = "textName";
            this.textName.Size = new System.Drawing.Size(161, 29);
            this.textName.TabIndex = 7;
            this.textName.TextChanged += new System.EventHandler(this.textName_TextChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.textName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnPredictGrades);
            this.Controls.Add(this.btnViewReport);
            this.Controls.Add(this.btnAddBreakSession);
            this.Controls.Add(this.btnAddStudySession);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAddStudySession;
        private System.Windows.Forms.Button btnAddBreakSession;
        private System.Windows.Forms.Button btnViewReport;
        private System.Windows.Forms.Button btnPredictGrades;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textName;
    }
}