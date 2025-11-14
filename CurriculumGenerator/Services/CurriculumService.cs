using CurriculumGenerator.Entities;
using iText.IO.Font.Constants;
using iText.Kernel.Colors;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Borders;
using iText.Layout.Element;


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
            document.Add(CreateCareerObjectiveSectionTable(curriculum));

            if (curriculum.Experiences != null && curriculum.Experiences.Count > 0)
            {
                document.Add(CreateExperienceSectionTable(curriculum));
            }

            document.Add(CreateEducationSectionTable(curriculum));

            if (curriculum.Languages != null && curriculum.Languages.Count > 0)
            {
                document.Add(CreateLanguageSectionTable(curriculum));
            }


            document.Close();

            var result = memoryStream.ToArray();

            return result;
        }


        private static Cell CreateCell(string text, int fontSize, int rowspan = 1, int colspan = 1)
        {

            Cell cell = new(rowspan, colspan);
            cell.Add(
                new Paragraph(text)
                .SetFontSize(fontSize)
                .SetBorder(Border.NO_BORDER)

                );



            return cell;
        }

        private Table CreateHeaderTable(Curriculum curriculum)
        {
            Table tableHeader = new(12);
            tableHeader.AddCell(CreateCell(curriculum.FullName, 20, 1, 12).SetBorder(Border.NO_BORDER).SetFont(bold));
            tableHeader.AddCell(CreateCell(curriculum.ProfessionalTitle, 12, 1, 12).SetBorder(Border.NO_BORDER));
            tableHeader.AddCell(CreateCell($"{curriculum.City}, {curriculum.State}", 12, 1, 6).SetBorder(Border.NO_BORDER));
            tableHeader.AddCell(CreateCell(curriculum.PhoneNumber, 12, 1, 6).SetBorder(Border.NO_BORDER));

            tableHeader.AddCell(CreateCell(curriculum.Email, 12, 1, 12).SetBorder(Border.NO_BORDER).SetFontColor(new DeviceRgb(0, 0, 238)));

            if(curriculum.LinkedinLink != null)
            tableHeader.AddCell(CreateCell(curriculum.LinkedinLink, 12, 1, 12).SetBorder(Border.NO_BORDER).SetFontColor(new DeviceRgb(0, 0, 238)));
            if(curriculum.GitHubLink != null)
            tableHeader.AddCell(CreateCell(curriculum.GitHubLink, 12, 1, 12).SetBorder(Border.NO_BORDER).SetFontColor(new DeviceRgb(0, 0, 238)));



            return tableHeader;
        }

        private Table CreateCareerObjectiveSectionTable(Curriculum curriculum)
        {
            Table tableCareerObjectiveSection = new(12);

            tableCareerObjectiveSection.AddCell(CreateCell("Objetivo", 16, 1, 12).SetBorder(Border.NO_BORDER).SetFont(bold));
            tableCareerObjectiveSection.AddCell(CreateCell(curriculum.CareerObjective, 12, 1, 12).SetBorder(Border.NO_BORDER));
            tableCareerObjectiveSection.SetMarginTop(15);
            return tableCareerObjectiveSection;
        }

        private Table CreateExperienceSectionTable(Curriculum curriculum)
        {

            var experiences = curriculum.Experiences;


            Table tableExperienceSection = new(12);

            tableExperienceSection.AddCell(CreateCell("Experiência", 16, 1, 12).SetBorder(Border.NO_BORDER).SetFont(bold));

            foreach (var experience in experiences)
            {
                string startDate = experience.StartDate.ToString("MM/yyyy");
                string? endDate = experience.EndDate.HasValue ? experience.EndDate?.ToString("MM/yyyy") : "Atualmente";

                tableExperienceSection.AddCell(CreateCell($"{experience.JobTitle} - {experience.CompanyName}", 12, 1, 12).SetBorder(Border.NO_BORDER));
                tableExperienceSection.AddCell(CreateCell($"{startDate} - {endDate}", 8, 1, 12).SetBorder(Border.NO_BORDER));
                tableExperienceSection.AddCell(CreateCell(experience.Description, 12, 1, 12).SetBorder(Border.NO_BORDER));
            }
            tableExperienceSection.SetMarginTop(15);
            return tableExperienceSection;
        }

        private Table CreateEducationSectionTable(Curriculum curriculum)
        {


            Table tableEducation = new(12);
            tableEducation.AddCell(CreateCell("Educação", 16, 1, 12).SetBorder(Border.NO_BORDER).SetFont(bold));

            foreach (var education in curriculum.EducationList)
            {

                string startDate = education.StartDate.ToString("MM/yyyy");
                string? endDate = education.EndDate.HasValue ? education.EndDate?.ToString("MM/yyyy") : "Atualmente";


                tableEducation.AddCell(CreateCell($"{education.Course} - {education.InstitutionName}", 12, 1, 12).SetBorder(Border.NO_BORDER));
                tableEducation.AddCell(CreateCell($"{startDate} - {endDate}", 8, 1, 12).SetBorder(Border.NO_BORDER));

            }

            tableEducation.SetMarginTop(15);
            return tableEducation;
        }


        private Table CreateLanguageSectionTable(Curriculum curriculum)
        {


            Table tableLanguage = new(12);
            tableLanguage.AddCell(CreateCell("Idiomas", 16, 1, 12).SetBorder(Border.NO_BORDER).SetFont(bold));

            foreach (var language in curriculum.Languages)
            {



                tableLanguage.AddCell(CreateCell($"{language.Name} {language.Proficiency}", 12, 1, 12).SetBorder(Border.NO_BORDER));

            }

            tableLanguage.SetMarginTop(15);
            return tableLanguage;
        }






    }




}

