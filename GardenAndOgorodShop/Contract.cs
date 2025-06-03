using System;
using System.IO;
using Microsoft.Office.Interop.Word;
using System.Windows.Forms;
using System.Globalization;

namespace GardenAndOgorodShop
{
    public static class Contract
    {
        public static void ContractWithSupplier(string product_name, string supplier_name, int amount, int id_product, string supplier_director, string product_price, string supplier_inn)
        {
            if (!Directory.Exists("ContractWithSupplier"))
            {
                try
                {
                    Directory.CreateDirectory("ContractWithSupplier");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при создании папки '{"ContractWithSupplier"}': {ex.Message}", "Создание папки", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            string templatePath = "templatesAgreements\\templateContractWithSupplier.docx";
            string outputFilePath = $"ContractWithSupplier\\ContractWithSupplier {DateTime.Now.ToString("dd.MM.yyyy h.mm.ss")}.docx";

            CultureInfo culture = new CultureInfo("ru-RU");
            string formattedDate = DateTime.Now.ToString("«dd» MMMM yyyy 'г.'", culture);

            Microsoft.Office.Interop.Word.Application wordApp = null;
            Microsoft.Office.Interop.Word.Document wordDoc = null;

            try
            {
                wordApp = new Microsoft.Office.Interop.Word.Application();
                wordApp.Visible = false;

                wordDoc = wordApp.Documents.Open($"{Directory.GetCurrentDirectory()}\\{templatePath}");
                wordDoc.Activate();

                FindAndReplace(wordApp, "[supplierName]", $"{supplier_name}");
                FindAndReplace(wordApp, "[id]", $"{id_product}");
                FindAndReplace(wordApp, "[date]", $"{formattedDate}");
                FindAndReplace(wordApp, "[supplierDirector]", $"{supplier_director}");
                FindAndReplace(wordApp, "[productName]", $"{product_name}");
                FindAndReplace(wordApp, "[productPrice]", $"{product_price}");
                FindAndReplace(wordApp, "[supplierINN]", $"{supplier_inn}");

                wordDoc.SaveAs2($"{Directory.GetCurrentDirectory()}\\{outputFilePath}");

                wordApp.Visible = true; 
                wordDoc = wordApp.Documents.Open($"{Directory.GetCurrentDirectory()}\\{outputFilePath}"); 
                wordDoc.Activate();
                wordApp.PrintPreview = true;

                MessageBox.Show($"Документ успешно заполнен и сохранен в: {outputFilePath}", "Договор о поставке", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}", "Договор о поставке", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (wordDoc != null)
                {
                    wordDoc.Close();
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(wordDoc);
                    wordDoc = null;
                }

                if (wordApp != null)
                {
                    wordApp.Quit();
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(wordApp);
                    wordApp = null;
                }

                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }
        private static void FindAndReplace(Microsoft.Office.Interop.Word.Application wordApp, string searchText, string replaceText)
        {
            object missing = Type.Missing;
            object findText = searchText;
            object replaceWithText = replaceText;
            object wrapMode = WdFindWrap.wdFindContinue;
            object replace = WdReplace.wdReplaceAll;

            foreach (Microsoft.Office.Interop.Word.Range range in wordApp.ActiveDocument.StoryRanges)
            {
                range.Find.Execute(ref findText, ref missing, ref missing, ref missing, ref missing,
                                    ref missing, ref missing, ref wrapMode, ref missing, ref replaceWithText,
                                    ref replace, ref missing, ref missing, ref missing, ref missing);
            }
        }
    }
}
