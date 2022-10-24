using StudentuDienynas.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace StudentuDienynas.Repo
{
    public class SubjectRepository
    {
      private List<Subject> Subjects { get; set; }
        public SubjectRepository()
        {
            Subjects = new List<Subject>();
            Subjects.Add(new Subject(1, "Rusu kalba", "Matematika", "Lietuviu kalba", "Istorija"));
            Subjects.Add(new Subject(2, "Vokieciu kalba", "Matematika", "Lietuviu kalba", "Chemija"));
            Subjects.Add(new Subject(3, "Anglu kalba", "Matematika", "Lietuviu kalba", "Informatika"));
            Subjects.Add(new Subject(4, "Fizika", "Matematika", "Lietuviu kalba", "Informatika"));
            Subjects.Add(new Subject(5, "Anglu kalba", "Matematika", "Lietuviu kalba", "Informatika"));
            Subjects.Add(new Subject(6, "Anglu kalba", "Chemija", "Lietuviu kalba", "Informatika"));
            Subjects.Add(new Subject(7, "Anglu kalba", "Matematika", "Lietuviu kalba", "Fizika"));
            Subjects.Add(new Subject(8, "Anglu kalba", "Kuno Kultura", "Lietuviu kalba", "Geografija"));
            Subjects.Add(new Subject(9, "Anglu kalba", "Matematika", "Lietuviu kalba", "Informatika"));
            Subjects.Add(new Subject(10, "Anglu kalba", "Matematika", "Lietuviu kalba", "Informatika"));
            Subjects.Add(new Subject(11, "Biologija", "Matematika", "Lietuviu kalba", "Informatika"));
            Subjects.Add(new Subject(12, "Anglu kalba", "Fizinis", "Lietuviu kalba", "Informatika"));
            Subjects.Add(new Subject(13, "Anglu kalba", "Matematika", "Lietuviu kalba", "Informatika"));
            Subjects.Add(new Subject(14, "Geografija", "Matematika", "Lietuviu kalba", "Informatika"));
            Subjects.Add(new Subject(15, "Istorija", "Matematika", "Lietuviu kalba", "Informatika"));
            Subjects.Add(new Subject(16, "Anglu kalba", "Matematika", "Lietuviu kalba", "Informatika"));
            Subjects.Add(new Subject(17, "Vokieciu kalba", "Daile", "Lietuviu kalba", "Informatika"));
            Subjects.Add(new Subject(18, "Anglu kalba", "Matematika", "Lietuviu kalba", "Muzika"));
            Subjects.Add(new Subject(19, "Anglu kalba", "Matematika", "Lietuviu kalba", "Informatika"));
            Subjects.Add(new Subject(20, "Anglu kalba", "Matematika", "Lietuviu kalba", "Geografija"));
        }
        public List<Subject> Retrieve()
        {
            return Subjects;
        }
        public Subject Retrieve(int subjectId)
        {
            return Subjects.SingleOrDefault(x => x.Id == subjectId);
        }
    }
}
