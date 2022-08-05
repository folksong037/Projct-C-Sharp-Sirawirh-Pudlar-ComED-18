//หน้าสมัครสมาชิก
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
    public partial class Register : Form
    {
        int X = 0;
        
        private MySqlConnection databaseConnection()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=projctperfume;";
            MySqlConnection conn = new MySqlConnection(connectionString);
            return conn;
        }
        public Register()
        {
            InitializeComponent();
            
        }

        private void Register_load(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }


        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void addbtn_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "" || textBox7.Text == "" || textBox8.Text == "")
            {
                MessageBox.Show("กรอกข้อมูลให้ครบถ้วน", "Fail ✕");
                
            }
            if(textBox8.Text.Length < 10)
            {
                MessageBox.Show("กรอกเบอร์โทรให้ครบถ้วน", "Fail ✕");
            }
            else
            {
                MySqlConnection conn = databaseConnection();
                conn.Open();
                MySqlCommand cmd;
                cmd = conn.CreateCommand();
                cmd.CommandText = $"SELECT*FROM login WHERE username =\"{textBox3.Text}\"";
                MySqlDataReader row = cmd.ExecuteReader();
                if (row.HasRows)
                {
                    MessageBox.Show("มีชื่อผู้ใช้นี้อยู่ในระบบอยู่แล้ว", "Fail ✕");
                    X = 2;
                }
                if (X == 0)

                {
                    MySqlConnection conn2 = databaseConnection();
                    String sql = "INSERT INTO login (username,password,name,email,address,tel) VALUES('" + textBox3.Text + "' , '" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + textBox8.Text + "')";
                    MySqlCommand cmd2 = new MySqlCommand(sql, conn2);
                    conn2.Open();
                    int rows = cmd2.ExecuteNonQuery();
                    conn2.Close();
                    if (rows > 0)

                    {
                        MessageBox.Show("Add data complete");
                        
                        textBox3.Clear();
                        textBox4.Clear();
                        textBox5.Clear();
                        textBox6.Clear();
                        textBox7.Clear();
                        textBox8.Clear();
                    }


                }
                X = 0;
            }
            


        }


        private void textBox3_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void backbtn_Click(object sender, EventArgs e)
        {
            welcome Register = new welcome();
            this.Hide();
            Register.Show();
        }

        private void Register_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 65 || e.KeyChar > 90)&&(e.KeyChar < 97 || e.KeyChar > 122) && (e.KeyChar != 8) && (e.KeyChar != 32))
            {
                e.Handled = true;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (System.Text.Encoding.UTF8.GetByteCount(new char[] { e.KeyChar }) > 1)
            {
                e.Handled = true;
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (System.Text.Encoding.UTF8.GetByteCount(new char[] { e.KeyChar }) > 1)
            {
                e.Handled = true;
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (System.Text.Encoding.UTF8.GetByteCount(new char[] { e.KeyChar }) > 1)
            {
                e.Handled = true;
            }
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(textBox8.Text.Length < 10)
            {
                if ((e.KeyChar < 48 || e.KeyChar > 57) && (e.KeyChar != 8))
                {
                    e.Handled = true;
                }
            }
            else
            {
                e.Handled = true;
            }
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {

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

        private void textBox8_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                addbtn.PerformClick();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}