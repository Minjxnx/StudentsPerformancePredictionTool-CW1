using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsPerformancePredictionTool_CW1.Models
{
    public class User
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public Dictionary<string, double> KnowledgeLevel { get; set; } = new Dictionary<string, double>();
        public List<StudySession> StudySessions { get; set; } = new List<StudySession>();
        public List<BreakSession> BreakSessions { get; set; } = new List<BreakSession>();
    }
}
