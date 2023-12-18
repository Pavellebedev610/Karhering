using Microsoft.VisualBasic.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Karhering
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {


        }

        private void button_Click(object sender, EventArgs e)
        {
            Baza dataBases = new Baza();

            var mail = guna2TextBox1.Text;
            var password = guna2TextBox2.Text;

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            string querystring = $"select id_polz, FIO, number_prav from client where mail = '{mail}' and password ='{password}'";

            SqlCommand command = new SqlCommand(querystring, dataBases.getConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);




            if (table.Rows.Count == 1)
            {
                DataBank.Text = guna2TextBox3.Text;
                DataBank.Text3 = guna2TextBox1.Text;
                MessageBox.Show("Вы вошли!");
                Hub log1 = new Hub();
                this.Hide();
                log1.Show();

            }
            else
                MessageBox.Show("Такого пользователя нет!");

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Registration log = new Registration();
            this.Hide();
            log.Show();
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
