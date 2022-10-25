

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
                    methods.DeleteStudentById();
                    break;
                case 3:
                    methods.AllStudentList();
                    break;
                case 4:
                    methods.Report();
                    break;
                case 5:
                    methods.StudentsSubjectList();
                    break;
                case 6:
                    methods.SendEmail();
                    break;
                case 7:
                    methods.GeneratePDF();
                   break;
                case 8:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Pasirinkite skaiciu is Meniu");
                    break;


            }
        }
    }
}
