using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentuDienynas.Classes
{
    public class ReportItem
    {
        public string StudentName { get; set; }
        public string StudentSurname { get; set; }
        public decimal FirstTrim { get; set; }
        public decimal SecondTrim { get; set; }
        public decimal ThirdTrim { get; set; }
        public decimal YearAvarage { get; set; }
        public string SubjectName { get; set; }
        public string SubjectName2 { get; set; }
        public string SubjectName3 { get; set; }
        public string SubjectName4 { get; set; }

        public ReportItem()
        {
        }
        public ReportItem(string studentName, string studentSurname, decimal firstTrim, decimal secondTrim, decimal thirdTrim, decimal yearAvarage)
        {
            StudentName = studentName;
            StudentSurname = studentSurname;
            FirstTrim = firstTrim;
            SecondTrim = secondTrim;
            ThirdTrim = thirdTrim;
            YearAvarage = yearAvarage;
        }


    }
}
