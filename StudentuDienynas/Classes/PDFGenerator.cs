using IronPdf;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentuDienynas.Classes
{
    public class PDFGenerator
    {
        public void GeneratePDF() { 
        var htmlToPdf = new HtmlToPdf();
        var pdfDocument = htmlToPdf.RenderHTMLFileAsPdf("C:\\Users\\AP\\Desktop\\New folder\\BE\\C#-Exam\\StudentuDienynas\\StudentuDienynas\\report.html");
        pdfDocument.SaveAs("ataskaita.pdf");
            Console.WriteLine("Ataskaita sukurta: ataskaita.pdf");
        }
        public void OpenFile(string fileName)
        {
            ProcessStartInfo pi = new ProcessStartInfo(fileName);
            pi.Arguments = Path.GetFileName(fileName);
            pi.UseShellExecute = true;
            pi.WorkingDirectory = Path.GetDirectoryName(fileName);
            pi.FileName = fileName;
            pi.Verb = "OPEN";
            Process.Start(pi);
        }
    }
}
