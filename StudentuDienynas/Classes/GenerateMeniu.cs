using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentuDienynas.Classes
{
    public class GenerateMeniu
    {
        public void CreateMenu(int userInput)
        {
            Methods methods = new Methods();
            switch (userInput)
            {
                case 1:
                    methods.AddStudent();
                    break;
                case 2:
                    methods.AllStudentList();
                    break;
                case 3:
                    methods.Report();
                    break;
                case 4:
                    methods.StudentsSubjectList();
                    break;
                case 5:
                    methods.SendEmail();
                    break;
                case 6:
                    methods.GeneratePDF();
                    break;
                case 7:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Pasirinkite skaiciu is Meniu");
                    break;


            }
        }
    }
}
