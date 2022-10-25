using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentuDienynas.Entities
{
    public class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public string FullName
        {
            get { return Name + " " + Surname; }
        }
        public Student()
        {
        }

        public Student(int id, string name, string surname)
        {
            StudentId = id;
            Name = name;
            Surname = surname;
        }
    }
}
