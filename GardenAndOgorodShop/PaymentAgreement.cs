using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;
using Microsoft.Office.Interop.Excel;

namespace GardenAndOgorodShop
{

    public static class PaymentAgreement
    {
        public static async Task createExcelAgreement()
        {
            Excel.Application xlApp = null;
            Workbook xlWorkbook = null;
            Worksheet xlWorksheet = null;
            try
            {
                System.Data.DataTable products_order = await DBHandler.getProductsOrder_forBill();
                await Task.Run(() => // Выполняем в отдельном потоке
                {
                    xlApp = new Excel.Application();
                    xlWorkbook = xlApp.Workbooks.Open($"{Directory.GetCurrentDirectory()}\\templatesAgreements\\templateXLSX.xlsx");
                    xlWorksheet = (Excel.Worksheet)xlWorkbook.Sheets[1];

                    xlWorksheet.Range["B3"].Value2 = DateTime.Now.ToString(); // Заполняем ячейки
                    xlWorksheet.Range["B6"].Value2 = $"КАССИР {UserConfiguration.UserID}";
                    xlWorksheet.Range["B7"].Value2 = $"#{UserConfiguration.Current_order_id}";

                    int counter_row = 9;
                    double summ = 0;
                    if (products_order.Rows.Count > 0)
                    {
                        foreach (System.Data.DataRow product in products_order.Rows)
                        {
                            string title = $"{product[0]}";
                            string amount = $"{product[1]}";
                            string price = $"{Convert.ToDouble(product[2]) - Convert.ToDouble(product[2]) * (Convert.ToDouble(product[3]) / 100)}";
                            xlWorksheet.Range[$"A{counter_row}"].Value2 = title;
                            xlWorksheet.Range[$"B{counter_row}"].Value2 = $"{amount} x {price}";
                            counter_row++;
                            summ += Convert.ToDouble(product[1]) * Convert.ToDouble(price);
                            xlWorksheet.Range[$"B{counter_row}"].Value2 = $"{summ}";
                            counter_row++;
                        }
                    }
                    double nds = summ * 0.13;
                    xlWorksheet.Range[$"A{counter_row}"].Value2 = $"ИТОГ";
                    xlWorksheet.Range[$"B{counter_row}"].Value2 = $"{summ}";
                    xlWorksheet.Range[$"A{counter_row+=2}"].Value2 = $"НДС";
                    xlWorksheet.Range[$"B{counter_row}"].Value2 = $"{Math.Round(nds, 2)}";
                    if (!Directory.Exists("PaymentAgreements"))
                    {
                        try
                        {
                            Directory.CreateDirectory("PaymentAgreements");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Ошибка при создании папки '{"PaymentAgreements"}': {ex.Message}", "Создание папки", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    string path_name = $"PaymentAgreements\\Продажа {UserConfiguration.Current_order_id}.xlsx";

                    xlWorkbook.SaveAs($"{Directory.GetCurrentDirectory()}\\{path_name}");
                    xlWorkbook.Close();
                    xlApp.Quit();
                    MessageBox.Show($"Excel-чек создан, проверьте его по пути {path_name}");
                    string filePath = $"{Directory.GetCurrentDirectory()}\\{path_name}";

                    xlApp = new Excel.Application();
                    xlWorkbook = xlApp.Workbooks.Open(filePath);
                    xlWorksheet = (Worksheet)xlWorkbook.Sheets[1];

                    // Настраиваем параметры страницы (необязательно, но может помочь)
                    xlWorksheet.PageSetup.Orientation = XlPageOrientation.xlPortrait;
                    xlWorksheet.PageSetup.Zoom = false;
                    xlWorksheet.PageSetup.FitToPagesWide = 1;
                    xlWorksheet.PageSetup.FitToPagesTall = 1;

                    // Отображаем предварительный просмотр
                    xlApp.Visible = true; // Сначала делаем Excel видимым
                    xlWorksheet.PrintPreview(true);  // Затем открываем просмотр
                });

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при заполнении шаблона Excel: {ex.Message}");
            }
            finally
            {
                // Освобождаем COM-объекты (ОЧЕНЬ ВАЖНО!)
                if (xlWorksheet != null) Marshal.ReleaseComObject(xlWorksheet);
                if (xlWorkbook != null) Marshal.ReleaseComObject(xlWorkbook);
                if (xlApp != null) Marshal.ReleaseComObject(xlApp);
            }
        }
    }
}
