﻿using BTL.Forms.Main;
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
        public Loading()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            progressBar1.Increment(20);
            if (progressBar1.Value == 500)
            {
                timer1.Enabled = false;
                MainForm main = new MainForm();
                this.Close();
                main.Show();
                
            }
        }
    }
}