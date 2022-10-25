using StudentuDienynas.Entities;
using StudentuDienynas.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentuDienynas.Classes
{
    public class Init
    {
        private SubjectRepository subject;
        private StudentsRepository students;
        private MarksRepository marks;
        private ReportGenerator reportGenerator;
        public Init()
        {
            subject = new SubjectRepository();
            students = new StudentsRepository();
            marks = new MarksRepository();
            reportGenerator = new ReportGenerator(students, marks, subject);
        }
        public void Start()
        {
            while (true)
            {
                
                int firstSelect = GetFirstUserInputFromConsole();
                CreateMenu(firstSelect);
                Console.WriteLine("Jeigu norite pradeti is naujo, paspauskite 'Enter'");
                Console.ReadLine();
                Console.Clear();
            }

        }
        public void CreateMenu(int userInput)
        {
            
            switch (userInput)
            {
                case 1:
                    AddStudent();
                    break;
                case 2:
                   DeleteStudentById();
                    break;
                case 3:
                    AllStudentList();
                    break;
                case 4:
                    Report();
                    break;
                case 5:
                    StudentsSubjectList();
                    break;
                case 6:
                    SendEmail();
                    break;
                case 7:
                    GeneratePDF();
                    break;
                case 8:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Pasirinkite skaiciu is Meniu");
                    break;


            }
        }
        public void AddStudent()
        {
            var s1 = new Student();
            var m1 = new Mark();
            Console.WriteLine("Studento ivedimas:");
            var id = students.Retrieve().Count() + 1;


            s1.StudentId = id;

            Console.WriteLine("Iveskite varda");
            s1.Name = Console.ReadLine();
            Console.WriteLine("Iveskite pavarde");
            s1.Surname = Console.ReadLine();
            m1.StudentId = s1.StudentId;

            bool isValid = true;
            bool isValid2 = true;
            bool isValid3 = true;
            while (isValid)
            {
                Console.WriteLine("Iveskite 1 trimestro pazymi (1-10)");
                int firstTrim = GetSecondUserInputFromConsole();
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
            while (isValid2)
            {
                Console.WriteLine("Iveskite 2 trimestro pazymi (1-10)");
                int secondTrim = GetSecondUserInputFromConsole();
                if (secondTrim > 0 && secondTrim <= 10)
                {
                    m1.SecondTrim = secondTrim;
                    isValid2 = false;
                }
                else
                {
                    Console.WriteLine("Patikrinkite ar teisingai ivedate pazymi.");
                }
            };
            while (isValid3)
            {
                Console.WriteLine("Iveskite 3 trimestro pazymi (1-10)");
                int thirdTrim = GetSecondUserInputFromConsole();
                if (thirdTrim > 0 && thirdTrim <= 10)
                {
                    m1.ThirdTrim = thirdTrim;
                    isValid3 = false;
                }
                else
                {
                    Console.WriteLine("Patikrinkite ar teisingai ivedate pazymi.");
                }
            };
            students.Save(s1);
            marks.Save(m1);

            Console.WriteLine("Studentas sekmingai pridetas");

            var allStudentsAndMarks = reportGenerator.GenerateStudentsAndTheirAllTrimAndYearAvr();

            foreach (var student in allStudentsAndMarks)
            {
                Console.WriteLine($"{student.StudentName} {student.StudentSurname} 1:{student.FirstTrim}; 2:{student.SecondTrim}; 3:{student.ThirdTrim}; Metinis: {Math.Round(student.YearAvarage, 2)}");
            }
        }
        public int GetFirstUserInputFromConsole()
        {
            bool isCorrectNumber = false;
            int argumentValue = 0;

            while (!isCorrectNumber)
            {
                Console.WriteLine("Meniu:\n [1] Prideti Studenta\n [2] Pasalinti studenta\n [3] Esamas studentu sarasas\n [4] Rodyti studentus kuriu metinis (ivesti)\n [5] Studentu dalyku sarasas\n [6] Siusti ataskaita i el. pasta\n [7] Atspausdinti ataskaita PDF\n [8] Iseiti is programos\n");
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
                    Console.WriteLine("Iveskite skaiciu");
                }

            }
            return argumentValue;
        }
        public void Report()
        {

            var average = reportGenerator.GenerateStudentWithAverageAbove();

            foreach (var item in average)
            {
                Console.WriteLine($"{item.StudentSurname}: metinis pazymys  {Math.Round(item.YearAvarage, 2)}");
            }


        }
        public void AllStudentList()
        {

            var allStudentsAndMarks = reportGenerator.GenerateStudentsAndTheirAllTrimAndYearAvr();

            foreach (var student in allStudentsAndMarks)
            {
                Console.WriteLine($"{student.StudentName} {student.StudentSurname} 1:{student.FirstTrim}; 2:{student.SecondTrim}; 3:{student.ThirdTrim}; Metinis: {Math.Round(student.YearAvarage, 2)}");
            }
        }
        public void StudentsSubjectList()
        {
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
        public void GeneratePDF()
        {
            PDFGenerator pdf = new PDFGenerator();
            pdf.GeneratePDF();
            pdf.OpenFile("ataskaita.pdf");
        }
        public void DeleteStudentById()
        {
            Console.WriteLine("Iveskite ID kuri studenta norite pasalinti");

            int studentId = int.Parse(Console.ReadLine());
            if(studentId == 0)
            {
                Console.WriteLine("Toks neegzistuoja");
            }
            else {
            students.Delete(studentId);
                marks.Delete(studentId);
            }
        }
    }
}
