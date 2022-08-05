using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Project_Perfume
{
    public partial class Addmin : Form
    {
        public static string adminlogin;
        private MySqlConnection databaseConnection()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=projctperfume;";
            MySqlConnection conn = new MySqlConnection(connectionString);
            return conn;
        }
        public Addmin()
        {
            InitializeComponent();
        }


        private void textBox1_TextChanged_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (System.Text.Encoding.UTF8.GetByteCount(new char[] { e.KeyChar }) > 1)
            {
                e.Handled = true;
            }
        }

        private void textBox2_TextChanged_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && (e.KeyChar != 8))
            {
                e.Handled = true;
            }
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void login_Click_1(object sender, EventArgs e)
        {
            MySqlConnection conn = databaseConnection();
            conn.Open();

            MySqlCommand cmd;

            cmd = conn.CreateCommand();
            cmd.CommandText = $"SELECT*FROM addmin WHERE 	nameaddmin =\"{textBox1.Text}\" AND passwordaddmin=\"{textBox2.Text}\"";

            MySqlDataReader Row = cmd.ExecuteReader();
            if (Row.HasRows)
            {
                MessageBox.Show("Login Admin Success", "Admin ✓");
                Product Addmin = new Product();
                adminlogin = textBox1.Text;
                this.Hide();
                Addmin.Show();
            }
            else { MessageBox.Show("Incorrect Username or Password", "Admin Fail ✕"); }
            conn.Close();
        }

        private void Addmin_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void backbtn_Click(object sender, EventArgs e)
        {
            welcome Addmin = new welcome();
            this.Hide();
            Addmin.Show();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (System.Text.Encoding.UTF8.GetByteCount(new char[] { e.KeyChar }) > 1)
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (System.Text.Encoding.UTF8.GetByteCount(new char[] { e.KeyChar }) > 1)
            {
                e.Handled = true;
            }
        }

        private void exit_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you want to exit application", "Exit ?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Application.Exit();
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                login.PerformClick();
            }
        }
    }
}