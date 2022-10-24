using IronPdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentuDienynas.Classes
{
    public class PDFGenerator
    {
        public void GeneratePDF() { 
        var htmlToPdf = new HtmlToPdf();
        var pdfDocument = htmlToPdf.RenderHTMLFileAsPdf("report.html");
        pdfDocument.SaveAs("ataskaita.pdf");
            Console.WriteLine("Ataskaita sukurta: ataskaita.pdf");
        }
    }
}
