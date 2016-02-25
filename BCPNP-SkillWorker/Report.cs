using System.Diagnostics;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace ImmManager
{
    public class Report
    {

        public static void generateReport(SWInfo sw)
        {

            Font fontLevel1 = FontFactory.GetFont("Arial", 24, Font.BOLD, BaseColor.BLACK);
            Font fontLevel2 = FontFactory.GetFont("Arial", 20, Font.BOLD, BaseColor.BLACK);
            Font fontLevel3 = FontFactory.GetFont("Arial", 18, Font.BOLD, BaseColor.BLACK);
            Font fontLevel4 = FontFactory.GetFont("Arial", 18, Font.BOLD, BaseColor.BLACK);
            Font fontTitle3 = FontFactory.GetFont("Arial", 16, Font.BOLD, BaseColor.BLACK);
            Font fontTitle4 = FontFactory.GetFont("Arial", 12, Font.BOLD, BaseColor.BLACK);
            Font fontBody = FontFactory.GetFont("Arial", 10, Font.BOLD, BaseColor.BLACK);
            Font fontFoot = FontFactory.GetFont("Arial", 10, Font.BOLD, BaseColor.BLACK);
            Font fontNote = FontFactory.GetFont("Arial", 10, Font.ITALIC, BaseColor.BLUE);
            // setup Chinese fonts
            // Kai Fonts
            string cfontpath = @"C:\C#\Chinesefonts\XinshuFont.ttf";
            BaseFont bf = BaseFont.CreateFont(cfontpath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
            Font cfontContent = new Font(bf, 11);
            Font cfontHeader = new Font(bf, 12);

            //Kai Fonts
            string cfontpath1 = @"C:\C#\Chinesefonts\kaiBoldFont.ttf";
            BaseFont bf1 = BaseFont.CreateFont(cfontpath1, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
            Font cfontNote = new Font(bf1, 10);

            Font cfontLevel1 = new Font(bf1, 24);
            Font cfontLevel2 = new Font(bf1, 24);
            Font cfontLevel3 = new Font(bf1, 24);
            Font cfontLevel4 = new Font(bf1, 24);
            Font cfontLevel5 = new Font(bf1, 24);



            Document doc = new Document(PageSize.LETTER, 72, 72, 72, 72);

            PdfWriter.GetInstance(doc, new FileStream(@"c:\vba\hello.pdf", FileMode.Create));

            doc.Open();

            // add a img to pdf
            Image img = Image.GetInstance(@"c:\vba\logo.png");
            img.SetAbsolutePosition(toUnit(5.5f), toUnit(9.75f));
            // set the size to be 2.5 inch x 1.5 inch
            img.ScaleToFit(toUnit(2.5f), toUnit(1.5f));
            doc.Add(img);

            doc.Add(new Paragraph("\n\n\n"));

            Paragraph Title = (new Paragraph(18.5f, " BCPNP Skill Worker Consultation", fontLevel1) { SpacingAfter = 5 });
            Paragraph paraforClient = (new Paragraph(18.5f, "For: " + sw.Client + "   Date:" + DateTime.Today.ToString("MMM-dd,yyyy"), cfontLevel4) { SpacingAfter = 5 });
            Title.Alignment = Element.ALIGN_CENTER;
            paraforClient.Alignment = Element.ALIGN_CENTER;
            ////para.IndentationRight = 10;
            doc.Add(Title);
            doc.Add(paraforClient);

            doc.Add(new Phrase(18.5f, "\nNOC: " + sw.NOC + "     Total Points: " + sw.TotalPoints.ToString() + "\n\n", fontTitle4));

            //p.IndentationRight = 100;
            //p.IndentationLeft = 100;
            PdfPTable table = new PdfPTable(3);

            table.HorizontalAlignment = Element.ALIGN_MIDDLE;
            // float[] width = new float[3] { toUnit(2.17f),toUnit(2.17f),toUnit(2.17f)};
            table.WidthPercentage = 100;
            table.GetFittingRows(18f, 0);
            PdfPCell cell = new PdfPCell(new Phrase((sw.Client + " Scores in detail"), fontTitle3));
            cell.Colspan = 3;

            cell.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right
            table.AddCell(cell);


            table.AddCell("Client");
            table.AddCell("NOC");
            table.AddCell("Total Points");



            PdfPCell c21 = new PdfPCell(new Phrase(sw.Client));
            table.AddCell(c21);
            c21.HorizontalAlignment = 1;

            PdfPCell c22 = new PdfPCell(new Phrase(sw.NOC));
            c22.HorizontalAlignment = 1;
            table.AddCell(c22);

            PdfPCell c23 = new PdfPCell(new Phrase(sw.TotalPoints.ToString()));
            c23.HorizontalAlignment = 1;
            table.AddCell(c23);

            table.AddCell("00 Bonus");
            table.AddCell("Skill Level");
            table.AddCell("Top 100 Bonus");
            PdfPCell c31 = new PdfPCell(new Phrase(sw.NocBonusPoints.ToString()));
            table.AddCell(c31);
            c31.HorizontalAlignment = 1;

            PdfPCell c32 = new PdfPCell(new Phrase(sw.SkillLevelPoints.ToString()));
            c32.HorizontalAlignment = 1;
            table.AddCell(c32);

            PdfPCell c33 = new PdfPCell(new Phrase(sw.Top100Bonus.ToString()));
            c33.HorizontalAlignment = 1;
            table.AddCell(c33);

            table.AddCell("Current working in BC");
            table.AddCell("Annual Wage points");
            table.AddCell("Region points");
            PdfPCell c41 = new PdfPCell(new Phrase(sw.CurrentWorkPoints.ToString()));
            table.AddCell(c41);
            c41.HorizontalAlignment = 1;

            PdfPCell c42 = new PdfPCell(new Phrase(sw.WagePoints.ToString()));
            c42.HorizontalAlignment = 1;
            table.AddCell(c42);

            PdfPCell c43 = new PdfPCell(new Phrase(sw.RegionPoints.ToString()));
            c43.HorizontalAlignment = 1;
            table.AddCell(c43);

            table.AddCell("Direct Work Exp");
            table.AddCell("1 year in BC");
            table.AddCell("Education points");
            PdfPCell c51 = new PdfPCell(new Phrase(sw.DirectWorkExperiencePoints.ToString()));
            table.AddCell(c51);
            c51.HorizontalAlignment = 1;

            PdfPCell c52 = new PdfPCell(new Phrase(sw.OneYearDirectExperienceInCanadaPoints.ToString()));
            c52.HorizontalAlignment = 1;
            table.AddCell(c52);

            PdfPCell c53 = new PdfPCell(new Phrase(sw.EducationPoints.ToString()));
            c53.HorizontalAlignment = 1;
            table.AddCell(c53);

            table.AddCell("Education Bonus");
            table.AddCell("Language points");

            PdfPCell c61 = new PdfPCell(new Phrase(sw.EducationBonusPoints.ToString()));
            table.AddCell(c61);
            c61.HorizontalAlignment = 1;

            PdfPCell c62 = new PdfPCell(new Phrase(sw.CLBPoints.ToString()));
            c62.HorizontalAlignment = 1;
            table.AddCell(c62);



            doc.Add(table);


            Chunk thanks = new Chunk("\n\nThanks for your enquiry\n\n");
            //  sign.Leading = 36;
            doc.Add(thanks);
            RCICSigning(doc);
            table.SpacingAfter = 0;
            Chunk sign = new Chunk("Jacky Zhang\nRCIC: R511623\n");
            doc.Add(sign);

            //float curY = writer.GetVerticalPosition(false);
            //float x = doc.Left + sign.GetWidthPoint();
            //MessageBox.Show(x.ToString());


            doc.Close();

            //MessageBox.Show("File created");

            // Open the new created pdf
            System.Diagnostics.Process.Start(@"c:\vba\hello.pdf");


        }

        private static void RCICSigning(Document doc)
        {
            Image signature = Image.GetInstance(@"c:\vba\Signature.jpg");
            //signature.SetAbsolutePosition(toUnit(5.5f), toUnit(9.75f));
            // set the size to be 2.5 inch x 1.5 inch
            signature.ScaleToFit(toUnit(1.2f), toUnit(0.6f));
            doc.Add(signature);
        }

        public static float toUnit(float inch)
        {

            return inch * 72;
        }

    }

    public class SWInfo
    {

        public string Client { get; set; }
        public int TotalPoints { get; set; }

        public string NOC { get; set; }
        public char SkillLevel { get; set; }
        public bool Intop100 { get; set; }
        public bool CurrentWorkInBCPosition { get; set; }
        public float Wage { get; set; }
        public string Region { get; set; }
        public float DirectWorkExperience { get; set; }
        public bool OneYearDirectExperienceInCanada { get; set; }
        public string Education { get; set; }
        public string EducationBonus { get; set; }
        public int CLB { get; set; }
        public float[] WageDetail { get; set; }  // Working hours per week, hourly rate, monthly rate and annual salary
        public float[] IELTS { get; set; }       // IETLS: listening, reading, writing and speaking
        public int[] CLEPIPG14 { get; set; }     // CELPIP 2014:listening, reading, writing and speaking
        public string[] CELPIPG13 { get; set; }  // CELPIP 2013:listening, reading, writing and speaking

        public int NocBonusPoints { get; set; }
        public int JobLevelPoints { get; set; }
        public int CurrentWorkPoints { get; set; }
        public int WagePoints { get; set; }
        public int RegionPoints { get; set; }
        public int OccupationBonus { get; set; }
        public int SkillLevelPoints { get; set; }
        public int Top100Bonus { get; set; }
        public int DirectWorkExperiencePoints { get; set; }
        public int OneYearDirectExperienceInCanadaPoints { get; set; }
        public int EducationPoints { get; set; }
        public int EducationBonusPoints { get; set; }
        public int CLBPoints { get; set; }


    }
}
