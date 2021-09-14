using BTL.Models;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL.Forms.Main.DatHang
{
    public partial class SanPhamSapHet : Form
    {
        QLBanMyPhamContext db;
        public SanPhamSapHet()
        {
            InitializeComponent();
        }
        public SanPhamSapHet(QLBanMyPhamContext currentDb)
        {
            InitializeComponent();
            db = currentDb;
        }

        private void SanPhamSapHet_Load(object sender, EventArgs e)
        {
            hienThi();
        }
        private void hienThi()
        {
            var sp = db.SanPhams.Where(s => s.Slton <= s.DinhMucHetHang).ToList();
            dgvSP.Rows.Clear();
            foreach (var item in sp)
            {
                dgvSP.Rows.Add(item.MaSp, item.TenSp, item.Slton, item.DinhMucHetHang);
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSLTonDuoi.Text == "") throw new Exception("Vui lòng nhập số lượng để tìm");
                if (int.Parse(txtSLTonDuoi.Text) < 0) throw new Exception("Nhập số >= 0");
                var sp = db.SanPhams.Where(s => s.Slton <= int.Parse(txtSLTonDuoi.Text)).ToList();
                dgvSP.Rows.Clear();
                foreach (var item in sp)
                {
                    dgvSP.Rows.Add(item.MaSp, item.TenSp, item.Slton, item.DinhMucHetHang);
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Vui lòng nhập số");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnTaiLai_Click(object sender, EventArgs e)
        {
            hienThi();
            txtSLTonDuoi.Clear();
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            int rowIndex = 1;
            Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel._Workbook workbook = excelApp.Application.Workbooks.Add(Type.Missing);
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
            excelApp.Visible = true;
            worksheet = workbook.Sheets["Sheet1"];
            worksheet = workbook.ActiveSheet;

            worksheet.Name = "Hàng sắp hết";
            rowIndex++;
            Microsoft.Office.Interop.Excel.Range head = worksheet.get_Range("B2", "B2");
            if (txtSLTonDuoi.Text == "")
                head.Value2 = "Danh sách hàng sắp hết";
            else
                head.Value2 = "Danh sách hàng có số lượng dưới " + txtSLTonDuoi.Text;
            head.Font.Size = 18;
            head.Font.Bold = true;
            head.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            rowIndex++;

            Microsoft.Office.Interop.Excel.Range oRange = null;
            for (int i = 0; i < dgvSP.Columns.Count; i++)
            {
                oRange = (Microsoft.Office.Interop.Excel.Range)worksheet.Cells[rowIndex, i + 2];
                oRange.Value2 = dgvSP.Columns[i].HeaderText;
                oRange.Borders.LineStyle = Microsoft.Office.Interop.Excel.Constants.xlSolid;
                oRange.Interior.ColorIndex = 6;
            }
            rowIndex++;

            for (int i = 0; i < dgvSP.Rows.Count; i++)
            {

                for (int j = 0; j < dgvSP.Columns.Count; j++)
                {
                    oRange = (Microsoft.Office.Interop.Excel.Range)worksheet.Cells[rowIndex, j + 2];
                    oRange.NumberFormat = "@";
                    oRange.Value2 = dgvSP[j, i].Value.ToString();
                    oRange.Borders.LineStyle = Microsoft.Office.Interop.Excel.Constants.xlSolid;
                }
                rowIndex++;
            }

            excelApp.Columns.AutoFit();
            excelApp.Visible = true;
        }

        private void btnXuatPDF_Click(object sender, EventArgs e)
        {
            this.Close();
            SaveFileDialog luu = new SaveFileDialog();
            luu.Filter = "pdf files (*.pdf) |*.pdf";
            if (luu.ShowDialog() == DialogResult.OK)
            {
                string path = luu.FileName;
                ExportPdf(path);
                MessageBox.Show("Xuất file pdf thành công!");
            }
        }
        void ExportPdf(String strPdfPath)
        {
            // Đường dẫn tới file chứa font times news roman
            string timesTTF = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "times.TTF");
            // Tạo đối tượng BaseFont
            BaseFont bf = BaseFont.CreateFont(timesTTF, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
            //Create a specific font object
            iTextSharp.text.Font font = new iTextSharp.text.Font(bf, 13);
            iTextSharp.text.Font fontNghien = new iTextSharp.text.Font(bf, 13, iTextSharp.text.Font.ITALIC);
            iTextSharp.text.Font fontBig = new iTextSharp.text.Font(bf, 18, iTextSharp.text.Font.BOLD);
            iTextSharp.text.Font fontBold = new iTextSharp.text.Font(bf, 12, iTextSharp.text.Font.BOLD);
            //tạo file    
            FileStream fs = new FileStream(strPdfPath, FileMode.Create, FileAccess.Write, FileShare.None);
            Document document = new Document(PageSize.A4);
            PdfWriter write = PdfWriter.GetInstance(document, fs);
            document.Open();

            #region header

            Paragraph ds = new Paragraph();
            ds.Alignment = Element.ALIGN_CENTER;
            ds.SpacingAfter = 5;
            if (txtSLTonDuoi.Text == "")
                ds.Add(new Chunk(label1.Text, fontBig));
            else
                ds.Add(new Chunk("Danh sách hàng có số lượng tồn dưới s" + txtSLTonDuoi.Text, fontBig));
            document.Add(ds);

            #endregion

            #region DataGridview
            PdfPTable table = new PdfPTable(dgvSP.Columns.Count);
            table.SpacingBefore = 30;
            table.WidthPercentage = 100;
            for (int i = 0; i < dgvSP.Columns.Count; i++)
            {
                PdfPCell cell = new PdfPCell();
                cell.BackgroundColor = iTextSharp.text.BaseColor.YELLOW;
                cell.AddElement(new Chunk(dgvSP.Columns[i].HeaderText, font));
                table.AddCell(cell);
            }

            for (int i = 0; i < dgvSP.Rows.Count; i++)
            {
                for (int j = 0; j < dgvSP.Columns.Count; j++)
                {
                    PdfPCell cell = new PdfPCell();
                    cell.AddElement(new Chunk(dgvSP[j, i].Value.ToString(), font));
                    table.AddCell(cell);
                }

            }
            document.Add(table);
            #endregion

            document.Close();
            write.Close();
            fs.Close();
        }
    }
}
