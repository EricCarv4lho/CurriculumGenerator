using CurriculumGenerator.Entities;
using iText.IO.Font;
using iText.IO.Font.Constants;
using iText.Kernel.Colors;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Borders;
using iText.Layout.Element;
using System.Runtime.CompilerServices;


namespace CurriculumGenerator.Services
{
    public class CurriculumService
    {
       
        private readonly PdfFont bold = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);
        public byte[] GenerateCurriculum(Curriculum curriculum)
        {
          using var memoryStream = new MemoryStream();

            
            var pdfWriter = new PdfWriter(memoryStream);
            var pdfDoc = new PdfDocument(pdfWriter);

            Document document = new(pdfDoc, iText.Kernel.Geom.PageSize.A4);

           
            document.Add(CreateHeaderTable(curriculum));
            document.Close();

            var result = memoryStream.ToArray();

            return result;
        }


        public Cell CreateCell(string text, int fontSize, int rowspan = 1, int colspan = 1)
        {
            
            Cell cell = new(rowspan, colspan);
            cell.Add(
                new Paragraph(text)
                .SetFontSize(fontSize)
                .SetBorder(Border.NO_BORDER)
                
                );
            
           

            return cell;
        }

        public Table CreateHeaderTable(Curriculum curriculum)
        {
            Table tableHeader = new(12);
            tableHeader.AddCell(CreateCell(curriculum.FullName, 20, 1,12).SetBorder(Border.NO_BORDER).SetFont(bold));
            tableHeader.AddCell(CreateCell(curriculum.ProfessionalTitle, 12, 1, 12).SetBorder(Border.NO_BORDER));
            tableHeader.AddCell(CreateCell($"{curriculum.City}, {curriculum.State}", 12, 1, 6).SetBorder(Border.NO_BORDER));
            tableHeader.AddCell(CreateCell(curriculum.PhoneNumber, 12, 1, 6).SetBorder(Border.NO_BORDER));

            tableHeader.AddCell(CreateCell(curriculum.Email, 12, 1, 12).SetBorder(Border.NO_BORDER).SetFontColor(new DeviceRgb(0, 0, 238)));
            tableHeader.AddCell(CreateCell(curriculum.LinkedinLink, 12, 1, 12).SetBorder(Border.NO_BORDER).SetFontColor(new DeviceRgb(0, 0, 238)));
            tableHeader.AddCell(CreateCell(curriculum.GitHubLink, 12, 1, 12).SetBorder(Border.NO_BORDER).SetFontColor(new DeviceRgb(0, 0, 238)));

               


            return tableHeader;
        }

      


    }
}
