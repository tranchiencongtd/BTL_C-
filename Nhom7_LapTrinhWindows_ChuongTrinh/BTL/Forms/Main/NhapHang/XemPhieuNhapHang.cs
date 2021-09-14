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

namespace BTL.Forms.Main.NhapHang
{
    public partial class XemPhieuNhapHang : Form
    {
        QLBanMyPhamContext db = new QLBanMyPhamContext();
        CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");
        public XemPhieuNhapHang(PhieuNhap a)
        {

            InitializeComponent();
            var pdh = db.PhieuDatHangs.Single(x => x.MaPhieuDat == a.MaPhieuDat);
            var ncc = db.NhaCcs.Single(x => x.MaNcc == pdh.MaNcc);
            var nvn = db.NhanViens.Single(x => x.MaNv == pdh.MaNv);
            var ch = db.CuaHangs.Single(x => x.MaCuaHang == pdh.MaCuaHang);
            labelTenNCC.Text = ncc.TenNcc;
            labelDiaChiNCC.Text = ncc.DiaChi;
            labelMaPhieuNH.Text = a.MaPhieuNhap;
            labelNgayTao.Text = a.NgayNhap.ToString("dd-MM-yyyy");
            labelSDTNCC.Text = ncc.DienThoai;
            labelTenCH.Text = ch.TenCuaHang;
            labelDiaChiCH.Text = ch.DiaChi;
            labelSoDienThoaiCH.Text = ch.DienThoai;
            labelTenNV.Text = nvn.TenNv;
            labelthanhtoan.Text = a.ThanhToan;
            string maphieunhap = a.MaPhieuNhap;
            var pn = (from pn1 in db.PhieuNhaps
                      join
                        pd in db.PhieuDatHangs on
                        pn1.MaPhieuDat equals pd.MaPhieuDat
                      join nv in db.NhanViens on
                      pn1.MaNv equals nv.MaNv
                      where pn1.MaPhieuNhap.Equals(maphieunhap)
                      select new
                      {
                          mapn = pn1.MaPhieuNhap,
                          mach = pd.MaCuaHang,
                          mancc = pd.MaNcc,
                          ngaynhap = pn1.NgayNhap,
                          tt = pn1.ThanhToan,
                          nn = nv.TenNv,
                          mapd = pd.MaPhieuDat
                      }).ToList();
            var ctpn = (from ct in db.DongPhieuNhaps
                        join pn2 in db.PhieuNhaps on
                        ct.MaPhieuNhap equals pn2.MaPhieuNhap
                        join sp in db.SanPhams on
                        ct.MaSp equals sp.MaSp
                        where pn2.MaPhieuNhap.Equals(maphieunhap)
                        select new
                        {
                            msp = sp.MaSp,
                            tsp = sp.TenSp,
                            sl = ct.SoLuong,
                            gia = ct.GiaNhap
                        }
            ).ToList();
            dataViewSpCanDoi.Rows.Clear();
            long tongtien = 0;
            foreach (var item in ctpn)
            {
                tongtien += (long)(item.sl * item.gia);
                dataViewSpCanDoi.Rows.Add(item.msp, item.tsp, item.sl, ((decimal)item.gia).ToString("#,###", cul.NumberFormat), ((decimal)(item.sl * item.gia)).ToString("#,###", cul.NumberFormat));
            }
            labelTongTien.Text = tongtien.ToString("#,###", cul.NumberFormat) +"VND";

        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void xuấtExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            exportExcelFile();
        }

