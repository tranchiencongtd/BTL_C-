using BTL.Forms.Main;
using BTL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL.Forms.Login
{
    public partial class Loading : Form
    {
        public TaiKhoan user;

        public Loading(TaiKhoan x)
        {
            InitializeComponent();
            user = x;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            progressBar1.Increment(20);
            if (progressBar1.Value == 500)
            {
                timer1.Enabled = false;
                MainForm main = new MainForm(user);
                this.Close();
                main.Show();
                
            }
        }
    }
}
