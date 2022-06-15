using System;
using System.Data;
using System.Drawing;
using System.Windows;
using System.Windows.Controls;
using Hospital.Model;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Grid;

namespace Hospital.View.DoctorView.Checkup
{
    public partial class ReportUC : UserControl
    {
        private Patient _patient;
        private string _text;
        public ReportUC(Patient patient, String text)
        {
            _patient = patient;
            _text = text;
            InitializeComponent();
        }

        private void Confirm_OnClick(object sender, RoutedEventArgs e)
        {
            if (CheckupToggleSwitch.IsEnabled)
            {
                CreateCheckupPDF();
            }

            if (PrescriptionToggleSwitch.IsEnabled)
            {
                CreatePrescriptionPDF();
            }
        }

        private void CreateCheckupPDF()
        {
            PdfDocument doc = new PdfDocument();
            PdfPage page = doc.Pages.Add();
            PdfGraphics graphics = page.Graphics;

            PdfBrush solidBrush = new PdfSolidBrush(new PdfColor(66, 165, 245));
            RectangleF bounds = new RectangleF(0, 0, graphics.ClientSize.Width, 30);
            graphics.DrawRectangle(solidBrush, bounds);
            PdfFont subHeadingFont = new PdfStandardFont(PdfFontFamily.Helvetica, 15);
            PdfTextElement element = new PdfTextElement("Anamnesis", subHeadingFont);
            element.Brush = PdfBrushes.White;

            PdfLayoutResult result = element.Draw(page, new PointF(10, bounds.Top + 8));
            string currentDate = "DATE " + DateTime.Now.ToString("dd.M.yyyy.");
            SizeF textSize = subHeadingFont.MeasureString(currentDate);
            PointF textPosition = new PointF(graphics.ClientSize.Width - textSize.Width - 10, result.Bounds.Y);
            graphics.DrawString(currentDate, subHeadingFont, element.Brush, textPosition);

            PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 28);
            graphics.DrawString("Zdravo Hospital", font, solidBrush, new PointF(180, 70));
            PdfBitmap image = new PdfBitmap("../../View/DoctorView/Resources/Images/logo_green.png");
            bounds = new RectangleF(0, bounds.Bottom, 150, 150);
            graphics.DrawImage(image, bounds);

            DataTable dataTable = new DataTable();

            dataTable.Columns.Add("Name");
            dataTable.Columns.Add("Surname");
            dataTable.Columns.Add("Gender");
            dataTable.Columns.Add("Health insurance ID");
            dataTable.Columns.Add("Blood type");

            if (_patient != null)
            {
                dataTable.Rows.Add(_patient.Name, _patient.LastName, _patient.Gender,
                    _patient.HealthInsuranceId, _patient.BloodType);
            }

            PdfGrid grid = new PdfGrid();
            grid.DataSource = dataTable;
            PdfGridCellStyle cellStyle = new PdfGridCellStyle();
            cellStyle.Borders.All = PdfPens.White;
            PdfGridRow header = grid.Headers[0];

            PdfGridCellStyle headerStyle = new PdfGridCellStyle();
            headerStyle.Borders.All = new PdfPen(new PdfColor(66, 165, 245));
            headerStyle.BackgroundBrush = new PdfSolidBrush(new PdfColor(66, 165, 245));
            headerStyle.TextBrush = PdfBrushes.White;
            headerStyle.Font = new PdfStandardFont(PdfFontFamily.TimesRoman, 13, PdfFontStyle.Regular);

            for (int i = 0; i < header.Cells.Count; i++)
            {
                header.Cells[i].StringFormat = new PdfStringFormat(PdfTextAlignment.Center, PdfVerticalAlignment.Middle);
            }

            header.ApplyStyle(headerStyle);
            PdfGridRow row = grid.Rows[0];

            cellStyle.Borders.All = new PdfPen(new PdfColor(217, 217, 217), 0.70f);
            cellStyle.Font = new PdfStandardFont(PdfFontFamily.TimesRoman, 12f);
            cellStyle.TextBrush = new PdfSolidBrush(new PdfColor(131, 130, 136));
            cellStyle.StringFormat = new PdfStringFormat(PdfTextAlignment.Center, PdfVerticalAlignment.Middle);
            row.ApplyStyle(cellStyle);

            PdfGridLayoutFormat layoutFormat = new PdfGridLayoutFormat();
            layoutFormat.Layout = PdfLayoutType.Paginate;
            PdfGridLayoutResult gridResult = grid.Draw(page,
                new RectangleF(new PointF(0, bounds.Bottom + 5),
                    new SizeF(graphics.ClientSize.Width, graphics.ClientSize.Height - 100)), layoutFormat);

            var brush = new PdfSolidBrush(new PdfColor(50, 50, 50));

            font = new PdfStandardFont(PdfFontFamily.Helvetica, 14);
            graphics.DrawString(_text, font, brush,
                new RectangleF(new PointF(0, gridResult.Bounds.Bottom + 20),
                    new SizeF(graphics.ClientSize.Width, graphics.ClientSize.Height - 100)));


