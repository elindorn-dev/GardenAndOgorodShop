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
                    ChartObject myChart = (ChartObject)xlCharts.Add(25, 100, 350, 180);
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
                    chart.ChartTitle.Text = "Распределение данных";
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
                    

                    string path_name = $"ReportsControlProducts\\Контроль остатков {DateTime.Now.ToString("dd.MM.yyyy h.mm.ss")}.xlsx";
                    xlWorkbook.SaveAs($"{Directory.GetCurrentDirectory()}\\{path_name}");
                    xlWorkbook.Close();
                    xlApp.Quit();
                    MessageBox.Show($"Excel-отчёт создан, проверьте его по пути {path_name}");
                    string filePath = $"{Directory.GetCurrentDirectory()}\\{path_name}";

                    // Создаем экземпляр Excel
                    Excel.Application excelApp = new Excel.Application();
                    excelApp.Visible = true; // Делаем Excel видимым

                    // Открываем документ
                    Excel.Workbook workbook = excelApp.Workbooks.Open(filePath);

                    // Устанавливаем режим просмотра на печать
                    excelApp.ActiveWindow.View = Excel.XlWindowView.xlPageLayoutView;
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




            //try
            //{
            //    Excel.Application application = new Excel.Application();
            //    application.Workbooks.Add(Type.Missing);
            //    Worksheet sheet = (Worksheet)application.Sheets[1];

            //    await Task.Run(() =>
            //    {
            //        for (int i = 1; i <= 10; i++)
            //        {
            //            sheet.Cells[i, 1] = i;
            //            sheet.Cells[i, 2] = Math.Sin(i);
            //        }

            //        ChartObjects xlCharts = (ChartObjects)sheet.ChartObjects(Type.Missing);
            //        ChartObject myChart = (ChartObject)xlCharts.Add(110, 0, 500, 300);
            //        Chart chart = myChart.Chart;
            //        SeriesCollection seriesCollection = (SeriesCollection)chart.SeriesCollection(Type.Missing);
            //        Series series = seriesCollection.NewSeries();
            //        series.XValues = sheet.get_Range("A1", "A10");
            //        series.Values = sheet.get_Range("B1", "B10");
            //        chart.ChartType = XlChartType.xlXYScatterSmooth;
            //        application.Visible = true;
            //    });
            //}
            //catch (Exception e)
            //{
            //    MessageBox.Show("Ошибка в формировании отчёта \"Контроль остатков\"\n"+e.Message);
            //}

        }
    }
}
