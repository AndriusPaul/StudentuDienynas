using StudentuDienynas.Entities;
using StudentuDienynas.Repo;

namespace TestProject1
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void SaveStudent_WhenMultipleObjectsCreated_ReturnsMultipleObjects()
        {
            //Arrange
            var studentai = new StudentsRepository();
            var s1 = new Student();
            var s2 = new Student();
            var s3 = new Student();

            s1.StudentId = 21;
            s1.Name = "Jonas";
            s1.Surname = "Jonaitis";

            s2.StudentId = 22;
            s2.Name = "Petras";
            s2.Surname = "Petraitis";

            s3.StudentId = 23;
            s3.Name = "Linas";
            s3.Surname = "Linaitis";

            //Act

            studentai.Save(s1);
            studentai.Save(s2);
            studentai.Save(s3);
            List<Student> resultatas = studentai.Retrieve();

            //Assert
            Assert.AreEqual(23, resultatas.Count);
        }
        [Test]

        public void GetSubjectByID_WhenGivenID_ReturnsSubjectName()
        {
            //Arrange
            SubjectRepository subject = new SubjectRepository();

            Subject sj1 = new Subject
            {
                Id = 21,
                SubjectName = "Anglu kalba",
                SubjectName2 = "Lietuviu kalba",
                SubjectName3 = "Informatika",
                SubjectName4 = "Fizika",
            };
            //Act
            subject.Save(sj1);
            
            var result = subject.Retrieve(21);
            var expected = result.SubjectName4;
            //Assert
            Assert.AreEqual(expected, result.SubjectName4);
        }
    }
}