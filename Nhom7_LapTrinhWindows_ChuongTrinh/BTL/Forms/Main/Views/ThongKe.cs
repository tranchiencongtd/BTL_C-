using BTL.Models;
using BTL.Ultilities;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL.Forms.Main.Views
{
    public partial class ThongKe : Form
    {
        QLBanMyPhamContext db = new QLBanMyPhamContext();
        TaiKhoan user;
        Form parent;
        DateTime start, end;
        
        CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");
        
        

        public ThongKe(Form p, TaiKhoan x)
        {
            user = x;
            parent = p;
            InitializeComponent();
            
        }
        
        private void ThongKe_Load(object sender, EventArgs e)
        {
            start = DateTime.Today;
            end = DateTime.Today.AddHours(22);
            hienThiData();
            label1.Text = "Doanh Thu (Hôm Nay)";
            double tongdthn = 0;
            double tongdthq = 0;
            tongdthq = comparedt();
            for (int i = 0; i < dataspban.Rows.Count; i++)
            {
                tongdthn += double.Parse(dataspban.Rows[i].Cells[2].Value.ToString()) * Int32.Parse(dataspban.Rows[i].Cells[3].Value.ToString());
            }

            if (tongdthq == 0) { label5.Text = "Doanh thu so với hôm qua:    Tăng 100%"; }
            else
            {
                double pt = tongdthn - tongdthq;
                if (pt < 0)
                {
                    label5.Text = "Doanh thu so với hôm qua:    Giảm " + ((int)((-pt / tongdthq) * 100)).ToString() + "%";
                }
                else
                {
                    if (pt == 0)
                    {
                        label5.Text = "Doanh thu so với hôm qua:    Tăng 0%";
                    }
                    else
                    {
                        label5.Text = "Doanh thu so với hôm qua:    Tăng " + ((int)((pt / tongdthq) * 100)).ToString() + "%";
                    }
                }
            }

        }
        
        private double comparedt()
        {
            double tongdthq = 0;
            start = DateTime.Today.AddDays(-1);
            end = DateTime.Today.AddDays(-1).AddHours(16);
            var hd = db.HoaDons.Select(s => s);// lấy ra tất cả hóa đơn
            foreach (var s in hd) // duyệt danh sách các hóa đơn
            {
                DateTime ngaylap = s.NgayLap;
                if (DateTime.Compare(ngaylap, start) >= 0 &&
                    DateTime.Compare(ngaylap, end) <= 0)
                {//kiểm tra hóa đơn có ngày lập là date



                    var ds = (from cthd in db.ThongTinHds
                              join sp in db.SanPhams on cthd.MaSp equals sp.MaSp
                              join h in db.HoaDons on cthd.MaHd equals h.MaHd
                              where h.MaHd.Equals(s.MaHd)
                              select new
                              {
                                  masp = cthd.MaSp,
                                  tensp = cthd.MaSpNavigation.TenSp,
                                  gia = cthd.DonGiaHt,
                                  slban = cthd.SoLuongMua
                              }).ToList();

                    foreach (var item in ds)
                    {
                        tongdthq += double.Parse(item.slban.ToString()) * double.Parse(item.gia.ToString());
                    }
                }
            }
            return tongdthq;
        }
        private void btntim_Click(object sender, EventArgs e)
        {
            DateTime timebd = ngaybd.Value;
            DateTime timekt = ngaykt.Value;
            start = timebd;
            end = timekt.AddHours(16);
            if (ngaybd.Value.Date.CompareTo(ngaykt.Value.Date) >= 0)
            {
                MessageBox.Show("Ngày bắt đầu phải nhỏ hơn ngày kết thúc!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            hienThiData();
            if (dataspban.Rows.Count <= 0)
            {
                lbdoanhthu.Text = "0 VNĐ";
                lbkhachhang.Text = "0";
                lbtonghangban.Text = "0";
                lbspbc.Text = "";
                lbspin.Text = "";
            }
            label1.Text = "Doanh Thu (Đã Lọc)";
            double tongdthn1 = 0;
            double tongdthq2 = 0;
            tongdthq2 = comparedt2();
            for (int i = 0; i < dataspban.Rows.Count; i++)
            {
                tongdthn1 += double.Parse(dataspban.Rows[i].Cells[2].Value.ToString()) * Int32.Parse(dataspban.Rows[i].Cells[3].Value.ToString());
            }
            double pt = tongdthn1 - tongdthq2;
            if (tongdthq2 == 0) { label5.Text = "Doanh thu so với kì trước:     Tăng 100%"; }
            else
            {
                if (pt < 0)
                {
                    label5.Text = "Doanh thu so với kì trước:     Giảm " + ((int)((-pt / tongdthq2) * 100)).ToString() + "%";
                }
                else
                {
                    if (pt == 0)
                    {
                        label5.Text = "Doanh thu so với kì trước:     Tăng 0%";
                    }
                    else
                    {
                        label5.Text = "Doanh thu so với kì trước:     Tăng " + ((int)((pt / tongdthq2) * 100)).ToString() + "%";
                    }
                }
            }


        }
        private double comparedt2()
        {
            double tongdthq2 = 0;
            DateTime timebd = ngaybd.Value;
            DateTime timekt = ngaykt.Value;
            start = timebd.AddMonths(-1);
            end = timekt.AddMonths(-1).AddHours(16);
            var hd = db.HoaDons.Select(s => s);// lấy ra tất cả hóa đơn
            foreach (var s in hd) // duyệt danh sách các hóa đơn
            {
                DateTime ngaylap = s.NgayLap;
                if (DateTime.Compare(ngaylap, start) >= 0 &&
                    DateTime.Compare(ngaylap, end) <= 0)
                {//kiểm tra hóa đơn có ngày lập là date



                    var ds = (from cthd in db.ThongTinHds
                              join sp in db.SanPhams on cthd.MaSp equals sp.MaSp
                              join h in db.HoaDons on cthd.MaHd equals h.MaHd
                              where h.MaHd.Equals(s.MaHd)
                              select new
                              {
                                  masp = cthd.MaSp,
                                  tensp = cthd.MaSpNavigation.TenSp,
                                  gia = cthd.DonGiaHt,
                                  slban = cthd.SoLuongMua
                              }).ToList();

                    foreach (var item in ds)
                    {
                        tongdthq2 += double.Parse(item.slban.ToString()) * double.Parse(item.gia.ToString());
                    }
                }
            }
            return tongdthq2;
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ThongKe_Load(sender, e);
            start = DateTime.Today;
            end = DateTime.Today.AddHours(24);
            hienThiData();
            ngaybd.Value = ngaykt.Value = DateTime.Today;
            label1.Text = "Doanh Thu (Hôm Nay)";
            double tongdthn = 0;
            double tongdthq = 0;
            tongdthq = comparedt();
            for (int i = 0; i < dataspban.Rows.Count; i++)
            {
                tongdthn += double.Parse(dataspban.Rows[i].Cells[2].Value.ToString()) * Int32.Parse(dataspban.Rows[i].Cells[3].Value.ToString());
            }
            
            if (tongdthq == 0) { label5.Text = "Doanh thu so với hôm qua:    Tăng 100%"; }
            else
            {
                double pt = tongdthn - tongdthq;
                if (pt < 0)
                {
                    label5.Text = "Doanh thu so với hôm qua:    Giảm " + ((int)((-pt / tongdthq) * 100)).ToString() + "%";
                }
                else
                {
                    if (pt == 0)
                    {
                        label5.Text = "Doanh thu so với hôm qua:    Tăng 0%";
                    }
                    else
                    {
                        label5.Text = "Doanh thu so với hôm qua:    Tăng " + ((int)((pt / tongdthq) * 100)).ToString() + "%";
                    }
                }
            }
        }

        private void btnxuatf_Click(object sender, EventArgs e)
        {
            exportExcelFile();
        }

        private void hienThiData()
        {
            
            dataspban.Rows.Clear();

            int shd = 0;
            var hd = db.HoaDons.Select(s => s);// lấy ra tất cả hóa đơn
            var li = new List<string>();
            foreach (var s in hd) // duyệt danh sách các hóa đơn
            {
                DateTime ngaylap = s.NgayLap;
                if (DateTime.Compare(ngaylap, start) >= 0 &&
                    DateTime.Compare(ngaylap, end) <= 0)
                {//kiểm tra hóa đơn có ngày lập là date
                    var lskh = db.KhachHangs.Select(kh => kh);
                    foreach (var kh in lskh)
                    {
                        if (s.MaKh.Equals(kh.MaKh))
                            li.Add(s.MaKh);
                    }
                }
            }
            for (int i = 0; i < li.Distinct().Count(); i++)
            {
                shd++;
            }

            foreach (var s in hd) // duyệt danh sách các hóa đơn
            {
                DateTime ngaylap = s.NgayLap;
                if (DateTime.Compare(ngaylap, start) >= 0 &&
                    DateTime.Compare(ngaylap, end) <= 0)
                {//kiểm tra hóa đơn có ngày lập là date



                    var ds = (from cthd in db.ThongTinHds
                              join sp in db.SanPhams on cthd.MaSp equals sp.MaSp
                              join h in db.HoaDons on cthd.MaHd equals h.MaHd
                              where h.MaHd.Equals(s.MaHd)
                              select new
                              {
                                  masp = cthd.MaSp,
                                  tensp = cthd.MaSpNavigation.TenSp,
                                  gia = cthd.DonGiaHt,
                                  slban = cthd.SoLuongMua
                              }).ToList();

                    foreach (var item in ds)
                    {
                        bool isOK = false;
                        if (dataspban.Rows.Count > 0)
                        {

                            for (int i = 0; i < dataspban.Rows.Count; i++)
                            {
                                if (dataspban.Rows[i].Cells[0].Value.ToString().Equals(item.masp))
                                {
                                    if (dataspban.Rows[i].Cells[2].Value.ToString().Equals(item.gia.ToString()))
                                    {
                                        dataspban.Rows[i].Cells[3].Value = Int32.Parse(dataspban.Rows[i].Cells[3].Value.ToString()) + Int32.Parse(item.slban.ToString());
                                        isOK = true;
                                    }
                                }
                            }
                        }
                        if (!isOK)
                            dataspban.Rows.Add(item.masp, item.tensp, item.gia, item.slban);

                        int slmax = Int32.Parse(dataspban.Rows[0].Cells[3].Value.ToString());
                        int slmin = Int32.Parse(dataspban.Rows[0].Cells[3].Value.ToString());
                        string tenspmax = dataspban.Rows[0].Cells[1].Value.ToString();
                        string tenspmin = dataspban.Rows[0].Cells[1].Value.ToString();
                        for (int i = 0; i < dataspban.Rows.Count; i++)
                        {

                            if (Int32.Parse(dataspban.Rows[i].Cells[3].Value.ToString()) > slmax)
                            {
                                slmax = Int32.Parse(dataspban.Rows[i].Cells[3].Value.ToString());
                                tenspmax = dataspban.Rows[i].Cells[1].Value.ToString();
                            }
                            if (Int32.Parse(dataspban.Rows[i].Cells[3].Value.ToString()) < slmin)
                            {
                                slmin = Int32.Parse(dataspban.Rows[i].Cells[3].Value.ToString());
                                tenspmin = dataspban.Rows[i].Cells[1].Value.ToString(); ;
                            }
                        }
                        int tongban = 0;
                        double tongdt = 0;
                        for (int i = 0; i < dataspban.Rows.Count; i++)
                        {
                            tongban += Int32.Parse(dataspban.Rows[i].Cells[3].Value.ToString());
                            tongdt += double.Parse(dataspban.Rows[i].Cells[2].Value.ToString()) * Int32.Parse(dataspban.Rows[i].Cells[3].Value.ToString());

                        }
                        
                        
                        
                            lbdoanhthu.Text = tongdt.ToString("#,###.###", cul.NumberFormat) + " VNĐ";
                            lbtonghangban.Text = tongban.ToString();
                            lbspbc.Text = tenspmax + " - số lượng:" + slmax.ToString();
                            lbspin.Text = tenspmin + " - số lượng:" + slmin.ToString();
                        
                    }
                }
            }
            lbkhachhang.Text = shd.ToString();
            var ls = db.PhieuDoiTras.Select(dt => dt);
            int sdt = 0;
            foreach (var dt in ls)
            {
                DateTime ngaylapdt = (DateTime)dt.NgayLap;
                if (DateTime.Compare(ngaylapdt, start) >= 0 &&
                    DateTime.Compare(ngaylapdt, end) <= 0) { sdt++; }
            }
            lbdoitra.Text = sdt.ToString();

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


            worksheet.Name = "Báo Cáo Thống Kê";
            worksheet.get_Range("A1", "A1").Cells.Font.Size = 16;
            worksheet.Cells[rowIndex, 1] = "CoCoShop";
            rowIndex++;
            worksheet.get_Range("A2", "A2").Cells.Font.Size = 16;
            excelApp.Cells[rowIndex, 1] = "Beauty & Comestic";

            rowIndex++;
            Microsoft.Office.Interop.Excel.Range head = worksheet.get_Range("B3", "F4");
            head.MergeCells = true;
            head.Value2 = "Báo Cáo Thống Kê";
            head.Font.Bold = true;
            head.Font.Name = "Tahoma";
            head.Font.Size = "20";
            head.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            rowIndex++;
            rowIndex++;
            rowIndex++;
            if (DateTime.Compare(ngaybd.Value.Date, ngaykt.Value.Date) == 0)
            {
                worksheet.Cells[rowIndex, 3] = "Thời gian bán: ";
                worksheet.Cells[rowIndex, 4] = ngaybd.Value.ToShortDateString();
                rowIndex++;

            }
            else
            {
                worksheet.Cells[rowIndex, 3] = "Thời gian bắt đầu: ";
                worksheet.Cells[rowIndex, 4] = ngaybd.Value.ToShortDateString();
                rowIndex++;
                worksheet.Cells[rowIndex, 3] = "Thời gian kết thúc: ";
                worksheet.Cells[rowIndex, 4] = ngaykt.Value.ToShortDateString();
                rowIndex++;
            }

            rowIndex++;
            Microsoft.Office.Interop.Excel.Range tieude = worksheet.Cells[rowIndex, 3];
            tieude.MergeCells = true;
            tieude.Value2 = "Danh sách sản phẩm đã bán:";
            tieude.Font.Name = "Tahoma";
            tieude.Font.Size = "11";
            rowIndex++;


            Microsoft.Office.Interop.Excel.Range oRange = null;
            oRange = (Microsoft.Office.Interop.Excel.Range)worksheet.Cells[rowIndex, 2];
            oRange.Value2 = "STT";
            oRange.Borders.LineStyle = Microsoft.Office.Interop.Excel.Constants.xlSolid;
            oRange.Interior.ColorIndex = 38;
            for (int i = 0; i < dataspban.Columns.Count; i++)
            {
                oRange = (Microsoft.Office.Interop.Excel.Range)worksheet.Cells[rowIndex, i + 3];

                oRange.Value2 = dataspban.Columns[i].HeaderText;
                oRange.Font.Name = "Tahoma";
                oRange.Font.Size = "11";
                oRange.Borders.LineStyle = Microsoft.Office.Interop.Excel.Constants.xlSolid;
                oRange.Interior.ColorIndex = 38;
            }
            rowIndex++;
            int count = 1;
            for (int i = 0; i < dataspban.Rows.Count; i++)
            {
                oRange = (Microsoft.Office.Interop.Excel.Range)worksheet.Cells[i + rowIndex, 2];
                oRange.Value2 = count;
                oRange.Font.Name = "Tahoma";
                oRange.Font.Size = "11";
                oRange.Borders.LineStyle = Microsoft.Office.Interop.Excel.Constants.xlSolid;
                for (int j = 0; j < dataspban.Columns.Count; j++)
                {
                    oRange = (Microsoft.Office.Interop.Excel.Range)worksheet.Cells[i + rowIndex, j + 3];
                    oRange.Value2 = dataspban.Rows[i].Cells[j].Value + "";
                    oRange.Font.Name = "Tahoma";
                    oRange.Font.Size = "11";
                    oRange.Borders.LineStyle = Microsoft.Office.Interop.Excel.Constants.xlSolid;
                }
                count++;
            }
            rowIndex += count + 2;
            //doanh thu
            worksheet.Cells[rowIndex, 3] = "Doanh thu: ";
            worksheet.Cells[rowIndex, 4] = lbdoanhthu.Text;
            //số phiếu trả
            worksheet.Cells[rowIndex, 5] = "Số phiếu đổi trả: ";
            worksheet.Cells[rowIndex, 6] = lbdoitra.Text;


            rowIndex += 2;

            //sản phẩm bán chạy
            worksheet.Cells[rowIndex, 3] = "Sản phẩm bán chạy: ";
            worksheet.Cells[rowIndex, 4] = lbspbc.Text;
            //số khách hàng
            worksheet.Cells[rowIndex, 5] = "Số khách hàng: ";
            worksheet.Cells[rowIndex, 6] = lbkhachhang.Text;
            rowIndex += 2;
            //số sản phẩm bán chậm
            worksheet.Cells[rowIndex, 3] = "Sản phẩm bán chạy: ";
            worksheet.Cells[rowIndex, 4] = lbspin.Text;
            //tổng sản phẩm đã bán
            worksheet.Cells[rowIndex, 5] = "Tổng sản phẩm đã bán: ";
            worksheet.Cells[rowIndex, 6] = lbtonghangban.Text;
            rowIndex += 2;
            worksheet.Cells[rowIndex, 5] = "Người Lập: ";
            worksheet.Cells[rowIndex, 6] = "Trần Chiến Công";
            rowIndex++;

            excelApp.Columns.AutoFit();
            excelApp.Visible = true;

        }
        
        /*private void btnxuatpdf_Click(object sender, EventArgs e)
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

        private void ExportPdf(String strPdfPath)
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
            prgCuahang.Add(new Chunk(string.Format("CoCoShop"), fontBig));
            document.Add(prgCuahang);

            Paragraph prgCuahangdc = new Paragraph();
            prgCuahangdc.Alignment = Element.ALIGN_LEFT;
            prgCuahangdc.IndentationLeft = 5;
            prgCuahangdc.SpacingAfter = 5;
            prgCuahangdc.Add(new Chunk(string.Format("Beauty & Comestic"), font));
            document.Add(prgCuahangdc);

            #endregion

            #region header

            Paragraph prgdh = new Paragraph();
            prgdh.Alignment = Element.ALIGN_CENTER;
            prgdh.SpacingAfter = 5;
            prgdh.Add(new Chunk(string.Format("BÁO CÁO THỐNG KÊ"), fontBig));
            document.Add(prgdh);



            if (DateTime.Compare(ngaybd.Value.Date, ngaykt.Value.Date) == 0)
            {
                Paragraph prgMdh = new Paragraph();
                prgMdh.Alignment = Element.ALIGN_CENTER;
                prgMdh.SpacingAfter = 5;
                prgMdh.Add(new Chunk(string.Format("{0}", "Thời gian bán:" + ngaybd.Value.ToShortDateString()), fontBold));
                document.Add(prgMdh);

            }
            else
            {
                Paragraph prgMdh1 = new Paragraph();
                prgMdh1.Alignment = Element.ALIGN_CENTER;
                prgMdh1.SpacingAfter = 5;
                prgMdh1.Add(new Chunk(string.Format("{0}", "Thời gian bắt đầu:" + ngaybd.Value.ToShortDateString()), fontBold));
                document.Add(prgMdh1);
                Paragraph prgMdh2 = new Paragraph();
                prgMdh2.Alignment = Element.ALIGN_CENTER;
                prgMdh2.SpacingAfter = 5;
                prgMdh2.Add(new Chunk(string.Format("{0}", "Thời gian kết thúc:" + ngaykt.Value.ToShortDateString()), fontBold));
                document.Add(prgMdh2);
            }

            #endregion

            #region DataGridview
            PdfPTable table = new PdfPTable(4);
            table.SpacingBefore = 30;
            table.WidthPercentage = 100;
            for (int i = 0; i < c; i++)
            {
                PdfPCell cell = new PdfPCell();
                cell.BackgroundColor = iTextSharp.text.BaseColor.YELLOW;
                cell.AddElement(new Chunk(dataspban.Columns[i].HeaderText, font));
                table.AddCell(cell);
            }

            for (int i = 0; i < r; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    PdfPCell cell = new PdfPCell();
                    cell.AddElement(new Chunk(dataspban[j, i].Value.ToString(), font));
                    table.AddCell(cell);
                }

            }
            document.Add(table);
            #endregion

            #region tt chung
            Paragraph pTongtien = new Paragraph();
            pTongtien.Alignment = Element.ALIGN_LEFT;
            pTongtien.SpacingAfter = 5;
            pTongtien.SpacingBefore = 15;
            pTongtien.Add(new Chunk(string.Format("{0,-65}{1,-20}", "Doanh thu: " + lbdoanhthu.Text, "Số phiếu đổi trả: " + lbdoitra.Text), font));
            document.Add(pTongtien);


            Paragraph pkhth = new Paragraph();
            pkhth.Alignment = Element.ALIGN_LEFT;
            pkhth.SpacingAfter = 5;
            pkhth.SpacingBefore = 15;
            pkhth.Add(new Chunk(string.Format("{0,-65}{1,-20}", "Sản phẩm bán chạy: " + lbspbc.Text, "Số khách hàng: " + lbkhachhang.Text), font));
            document.Add(pkhth);

            Paragraph pkhth1 = new Paragraph();
            pkhth1.Alignment = Element.ALIGN_LEFT;
            pkhth1.SpacingAfter = 5;
            pkhth1.SpacingBefore = 15;
            pkhth1.Add(new Chunk(string.Format("{0,-65}{1,-20}", "Sản phẩm bán chậm: " + lbspin.Text, "Tổng số hàng đã bán: " + lbtonghangban.Text), font));
            document.Add(pkhth1);

            Paragraph pkhth2 = new Paragraph();
            pkhth2.Alignment = Element.ALIGN_RIGHT;
            pkhth2.SpacingAfter = 5;
            pkhth2.SpacingBefore = 15;
            pkhth1.Add(new Chunk(string.Format("{0}", "Người lập " + " Trần Chiến Công"), font));
            document.Add(pkhth2);
            #endregion

            document.Close();
            write.Close();
            fs.Close();
        }*/
    }
}
