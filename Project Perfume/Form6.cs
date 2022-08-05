using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_Perfume
{
    public partial class welcome : Form
    {
        public welcome()
        {
            InitializeComponent();
        }

        private void website_Click(object sender, EventArgs e)
        {
            Login web = new Login();
            this.Hide();
            web.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Register web = new Register();
            this.Hide();
            web.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Addmin web = new Addmin();
            this.Hide();
            web.Show();
        }

        private void welcome_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
