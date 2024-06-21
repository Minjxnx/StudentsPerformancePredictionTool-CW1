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
    }
}
