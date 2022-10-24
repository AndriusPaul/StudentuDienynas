using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using StudentuDienynas.Repo;
using System.Reflection.Metadata;
using IronPdf;

namespace StudentuDienynas.Classes
{
    public class SendingToEmail
    {
        public void SendEmail()
        {

            StudentsRepository student = new StudentsRepository();
            MarksRepository mark = new MarksRepository();
            SubjectRepository subject = new SubjectRepository();
            ReportGenerator reportGenerator = new ReportGenerator(student, mark, subject);
            GenerateHTML htmlGenerator = new GenerateHTML(reportGenerator);

            SendingToEmail email = new SendingToEmail();
            var studentList = htmlGenerator.GenerateHTMLWithColor();

            MailAddress to = new MailAddress("to@example.com");
            MailAddress from = new MailAddress("from@example.com");
            MailMessage message = new MailMessage(from, to);
            message.Subject = "Report";
            message.IsBodyHtml = true;
            message.Body = studentList;
            SmtpClient client = new SmtpClient("smtp.mailtrap.io", 2525)
            {
                Credentials = new NetworkCredential("7e71012932f43c", "2da6940405fbed"),
                EnableSsl = true
            };
            try
            {
                client.Send(message);
            }
            catch (SmtpException ex)
            {
                Console.WriteLine(ex.ToString());
            }

            Console.WriteLine("Email sent to " + to);

            System.IO.File.WriteAllText(@"C:\Users\AP\Desktop\New folder\BE\C#-Exam\StudentuDienynas\StudentuDienynas\report.html", studentList);
            var htmlToPdf = new HtmlToPdf();
            var pdfDocument = htmlToPdf.RenderHTMLFileAsPdf("report.html");
            pdfDocument.SaveAs("ataskaita.pdf");
        }
    }
}
