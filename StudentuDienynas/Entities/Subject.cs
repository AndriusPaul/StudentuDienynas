using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentuDienynas.Entities
{
    public class Subject
    {
        public int Id { get; set; }
        public string SubjectName { get; set; }
        public string SubjectName2 { get; set; }
        public string SubjectName3 { get; set; }
        public string SubjectName4 { get; set; }
        
        public Subject(int id, string subjectName, string subjectName2,string subjectName3, string subjectName4)
        {
            Id = id;
            SubjectName = subjectName;
            SubjectName2 = subjectName2;
            SubjectName3 = subjectName3;
            SubjectName4 = subjectName4;
        }
    }
}
