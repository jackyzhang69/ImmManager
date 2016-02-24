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
            //string cfontpath = @"C:\C#\Chinesefonts\XinshuFont.ttf";
            //BaseFont bf = BaseFont.CreateFont(cfontpath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
            //Font cfontContent = new Font(bf, 11);
            //Font cfontHeader = new Font(bf, 12);

            // Kai Fonts
            //static string cfontpath-1 = @"C:\C#\Chinesefonts\kaiBoldFont.ttf";
            //static BaseFont bf-1 = BaseFont.CreateFont(cfontpath-1, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
            //static Font cfontContent-1 = new Font(bf-1, 11);
            //static Font cfontHeader-1 = new Font(bf-1, 12);


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
            Paragraph paraforClient = (new Paragraph(18.5f, "For: " + sw.Client + "   Date:" + DateTime.Today.ToString("MMM-dd,yyyy"), fontLevel2) { SpacingAfter = 5 });
            Title.Alignment = Element.ALIGN_CENTER;
            paraforClient.Alignment = Element.ALIGN_CENTER;
            ////para.IndentationRight = 10;
            doc.Add(Title);
            doc.Add(paraforClient);

            doc.Add(new Phrase(18.5f, "\nNOC: " + sw.NOC + "\t\tTotal Points: " + sw.TotalPoints.ToString() + "\n\n", fontTitle4));

            //p.IndentationRight = 100;
            //p.IndentationLeft = 100;
            PdfPTable table = new PdfPTable(3);

            table.HorizontalAlignment = Element.ALIGN_MIDDLE;
            // float[] width = new float[3] { toUnit(2.17f),toUnit(2.17f),toUnit(2.17f)};
            table.WidthPercentage = 100;
            table.GetFittingRows(18f, 0);
            PdfPCell cell = new PdfPCell(new Phrase((sw.Client + " BCPNP Skill Worker Scores"), fontLevel4));
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

            PdfPCell c32 = new PdfPCell(new Phrase(sw.TotalPoints.ToString()));
            c32.HorizontalAlignment = 1;
            table.AddCell(c32);



            doc.Add(table);


            Chunk thanks = new Chunk("Thanks for your enquiry\n\n");
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
            Process myProcess = new Process();
            myProcess.StartInfo.FileName = "acroRd32.exe"; //not the full application path
            myProcess.StartInfo.Arguments = @" C:\vba\hello.pdf";
            myProcess.Start();

        }

        private static void RCICSigning(Document doc)
        {
            Image signature = Image.GetInstance(@"c:\vba\signature-jacky.png");
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
