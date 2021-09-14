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

namespace BTL.Forms.Main.DoiTra
{
    public partial class XemDoiTraForm : Form
    {

        QLBanMyPhamContext db = new QLBanMyPhamContext();
        CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");
        public XemDoiTraForm()
        {
            InitializeComponent();
        }

        public XemDoiTraForm(QLBanMyPhamContext currentDb)
        {
            InitializeComponent();
            db = currentDb;
        }

        private void tinhTienKhachTra()
        {
            decimal tongTienDoi = 0m;
            for (int i = 0; i < dataViewSPTra.Rows.Count; i++)
            {
                tongTienDoi += decimal.Parse(dataViewSPTra.Rows[i].Cells[4].Value.ToString(), cul);
            }

            decimal tongTienCanDoi = 0m;
            for (int i = 0; i < dataViewSPDoi.Rows.Count; i++)
            {
                tongTienCanDoi += decimal.Parse(dataViewSPDoi.Rows[i].Cells[4].Value.ToString(), cul);
            }

            if (tongTienDoi >= tongTienCanDoi)
            {
                labelTienKhachTra.Text = "0 VND";
            }
            else
            {
                labelTienKhachTra.Text = (tongTienCanDoi - tongTienDoi).ToString("#,###", cul.NumberFormat) + " VND";
            }
        }

