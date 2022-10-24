using StudentuDienynas.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentuDienynas.Repo
{
    public class StudentsRepository
    {
        private List<Student> Students { get; set; }
        public StudentsRepository()
        {
            Students = new List<Student>();
            Students.Add(new Student(1, "Tomas", "Tamasauskas"));
            Students.Add(new Student(2, "Linas", "Linauskas"));
            Students.Add(new Student(3, "Jonas", "Jonaitis"));
            Students.Add(new Student(4, "Eddie", "Wardel"));
            Students.Add(new Student(5, "Bay", "Comoletti"));
            Students.Add(new Student(6, "Harbert", "Uwins"));
            Students.Add(new Student(7, "Caresa", "Rowney"));
            Students.Add(new Student(8, "Shelly", "Seedhouse"));
            Students.Add(new Student(9, "Homer", "Crannach"));
            Students.Add(new Student(10, "Abrahan", "Turk"));
            Students.Add(new Student(11, "Koo", "Blazeby"));
            Students.Add(new Student(12, "Mollie", "Glide"));
            Students.Add(new Student(13, "Hortensia", "Vaneschi"));
            Students.Add(new Student(14, "Juliane", "Janicek"));
            Students.Add(new Student(15, "Sayer", "Domm"));
            Students.Add(new Student(16, "Jules", "Kirkland"));
            Students.Add(new Student(17, "Georgiana", "Murcott"));
            Students.Add(new Student(18, "Carlota", "Dedman"));
            Students.Add(new Student(19, "Randell", "Flecknoe"));
            Students.Add(new Student(20, "Phedra", "Sturdy"));
        }
        public List<Student> Retrieve()
        {
            return Students;
        }
        public Student Retrieve(int studentId)
        {
            return Students.SingleOrDefault(x => x.StudentId == studentId);
        }
        public void Save(Student entity)
        {
            Students.Add(entity);
        }
    }
}
