
namespace BTL.Forms.Main.Customer
{
    partial class UpdateFormKH
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ibtnThoat = new FontAwesome.Sharp.IconButton();
            this.ibtnUpdate = new FontAwesome.Sharp.IconButton();
            this.txtTichDiem = new System.Windows.Forms.TextBox();
            this.txtSDT = new System.Windows.Forms.TextBox();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.ibtnThoat);
            this.groupBox1.Controls.Add(this.ibtnUpdate);
            this.groupBox1.Controls.Add(this.txtTichDiem);
            this.groupBox1.Controls.Add(this.txtSDT);
            this.groupBox1.Controls.Add(this.txtHoTen);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.groupBox1.Location = new System.Drawing.Point(21, 38);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(473, 447);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông Tin Khách Hàng";
            // 
            // ibtnThoat
            // 
            this.ibtnThoat.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ibtnThoat.IconChar = FontAwesome.Sharp.IconChar.PaperPlane;
            this.ibtnThoat.IconColor = System.Drawing.Color.Black;
            this.ibtnThoat.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ibtnThoat.IconSize = 30;
            this.ibtnThoat.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.ibtnThoat.Location = new System.Drawing.Point(279, 380);
            this.ibtnThoat.Name = "ibtnThoat";
            this.ibtnThoat.Size = new System.Drawing.Size(138, 40);
            this.ibtnThoat.TabIndex = 53;
            this.ibtnThoat.Text = "Thoát";
            this.ibtnThoat.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.ibtnThoat.UseVisualStyleBackColor = true;
            this.ibtnThoat.Click += new System.EventHandler(this.ibtnThoat_Click);
            // 
            // ibtnUpdate
            // 
            this.ibtnUpdate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ibtnUpdate.IconChar = FontAwesome.Sharp.IconChar.PaintBrush;
            this.ibtnUpdate.IconColor = System.Drawing.Color.Black;
            this.ibtnUpdate.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ibtnUpdate.IconSize = 30;
            this.ibtnUpdate.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.ibtnUpdate.Location = new System.Drawing.Point(44, 380);
            this.ibtnUpdate.Name = "ibtnUpdate";
            this.ibtnUpdate.Size = new System.Drawing.Size(138, 40);
            this.ibtnUpdate.TabIndex = 52;
            this.ibtnUpdate.Text = "Sửa";
            this.ibtnUpdate.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.ibtnUpdate.UseVisualStyleBackColor = true;
            this.ibtnUpdate.Click += new System.EventHandler(this.ibtnUpdate_Click);
            // 
            // txtTichDiem
            // 
            this.txtTichDiem.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtTichDiem.ForeColor = System.Drawing.Color.Black;
            this.txtTichDiem.Location = new System.Drawing.Point(205, 298);
            this.txtTichDiem.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTichDiem.MaxLength = 10;
            this.txtTichDiem.Multiline = true;
            this.txtTichDiem.Name = "txtTichDiem";
            this.txtTichDiem.ReadOnly = true;
            this.txtTichDiem.Size = new System.Drawing.Size(241, 37);
            this.txtTichDiem.TabIndex = 49;
            this.txtTichDiem.Text = "0";
            // 
            // txtSDT
            // 
            this.txtSDT.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtSDT.ForeColor = System.Drawing.Color.Black;
            this.txtSDT.Location = new System.Drawing.Point(205, 188);
            this.txtSDT.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSDT.MaxLength = 11;
            this.txtSDT.Multiline = true;
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Size = new System.Drawing.Size(241, 37);
            this.txtSDT.TabIndex = 48;
            this.txtSDT.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSDT_KeyPress);
            // 
            // txtHoTen
            // 
            this.txtHoTen.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtHoTen.ForeColor = System.Drawing.Color.Black;
            this.txtHoTen.Location = new System.Drawing.Point(205, 78);
            this.txtHoTen.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtHoTen.Multiline = true;
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(241, 37);
            this.txtHoTen.TabIndex = 47;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label4.Location = new System.Drawing.Point(22, 192);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(138, 28);
            this.label4.TabIndex = 46;
            this.label4.Text = "Số điện thoại";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(22, 303);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(139, 28);
            this.label3.TabIndex = 45;
            this.label3.Text = "Điểm tích lũy";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(22, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 28);
            this.label1.TabIndex = 44;
            this.label1.Text = "Tên khách hàng";
            // 
            // UpdateFormKH
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(519, 509);
            this.Controls.Add(this.groupBox1);
            this.Name = "UpdateFormKH";
            this.Text = "Sửa Thông Tin Khách Hàng";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.UpdateFormKH_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private FontAwesome.Sharp.IconButton ibtnThoat;
        private FontAwesome.Sharp.IconButton ibtnUpdate;
        private System.Windows.Forms.TextBox txtTichDiem;
        private System.Windows.Forms.TextBox txtSDT;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
    }
}