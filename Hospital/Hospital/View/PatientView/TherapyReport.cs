using Hospital.Repository;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Tables;
using System.Data;
using Hospital.Model;
using System.Windows;
using Hospital.Controller;

namespace Hospital.View.PatientView
{
    internal class TherapyReport
    {
        private App app;
        public Patient patient;

        public TherapyReport()
        {
            app = Application.Current as App;
            patient = app._patientController.ReadById(LogIn.LoggedUser.Id);
        }
        public void CreatePDF()
        {
            using (PdfDocument doc = new PdfDocument())
            {
                PdfPage page = doc.Pages.Add();
                PdfGraphics graphics = page.Graphics;
                PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 14);
                PdfFont fontHeader = new PdfStandardFont(PdfFontFamily.Helvetica, 17, PdfFontStyle.Bold);
                PdfFont fontSince = new PdfStandardFont(PdfFontFamily.Helvetica, 10);
                string zdravo = "ZDRAVO CORPORATION";
                graphics.DrawString(zdravo, fontHeader, PdfBrushes.Black, new System.Drawing.PointF(0, 0));
                string since = "Since 2022.";
                graphics.DrawString(since, fontSince, PdfBrushes.Black, new System.Drawing.PointF(0, 20));
                
                string textPDF = "Patient therapy report";
                graphics.DrawString(textPDF, font, PdfBrushes.Black, new System.Drawing.PointF(200, 80));
                PdfLightTable pdfLightTable = new PdfLightTable();
                DataTable table = new DataTable();
                table.Columns.Add("Id");
                table.Columns.Add("Medicine");
                table.Columns.Add("Time");
                table.Columns.Add("Text");
                foreach (Therapy therapy in app._therapyController.ReadBypatientId(patient.Id))
                {
                    table.Rows.Add(new string[]
                    {
                        therapy.Id.ToString(),
                        therapy.Medicine,
                        therapy.Time.ToString("dd.MM.yyyy HH:mm"),
                        therapy.TherapyText
                    });
                }
                pdfLightTable.DataSource = table;
                pdfLightTable.Style.ShowHeader = true;
                pdfLightTable.Draw(page, new System.Drawing.PointF(0, 150));
                doc.Save(@"C:\Users\Milina\Desktop\TherapyReport.pdf");
                doc.Close(true);
            }
        }

        public void GenerateReport()
        {
            CreatePDF();
        }

    }
}
