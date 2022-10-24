using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentuDienynas.Classes
{
    public class Init
    {
        public void Initing()
        {
            while (true)
            {
                Methods methods = new Methods();
                GenerateMeniu meniu = new GenerateMeniu();
                int firstSelect = methods.GetFirstUserInputFromConsole();
                meniu.CreateMenu(firstSelect);
                Console.WriteLine("Jeigu norite pradeti is naujo, paspauskite 'Enter'");
                Console.ReadLine();
                Console.Clear();
            }
        }
    }
}
