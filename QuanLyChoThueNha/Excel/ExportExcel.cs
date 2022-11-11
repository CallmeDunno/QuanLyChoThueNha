using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace QuanLyChoThueNha
{
    internal class ExportExcel
    {
        public void ExportFileExcel(DataGridView dgv, string title)
        {
            Excel.Application exApp = new Excel.Application();
            Excel.Workbook exBook = exApp.Workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
            Excel.Worksheet exSheet = (Excel.Worksheet)exBook.Worksheets[1];
            exSheet.get_Range("B1:H1").Font.Bold = true;
            exSheet.get_Range("B1:H1").Font.Size = 26;
            exSheet.get_Range("B1:H1").Merge(true);
            exSheet.get_Range("B1").Value = title;

            char[] alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            for (int i = 0; i < dgv.Columns.Count; i++)
            {
                exSheet.get_Range(alpha[i] + (3).ToString()).Value = dgv.Columns[i].HeaderText;
            }
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                int j = 0;
                while (j < dgv.Columns.Count)
                {
                    exSheet.get_Range(alpha[j] + (i + 4).ToString()).Value = dgv.Rows[i].Cells[j].Value;
                    j++;
                }
            }
            exBook.Activate();
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel Document(*.xlsx)|*.xlsx  |Word Document(*.docx) |*.docx|All files(*.*)|*.*";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                exBook.SaveAs(saveFileDialog.FileName.ToString());
                exApp.Quit();
                MessageBox.Show("Xuất file Excel thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }
    }
}
