using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentuDienynas.Classes
{
    public class GenerateHTML
    {
        private ReportGenerator _reportGenerator { get; set; }

        public GenerateHTML(ReportGenerator reportGenerator)
        {
            _reportGenerator = reportGenerator;
        }
        public string GenerateHTMLWithColor()
        {
            var generateStudentsWithInputYearMarks = _reportGenerator.GenerateStudentWithAverageAbove();
            var studentList = _reportGenerator.GenerateStudentsAndTheirAllTrimAndYearAvr();
            var studentAndSubject = _reportGenerator.GenerateStudentsSubjects();
            string html = "<!doctype html><html><head><meta http-equiv=”Content-Type”/><meta name=”viewport”/><title>Report</title></head><body><table style= width:100%>";

            html += "<tr>";
            html += "<th style='background-color: #cee6ef;border: 1px solid #ccc'>Student Name</th>";
            html += "<th style='background-color: #cee6ef;border: 1px solid #ccc'>Student Surname</th>";
            html += "<th style='background-color: #cee6ef;border: 1px solid #ccc'>First Trimester</th>";
            html += "<th style='background-color: #cee6ef;border: 1px solid #ccc'>Second Trimester</th>";
            html += "<th style='background-color: #cee6ef;border: 1px solid #ccc'>Third Trimister</th>";
            html += "<th style='background-color: #cee6ef;border: 1px solid #ccc'>Year Average</th>";
            html += "</tr>";

            foreach (var student in generateStudentsWithInputYearMarks)
            {

                html += "<tr>";
                html += "<td style='background-color: #cee6ef; border: 1px solid #ccc'>" + student.StudentName + "</td>";
                html += "<td style='background-color: #cee6ef; border: 1px solid #ccc'>" + student.StudentSurname + "</td>";
                html += "<td style='background-color: #cee6ef; border: 1px solid #ccc'>" + student.FirstTrim + "</td>";
                html += "<td style='background-color: #cee6ef; border: 1px solid #ccc'>" + student.SecondTrim + "</td>";
                html += "<td style='background-color: #cee6ef; border: 1px solid #ccc'>" + student.ThirdTrim + "</td>";
                html += "<td style='background-color: #cee6ef; border: 1px solid #ccc'>" + Math.Round(student.YearAvarage, 2) + "</td>";
                html += "</tr>";
            }
            html += "</table>";
            html += "<div style= height:20px></div>";
            html += "<table style= width:100%>";
            html += "<tr>";
            html += "<th style='background-color: #ff8e8e;border: 1px solid #ccc'>Student Name</th>";
            html += "<th style='background-color: #ff8e8e;border: 1px solid #ccc'>Student Surname</th>";
            html += "<th style='background-color: #ff8e8e;border: 1px solid #ccc'>First Trimester</th>";
            html += "<th style='background-color: #ff8e8e;border: 1px solid #ccc'>Second Trimester</th>";
            html += "<th style='background-color: #ff8e8e;border: 1px solid #ccc'>Third Trimister</th>";
            html += "<th style='background-color: #ff8e8e;border: 1px solid #ccc'>Year Average</th>";
            html += "</tr>";


            foreach (var student in studentList)
            {

                html += "<tr>";
                html += "<td style='background-color: #ff8e8e; border: 1px solid #ccc'>" + student.StudentName + "</td>";
                html += "<td style='background-color: #ff8e8e; border: 1px solid #ccc'>" + student.StudentSurname + "</td>";
                html += "<td style='background-color: #ff8e8e; border: 1px solid #ccc'>" + student.FirstTrim + "</td>";
                html += "<td style='background-color: #ff8e8e; border: 1px solid #ccc'>" + student.SecondTrim + "</td>";
                html += "<td style='background-color: #ff8e8e; border: 1px solid #ccc'>" + student.ThirdTrim + "</td>";
                html += "<td style='background-color: #ff8e8e; border: 1px solid #ccc'>" + Math.Round(student.YearAvarage, 2) + "</td>";
                html += "</tr>";
            }
            html += "</table>";
            html += "<div style= height:20px></div>";
            html += "<table style= width:100%>";
            html += "<tr>";
            html += "<th style='background-color: #5b99f7;border: 1px solid #ccc'>Student Name</th>";
            html += "<th style='background-color: #5b99f7;border: 1px solid #ccc'>Student Surname</th>";
            html += "<th style='background-color: #5b99f7;border: 1px solid #ccc'>Subject One</th>";
            html += "<th style='background-color: #5b99f7;border: 1px solid #ccc'>Subject Two</th>";
            html += "<th style='background-color: #5b99f7;border: 1px solid #ccc'>Subject Three</th>";
            html += "<th style='background-color: #5b99f7;border: 1px solid #ccc'>Subject Four</th>";
            html += "</tr>";

            foreach (var student in studentAndSubject)
            {

                html += "<tr>";
                html += "<td style='background-color: #5b99f7; border: 1px solid #ccc'>" + student.StudentName + "</td>";
                html += "<td style='background-color: #5b99f7; border: 1px solid #ccc'>" + student.StudentSurname + "</td>";
                html += "<td style='background-color: #5b99f7; border: 1px solid #ccc'>" + student.SubjectName + "</td>";
                html += "<td style='background-color: #5b99f7; border: 1px solid #ccc'>" + student.SubjectName2 + "</td>";
                html += "<td style='background-color: #5b99f7; border: 1px solid #ccc'>" + student.SubjectName3 + "</td>";
                html += "<td style='background-color: #5b99f7; border: 1px solid #ccc'>" + student.SubjectName4 + "</td>";
                html += "</tr>";
            }
            html += "</table></body>";

            return html;

        }

    }
}

