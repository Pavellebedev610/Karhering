using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Karhering
{
    public partial class Registration : Form
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void label7_Click(object sender, EventArgs e)
        {
        }

        private void button_Click(object sender, EventArgs e)
        {
            Baza dataBases = new Baza();
            var fio = guna2TextBox1.Text;
            var mail = guna2TextBox3.Text;
            var password = guna2TextBox2.Text;
            var number_prav = guna2TextBox4.Text;
            var telefon = guna2TextBox5.Text;

            string querystring = $"insert into client(FIO, mail, password, number_prav, telefon) values ('{fio}','{mail}','{password}','{number_prav}','{telefon}')";

            SqlCommand command = new SqlCommand(querystring, dataBases.getConnection());

            dataBases.openConnection();

            if (command.ExecuteNonQuery() == 1)
            {
                DataBank.Text2 = guna2TextBox5.Text;
                MessageBox.Show("accaunt succesful create!");
                Login frmlgn = new Login();
                this.Hide();
                frmlgn.ShowDialog();
            }
            else
            {
                MessageBox.Show("akkaunt ne sozdan");
            }
            dataBases.closeConnection();
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void guna2TextBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
