using System.Diagnostics;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System;
using System.Reflection;
using System.Drawing.Imaging;
using ToolLib;

namespace ImmManager
{
    public class Report
    {

        public static void generateReport(SWInfo sw)
        {
            string[,] info = new string[,] {
                {"Calculation Items","Your Condition","Your Points" },
                {"Some NOC codes could get bonus",sw.NOC,sw.NocBonusPoints.ToString()},
                {"Skill level and points",sw.SkillLevel.ToString(),sw.JobLevelPoints.ToString()},
                {"Is your job in Top 100",sw.Intop100?"Yes":"No",sw.Top100Bonus.ToString()},
                {"Current in BC working in same occupation",sw.CurrentWorkInBCPosition?"Yes":"No",sw.CurrentWorkPoints.ToString()},
                {"Annual job wage",sw.Wage.ToString(), sw.WagePoints.ToString()},
                {"Work region", sw.Region,sw.RegionPoints.ToString()},
                {"Direct related work experience",sw.DirectWorkExperience.ToString(),sw.DirectWorkExperiencePoints.ToString()},
                {"One year direct experience in Canada",sw.OneYearDirectExperienceInCanada?"Yes":"No",sw.OneYearDirectExperienceInCanadaPoints.ToString()},
                {"Education Level",sw.Education, sw.EducationPoints.ToString()},
                {"Education bonus",sw.EducationBonus,sw.EducationBonusPoints.ToString() },
                {"CLB Luange level",sw.CLB.ToString(),sw.CLBPoints.ToString()}
            };



            Document doc = new Document(PageSize.LETTER, 72, 72, 72, 72);
            
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string fn = path + @"\BCPNP-SW Points-" + sw.Client + DateTime.Now.ToString("yyMMdd") + "-" + String.Format("{0:hh}", DateTime.Now) + String.Format("{0:mm}", DateTime.Now) + String.Format("{0:ss}", DateTime.Now) + ".pdf";
            PdfWriter.GetInstance(doc, new FileStream(fn, FileMode.Create));

            doc.Open();

            // add a img to pdf

            iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(@"Resources\logo.png");

            img.SetAbsolutePosition(toUnit(5f), toUnit(9.75f));
            // set the size to be 2.5 inch x 1.5 inch
            img.ScaleToFit(toUnit(2.5f), toUnit(1.5f));
            doc.Add(img);

            doc.Add(new Paragraph("\n\n\n"));

            PDFItems font = new PDFItems();

            Paragraph Title = (new Paragraph(18.5f, " BCPNP Skill Worker Scoring Anlaysis", font.fontLevel3) { SpacingAfter = 15 });
            Paragraph paraforClient = (new Paragraph(18.5f, "For: " + sw.Client + "   Date: " + DateTime.Today.ToString("MMM-dd,yyyy") + "     Total Points: " + sw.TotalPoints.ToString(), font.fontLevel6) { SpacingAfter = 10 });
            Title.Alignment = Element.ALIGN_CENTER;
            paraforClient.Alignment = Element.ALIGN_CENTER;
            ////para.IndentationRight = 10;
            doc.Add(Title);
            doc.Add(paraforClient);


            PdfPTable table = new PdfPTable(3);
            float[] sglTblHdWidths = new float[3];
            sglTblHdWidths[0] = 300f;
            sglTblHdWidths[1] = 200f;
            sglTblHdWidths[2] = 100f;
            // Set the column widths on table creation. Unlike HTML cells cannot be sized.
            table.SetWidths(sglTblHdWidths);

            table.HorizontalAlignment = Element.ALIGN_MIDDLE;
            // float[] width = new float[3] { toUnit(2.17f),toUnit(2.17f),toUnit(2.17f)};
            table.WidthPercentage = 100;
            table.GetFittingRows(18f, 0);
            PdfPCell cell = new PdfPCell(new Phrase((sw.Client + " Scores in detail\n"), font.fontLevel5));
            cell.Colspan = 3;

            cell.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right
            table.AddCell(cell);


            for(int i = 0; i < info.Length / 3; i++)
            {
                table.AddCell(info[i, 0]);
                table.AddCell(info[i, 1]);
                table.AddCell(info[i, 2]);

            }

            doc.Add(table);


            Chunk thanks = new Chunk("\nThanks for your enquiry.\nIf you have further requirement for how to upgrade your scores, please make an appointment with our ICCRC licensed Immigration Consultant.\n\n");
            //  sign.Leading = 36;
            doc.Add(thanks);
            //RCICSigning(doc);
            //table.SpacingAfter = 0;
            //Chunk sign = new Chunk("Jacky Zhang\nRCIC: R511623\n");
            //doc.Add(sign);

            //float curY = writer.GetVerticalPosition(false);
            //float x = doc.Left + sign.GetWidthPoint();
            //MessageBox.Show(x.ToString());

            Chunk contact1 = new Chunk("\n\n\nContact Information\nGuangson Headquarter:\n#1017 4500 Kingsway, Burnaby V5H 2A9\nEmail:info@guangson.com\tTel:+ 1 604 - 282 - 1536");
            //contact1.Font = fontBody;
            doc.Add(contact1);

            

            Chunk contact2 = new Chunk("\nGuangson Immigration:\n#2319 4500 Kingsway, Burnaby V5H 2A9\nEmail:immigration@guangson.com\t+ 1 604-558-1536");
            //contact2.Font = cxfontLevel1;
            doc.Add(contact2);
            //BaseFont.AddToResourceSearch("iTextAsian.dll");
            BaseFont bfChinese = BaseFont.CreateFont(
               "MHei-Medium",
               "UniCNS-UCS2-H", // 橫式中文
               BaseFont.NOT_EMBEDDED
            );
            Font fontChinese = new Font(bfChinese, 8);
            doc.Add(new Paragraph(
                @"聰明難，糊塗難，
                由聰明而轉入糊塗更難，
                放一著，退一步，當下心安，非圖後來福報也。",
                fontChinese
            ));
            doc.Add(new Paragraph(
                @"1991年9月—1996年6月：
                哈尔滨市马家沟小学
                1996年9月—2000年6月：
                哈尔滨市萧红中学
                2000年9月—2003年6月：
                哈尔滨市第十三中学
                2003年9月—2005年5月：
                加拿大多伦多Seneca学院（ESL）
                2006年9月—2010年6月:
                哈尔滨师范大学运动训练专业",
                fontChinese
            ));


            doc.Close();

            // Open the new created pdf
            System.Diagnostics.Process.Start(fn);


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
