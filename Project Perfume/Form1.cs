//หน้าล็อคอิน
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
    
    public partial class Login : Form
    {
        public static string usernamelogin;
        private MySqlConnection databaseConnection()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=projctperfume;";

            MySqlConnection conn = new MySqlConnection(connectionString);

            return conn;
            
        }
        public Login()
        {
            InitializeComponent();
        }
        
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

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
            if ((e.KeyChar < 48 || e.KeyChar > 57) && (e.KeyChar != 8))
            {
                e.Handled = true;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void loginbtn_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = databaseConnection();
            conn.Open();

            MySqlCommand cmd;

            cmd = conn.CreateCommand();
            cmd.CommandText = $"SELECT*FROM login WHERE 	username =\"{usernametext.Text}\" AND password=\"{passwordtext.Text}\"";

            MySqlDataReader Row = cmd.ExecuteReader();
            if (Row.HasRows)
            {
                pickup f3 = new pickup();
                MySqlConnection conn3 = databaseConnection();
                conn3.Open(); // สร้างพารามิเตอร์ ID เก็บค่า usernameText 
                MySqlCommand cmd2 = new MySqlCommand("SELECT username from login where  username = @ID", conn3);
                cmd2.Parameters.AddWithValue("@ID", (usernametext.Text));
                MySqlDataReader da = cmd2.ExecuteReader();
                while (da.Read())
                
                MessageBox.Show("Login Success", "Login ✓");
                usernamelogin = usernametext.Text;
                pickup f1 = new pickup();
                this.Hide();
                f1.Show();
                {
                    f1.namez = da.GetValue(0).ToString();
                    
                }

            }
            else { MessageBox.Show("Incorrect Username or Password", "Fail ✕"); }
            conn.Close();
            
        }

        private void adminbtn_Click(object sender, EventArgs e)
        {
            welcome login = new welcome();
            this.Hide();
            login.Show();
        }

        private void usernametext_TextChanged(object sender, EventArgs e)
        {

        }

        private void registerbtn_Click(object sender, EventArgs e)
        {
            Register f1 = new Register();
            this.Hide();
            f1.Show();
        }

        private void passwordtext_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void passwordtext_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (System.Text.Encoding.UTF8.GetByteCount(new char[] { e.KeyChar }) > 1)
            {
                e.Handled = true;
            }
        }

        private void usernametext_KeyPress(object sender, KeyPressEventArgs e)
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

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            welcome login = new welcome();
            this.Hide();
            login.Show();
        }

        private void passwordtext_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                loginbtn.PerformClick();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
