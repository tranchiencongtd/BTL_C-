
namespace BTL.Forms.Main.DatHang
{
    partial class AddSanPhamDat
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxMaSP = new System.Windows.Forms.ComboBox();
            this.txtTenSP = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSoLuongDat = new System.Windows.Forms.TextBox();
            this.txtDonGia = new System.Windows.Forms.TextBox();
            this.btnTim = new FontAwesome.Sharp.IconButton();
            this.btnHuy = new FontAwesome.Sharp.IconButton();
            this.btnThemSP = new FontAwesome.Sharp.IconButton();
            this.btnTaiLai = new FontAwesome.Sharp.IconButton();
            this.btnTimSPTonDuoi = new FontAwesome.Sharp.IconButton();
            this.txtSLTonDuoi = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dgvSP = new System.Windows.Forms.DataGridView();
            this.maSanPham = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tenSanPham = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SLTon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dmDatHang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.labelTieuDe = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSP)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(365, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(295, 41);
            this.label1.TabIndex = 4;
            this.label1.Text = "Thêm sản phẩm đặt";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(68, 191);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 28);
            this.label5.TabIndex = 8;
            this.label5.Text = "Đơn giá:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(23, 141);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(130, 28);
            this.label4.TabIndex = 9;
            this.label4.Text = "Số lượng đặt:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(16, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 28);
            this.label3.TabIndex = 10;
            this.label3.Text = "Tên sản phẩm:";
            // 
            // comboBoxMaSP
            // 
            this.comboBoxMaSP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMaSP.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.comboBoxMaSP.FormattingEnabled = true;
            this.comboBoxMaSP.Location = new System.Drawing.Point(159, 36);
            this.comboBoxMaSP.Name = "comboBoxMaSP";
            this.comboBoxMaSP.Size = new System.Drawing.Size(227, 36);
            this.comboBoxMaSP.TabIndex = 7;
            this.comboBoxMaSP.SelectedIndexChanged += new System.EventHandler(this.comboBoxMaSP_SelectedIndexChanged);
            // 
            // txtTenSP
            // 
            this.txtTenSP.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtTenSP.Location = new System.Drawing.Point(159, 87);
            this.txtTenSP.Name = "txtTenSP";
            this.txtTenSP.Size = new System.Drawing.Size(227, 34);
            this.txtTenSP.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(16, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 28);
            this.label2.TabIndex = 5;
            this.label2.Text = "Mã sản phẩm:";
            // 
            // txtSoLuongDat
            // 
            this.txtSoLuongDat.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtSoLuongDat.Location = new System.Drawing.Point(159, 138);
            this.txtSoLuongDat.Name = "txtSoLuongDat";
            this.txtSoLuongDat.Size = new System.Drawing.Size(227, 34);
            this.txtSoLuongDat.TabIndex = 6;
            // 
            // txtDonGia
            // 
            this.txtDonGia.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtDonGia.Location = new System.Drawing.Point(159, 188);
            this.txtDonGia.Name = "txtDonGia";
            this.txtDonGia.Size = new System.Drawing.Size(227, 34);
            this.txtDonGia.TabIndex = 6;
            // 
            // btnTim
            // 
            this.btnTim.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnTim.IconChar = FontAwesome.Sharp.IconChar.Search;
            this.btnTim.IconColor = System.Drawing.Color.Black;
            this.btnTim.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnTim.IconSize = 30;
            this.btnTim.Location = new System.Drawing.Point(404, 87);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(48, 35);
            this.btnTim.TabIndex = 70;
            this.btnTim.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTim.UseVisualStyleBackColor = true;
            this.btnTim.Click += new System.EventHandler(this.btnTim_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnHuy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHuy.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnHuy.ForeColor = System.Drawing.Color.White;
            this.btnHuy.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnHuy.IconColor = System.Drawing.Color.Black;
            this.btnHuy.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnHuy.Location = new System.Drawing.Point(262, 415);
            this.btnHuy.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(113, 53);
            this.btnHuy.TabIndex = 72;
            this.btnHuy.Text = "HỦY";
            this.btnHuy.UseVisualStyleBackColor = false;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // btnThemSP
            // 
            this.btnThemSP.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnThemSP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemSP.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnThemSP.ForeColor = System.Drawing.Color.White;
            this.btnThemSP.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnThemSP.IconColor = System.Drawing.Color.Black;
            this.btnThemSP.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnThemSP.Location = new System.Drawing.Point(143, 415);
            this.btnThemSP.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnThemSP.Name = "btnThemSP";
            this.btnThemSP.Size = new System.Drawing.Size(113, 53);
            this.btnThemSP.TabIndex = 71;
            this.btnThemSP.Text = "THÊM";
            this.btnThemSP.UseVisualStyleBackColor = false;
            this.btnThemSP.Click += new System.EventHandler(this.btnThemSP_Click);
            // 
            // btnTaiLai
            // 
            this.btnTaiLai.IconChar = FontAwesome.Sharp.IconChar.Redo;
            this.btnTaiLai.IconColor = System.Drawing.Color.Black;
            this.btnTaiLai.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnTaiLai.IconSize = 25;
            this.btnTaiLai.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTaiLai.Location = new System.Drawing.Point(950, 101);
            this.btnTaiLai.Name = "btnTaiLai";
            this.btnTaiLai.Size = new System.Drawing.Size(80, 32);
            this.btnTaiLai.TabIndex = 78;
            this.btnTaiLai.Text = "Tải lại";
            this.btnTaiLai.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTaiLai.UseVisualStyleBackColor = true;
            this.btnTaiLai.Click += new System.EventHandler(this.btnTaiLai_Click);
            // 
            // btnTimSPTonDuoi
            // 
            this.btnTimSPTonDuoi.IconChar = FontAwesome.Sharp.IconChar.Search;
            this.btnTimSPTonDuoi.IconColor = System.Drawing.Color.Black;
            this.btnTimSPTonDuoi.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnTimSPTonDuoi.IconSize = 25;
            this.btnTimSPTonDuoi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTimSPTonDuoi.Location = new System.Drawing.Point(806, 104);
            this.btnTimSPTonDuoi.Name = "btnTimSPTonDuoi";
            this.btnTimSPTonDuoi.Size = new System.Drawing.Size(35, 32);
            this.btnTimSPTonDuoi.TabIndex = 77;
            this.btnTimSPTonDuoi.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTimSPTonDuoi.UseVisualStyleBackColor = true;
            this.btnTimSPTonDuoi.Click += new System.EventHandler(this.btnTimSPTonDuoi_Click);
            // 
            // txtSLTonDuoi
            // 
            this.txtSLTonDuoi.Location = new System.Drawing.Point(666, 107);
            this.txtSLTonDuoi.Name = "txtSLTonDuoi";
            this.txtSLTonDuoi.Size = new System.Drawing.Size(125, 27);
            this.txtSLTonDuoi.TabIndex = 76;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(497, 108);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(163, 25);
            this.label6.TabIndex = 75;
            this.label6.Text = "Số lượng tồn dưới:";
            // 
            // dgvSP
            // 
            this.dgvSP.AllowUserToAddRows = false;
            this.dgvSP.AllowUserToDeleteRows = false;
            this.dgvSP.AllowUserToOrderColumns = true;
            this.dgvSP.AllowUserToResizeRows = false;
            this.dgvSP.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSP.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvSP.BackgroundColor = System.Drawing.Color.White;
            this.dgvSP.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvSP.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvSP.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightPink;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.LightPink;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSP.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSP.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.maSanPham,
            this.tenSanPham,
            this.SLTon,
            this.dmDatHang});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(5, 7, 5, 7);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(226)))), ((int)(((byte)(246)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSP.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvSP.EnableHeadersVisualStyles = false;
            this.dgvSP.GridColor = System.Drawing.Color.DimGray;
            this.dgvSP.Location = new System.Drawing.Point(501, 143);
            this.dgvSP.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvSP.Name = "dgvSP";
            this.dgvSP.ReadOnly = true;
            this.dgvSP.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSP.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvSP.RowHeadersVisible = false;
            this.dgvSP.RowHeadersWidth = 51;
            this.dgvSP.RowTemplate.Height = 29;
            this.dgvSP.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSP.Size = new System.Drawing.Size(529, 325);
            this.dgvSP.TabIndex = 74;
            this.dgvSP.DoubleClick += new System.EventHandler(this.dgvSP_DoubleClick);
            // 
            // maSanPham
            // 
            this.maSanPham.FillWeight = 96.9697F;
            this.maSanPham.HeaderText = "Mã sản phẩm";
            this.maSanPham.MinimumWidth = 6;
            this.maSanPham.Name = "maSanPham";
            this.maSanPham.ReadOnly = true;
            // 
            // tenSanPham
            // 
            this.tenSanPham.FillWeight = 162.3917F;
            this.tenSanPham.HeaderText = "Tên sản phẩm";
            this.tenSanPham.MinimumWidth = 6;
            this.tenSanPham.Name = "tenSanPham";
            this.tenSanPham.ReadOnly = true;
            // 
            // SLTon
            // 
            this.SLTon.FillWeight = 83.05437F;
            this.SLTon.HeaderText = "Số lượng tồn";
            this.SLTon.MinimumWidth = 6;
            this.SLTon.Name = "SLTon";
            this.SLTon.ReadOnly = true;
            // 
            // dmDatHang
            // 
            this.dmDatHang.HeaderText = "Định mức đặt hàng";
            this.dmDatHang.MinimumWidth = 6;
            this.dmDatHang.Name = "dmDatHang";
            this.dmDatHang.ReadOnly = true;
            // 
            // labelTieuDe
            // 
            this.labelTieuDe.AutoSize = true;
            this.labelTieuDe.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelTieuDe.Location = new System.Drawing.Point(496, 73);
            this.labelTieuDe.Name = "labelTieuDe";
            this.labelTieuDe.Size = new System.Drawing.Size(282, 28);
            this.labelTieuDe.TabIndex = 73;
            this.labelTieuDe.Text = "Danh sách sản phẩm sắp hết";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnTim);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.comboBoxMaSP);
            this.groupBox1.Controls.Add(this.txtDonGia);
            this.groupBox1.Controls.Add(this.txtSoLuongDat);
            this.groupBox1.Controls.Add(this.txtTenSP);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.Location = new System.Drawing.Point(29, 132);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(462, 261);
            this.groupBox1.TabIndex = 79;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sản phẩm cần thêm vào phiếu đặt";
            // 
            // AddSanPhamDat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1070, 506);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnTaiLai);
            this.Controls.Add(this.btnTimSPTonDuoi);
            this.Controls.Add(this.txtSLTonDuoi);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dgvSP);
            this.Controls.Add(this.labelTieuDe);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.btnThemSP);
            this.Controls.Add(this.label1);
            this.Name = "AddSanPhamDat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddSanPhamDat";
            this.Load += new System.EventHandler(this.AddSanPhamDat_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSP)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxMaSP;
        private System.Windows.Forms.TextBox txtTenSP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSoLuongDat;
        private System.Windows.Forms.TextBox txtDonGia;
        private FontAwesome.Sharp.IconButton btnTim;
        private FontAwesome.Sharp.IconButton btnHuy;
        private FontAwesome.Sharp.IconButton btnThemSP;
        private FontAwesome.Sharp.IconButton btnTaiLai;
        private FontAwesome.Sharp.IconButton btnTimSPTonDuoi;
        private System.Windows.Forms.TextBox txtSLTonDuoi;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dgvSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn maSanPham;
        private System.Windows.Forms.DataGridViewTextBoxColumn tenSanPham;
        private System.Windows.Forms.DataGridViewTextBoxColumn SLTon;
        private System.Windows.Forms.DataGridViewTextBoxColumn dmDatHang;
        private System.Windows.Forms.Label labelTieuDe;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}