        private void XemDoiTraForm_Load(object sender, EventArgs e)
        {
            try
            {
                string maPDT = (string)this.Tag;
                PhieuDoiTra pdt = db.PhieuDoiTras.Find(maPDT);
                string maKH = db.HoaDons.Find(pdt.MaHd).MaKh;
                var kh = db.KhachHangs.Find(maKH);
                var nv = db.NhanViens.Find(pdt.MaNv);
                var ch = db.CuaHangs.Find(nv.MaCuaHang);

                labelTenCH.Text = ch.TenCuaHang;
                labelDiaChiCH.Text = ch.DiaChi;
                labelSdtCH.Text = ch.DienThoai;
                labelMaPhieu.Text = maPDT;
                labelKH.Text = kh.TenKh;
                labelSDT.Text = kh.Sdt;
                labelNV.Text = nv.TenNv;
                labelNgayTao.Text = pdt.NgayLap.Value.ToString("dd-MM-yyyy HH:mm:ss");

                var ttpdt = db.ThongTinSpdts.Where(s => s.MaPhieuDt == maPDT).ToList();
                foreach (var item in ttpdt)
                {
                    SanPham sp = db.SanPhams.Find(item.MaSp);
                    if(item.PhanLoai==false)
                    {
                        dataViewSPTra.Rows.Add(item.MaSp, sp.TenSp, item.SoLuongDt, ((decimal)item.DonGiaHt).ToString("#,###", cul.NumberFormat), ((decimal)(item.SoLuongDt * item.DonGiaHt)).ToString("#,###", cul.NumberFormat));
                    } else
                    {
                        dataViewSPDoi.Rows.Add(item.MaSp, sp.TenSp, item.SoLuongDt, ((decimal)item.DonGiaHt).ToString("#,###", cul.NumberFormat), ((decimal)(item.SoLuongDt * item.DonGiaHt)).ToString("#,###", cul.NumberFormat));
                    }  
                }
                txtLyDo.Text = pdt.LyDoDt;
                tinhTienKhachTra();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

        private void thoatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void xuatPDTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            thoatToolStripMenuItem_Click(sender, e);
            Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel._Workbook workbook = excelApp.Application.Workbooks.Add(Type.Missing);
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;

            excelApp.Visible = true;
            worksheet = workbook.Sheets["Sheet1"];
            worksheet = workbook.ActiveSheet;

            worksheet.Cells[1, 1] = labelTenCH.Text + " - " + labelSdtCH.Text;
            worksheet.Cells[2, 1] = labelDiaChiCH.Text;
            Microsoft.Office.Interop.Excel.Range head = worksheet.get_Range("B3", "F4");
            head.MergeCells = true;
            head.Value2 = label1.Text;
            head.Font.Bold = true;
            head.Font.Name = "Tahoma";
            head.Font.Size = "18";
            head.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;


            Microsoft.Office.Interop.Excel.Range labelMPD = worksheet.get_Range("D5", "D5");
            labelMPD.MergeCells = true;
            labelMPD.Value2 = labelMaPhieu.Text;
            labelMPD.Font.Bold = true;
            labelMPD.Font.Name = "Tahoma";
            labelMPD.Font.Size = "11";
            labelMPD.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;


            Microsoft.Office.Interop.Excel.Range lbKhach = worksheet.get_Range("B7", "B7");
            lbKhach.MergeCells = true;
            lbKhach.Value2 = "Tên khách hàng";
            lbKhach.Font.Name = "Tahoma";
            lbKhach.Font.Size = "11";



            Microsoft.Office.Interop.Excel.Range lbKH = worksheet.get_Range("C7", "C7");
            lbKH.MergeCells = true;
            lbKH.Value2 = labelKH.Text;
            lbKH.Font.Name = "Tahoma";
            lbKH.Font.Size = "11";


            Microsoft.Office.Interop.Excel.Range lbThuN = worksheet.get_Range("E7", "E7");
            lbThuN.MergeCells = true;
            lbThuN.Value2 = "Thu ngân";
            lbThuN.Font.Name = "Tahoma";
            lbThuN.Font.Size = "11";


            Microsoft.Office.Interop.Excel.Range lbTN = worksheet.get_Range("F7", "F7");
            lbTN.MergeCells = true;
            lbTN.Value2 = labelNV.Text;
            lbTN.Font.Name = "Tahoma";
            lbTN.Font.Size = "11";


            Microsoft.Office.Interop.Excel.Range lbSdt = worksheet.get_Range("B9", "B9");
            lbSdt.MergeCells = true;
            lbSdt.Value2 = "Số điện thoại";
            lbSdt.Font.Name = "Tahoma";
            lbSdt.Font.Size = "11";


            Microsoft.Office.Interop.Excel.Range lbSodt = worksheet.get_Range("C9", "C9");
            lbSodt.MergeCells = true;
            lbSodt.Value2 = "(+84)" + labelSDT.Text;
            lbSodt.Font.Name = "Tahoma";
            lbSodt.Font.Size = "11";


            Microsoft.Office.Interop.Excel.Range lbNx = worksheet.get_Range("E9", "E9");
            lbNx.MergeCells = true;
            lbNx.Value2 = "Ngày xuất HD";
            lbNx.Font.Name = "Tahoma";
            lbNx.Font.Size = "11";


            Microsoft.Office.Interop.Excel.Range lbNgayx = worksheet.get_Range("F9", "F9");
            lbNgayx.MergeCells = true;
            lbNgayx.Value2 = labelNgayTao.Text;
            lbNgayx.Font.Name = "Tahoma";
            lbNgayx.Font.Size = "11";
            lbNgayx.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;

            // Danh sach san pham tra
            int rowIndex = 13;
            Microsoft.Office.Interop.Excel.Range tieude = worksheet.Cells[rowIndex, 2];
            tieude.MergeCells = true;
            tieude.Value2 = "Danh sách sản phẩm trả:";
            tieude.Font.Name = "Tahoma";
            tieude.Font.Size = "11";

            rowIndex++;
            Microsoft.Office.Interop.Excel.Range oRange = null;
            for (int i = 0; i < dataViewSPTra.Columns.Count; i++)
            {
                oRange = (Microsoft.Office.Interop.Excel.Range)worksheet.Cells[rowIndex, i + 2];

                oRange.Value2 = dataViewSPTra.Columns[i].HeaderText;
                oRange.Font.Name = "Tahoma";
                oRange.Font.Size = "11";
                oRange.Borders.LineStyle = Microsoft.Office.Interop.Excel.Constants.xlSolid;
                oRange.Interior.ColorIndex = 6;
            }

            rowIndex++;
            for (int i = 0; i < dataViewSPTra.Rows.Count; i++)
            {

                for (int j = 0; j < dataViewSPTra.Columns.Count; j++)
                {
                    oRange = (Microsoft.Office.Interop.Excel.Range)worksheet.Cells[rowIndex, j + 2];
                    oRange.NumberFormat = "@";
                    oRange.Value2 = dataViewSPTra[j, i].Value.ToString();
                    oRange.Font.Name = "Tahoma";
                    oRange.Font.Size = "11";
                    oRange.Borders.LineStyle = Microsoft.Office.Interop.Excel.Constants.xlSolid;
                }
                rowIndex++;
            }

            //San pham doi
            rowIndex++;
            Microsoft.Office.Interop.Excel.Range tieude2 = worksheet.Cells[rowIndex, 2];
            tieude2.MergeCells = true;
            tieude2.Value2 = "Danh sách sản phẩm đổi:";
            tieude2.Font.Name = "Tahoma";
            tieude2.Font.Size = "11";

            rowIndex++;
            Microsoft.Office.Interop.Excel.Range oRange2 = null;
            for (int i = 0; i < dataViewSPDoi.Columns.Count; i++)
            {
                oRange2 = (Microsoft.Office.Interop.Excel.Range)worksheet.Cells[rowIndex, i + 2];

                oRange2.Value2 = dataViewSPDoi.Columns[i].HeaderText;
                oRange2.Font.Name = "Tahoma";
                oRange2.Font.Size = "11";
                oRange2.Borders.LineStyle = Microsoft.Office.Interop.Excel.Constants.xlSolid;
                oRange2.Interior.ColorIndex = 6;
            }

            rowIndex++;
            for (int i = 0; i < dataViewSPDoi.Rows.Count; i++)
            {

                for (int j = 0; j < dataViewSPDoi.Columns.Count; j++)
                {
                    oRange2 = (Microsoft.Office.Interop.Excel.Range)worksheet.Cells[rowIndex, j + 2];
                    oRange2.NumberFormat = "@";
                    oRange2.Value2 = dataViewSPDoi[j, i].Value.ToString();
                    oRange2.Font.Name = "Tahoma";
                    oRange2.Font.Size = "11";
                    oRange2.Borders.LineStyle = Microsoft.Office.Interop.Excel.Constants.xlSolid;
                }
                rowIndex++;
            }
            ////////

            rowIndex++;
            Microsoft.Office.Interop.Excel.Range tdtTien = worksheet.Cells[rowIndex + 1, 5];
            tdtTien.MergeCells = true;
            tdtTien.Value2 = "Tổng tiền";
            tdtTien.Font.Name = "Tahoma";
            tdtTien.Font.Size = "11";
            tdtTien.Font.Bold = true;

            Microsoft.Office.Interop.Excel.Range tongT = worksheet.Cells[rowIndex + 1, 6];
            tongT.MergeCells = true;
            tongT.Value2 = labelTienKhachTra.Text;
            tongT.Font.Name = "Tahoma";
            tongT.Font.Size = "11";
            tongT.Font.Bold = true;

            excelApp.Columns.AutoFit();
            excelApp.Visible = true;
        }

        private void xuấtPDFToolStripMenuItem_Click(object sender, EventArgs e)
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

            #region subheader
            Paragraph prgCuahang = new Paragraph();
            prgCuahang.Alignment = Element.ALIGN_LEFT;
            prgCuahang.IndentationLeft = 5;
            prgCuahang.SpacingAfter = 5;
            prgCuahang.Add(new Chunk(labelTenCH.Text + " - " + labelSdtCH.Text, font));
            document.Add(prgCuahang);

            Paragraph prgCuahangdc = new Paragraph();
            prgCuahangdc.Alignment = Element.ALIGN_LEFT;
            prgCuahangdc.IndentationLeft = 5;
            prgCuahangdc.SpacingAfter = 5;
            prgCuahangdc.Add(new Chunk(labelDiaChiCH.Text, font));
            document.Add(prgCuahangdc);
            #endregion

            #region header

            Paragraph prghd = new Paragraph();
            prghd.Alignment = Element.ALIGN_CENTER;
            prghd.SpacingAfter = 5;
            prghd.Add(new Chunk(label1.Text, fontBig));
            document.Add(prghd);

            Paragraph prgMhd = new Paragraph();
            prgMhd.Alignment = Element.ALIGN_CENTER;
            prgMhd.SpacingAfter = 5;
            prgMhd.Add(new Chunk(labelMaPhieu.Text, fontBold));
            document.Add(prgMhd);
            #endregion

            #region tthd

            Paragraph pTenKH = new Paragraph();
            pTenKH.Alignment = Element.ALIGN_LEFT;
            pTenKH.SpacingAfter = 5;
            pTenKH.IndentationLeft = 25;
            pTenKH.SpacingBefore = 15;
            pTenKH.Add(new Chunk(string.Format("{0,-65}{1,-20}", label2.Text + " " + labelKH.Text, label4.Text + " " + labelNV.Text).ToString(), font));
            document.Add(pTenKH);

            #endregion

            #region Số đt + Ngày xuất

            Paragraph pStt = new Paragraph();
            pStt.Alignment = Element.ALIGN_LEFT;
            pStt.SpacingAfter = 5;
            pStt.IndentationLeft = 25;
            pStt.SpacingBefore = 15;
            pStt.Add(new Chunk(string.Format("{0,-65}{1,-20}", label3.Text + " " + labelSDT.Text, label6.Text + " " + labelNgayTao.Text), font));
            document.Add(pStt);

            #endregion

            #region tiêu đề ds trả

            Paragraph pTD = new Paragraph();
            pTD.Alignment = Element.ALIGN_LEFT;
            pTD.SpacingAfter = 5;
            pTD.IndentationLeft = 25;
            pTD.SpacingBefore = 15;
            pTD.Add(new Chunk(string.Format("{0,-75}", label5.Text), fontBold));
            document.Add(pTD);

            #endregion

            #region DataGridview trả
            PdfPTable tableT = new PdfPTable(dataViewSPTra.Columns.Count);
            tableT.SpacingBefore = 30;
            tableT.WidthPercentage = 100;
            for (int i = 0; i < dataViewSPTra.Columns.Count; i++)
            {
                PdfPCell cell = new PdfPCell();
                cell.BackgroundColor = iTextSharp.text.BaseColor.YELLOW;
                cell.AddElement(new Chunk(dataViewSPTra.Columns[i].HeaderText, font));
                tableT.AddCell(cell);
            }

            for (int i = 0; i < dataViewSPTra.Rows.Count; i++)
            {
                for (int j = 0; j < dataViewSPTra.Columns.Count; j++)
                {
                    PdfPCell cell = new PdfPCell();
                    cell.AddElement(new Chunk(dataViewSPTra[j, i].Value.ToString(), font));
                    tableT.AddCell(cell);
                }

            }
            document.Add(tableT);
            #endregion

            #region tiêu đề ds đổi

            Paragraph pTDD = new Paragraph();
            pTDD.Alignment = Element.ALIGN_LEFT;
            pTDD.SpacingAfter = 5;
            pTDD.IndentationLeft = 25;
            pTDD.SpacingBefore = 15;
            pTDD.Add(new Chunk(string.Format("{0,-75}", label8.Text), fontBold));
            document.Add(pTDD);

            #endregion

            #region DataGridview đổi
            PdfPTable table = new PdfPTable(dataViewSPDoi.Columns.Count);
            table.SpacingBefore = 30;
            table.WidthPercentage = 100;
            for (int i = 0; i < dataViewSPDoi.Columns.Count; i++)
            {
                PdfPCell cell = new PdfPCell();
                cell.BackgroundColor = iTextSharp.text.BaseColor.YELLOW;
                cell.AddElement(new Chunk(dataViewSPDoi.Columns[i].HeaderText, font));
                table.AddCell(cell);
            }

            for (int i = 0; i < dataViewSPDoi.Rows.Count; i++)
            {
                for (int j = 0; j < dataViewSPDoi.Columns.Count; j++)
                {
                    PdfPCell cell = new PdfPCell();
                    cell.AddElement(new Chunk(dataViewSPDoi[j, i].Value.ToString(), font));
                    table.AddCell(cell);
                }

            }
            document.Add(table);
            #endregion

            #region thành tiền
            Paragraph pTongtien = new Paragraph();
            pTongtien.Alignment = Element.ALIGN_RIGHT;
            pTongtien.SpacingAfter = 5;
            pTongtien.SpacingBefore = 15;
            pTongtien.Add(new Chunk(string.Format("{0}", label15.Text + " " + labelTienKhachTra.Text), font));
            document.Add(pTongtien);

            #endregion

            #region tiêu đề lý do đổi

            Paragraph lyDo = new Paragraph();
            lyDo.Alignment = Element.ALIGN_LEFT;
            lyDo.SpacingAfter = 5;
            lyDo.IndentationLeft = 25;
            lyDo.SpacingBefore = 15;
            lyDo.Add(new Chunk(string.Format("{0,-75}", label9.Text), fontBold));
            document.Add(lyDo);

            #endregion

            #region txtLyDo

            Paragraph plyDo = new Paragraph();
            plyDo.Alignment = Element.ALIGN_LEFT;
            plyDo.SpacingAfter = 5;
            plyDo.IndentationLeft = 25;
            plyDo.SpacingBefore = 15;
            plyDo.Add(new Chunk(string.Format("{0,-75}", txtLyDo.Text), font));
            document.Add(plyDo);

            #endregion

            iTextSharp.text.pdf.draw.LineSeparator line = new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 100.0F, iTextSharp.text.BaseColor.BLACK, Element.ALIGN_CENTER, 0);
            document.Add(line);

            Paragraph pLoi = new Paragraph();
            pLoi.Alignment = Element.ALIGN_CENTER;
            pLoi.SpacingAfter = 5;
            pLoi.SpacingBefore = 10;
            pLoi.Add(new Chunk(string.Format("{0}", label7.Text), fontNghien));
            document.Add(pLoi);


            document.Close();
            write.Close();
            fs.Close();
        }
    }
}
