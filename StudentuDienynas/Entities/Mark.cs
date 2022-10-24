using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentuDienynas.Entities
{
    public class Mark
    {
        public int Id { get; set; }
        public int FirstTrim { get; set; }
        public int SecondTrim { get; set; }
        public int ThirdTrim { get; set; }
        public decimal Total
        {
            get { return (FirstTrim + SecondTrim + ThirdTrim) / 3M; }
        }
        public Mark()
        {

        }
        public Mark(int id, int firstTrim, int secondTrim, int thirdTrim)
        {
            Id = id;
            FirstTrim = firstTrim;
            SecondTrim = secondTrim;
            ThirdTrim = thirdTrim;
        }
    }
}
