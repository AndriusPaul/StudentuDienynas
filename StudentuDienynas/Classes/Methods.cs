using StudentuDienynas.Entities;
using StudentuDienynas.Repo;

namespace StudentuDienynas.Classes
{
    public class Methods
    {
        private SubjectRepository subject;
        private StudentsRepository students;
        private MarksRepository marks;
        private ReportGenerator reportGenerator;
        
        public Methods()
        {
            subject = new SubjectRepository();
            students = new StudentsRepository();
            marks = new MarksRepository();
            reportGenerator = new ReportGenerator(students,marks,subject);
        }
        public void AddStudent()
        {
           

            var s1 = new Student();
            var m1 = new Mark();
            Console.WriteLine("Studento ivedimas:");

            s1.StudentId = students.Retrieve().Count() + 1;

            Console.WriteLine("Iveskite varda");
            s1.Name = Console.ReadLine();
            Console.WriteLine("Iveskite pavarde");
            s1.Surname = Console.ReadLine();
            m1.Id = s1.StudentId;

            bool isValid = true;
            bool isValid2 = true;
            bool isValid3 = true;
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
            while (isValid2)
            {
                Console.WriteLine("Iveskite 2 trimestro pazymi (1-10)");
                int secondTrim = Convert.ToInt32(Console.ReadLine());
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
                int thirdTrim = Convert.ToInt32(Console.ReadLine());
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
                    Console.WriteLine("Pasirinkite skaiciu is duoto saraso");
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
          var allStudentsAndMarks = reportGenerator.GenerateStudentsAndTheirAllTrimAndYearAvr();
            students.Delete();
            foreach (var student in allStudentsAndMarks)
            {
                Console.WriteLine($"{student.StudentName} {student.StudentSurname} 1:{student.FirstTrim}; 2:{student.SecondTrim}; 3:{student.ThirdTrim}; Metinis: {Math.Round(student.YearAvarage, 2)}");
            }
        }
    }
}
