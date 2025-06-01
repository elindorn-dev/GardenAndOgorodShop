using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace GardenAndOgorodShop
{
    public static class Reports
    {
        static void ApplyBorderToCell(Worksheet xlWorksheet, int row, string column)
        {
            Range cellRange = xlWorksheet.Range[$"{column}{row}"];
            cellRange.Borders.LineStyle = XlLineStyle.xlContinuous;
            cellRange.Borders.Weight = XlBorderWeight.xlThin;
        }
        static public async Task ReportBalanceСontrol()
        {
            Excel.Application xlApp = null;
            Workbook xlWorkbook = null;
            Worksheet xlWorksheet = null;

            try
            {
                System.Data.DataTable products = await DBHandler.LoadData("products");
                await Task.Run(() => // Выполняем в отдельном потоке
                {
                    xlApp = new Excel.Application();
                    xlWorkbook = xlApp.Workbooks.Open($"{Directory.GetCurrentDirectory()}\\templatesAgreements\\templateReportControlProducts.xlsx");
                    xlWorksheet = (Excel.Worksheet)xlWorkbook.Sheets[1];

                    int counter_row = 17;
                    if (products.Rows.Count > 0)
                    {
                        foreach (System.Data.DataRow product in products.Rows)
                        {
                            xlWorksheet.Range[$"A{counter_row}"].Value2 = $"{product[1]}";
                            ApplyBorderToCell(xlWorksheet, counter_row, "A");
                            xlWorksheet.Range[$"B{counter_row}"].Value2 = $"{product[6]}";
                            ApplyBorderToCell(xlWorksheet, counter_row, "B");
                            xlWorksheet.Range[$"C{counter_row}"].Value2 = $"{product[3]}";
                            ApplyBorderToCell(xlWorksheet, counter_row, "C");
                            xlWorksheet.Range[$"D{counter_row}"].Value2 = $"{product[9]}";
                            ApplyBorderToCell(xlWorksheet, counter_row, "D");
                            xlWorksheet.Range[$"E{counter_row}"].Formula = $"=B{counter_row}*C{counter_row}";
                            ApplyBorderToCell(xlWorksheet, counter_row, "E");
                            xlWorksheet.Range[$"F{counter_row}"].Formula = $"=E{counter_row}-E{counter_row}*(D{counter_row}/100)";
                            ApplyBorderToCell(xlWorksheet, counter_row, "F");
                            counter_row++;
                        }
                        xlWorksheet.Range[$"D{counter_row}"].Value2 = $"ИТОГО:";
                        xlWorksheet.Range[$"F{counter_row}"].Value2 = $"ПОТЕРЯ:";
                        counter_row++;
                        string[] fields_diagram = { "", "", "" };
                        fields_diagram[0] = $"D{counter_row}";
                        xlWorksheet.Range[fields_diagram[0]].Formula = $"=SUM(E17:E{counter_row-2})";
                        fields_diagram[1] = $"E{counter_row}";
                        xlWorksheet.Range[fields_diagram[1]].Formula = $"=SUM(F17:F{counter_row-2})";
                        fields_diagram[2] = $"F{counter_row}";
                        xlWorksheet.Range[fields_diagram[2]].Formula = $"=D{counter_row}-E{counter_row}";
                        
                    }

                    ChartObjects xlCharts = (ChartObjects)xlWorksheet.ChartObjects(Type.Missing);
                    ChartObject myChart = (ChartObject)xlCharts.Add(40, 110, 350, 180);
                    Chart chart = myChart.Chart;
                    SeriesCollection seriesCollection = (SeriesCollection)chart.SeriesCollection(Type.Missing);
                    Series series = seriesCollection.NewSeries();
                    Array values = new object[] {
                        xlWorksheet.Range[$"D{counter_row}"].Value2,
                        xlWorksheet.Range[$"E{counter_row}"].Value2,
                        xlWorksheet.Range[$"F{counter_row}"].Value2
                    };
                    series.Values = values;
                    Array categories = new object[] { "Валовая прибыль (без скидки)", "Валовая прибыль (со скидкой)", "Потеря" };
                    series.XValues = categories;

                    chart.HasTitle = true;
                    chart.ChartTitle.Text = "Анализ ведения скидок";
                    chart.ChartType = XlChartType.xlPie;
                    chart.ApplyDataLabels(XlDataLabelsType.xlDataLabelsShowPercent,
                                           Missing.Value,
                                           Missing.Value,
                                           Missing.Value,
                                           Missing.Value,
                                           Missing.Value,
                                           Missing.Value,
                                           Missing.Value,
                                           Missing.Value,
                                           Missing.Value);

                    if (!Directory.Exists("ReportsControlProducts"))
                    {
                        try
                        {
                            Directory.CreateDirectory("ReportsControlProducts");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Ошибка при создании папки '{"ReportsControlProducts"}': {ex.Message}", "Создание папки", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    string path_name = $"ReportsControlProducts\\Контроль остатков {DateTime.Now.ToString("dd.MM.yyyy h.mm.ss")}.xlsx";
                    xlWorkbook.SaveAs($"{Directory.GetCurrentDirectory()}\\{path_name}");
                    xlWorkbook.Close();
                    xlApp.Quit();
                    MessageBox.Show($"Excel-отчёт создан, проверьте его по пути {path_name}");
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
        static public async Task ReportAnalyzOrders(string date_from, string date_to)
        {
            Excel.Application xlApp = null;
            Workbook xlWorkbook = null;
            Worksheet xlWorksheet = null;

            try
            {
                System.Data.DataTable orders = await DBHandler.LoadDataReportOrders(date_from, date_to);
                await Task.Run(() => // Выполняем в отдельном потоке
                {
                    xlApp = new Excel.Application();
                    xlWorkbook = xlApp.Workbooks.Open($"{Directory.GetCurrentDirectory()}\\templatesAgreements\\templateReportOrders.xlsx");
                    xlWorksheet = (Excel.Worksheet)xlWorkbook.Sheets[1];

                    int counter_row = 7;
                    double itogo = 0.0;
                    if (orders.Rows.Count > 0)
                    {
                        foreach (System.Data.DataRow product in orders.Rows)
                        {
                            xlWorksheet.Range[$"A{counter_row}"].Value2 = $"{product[0]}";
                            ApplyBorderToCell(xlWorksheet, counter_row, "A");
                            xlWorksheet.Range[$"B{counter_row}"].Value2 = $"{product[2]}";
                            ApplyBorderToCell(xlWorksheet, counter_row, "B");
                            xlWorksheet.Range[$"C{counter_row}"].Value2 = $"{product[8]} {product[9].ToString().Substring(0,1)}. {product[10].ToString().Substring(0, 1)}.";
                            ApplyBorderToCell(xlWorksheet, counter_row, "C");
                            xlWorksheet.Range[$"D{counter_row}"].Value2 = $"{product[3]}";
                            ApplyBorderToCell(xlWorksheet, counter_row, "D");
                            xlWorksheet.Range[$"E{counter_row}"].Value2 = $"{product[4]}";
                            ApplyBorderToCell(xlWorksheet, counter_row, "E");

                            double cost = Convert.ToDouble(product[5]);
                            itogo += cost;

                            xlWorksheet.Range[$"F{counter_row}"].Value2 = $"{cost.ToString().Replace(',', '.')}";
                            ApplyBorderToCell(xlWorksheet, counter_row, "F");
                            counter_row++;
                        }
                        string formula = $"=SUM(F20:F{counter_row--})";
                        counter_row += 2;
                        xlWorksheet.Range[$"E{counter_row}"].Value2 = $"ИТОГО:";
                        xlWorksheet.Range[$"F{counter_row}"].Value2 = $"{itogo}";
                    }
                    if (!Directory.Exists("ReportsAnalyzOrders"))
                    {
                        try
                        {
                            Directory.CreateDirectory("ReportsAnalyzOrders");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Ошибка при создании папки '{"ReportsAnalyzOrders"}': {ex.Message}", "Создание папки", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    string path_name = $"ReportsAnalyzOrders\\Анализ продажи от {date_from.Replace(':', '.')} до {date_to.Replace(':', '.')}.xlsx";
                    xlWorkbook.SaveAs($"{Directory.GetCurrentDirectory()}\\{path_name}");
                    xlWorkbook.Close();
                    xlApp.Quit();
                    MessageBox.Show($"Excel-отчёт создан, проверьте его по пути {path_name}");
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
        static public async Task ReportWroteProduct(string product_name, int amount, string desc)
        {
            Excel.Application xlApp = null;
            Workbook xlWorkbook = null;
            Worksheet xlWorksheet = null;

            try
            {
                System.Data.DataTable products = await DBHandler.LoadData("products");
                await Task.Run(() => // Выполняем в отдельном потоке
                {
                    xlApp = new Excel.Application();
                    xlWorkbook = xlApp.Workbooks.Open($"{Directory.GetCurrentDirectory()}\\templatesAgreements\\templateWritedProduct.xlsx");
                    xlWorksheet = (Excel.Worksheet)xlWorkbook.Sheets[1];

                    string FIO_employee = DBHandler.GetEmployee_FIO();

                    DateTime now = DateTime.Now;
                    string dateTimeString = now.ToString("F");
                    xlWorksheet.Range[$"A1"].Value2 = $"Списание товара от {dateTimeString}";
                    xlWorksheet.Range[$"B6"].Value2 = $"{FIO_employee}";
                    xlWorksheet.Range[$"B8"].Value2 = $"{product_name}";
                    xlWorksheet.Range[$"B9"].Value2 = $"{amount}";
                    xlWorksheet.Range[$"B11"].Value2 = $"{desc}";

                    if (!Directory.Exists("WritesProduct"))
                    {
                        try
                        {
                            Directory.CreateDirectory("WritesProduct");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Ошибка при создании папки '{"WritesProduct"}': {ex.Message}", "Создание папки", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    string path_name = $"WritesProduct\\Списание товара от {DateTime.Now.ToString("dd.MM.yyyy h.mm.ss")}.xlsx";
                    xlWorkbook.SaveAs($"{Directory.GetCurrentDirectory()}\\{path_name}");
                    xlWorkbook.Close();
                    xlApp.Quit();
                    MessageBox.Show($"Excel-отчёт создан, проверьте его по пути {path_name}");
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