        public void exportExcelFile()
        {
            int rowIndex = 1;
            Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel._Workbook workbook = excelApp.Application.Workbooks.Add(Type.Missing);
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
            excelApp.Visible = true;
            worksheet = workbook.Sheets["Sheet1"];
            worksheet = workbook.ActiveSheet;

            worksheet.Name = "Phiếu nhập hàng";
            worksheet.get_Range("A1", "A1").Cells.Font.Size = 14;
            worksheet.Cells[rowIndex, 1] = labelTenCH.Text;
            rowIndex++;
            worksheet.get_Range("A2", "A2").Cells.Font.Size = 14;
            excelApp.Cells[rowIndex, 1] = labelDiaChiCH.Text;
            rowIndex++;

            worksheet.get_Range("A3", "A3").Cells.Font.Size = 14;
            excelApp.Cells[rowIndex, 1] = labelSoDienThoaiCH.Text;
            rowIndex++;

            Microsoft.Office.Interop.Excel.Range head = worksheet.get_Range("D4", "D4");
            head.Value2 = "PHIẾU NHẬP HÀNG";
            head.Font.Size = 18;
            head.Font.Bold = true;
            head.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            rowIndex++;

            Microsoft.Office.Interop.Excel.Range lableMaDH = worksheet.get_Range("D5", "D5");
            lableMaDH.MergeCells = true;
            lableMaDH.Value2 = labelMaPhieuNH.Text;
            lableMaDH.Font.Bold = true;
            lableMaDH.Font.Size = 14;
            lableMaDH.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            rowIndex++;

            excelApp.Cells[rowIndex, 2] = "Tên nhà cung cấp: ";
            excelApp.Cells[rowIndex, 3] = labelTenNCC.Text;
            excelApp.Cells[rowIndex, 5] = "Người lập phiếu: ";
            excelApp.Cells[rowIndex, 6] = labelTenNV.Text;
            rowIndex++;

            excelApp.Cells[rowIndex, 2] = "Địa chỉ: ";
            excelApp.Cells[rowIndex, 3] = labelDiaChiCH.Text;
            excelApp.Cells[rowIndex, 5] = "Ngày lập phiếu: ";
            excelApp.Cells[rowIndex, 6] = labelNgayTao.Text;
            rowIndex++;

            excelApp.Cells[rowIndex, 2] = "Số điện thoại: ";
            excelApp.Cells[rowIndex, 3] = labelSDTNCC.Text;
            excelApp.Cells[rowIndex, 5] = "Thanh toán: ";
            excelApp.Cells[rowIndex, 6] = labelthanhtoan.Text;
            rowIndex++;

            rowIndex++;

            Microsoft.Office.Interop.Excel.Range tieude = worksheet.Cells[rowIndex, 2];
            tieude.MergeCells = true;
            tieude.Font.Bold = true;
            tieude.Value2 = "Danh sách sản phẩm:";
            rowIndex++;

            Microsoft.Office.Interop.Excel.Range oRange = null;
            for (int i = 0; i < dataViewSpCanDoi.Columns.Count; i++)
            {
                oRange = (Microsoft.Office.Interop.Excel.Range)worksheet.Cells[rowIndex, i + 2];
                oRange.Value2 = dataViewSpCanDoi.Columns[i].HeaderText;
                oRange.Borders.LineStyle = Microsoft.Office.Interop.Excel.Constants.xlSolid;
                oRange.Interior.ColorIndex = 6;
            }
            rowIndex++;

            for (int i = 0; i < dataViewSpCanDoi.Rows.Count; i++)
            {

                for (int j = 0; j < dataViewSpCanDoi.Columns.Count; j++)
                {
                    oRange = (Microsoft.Office.Interop.Excel.Range)worksheet.Cells[rowIndex, j + 2];
                    oRange.NumberFormat = "@";
                    oRange.Value2 = dataViewSpCanDoi[j, i].Value.ToString();
                    oRange.Borders.LineStyle = Microsoft.Office.Interop.Excel.Constants.xlSolid;
                }
                rowIndex++;
            }
            Microsoft.Office.Interop.Excel.Range tdtTien = worksheet.Cells[rowIndex + 1, 5];
            tdtTien.MergeCells = true;
            tdtTien.Font.Bold = true;
            tdtTien.Value2 = "Tổng tiền:";
            tdtTien.Font.Bold = true;

            Microsoft.Office.Interop.Excel.Range tongT = worksheet.Cells[rowIndex + 1, 6];
            tongT.MergeCells = true;
            tongT.Value2 = labelTongTien.Text.ToString().Replace('.', ',');
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
            prgCuahang.Add(new Chunk(labelTenCH.Text, font));
            document.Add(prgCuahang);

            Paragraph prgCuahangdc = new Paragraph();
            prgCuahangdc.Alignment = Element.ALIGN_LEFT;
            prgCuahangdc.IndentationLeft = 5;
            prgCuahangdc.SpacingAfter = 5;
            prgCuahangdc.Add(new Chunk(labelDiaChiCH.Text, font));
            document.Add(prgCuahangdc);

            Paragraph prgCuahangSDT = new Paragraph();
            prgCuahangSDT.Alignment = Element.ALIGN_LEFT;
            prgCuahangSDT.IndentationLeft = 5;
            prgCuahangSDT.SpacingAfter = 5;
            prgCuahangSDT.Add(new Chunk(labelSoDienThoaiCH.Text, font));
            document.Add(prgCuahangSDT);
            #endregion

            #region header

            Paragraph prgdh = new Paragraph();
            prgdh.Alignment = Element.ALIGN_CENTER;
            prgdh.SpacingAfter = 5;
            prgdh.Add(new Chunk(label1.Text, fontBig));
            document.Add(prgdh);

            Paragraph prgMdh = new Paragraph();
            prgMdh.Alignment = Element.ALIGN_CENTER;
            prgMdh.SpacingAfter = 5;
            prgMdh.Add(new Chunk(labelMaPhieuNH.Text, fontBold));
            document.Add(prgMdh);
            #endregion

            #region pdh

            Paragraph pTenNCC = new Paragraph();
            pTenNCC.Alignment = Element.ALIGN_LEFT;
            pTenNCC.SpacingAfter = 5;
            pTenNCC.IndentationLeft = 25;
            pTenNCC.SpacingBefore = 15;
            pTenNCC.Add(new Chunk(string.Format("{0,-65}{1,-20}", label2.Text + " " + labelTenNCC.Text, label4.Text + " " + labelTenNV.Text).ToString(), font));
            document.Add(pTenNCC);

            #endregion

            #region địa chỉ + ngày lập

            Paragraph pStt = new Paragraph();
            pStt.Alignment = Element.ALIGN_LEFT;
            pStt.SpacingAfter = 5;
            pStt.IndentationLeft = 25;
            pStt.SpacingBefore = 15;
            pStt.Add(new Chunk(string.Format("{0,-65}{1,-20}", label3.Text + " " + labelDiaChiNCC.Text, label6.Text + " " + labelNgayTao.Text), font));
            document.Add(pStt);

            #endregion

            #region sdt ncc + thanh toán

            Paragraph pTD = new Paragraph();
            pTD.Alignment = Element.ALIGN_LEFT;
            pTD.SpacingAfter = 5;
            pTD.IndentationLeft = 25;
            pTD.SpacingBefore = 15;
            pTD.Add(new Chunk(string.Format("{0,-65}{1,-20}", label7.Text + " " + labelSDTNCC.Text, abcxyz.Text + " " + labelthanhtoan.Text), font));
            document.Add(pTD);

            #endregion

            #region DataGridview
            PdfPTable table = new PdfPTable(dataViewSpCanDoi.Columns.Count);
            table.SpacingBefore = 30;
            table.WidthPercentage = 100;
            for (int i = 0; i < dataViewSpCanDoi.Columns.Count; i++)
            {
                PdfPCell cell = new PdfPCell();
                cell.BackgroundColor = iTextSharp.text.BaseColor.YELLOW;
                cell.AddElement(new Chunk(dataViewSpCanDoi.Columns[i].HeaderText, font));
                table.AddCell(cell);
            }

            for (int i = 0; i < dataViewSpCanDoi.Rows.Count; i++)
            {
                for (int j = 0; j < dataViewSpCanDoi.Columns.Count; j++)
                {
                    PdfPCell cell = new PdfPCell();
                    cell.AddElement(new Chunk(dataViewSpCanDoi[j, i].Value.ToString(), font));
                    table.AddCell(cell);
                }

            }
            document.Add(table);
            #endregion

            #region tổng tiền
            Paragraph pTongtien = new Paragraph();
            pTongtien.Alignment = Element.ALIGN_RIGHT;
            pTongtien.SpacingAfter = 5;
            pTongtien.SpacingBefore = 15;
            pTongtien.Add(new Chunk(string.Format("{0}", label15.Text + " " + labelTongTien.Text), font));
            document.Add(pTongtien);


            #endregion

            document.Close();
            write.Close();
            fs.Close();
        }
    }
}
