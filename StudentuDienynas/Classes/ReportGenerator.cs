using StudentuDienynas.Entities;
using StudentuDienynas.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentuDienynas.Classes
{
    public class ReportGenerator
    {
        private StudentsRepository _student;
        private MarksRepository _marks;
        private SubjectRepository _subject;

        public ReportGenerator(StudentsRepository student, MarksRepository marks, SubjectRepository subject)
        {
            _student = student;
            _marks = marks;
            _subject = subject;
        }

        public List<ReportItem> GenerateStudentWithAverageAbove()
        {
            Console.WriteLine("Iveskite pazymi nuo kurio norite isfiltruoti studentus");
            var input2 = Convert.ToInt32(Console.ReadLine());
            List<Student> students = _student.Retrieve();
            List<ReportItem> reportItems = new List<ReportItem>();

            foreach (var student in students)
            {
                var marks = _marks.Retrieve(student.StudentId);
                var subject = _subject.Retrieve(marks.StudentId);
                if (marks.Total >= input2)
                {
                    reportItems.Add(new ReportItem()
                    {
                        StudentName = student.Name,
                        StudentSurname = student.Surname,
                        FirstTrim = marks.FirstTrim,
                        SecondTrim = marks.SecondTrim,
                        ThirdTrim = marks.ThirdTrim,
                        YearAvarage = marks.Total,
                    });

                }
            }
            return reportItems;
        }
        public List<ReportItem> GenerateStudentsSubjects()
        {
            List<Student> students = _student.Retrieve();
            List<ReportItem> reportItems = new List<ReportItem>();

            foreach (var student in students)
            {
                var subject = _subject.Retrieve(student.StudentId);

                reportItems.Add(new ReportItem()
                {
                    StudentName = student.Name,
                    StudentSurname = student.Surname,
                    SubjectName = subject.SubjectName,
                    SubjectName2 = subject.SubjectName2,
                    SubjectName3 = subject.SubjectName3,
                    SubjectName4 = subject.SubjectName4,
                });
            }
            return reportItems;
        }
        public List<ReportItem> GenerateStudentsAndTheirAllTrimAndYearAvr()
        {
            List<Student> students = _student.Retrieve();
            List<ReportItem> reportItems = new List<ReportItem>();

            foreach (var student in students)
            {
                var marks = _marks.Retrieve(student.StudentId);

                reportItems.Add(new ReportItem()
                {
                    StudentName = student.Name,
                    StudentSurname = student.Surname,
                    FirstTrim = marks.FirstTrim,
                    SecondTrim = marks.SecondTrim,
                    ThirdTrim = marks.ThirdTrim,
                    YearAvarage = marks.Total,
                });
            }
            return reportItems;
        }
    }
}