            doc.Save("../../View/DoctorView/Resources/Reports/Checkup--" + DateTime.Now.ToString("dd-MM-yyyy--HH-mm-ss") +
                     ".pdf");
            doc.Close(true);
        }

        private void CreatePrescriptionPDF()
        {
            PdfDocument doc = new PdfDocument();
            PdfPage page = doc.Pages.Add();
            PdfGraphics graphics = page.Graphics;

            PdfBrush solidBrush = new PdfSolidBrush(new PdfColor(66, 165, 245));
            RectangleF bounds = new RectangleF(0, 0, graphics.ClientSize.Width, 30);
            graphics.DrawRectangle(solidBrush, bounds);
            PdfFont subHeadingFont = new PdfStandardFont(PdfFontFamily.Helvetica, 15);
            PdfTextElement element = new PdfTextElement("Prescription", subHeadingFont);
            element.Brush = PdfBrushes.White;

            PdfLayoutResult result = element.Draw(page, new PointF(10, bounds.Top + 8));
            string currentDate = "DATE " + DateTime.Now.ToString("dd.M.yyyy.");
            SizeF textSize = subHeadingFont.MeasureString(currentDate);
            PointF textPosition = new PointF(graphics.ClientSize.Width - textSize.Width - 10, result.Bounds.Y);
            graphics.DrawString(currentDate, subHeadingFont, element.Brush, textPosition);

            PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 28);
            graphics.DrawString("Zdravo Hospital", font, solidBrush, new PointF(180, 70));
            PdfBitmap image = new PdfBitmap("../../View/DoctorView/Resources/Images/logo_green.png");
            bounds = new RectangleF(0, bounds.Bottom, 150, 150);
            graphics.DrawImage(image, bounds);

            DataTable dataTable = new DataTable();

            dataTable.Columns.Add("Name");
            dataTable.Columns.Add("Surname");
            dataTable.Columns.Add("Gender");
            dataTable.Columns.Add("Health insurance ID");
            dataTable.Columns.Add("Blood type");

            if (_patient != null)
            {
                dataTable.Rows.Add(_patient.Name, _patient.LastName, _patient.Gender,
                    _patient.HealthInsuranceId, _patient.BloodType);
            }

            PdfGrid grid = new PdfGrid();
            grid.DataSource = dataTable;
            PdfGridCellStyle cellStyle = new PdfGridCellStyle();
            cellStyle.Borders.All = PdfPens.White;
            PdfGridRow header = grid.Headers[0];

            PdfGridCellStyle headerStyle = new PdfGridCellStyle();
            headerStyle.Borders.All = new PdfPen(new PdfColor(66, 165, 245));
            headerStyle.BackgroundBrush = new PdfSolidBrush(new PdfColor(66, 165, 245));
            headerStyle.TextBrush = PdfBrushes.White;
            headerStyle.Font = new PdfStandardFont(PdfFontFamily.TimesRoman, 13, PdfFontStyle.Regular);

            for (int i = 0; i < header.Cells.Count; i++)
            {
                header.Cells[i].StringFormat = new PdfStringFormat(PdfTextAlignment.Center, PdfVerticalAlignment.Middle);
            }

            header.ApplyStyle(headerStyle);
            PdfGridRow row = grid.Rows[0];

            cellStyle.Borders.All = new PdfPen(new PdfColor(217, 217, 217), 0.70f);
            cellStyle.Font = new PdfStandardFont(PdfFontFamily.TimesRoman, 12f);
            cellStyle.TextBrush = new PdfSolidBrush(new PdfColor(131, 130, 136));
            cellStyle.StringFormat = new PdfStringFormat(PdfTextAlignment.Center, PdfVerticalAlignment.Middle);
            row.ApplyStyle(cellStyle);

            PdfGridLayoutFormat layoutFormat = new PdfGridLayoutFormat();
            layoutFormat.Layout = PdfLayoutType.Paginate;
            PdfGridLayoutResult gridResult = grid.Draw(page,
                new RectangleF(new PointF(0, bounds.Bottom + 5),
                    new SizeF(graphics.ClientSize.Width, graphics.ClientSize.Height - 100)), layoutFormat);

            var brush = new PdfSolidBrush(new PdfColor(50, 50, 50));

            font = new PdfStandardFont(PdfFontFamily.Helvetica, 14);
            graphics.DrawString(_text, font, brush,
                new RectangleF(new PointF(0, gridResult.Bounds.Bottom + 20),
                    new SizeF(graphics.ClientSize.Width, graphics.ClientSize.Height - 100)));


            doc.Save("../../View/DoctorView/Resources/Reports/Prescription--" + DateTime.Now.ToString("dd-MM-yyyy--HH-mm-ss") +
                     ".pdf");
            doc.Close(true);
        }

        private void Cancel_OnClick(object sender, RoutedEventArgs e)
        {
            MainWindow.MainFrame.GoBack();
        }
    }
}