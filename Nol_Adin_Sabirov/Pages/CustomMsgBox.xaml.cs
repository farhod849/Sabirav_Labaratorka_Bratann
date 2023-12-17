using Nol_Adin_Sabirov.Misc;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Microsoft.Office.Interop.Excel;
using Page = System.Windows.Controls.Page;
using Excel = Microsoft.Office.Interop.Excel;
using Window = Microsoft.Office.Interop.Excel.Window;
using Font = iTextSharp.text.Font;
using PdfPCell = iTextSharp.text.pdf.PdfPCell;
using System.Runtime.Remoting.Contexts;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace Nol_Adin_Sabirov.Pages
{
    /// <summary>
    /// Логика взаимодействия для CustomMsgBox.xaml
    /// </summary>
    public partial class CustomMsgBox : System.Windows.Window
    {
        public CustomMsgBox()
        {
            InitializeComponent();
        }

        private void Excel_Click(object sender, RoutedEventArgs e)
        {
            Excel.Application app = new Excel.Application()
            {
                Visible = true,
                SheetsInNewWorkbook = 2
            };
            Excel.Workbook workbook = app.Workbooks.Add(Type.Missing); app.DisplayAlerts = false;
            Excel.Worksheet sheet = (Excel.Worksheet)app.Worksheets.get_Item(1); sheet.Name = "Отчёт";
            sheet.Cells[1, 1] = "Наименование рейса"; sheet.Cells[1, 2] = "Дата";
            sheet.Cells[1, 3] = "Кол-во мест"; sheet.Cells[1, 4] = "Цена билета";
            sheet.Cells[1, 5] = "Стоимость проданных билетов";
            var currentRow = 2;
            var currentrow2 = 2;
            var prod = Conn.context.Spravochnaya.ToList(); foreach (var item in prod)
            {
                sheet.Cells[currentRow, 1] = item.NameReys;
                sheet.Cells[currentRow, 3] = item.KolVoSeat;
                currentRow++;
            }
            var a = 0;
            var ris = Conn.context.Ychetnaya.ToList();
            foreach (var item in ris)
            {
                sheet.Cells[currentrow2, 2] = item.DateVilet;
                sheet.Cells[currentrow2, 4] = item.PriceTicket;
                sheet.Cells[currentrow2, 5] = item.KolVoSells * item.PriceTicket;
                a += (int)(item.KolVoSells * item.PriceTicket);
                currentrow2++;
            }
            sheet.Cells[7, 1] = "Итого                                                     ";
            sheet.Cells[7, 5] = a.ToString();

            Excel.Range rang = sheet.get_Range("A1", "G7"); rang.Cells.Font.Name = "Times New Roman";

            rang.Cells.Font.Size = 10; rang.Font.Bold = true;
            rang.Font.Color = ColorTranslator.ToOle(System.Drawing.Color.Black);
            rang.Borders.Color = ColorTranslator.ToOle(System.Drawing.Color.Black);


        }

        private void PDF_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Document doc = new Document();
                PdfWriter.GetInstance(doc, new FileStream("Ведомость учета выручки.pdf", FileMode.Create));
                doc.Open();
                BaseFont baseFont = BaseFont.CreateFont(@"C:\Windows\Fonts\arial.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
                Font font = new Font(baseFont, Font.DEFAULTSIZE, Font.NORMAL);
                PdfPTable table = new PdfPTable(1);
                PdfPTable table2 = new PdfPTable(1);
                PdfPTable table3 = new PdfPTable(1);
                PdfPTable table4 = new PdfPTable(1);
                PdfPTable table5 = new PdfPTable(1);
                PdfPTable table6 = new PdfPTable(1);
                PdfPCell cell = new PdfPCell(new Phrase("Ведомость учета выручки от продажи билетов", font));
                cell.Colspan = 5;
                cell.HorizontalAlignment = 1;
                cell.Border = 0;
                table.AddCell(cell);
                table2.AddCell(cell);
                table3.AddCell(cell);
                table4.AddCell(cell);
                table5.AddCell(cell);

                table.AddCell(new PdfPCell(new Phrase(new Phrase("Наименование рейса", font))));
                table2.AddCell(new PdfPCell(new Phrase(new Phrase("Дата", font))));
                table3.AddCell(new PdfPCell(new Phrase(new Phrase("Кол-во мест", font))));
                table4.AddCell(new PdfPCell(new Phrase(new Phrase("Продано билетов", font))));
                table5.AddCell(new PdfPCell(new Phrase(new Phrase("Цена билета", font))));
                table6.AddCell(new PdfPCell(new Phrase(new Phrase("Стоимость проданных билетов", font))));
                var a = 0;
                for (int i = 0; i < Conn.context.Spravochnaya.ToList().Count; i++)
                {
                    var itemSprav = Conn.context.Spravochnaya.ToList()[i];
                    var itemYchet = Conn.context.Ychetnaya.ToList()[i];
                    table.AddCell(new Phrase(itemSprav.NameReys.ToString(), font));
                    table2.AddCell(new Phrase(itemYchet.DateVilet.ToString(), font));
                    table3.AddCell(new Phrase(itemSprav.NameReys.ToString(), font));
                    table4.AddCell(new Phrase(itemYchet.KolVoSells.ToString(), font));
                    table5.AddCell(new Phrase(itemYchet.PriceTicket.ToString(), font));
                    a = (int)(itemYchet.PriceTicket * itemYchet.KolVoSells);
                    table6.AddCell(new Phrase(a.ToString(), font));

                }
                doc.Add(table);
                doc.Add(table2);
                doc.Add(table3);
                doc.Add(table4);
                doc.Add(table5);
                doc.Close();
                MessageBox.Show("Pdf-документ сохранен");
            }
            catch
            {
                MessageBox.Show("Pdf-документ не сохранен", "Ошибка!");
            }
        }
    }
}
