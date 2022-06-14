using Hospital.Repository;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Tables;
using System.Windows;
using System.Data;
using Hospital.Model;

namespace Hospital.View.ManagerView
{
    public class ManagerReport
    {

        EquipmentRepository equipmentRepository = new EquipmentRepository();

        public void CreatePDF()
        {
            using (PdfDocument doc = new PdfDocument())
            {
                PdfPage page = doc.Pages.Add();
                PdfGraphics graphics = page.Graphics;
                PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 12);
                string textPDF = "Hospital equipment report";
                graphics.DrawString(textPDF, font, PdfBrushes.Black, new PointF(0, 0));
                PdfLightTable pdfLightTable = new PdfLightTable();
                DataTable table = new DataTable();
                table.Columns.Add("Id");
                table.Columns.Add("Name");
                table.Columns.Add("Room");
                table.Columns.Add("Quantity");
                foreach(Equipment equipment in equipmentRepository.Read())
                {
                    table.Rows.Add(new string[]
                    {
                    equipment.Id.ToString(),
                    equipment.Name,
                    equipment.Room,
                    equipment.Number.ToString()
                    });
                }
                pdfLightTable.DataSource = table;
                pdfLightTable.Style.ShowHeader = true;
                pdfLightTable.Draw(page, new PointF(0, 100));
                doc.Save(@"C:\Users\Nemanja\Desktop\SIMS\SIMS-projekat\Hospital\Hospital\Report\ManagerReport.pdf");
                doc.Close(true);
            }
        }

        public void GenerateReport()
        {
            CreatePDF();
        }
    }
}
