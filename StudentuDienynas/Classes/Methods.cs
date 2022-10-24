using StudentuDienynas.Entities;
using StudentuDienynas.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentuDienynas.Classes
{
    public class Methods
    {
        public void AddStudent()
        {
            StudentsRepository students = new StudentsRepository();
            MarksRepository marks = new MarksRepository();

            var s1 = new Student();
            var m1 = new Mark();
            Console.WriteLine("Studento ivedimas:");
            Console.WriteLine("Iveskite studento ID");
            bool isCorrect = true;
            while (isCorrect)
            {
                int id = Convert.ToInt32(Console.ReadLine());
                if (id != s1.StudentId || id != 0)
                {
                    s1.StudentId = id;
                    isCorrect = false;
                }
                else
                {
                    Console.WriteLine("bandykite dar karta");
                    isCorrect = true;
                }

            }

            Console.WriteLine("Iveskite varda");
            s1.Name = Console.ReadLine();
            Console.WriteLine("Iveskite pavarde");
            s1.Surname = Console.ReadLine();
            m1.Id = s1.StudentId;

            bool isValid = true;
            while (isValid)
            {
                Console.WriteLine("Iveskite 1 trimestro pazymi (1-10)");
                int firstTrim = Convert.ToInt32(Console.ReadLine());
                if (firstTrim > 0 && firstTrim <= 10)
                {
                    m1.FirstTrim = firstTrim;
                    isValid = false;
                }
                else
                {
                    Console.WriteLine("Patikrinkite ar teisingai ivedate pazymi.");
                }
            };
            while (isValid)
            {
                Console.WriteLine("Iveskite 2 trimestro pazymi (1-10)");
                int secondTrim = Convert.ToInt32(Console.ReadLine());
                if (secondTrim > 0 && secondTrim <= 10)
                {
                    m1.SecondTrim = secondTrim;
                    isValid = false;
                }
                else
                {
                    Console.WriteLine("Patikrinkite ar teisingai ivedate pazymi.");
                }
            };
            while (isValid)
            {
                Console.WriteLine("Iveskite 3 trimestro pazymi (1-10)");
                int thirdTrim = Convert.ToInt32(Console.ReadLine());
                if (thirdTrim > 0 && thirdTrim <= 10)
                {
                    m1.ThirdTrim = thirdTrim;
                    isValid = false;
                }
                else
                {
                    Console.WriteLine("Patikrinkite ar teisingai ivedate pazymi.");
                }
            };
            students.Save(s1);
            marks.Save(m1);

            Console.WriteLine("Studentas sekmingai pridetas");
        }
        public int GetFirstUserInputFromConsole()
        {
            bool isCorrectNumber = false;
            int argumentValue = 0;

            while (!isCorrectNumber)
            {
                Console.WriteLine("Meniu:\n [1] Prideti Studenta\n [2] Esamas studentu sarasas\n [3] Rodyti studentus kuriu metinis (ivesti)\n [4] Studentu dalyku sarasas\n [5] Siusti ataskaita i el. pasta\n [6] Iseiti is programos\n");
                string userInputValue = Console.ReadLine();

                if (int.TryParse(userInputValue, out argumentValue))
                {
                    isCorrectNumber = true;
                }
                else
                {
                    Console.WriteLine("Pasirinkite skaiciu is duoto saraso");
                }

            }
            return argumentValue;
        }
        public int GetSecondUserInputFromConsole()
        {
            bool isCorrectNumber = false;
            int argumentValue = 0;

            while (!isCorrectNumber)
            {
                string userInputValue = Console.ReadLine();

                if (int.TryParse(userInputValue, out argumentValue))
                {
                    isCorrectNumber = true;
                }
                else
                {
                    Console.WriteLine("Pasirinkite skaiciu is duoto saraso");
                }

            }
            return argumentValue;
        }
        public void Report()
        {
            StudentsRepository students = new StudentsRepository();
            MarksRepository marks = new MarksRepository();
            SubjectRepository subjects = new SubjectRepository();
            ReportGenerator reportGenerator = new ReportGenerator(students, marks, subjects);
            var above6 = reportGenerator.GenerateStudentWithAverageAbove();

            foreach (var item in above6)
            {
                Console.WriteLine($"{item.StudentSurname}: metinis pazymys  {Math.Round(item.YearAvarage, 2)}");
            }


        }

        public void AllStudentList()
        {
            StudentsRepository students = new StudentsRepository();
            MarksRepository marks = new MarksRepository();
            SubjectRepository subjects = new SubjectRepository();
            ReportGenerator reportGenerator = new ReportGenerator(students, marks, subjects);

            var allStudentsAndMarks = reportGenerator.GenerateStudentsAndTheirAllTrimAndYearAvr();

            foreach (var student in allStudentsAndMarks)
            {
                Console.WriteLine($"{student.StudentName} {student.StudentSurname} 1:{student.FirstTrim}; 2:{student.SecondTrim}; 3:{student.ThirdTrim}; Metinis: {Math.Round(student.YearAvarage, 2)}");
            }



        }
        public void StudentsSubjectList()
        {
            StudentsRepository students = new StudentsRepository();
            MarksRepository marks = new MarksRepository();
            SubjectRepository subjects = new SubjectRepository();
            ReportGenerator reportGenerator = new ReportGenerator(students, marks, subjects);

            var allStudentsAndSubject = reportGenerator.GenerateStudentsSubjects();
            foreach (var student in allStudentsAndSubject)
            {
                Console.WriteLine($"{student.StudentName} {student.StudentSurname}: {student.SubjectName}; {student.SubjectName2}; {student.SubjectName3}; {student.SubjectName4}");
            }
        }
        public void SendEmail()
        {
            SendingToEmail email = new SendingToEmail();
            email.SendEmail();
        }
    }
}
