//หน้าเพิ่มสินค้าเเละดูประวัติการซื้อ
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
    public partial class Product : Form
    {
        
        private void showdataGridView1()
        {
            MySqlConnection conn = databaseConnection();
            DataSet ds = new DataSet();
            conn.Open();
            MySqlCommand cmd;
            cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM product";
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(ds);
            conn.Close();
            dataGridView1.DataSource = ds.Tables[0].DefaultView;
        }

        private void showdataGridView2()
        {
            MySqlConnection conn = databaseConnection();
            DataSet ds = new DataSet();
            conn.Open();
            MySqlCommand cmd;
            cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM history2";
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(ds);
            conn.Close();
            dataGridView2.DataSource = ds.Tables[0].DefaultView;
        }

        private MySqlConnection databaseConnection()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=projctperfume;";
            MySqlConnection conn = new MySqlConnection(connectionString);
            return conn;
        }

        public Product()
        {
            InitializeComponent();
            showdataGridView1();
            showdataGridView2();
            panel1.Hide();
        }

        private void Product_Load(object sender, EventArgs e)
        {
            showdataGridView1();
            showdataGridView2();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.CurrentRow.Selected = true;
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["id"].FormattedValue.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["nameproduct"].FormattedValue.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells["price"].FormattedValue.ToString();
            textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells["stock"].FormattedValue.ToString();
        }


        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && (e.KeyChar != 8))
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

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && (e.KeyChar != 8))
            {
                e.Handled = true;
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && (e.KeyChar != 8))
            {
                e.Handled = true;
            }
        }


        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to EDIT Product?", "EDIT Product", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    int selectedRow = dataGridView1.CurrentCell.RowIndex;
                    int editId = Convert.ToInt32(dataGridView1.Rows[selectedRow].Cells["id"].Value);
                    MySqlConnection conn = databaseConnection();
                    String sql = "UPDATE product SET nameproduct = '" + textBox2.Text + "' , price = '" + textBox3.Text + "' , stock = '" + textBox4.Text + "' WHERE id = '" + editId + "'";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    conn.Open();
                    int rows = cmd.ExecuteNonQuery();
                    conn.Close();
                    if (rows > 0)
                    {
                        MessageBox.Show("Edit Product Complete", "EDIT");
                        showdataGridView1();
                    }
                }
                else if (dialogResult == DialogResult.No)
                {
                    //do something else
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Fail โปรดตรวจสอบข้อมูลอีกครั้ง", "Erorr");
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to SAVE Product", "SAVE Product", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    MySqlConnection conn = databaseConnection();
                    String sql = "INSERT INTO product (id,nameproduct,price,stock) VALUES('" + textBox1.Text + "' , '" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "' )";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    conn.Open();
                    int rows = cmd.ExecuteNonQuery();
                    conn.Close();
                    if (rows > 0)
                    {
                        MessageBox.Show("SAVE Product Complete","SAVE");
                        showdataGridView1();
                    }
                }
                else if (dialogResult == DialogResult.No)
                {
                    //do something else
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Fail โปรดตรวจสอบข้อมูลอีกครั้ง","Erorr");
            }            
            
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to DELETE Product", "DELETE Product", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    int selectedRow = dataGridView1.CurrentCell.RowIndex;
                    int deleteId = Convert.ToInt32(dataGridView1.Rows[selectedRow].Cells["id"].Value);
                    MySqlConnection conn = databaseConnection();
                    String sql = "DELETE FROM product WHERE id = '" + deleteId + "'";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    conn.Open();
                    int rows = cmd.ExecuteNonQuery();
                    conn.Close();
                    if (rows > 0)
                    {
                        MessageBox.Show("DELETE Product Complete", "DELETE");
                        showdataGridView1();
                    }  //do something
                }
                else if (dialogResult == DialogResult.No)
                {
                    //do something else
                }
            }
            catch (Exception) { }
            
            
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void Product_Load_1(object sender, EventArgs e)
        {
            int w = Screen.PrimaryScreen.Bounds.Width;
            int h = Screen.PrimaryScreen.Bounds.Height;
            this.Location = new Point(0, 0);
            this.Size = new Size(w, h);
            label1.Text = "ACCOUNT : " + Addmin.adminlogin;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            welcome Product = new welcome();
            this.Hide();
            Product.Show();
        }

        private void historybtn_Click(object sender, EventArgs e)
        {
            panel1.Show();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox5.Text != "")
            {
                MySqlConnection conn = databaseConnection();
                DataSet ds = new DataSet();
                conn.Open();
                MySqlCommand cmd;
                cmd = conn.CreateCommand();
                cmd.CommandText = ($"SELECT*FROM history2 WHERE namecustomer like\"%{textBox5.Text}\"");
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(ds);
                MySqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    MySqlConnection conn2 = databaseConnection();
                    conn2.Open();
                    MySqlCommand cmd2;
                    cmd2 = conn2.CreateCommand(); // เอาราคาจาก total ใน From history2 มาบวกกัน ให้เป็นราคาทั้งหมดของผุ้คนนั้นๆ
                    cmd2.CommandText = ($"SELECT SUM(total) FROM history2 WHERE namecustomer like\"%{textBox5.Text}\"");
                    MySqlDataReader dr2 = cmd2.ExecuteReader();
                    while (dr2.Read())
                    {
                        textBox6.Text = Convert.ToString(dr2[0]); // จะขึ้นโชว์ ราคารวมทั้งหมดที่ textBox6
                    }
                    conn2.Close();
                }
                conn.Close();
                dataGridView2.DataSource = ds.Tables[0].DefaultView; // โชว์ข้อมูลลูกค้าใน dataGridView2 ด้วย
            }
            else
            {
                showdataGridView2(); //หากไม่เสิร์ชชื่อ ก็จะโชว์ข้อมูลลูกค้าทุกคนทั้งหมด
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            panel1.Hide();
        }

        private void button8_Click(object sender, EventArgs e) // คำนวณยอดขายในเเต่ละวัน
        {
            textBox6.Text = "0";
            MySqlConnection conn = databaseConnection();
            DataSet ds = new DataSet();
            conn.Open();
            MySqlCommand cmd;
            cmd = conn.CreateCommand();
            cmd.CommandText = ($"SELECT*FROM history2 WHERE date BETWEEN \"{dateTimePicker1.Text}\" AND \"{dateTimePicker2.Text}\"");
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(ds);
            MySqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                
                MySqlConnection conn2 = databaseConnection();
                conn2.Open();
                MySqlCommand cmd2;
                cmd2 = conn2.CreateCommand(); // เอาราคาจาก total ใน From history2 มาบวกกัน ในระหว่างวันนั้นๆที่เราเลือกในปฏิทิน
                cmd2.CommandText = ($"SELECT SUM(total) FROM history2 WHERE date BETWEEN \"{dateTimePicker1.Text}\" AND \"{dateTimePicker2.Text}\"");
                MySqlDataReader dr2 = cmd2.ExecuteReader();
                while (dr2.Read())
                {
                    
                    textBox6.Text = Convert.ToString(dr2[0]); // จะขึ้นโชว์ ราคารวมยอดขายทั้งหมดที่ textBox6
                }
                conn2.Close();
            }
            conn.Close();
            dataGridView2.DataSource = ds.Tables[0].DefaultView;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (System.Text.Encoding.UTF8.GetByteCount(new char[] { e.KeyChar }) > 1)
            {
                e.Handled = true;
            }
        }

        private void textBox1_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && (e.KeyChar != 8))
            {
                e.Handled = true;
            }
        }

        private void textBox3_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && (e.KeyChar != 8))
            {
                e.Handled = true;
            }
        }

        private void textBox4_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && (e.KeyChar != 8))
            {
                e.Handled = true;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
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

        private void textBox5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button6.PerformClick();
            }
        }
    }
}
