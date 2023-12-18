using Guna.UI2.WinForms;
using Microsoft.VisualBasic.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Karhering
{
    public partial class Nastroiki : Form
    {
        public Nastroiki()
        {
            InitializeComponent();
            label6.Text = DataBank.Text2;
            label6.Text = DataBank.Text3;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Hub log = new Hub();
            this.Hide();
            log.Show();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Login log = new Login();
            this.Hide();
            log.Show();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            Delete log = new Delete();
            log.Show();
        }
    }
}

