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

namespace BTL.Forms.Main.HoaDons
{
    public partial class XemTTHDForm : Form
    {
        Models.QLBanMyPhamContext db;
        public XemTTHDForm()
        {
            InitializeComponent();
        }
        public XemTTHDForm(Models.QLBanMyPhamContext dt)
        {
            db = dt;
            InitializeComponent();
        }
        private void XemTTHDForm_Load(object sender, EventArgs e)
        {
            try
            {
                CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");   // try with "en-US"
                #region hien thi hoa don
                string maHD = (string)this.Tag;
                var hoadon = (from hd in db.HoaDons
                             where hd.MaHd == maHD
                             join kh in db.KhachHangs on hd.MaKh equals kh.MaKh
                             join nv in db.NhanViens on hd.MaNv equals nv.MaNv
                             join cuah in db.CuaHangs on nv.MaCuaHang equals cuah.MaCuaHang
                             select new
                             {
                                 mahd = hd.MaHd,
                                 tenkh=kh.TenKh,
                                 sdt=kh.Sdt,
                                 tichdiem=hd.TichDiemHt,
                                 tennv=nv.TenNv,
                                 ngaylap=hd.NgayLap,
                                 tongtien=(int)hd.TongTien,
                                 tench = cuah.TenCuaHang,
                                 diachich = cuah.DiaChi,
                                 sdtcuah = cuah.DienThoai
                             }).FirstOrDefault();
                labTench.Text = hoadon.tench;
                labSdtCh.Text = hoadon.sdtcuah;
                labDiachich.Text = hoadon.diachich;
                labMaHD.Text = "[" + hoadon.mahd + "]";
                labKH.Text = hoadon.tenkh;
                labSDT.Text = hoadon.sdt;
                labTD.Text = hoadon.tichdiem.ToString();
                labNV.Text = hoadon.tennv;
                labNgayThang.Text = hoadon.ngaylap.ToString("dd-MM-yyyy HH:mm:ss");
                #endregion
                var Tthds = from s in db.ThongTinHds
                            where s.MaHd == maHD
                            select new
                            {
                                masp = s.MaSp,
                                tensp = s.MaSpNavigation.TenSp,
                                solm = s.SoLuongMua,
                                dongia=(int)s.DonGiaHt,
                            };
                int Tong = 0;//Tong tien da co chiet khau
                foreach (var item in Tthds)
                {
                    dataViewSP.Rows.Add(item.masp, item.tensp, item.solm, item.dongia.ToString("#,###",cul.NumberFormat),(item.solm*item.dongia).ToString("#,###", cul.NumberFormat));
                    Tong +=item.solm * item.dongia;
                }
                string total = (Tong-hoadon.tongtien).ToString("#,###", cul.NumberFormat);
                string total1 = hoadon.tongtien.ToString("#,###", cul.NumberFormat);
                labChietKhau.Text = total + " VNĐ";
                labTongTien.Text = total1 + " VNĐ";
                if(Tong - hoadon.tongtien==0)
                    labChietKhau.Text = "0 VNĐ";
                if(hoadon.tongtien==0)
                    labTongTien.Text = "0 VNĐ";
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void xuatHDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
                SaveFileDialog luu = new SaveFileDialog();
                luu.Filter = "pdf files (*.pdf) |*.pdf";
                if (luu.ShowDialog() == DialogResult.OK)
                {
                    string path = luu.FileName;
                    //string path = @"C:\Users\MinhTu\Downloads\BTL-ver3\BTL\BTL\Forms\Main\HoaDons\SaveHD\test.pdf";
                    ExportPdf(path);
                    string adobePath = @"C:\Program Files (x86)\Adobe\Acrobat Reader DC\Reader\AcroRd32.exe";
                    System.Diagnostics.Process.Start(adobePath, path);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Xuất hóa đơn thành công!");
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
            prgCuahang.Add(new Chunk(labTench.Text + " - " + labSdtCh.Text, font));
            document.Add(prgCuahang);

            Paragraph prgCuahangdc = new Paragraph();
            prgCuahangdc.Alignment = Element.ALIGN_LEFT;
            prgCuahangdc.IndentationLeft = 5;
            prgCuahangdc.SpacingAfter = 5;
            prgCuahangdc.Add(new Chunk(labDiachich.Text, font));
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
            prgMhd.Add(new Chunk(labMaHD.Text, fontBold));
            document.Add(prgMhd);
            #endregion

            #region tthd

            Paragraph pTenKH = new Paragraph();
            pTenKH.Alignment = Element.ALIGN_LEFT;
            pTenKH.SpacingAfter = 5;
            pTenKH.IndentationLeft = 25;
            pTenKH.SpacingBefore = 15;
            pTenKH.Add(new Chunk(string.Format("{0,-65}{1,-20}", label2.Text + " " + labKH.Text, label4.Text + " " + labNV.Text).ToString(), font));
            document.Add(pTenKH);

            #endregion

            #region Số đt + Ngày xuất

            Paragraph pStt = new Paragraph();
            pStt.Alignment = Element.ALIGN_LEFT;
            pStt.SpacingAfter = 5;
            pStt.IndentationLeft = 25;
            pStt.SpacingBefore = 15;
            pStt.Add(new Chunk(string.Format("{0,-65}{1,-20}", label3.Text + " " + labSDT.Text, label6.Text + " " + labNgayThang.Text), font));
            document.Add(pStt);

            #endregion

            #region Tích điểm

            Paragraph pTD = new Paragraph();
            pTD.Alignment = Element.ALIGN_LEFT;
            pTD.SpacingAfter = 5;
            pTD.IndentationLeft = 25;
            pTD.SpacingBefore = 15;
            pTD.Add(new Chunk(string.Format("{0,-75}", label5.Text + " " + labTD.Text), font));
            document.Add(pTD);

            #endregion

            #region DataGridview
            PdfPTable table = new PdfPTable(dataViewSP.Columns.Count);
            table.SpacingBefore = 30;
            table.WidthPercentage = 100;
            for (int i = 0; i < dataViewSP.Columns.Count; i++)
            {
                PdfPCell cell = new PdfPCell();
                cell.BackgroundColor = iTextSharp.text.BaseColor.YELLOW;
                cell.AddElement(new Chunk(dataViewSP.Columns[i].HeaderText, font));
                table.AddCell(cell);
            }

            for (int i = 0; i < dataViewSP.Rows.Count; i++)
            {
                for (int j = 0; j < dataViewSP.Columns.Count; j++)
                {
                    PdfPCell cell = new PdfPCell();
                    cell.AddElement(new Chunk(dataViewSP[j, i].Value.ToString(), font));
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
            pTongtien.Add(new Chunk(string.Format("{0}", label11.Text + " " + labTongTien.Text), font));
            document.Add(pTongtien);

            Paragraph pChietKhau = new Paragraph();
            pChietKhau.Alignment = Element.ALIGN_RIGHT;
            pChietKhau.SpacingAfter = 30;
            pChietKhau.SpacingBefore = 5;
            pChietKhau.Add(new Chunk(string.Format("{0}", label10.Text + " " + labChietKhau.Text), font));
            document.Add(pChietKhau);



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
        private void thoatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void xuatExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            thoatToolStripMenuItem_Click(sender, e);
            Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel._Workbook workbook = excelApp.Application.Workbooks.Add(Type.Missing);
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;

            excelApp.Visible = true;
            worksheet = workbook.Sheets["Sheet1"];
            worksheet = workbook.ActiveSheet;

            worksheet.Cells[1, 1] = labTench.Text+"-"+labSdtCh.Text;
            worksheet.Cells[2, 1] = labDiachich.Text;
            Microsoft.Office.Interop.Excel.Range head = worksheet.get_Range("B3", "F4");
            head.MergeCells = true;
            head.Value2 = label1.Text;
            head.Font.Bold = true;
            head.Font.Name = "Tahoma";
            head.Font.Size = "18";
            head.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;


            Microsoft.Office.Interop.Excel.Range lableMaHD = worksheet.get_Range("B5", "F5");
            lableMaHD.MergeCells = true;
            lableMaHD.Value2 = labMaHD.Text;
            lableMaHD.Font.Bold = true;
            lableMaHD.Font.Name = "Tahoma";
            lableMaHD.Font.Size = "11";
            lableMaHD.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;


            Microsoft.Office.Interop.Excel.Range lbKhach = worksheet.get_Range("B7", "B7");
            lbKhach.MergeCells = true;
            lbKhach.Value2 = "Khách hàng";
            lbKhach.Font.Name = "Tahoma";
            lbKhach.Font.Size = "11";



            Microsoft.Office.Interop.Excel.Range lbKH = worksheet.get_Range("C7", "C7");
            lbKH.MergeCells = true;
            lbKH.Value2 = labKH.Text;
            lbKH.Font.Name = "Tahoma";
            lbKH.Font.Size = "11";


            Microsoft.Office.Interop.Excel.Range lbThuN = worksheet.get_Range("E7", "E7");
            lbThuN.MergeCells = true;
            lbThuN.Value2 = "Thu ngân";
            lbThuN.Font.Name = "Tahoma";
            lbThuN.Font.Size = "11";


            Microsoft.Office.Interop.Excel.Range lbTN = worksheet.get_Range("F7", "F7");
            lbTN.MergeCells = true;
            lbTN.Value2 = labNV.Text;
            lbTN.Font.Name = "Tahoma";
            lbTN.Font.Size = "11";


            Microsoft.Office.Interop.Excel.Range lbSdt = worksheet.get_Range("B9", "B9");
            lbSdt.MergeCells = true;
            lbSdt.Value2 = "Số điện thoại";
            lbSdt.Font.Name = "Tahoma";
            lbSdt.Font.Size = "11";


            Microsoft.Office.Interop.Excel.Range lbSodt = worksheet.get_Range("C9", "C9");
            lbSodt.MergeCells = true;
            lbSodt.NumberFormat = "@";
            lbSodt.Value2 = labSDT.Text;
            lbSodt.Font.Name = "Tahoma";
            lbSodt.Font.Size = "11";


            Microsoft.Office.Interop.Excel.Range lbNx = worksheet.get_Range("E9", "E9");
            lbNx.MergeCells = true;
            lbNx.Value2 = "Ngày xuất HD";
            lbNx.Font.Name = "Tahoma";
            lbNx.Font.Size = "11";


            Microsoft.Office.Interop.Excel.Range lbNgayx = worksheet.get_Range("F9", "F9");
            lbNgayx.MergeCells = true;
            lbNgayx.Value2 = labNgayThang.Text;
            lbNgayx.Font.Name = "Tahoma";
            lbNgayx.Font.Size = "11";
            lbNgayx.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;


            Microsoft.Office.Interop.Excel.Range lbdtl = worksheet.get_Range("B11", "B11");
            lbdtl.MergeCells = true;
            lbdtl.Value2 = "Tích điểm";
            lbdtl.Font.Name = "Tahoma";
            lbdtl.Font.Size = "11";


            Microsoft.Office.Interop.Excel.Range lbTichd = worksheet.get_Range("C11", "C11");
            lbTichd.MergeCells = true;
            lbTichd.Value2 = labTD.Text;
            lbTichd.Font.Name = "Tahoma";
            lbTichd.Font.Size = "11";
            lbTichd.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;

            int rowIndex = 13;
            Microsoft.Office.Interop.Excel.Range tieude = worksheet.Cells[rowIndex, 2];
            tieude.MergeCells = true;
            tieude.Value2 = "Danh sách sản phẩm:";
            tieude.Font.Name = "Tahoma";
            tieude.Font.Size = "11";
            rowIndex++;
            Microsoft.Office.Interop.Excel.Range oRange = null;
            for (int i = 0; i < dataViewSP.Columns.Count; i++)
            {
                oRange = (Microsoft.Office.Interop.Excel.Range)worksheet.Cells[rowIndex, i + 2];

                oRange.Value2 = dataViewSP.Columns[i].HeaderText;
                oRange.Font.Name = "Tahoma";
                oRange.Font.Size = "11";
                oRange.Borders.LineStyle= Microsoft.Office.Interop.Excel.Constants.xlSolid;
                oRange.Interior.ColorIndex = 6;
            }
            rowIndex++;

            for (int i = 0; i < dataViewSP.Rows.Count; i++)
            {

                for (int j = 0; j < dataViewSP.Columns.Count; j++)
                {
                    oRange = (Microsoft.Office.Interop.Excel.Range)worksheet.Cells[rowIndex, j + 2];
                    oRange.NumberFormat= "@";
                    oRange.Value2 = dataViewSP[j, i].Value.ToString();
                    oRange.Font.Name = "Tahoma";
                    oRange.Font.Size = "11";
                    oRange.Borders.LineStyle = Microsoft.Office.Interop.Excel.Constants.xlSolid;
                }
                rowIndex++;
            }

            Microsoft.Office.Interop.Excel.Range tdchietKhau = worksheet.Cells[rowIndex+1, 5];
            tdchietKhau.MergeCells = true;
            tdchietKhau.Value2 = "Chiết khấu";
            tdchietKhau.Font.Name = "Tahoma";
            tdchietKhau.Font.Size = "11";
            tdchietKhau.Font.Bold=true;

            Microsoft.Office.Interop.Excel.Range chieuKhau = worksheet.Cells[rowIndex+1, 6];
            chieuKhau.MergeCells = true;
            chieuKhau.Value2 = labChietKhau.Text;
            chieuKhau.Font.Name = "Tahoma";
            chieuKhau.Font.Size = "11";
            chieuKhau.Font.Bold = true;
            rowIndex++;
            Microsoft.Office.Interop.Excel.Range tdtTien = worksheet.Cells[rowIndex + 1, 5];
            tdtTien.MergeCells = true;
            tdtTien.Value2 = "Tổng tiền";
            tdtTien.Font.Name = "Tahoma";
            tdtTien.Font.Size = "11";
            tdtTien.Font.Bold = true;

            Microsoft.Office.Interop.Excel.Range tongT = worksheet.Cells[rowIndex + 1, 6];
            tongT.MergeCells = true;
            tongT.Value2 = labTongTien.Text;
            tongT.Font.Name = "Tahoma";
            tongT.Font.Size = "11";
            tongT.Font.Bold = true;

            excelApp.Columns.AutoFit();
            excelApp.Visible = true;
    }
    }
}
