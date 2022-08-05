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
using System.Text.RegularExpressions;

namespace Project_Perfume
{
    public partial class pickup : Form
    {   public String namez;
        
        String product_price; 
        int productprice_total = 0;
        List<String> de; // product name
        List<String> pri; // product price
        String get_it;
        
        int sumbt = 0;
        int total = 0;
        
        String addresstrue;
        String nametrue;
        String pricee;
        String menu;
        
        private void showdataGridView2()
        {
            panel1.Hide();
            MySqlConnection conn = databaseConnection();
            DataSet ds = new DataSet();
            conn.Open();
            MySqlCommand cmd;
            cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM product";
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
        public pickup()
        {
            InitializeComponent();
            receipt.Visible = false; //ซ่อนปุ่มสลิป ใบเสร็จ
            ReceiptLabel.Visible = false;
            showdataGridView2();
            pictureBox9.Visible = false;
            label6.Visible = false;
            pictureBox10.Visible = true;
            pictureBox12.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView2.CurrentRow.Selected = true; 
            detail.Text = dataGridView2.Rows[e.RowIndex].Cells["detail"].FormattedValue.ToString();
            name.Text = dataGridView2.Rows[e.RowIndex].Cells["nameproduct"].FormattedValue.ToString();
            price.Text = dataGridView2.Rows[e.RowIndex].Cells["price"].FormattedValue.ToString();
            stock.Text = dataGridView2.Rows[e.RowIndex].Cells["stock"].FormattedValue.ToString();
            link.Text = dataGridView2.Rows[e.RowIndex].Cells["link"].FormattedValue.ToString();
            pictureBox2.ImageLocation = $@"{link.Text}";
            path.Text = dataGridView2.Rows[e.RowIndex].Cells["path"].FormattedValue.ToString();
            pictureBox3.ImageLocation = $@"{path.Text}";
            path2.Text = dataGridView2.Rows[e.RowIndex].Cells["path2"].FormattedValue.ToString();
            pictureBox4.ImageLocation = $@"{path2.Text}";
            path3.Text = dataGridView2.Rows[e.RowIndex].Cells["path3"].FormattedValue.ToString();
            pictureBox5.ImageLocation = $@"{path3.Text}";
            path4.Text = dataGridView2.Rows[e.RowIndex].Cells["path4"].FormattedValue.ToString();
            pictureBox6.ImageLocation = $@"{path4.Text}";
            pictureBox8.Visible = false;
        }

        private void pickup_Load(object sender, EventArgs e)
        {
            showdataGridView2();
            panel1.Hide();
            timer1.Start();
            
        }

        private void pickupbtn_Click(object sender, EventArgs e)
        {
            
            
            int stockk = int.Parse(stock.Text);
            if(stockk > 0) // ถ้าสินค้าไม่เป็น 0 ก็จะเลือกสินค้าได้
            {
                product_price = ($"{price.Text}");
                int product_price2 = int.Parse(product_price); // เปลี่ยน product_price จาก  string ไปเป็น int เพื่อใช้ในการคำนวณ
                textBox4.Clear();
                productprice_total = product_price2 + productprice_total;
                textBox4.SelectedText = ($"{productprice_total}"); // ราคารวมไปใส่ไว้ใน textBox4 

                total = productprice_total;
                richTextBox2.SelectedText = ($"{name.Text}\n");
                richTextBox3.SelectedText = ($"{price.Text}\n");
                sumbt += 1; // เพิ่มชื่อสินค้าเข้าไปใน Bill
                stockk -= 1; //  ลบจำนวนสต๊อกสินค้า
                
                MySqlConnection conn = databaseConnection();
                MySqlCommand cmd = conn.CreateCommand();
                conn.Open();
                cmd.CommandText = $"UPDATE product SET stock = \"{stockk}\" WHERE nameproduct = \"{name.Text}\""; // อัพเดตข้อมูลสต๊อก จาก stockk ที่เปลี่ยนค่ามาเป็น int แล้ว  
                int rows = cmd.ExecuteNonQuery();
                if(rows > 0)
                {
                    pictureBox10.Visible = false;
                    pictureBox9.Visible = true;
                    label6.Visible = true;
                    MessageBox.Show($"You have aleady picked up","Pick up");
                    showdataGridView2();
                    stock.Text = stockk.ToString(); // จะเป็นการอัพเดต stock หลังจากที่ไก้เลือกสินค้าไป
                    pictureBox9.Visible = false;
                    label6.Visible = false;
                    pictureBox10.Visible = true;
                }
            }
            else
            {
                MessageBox.Show("Out of stock","Stock"); // ถ้าหาก stock สินค้าเป็น 0 ก็จะขึ้นว่าสินค้าหมด
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {
           

        }

        private void button5_Click(object sender, EventArgs e)
        {
            panel1.Hide();
            showdataGridView2();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            panel1.Show();
            num_load();
        }

        private void num_load() // สร้างฟังชันก์แสดงลำดับสอนค้าที่เราซื้อ
        {
            richTextBox4.Clear(); // เป็นการ split new line ของลำดับสินค้า
            string[] productname = richTextBox2.Text.Split(new string[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
            int loop = productname.Length;
            int n = 0;
            for (int i = 0; i < loop - 1; i++)
            {
                if(productname[i] != "")
                {
                    n += 1;
                    richTextBox4.Text += $"{n}\n";
                }
                
            }
        }

        private void detail_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form8 pickup = new Form8();
            pickup.Show();
            receipt.Visible = true;
            ReceiptLabel.Visible = true;// แสดงปุ่มสลิป ใบเสร็จ
            pictureBox12.Visible = true;
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            day.Text = DateTime.Now.ToLongTimeString(); // ประกาศให้ใช้งานเป็น วัน เวลา ปัจจุบัน
            timer.Text = DateTime.Now.ToLongDateString();
        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }
        List<Bill> allbill = new List<Bill>();
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            MySqlConnection conn = databaseConnection();
            MySqlCommand cmd = conn.CreateCommand();
            MySqlCommand cmd2 = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = $"SELECT name FROM login WHERE username = \"{namez}\"";// นำเอาชื่อของลูกค้ามาใช้ใน Bill
            MySqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                nametrue = Convert.ToString(dr.GetValue(0).ToString());
                

            }
            conn.Close();
            conn.Open();
            cmd2.CommandText = $"SELECT address FROM login WHERE username = \"{namez}\"";
            MySqlDataReader dr2 = cmd2.ExecuteReader();
            if (dr2.Read())
            {
                addresstrue = Convert.ToString(dr2.GetValue(0).ToString());


            }
            conn.Close();
            e.Graphics.DrawString("BILL", new Font("Footlight MT Light", 24, FontStyle.Bold), Brushes.MediumBlue, new Point(50, 30));
            e.Graphics.DrawString("NIKAI MODEL STORE", new Font("Script MT Bold", 26, FontStyle.Bold), Brushes.Blue, new Point(50, 90));
            e.Graphics.DrawString("Date " + System.DateTime.Now.ToString("dd/MM/yyyy HH : mm : ss น."), new Font("Footlight MT Light", 14, FontStyle.Regular), Brushes.MediumBlue, new PointF(500, 150));
            e.Graphics.DrawString("--------------------------------------------------------------------------------------------", new Font("Footlight MT Light", 16, FontStyle.Regular), Brushes.MediumBlue, new Point(80, 190));
            e.Graphics.DrawString(" ITEM                                                         PRICE(฿)", new Font("Footlight MT Light", 20, FontStyle.Regular), Brushes.MediumBlue, new Point(130, 220));
            e.Graphics.DrawString("--------------------------------------------------------------------------------------------", new Font("Footlight MT Light", 16, FontStyle.Regular), Brushes.MediumBlue, new Point(80, 250));
            int y = 320;
            int number = 1;
            int i = 0;
            e.Graphics.DrawString("" + pricee, new Font("Footlight MT Light", 16, FontStyle.Regular), Brushes.Blue, new PointF(80, 280));
            e.Graphics.DrawString("" + menu, new Font("Footlight MT Light", 16, FontStyle.Regular), Brushes.Blue, new PointF(650, 280));

            for (i = 0; i < sumbt; i += 1)
            {
                y = y + 23;
            }

            number = number + 1;
            {
                e.Graphics.DrawString("--------------------------------------------------------------------------------------------", new Font("Footlight MT Light", 16, FontStyle.Regular), Brushes.MediumBlue, new Point(80, y + 20));
                e.Graphics.DrawString("SUBTOTAL        " + total.ToString() + "฿", new Font("Footlight MT Light", 16, FontStyle.Regular), Brushes.MediumBlue, new Point(500, (y + 30) + 45));
                e.Graphics.DrawString("CUSTOMER        " + nametrue.ToString(), new Font("Footlight MT Light", 16, FontStyle.Bold), Brushes.MediumBlue, new Point(80, (y + 30) + 45));
                e.Graphics.DrawString("PAYMENT          " + total + "฿", new Font("Footlight MT Light", 16, FontStyle.Regular), Brushes.MediumBlue, new Point(500, ((y + 30) + 45) + 45));
                e.Graphics.DrawString("ADDRESS          " + addresstrue.ToString(), new Font("Footlight MT Light", 16, FontStyle.Bold), Brushes.MediumBlue, new Point(80, (((y + 30) + 45) + 45) + 45));


            }
            total = 0;
            sumbt = 0;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you Cler all the Items", "Cler Items", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                string[] productname = richTextBox2.Text.Split(new string[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);

                richTextBox2.Clear();
                richTextBox3.Clear();
                productprice_total = 0;
                textBox4.Clear();
                

                int loop = productname.Length;
                for (int i = 0; i < loop - 1; i++)
                {
                    MySqlConnection conn = databaseConnection();
                    MySqlCommand cmd = conn.CreateCommand();
                    conn.Open();
                    cmd.CommandText = $"SELECT stock FROM product WHERE nameproduct = \"{productname[i]}\"";
                    MySqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        int stockk = Convert.ToInt32(dr.GetValue(0).ToString());
                        stockk += 1;
                        MySqlConnection conn2 = databaseConnection();
                        MySqlCommand cmd2 = conn2.CreateCommand();
                        conn2.Open();
                        cmd2.CommandText = $"UPDATE product SET stock = \"{stockk}\" WHERE nameproduct = \"{productname[i]}\"";
                        int rows = cmd2.ExecuteNonQuery();
                        if (rows > 0)
                        {
                            showdataGridView2();
                        }
                        conn2.Close();

                    }
                    conn.Close();
                }
                MessageBox.Show("Clear the All Items", "CLEAR");
                textBox6.Clear();
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }

        }
        private void day_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            Login pickup = new Login();
            this.Hide();
            pickup.Show();
        }

        private void pickup_Load_1(object sender, EventArgs e)
        {
            int w = Screen.PrimaryScreen.Bounds.Width;
            int h = Screen.PrimaryScreen.Bounds.Height;
            this.Location = new Point(0, 0);
            this.Size = new Size(w, h);
            label4.Text = "ACCOUNT : " + Login.usernamelogin;
            label3.Text = "ACCOUNT : " + Login.usernamelogin;
            day.Text = System.DateTime.Now.ToShortDateString();
            timer.Text = System.DateTime.Now.ToShortTimeString();

            


        }

        private void delete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you to DELETE Item", "DELETE Item", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                string[] productname = richTextBox2.Text.Split(new string[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
                string[] productprice = richTextBox3.Text.Split(new string[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
                richTextBox2.Clear();
                richTextBox3.Clear();
                productprice_total = 0;
                textBox4.Clear();
                
            
                de = productname.ToList(); // list ของ productname
                pri = productprice.ToList(); // list ของ productprice
                int num_de = int.Parse(textBox6.Text); // เอาไว้ใช้ลบข้อมูลใน textBox6

                String nameproductstock = de[num_de - 1];

            
                
                de.Remove(de[num_de - 1]); // เอาข้อมูลออกจาก list productname จากข้อมูลที่คีย์ไปใน textBox6
                pri.Remove(pri[num_de - 1]); // เอาข้อมูลออกจาก list productprice จากข้อมูลที่คีย์ไปใน textBox6
                int loop = de.Count(); //  .Count นับว่าจำนวนใน de มีกี่ตัว
                for (int i = 0; i < loop; i++) // เป็นการ loop reset ลำดับของสินค้า เช่น ลำดับที่ 2 ออก จะเป็น 1 2 จะไม่เป็น  1 3
                {
                    richTextBox2.Text += de[i] + "\n"; // เอา list de ตำแหน่งที่ i มาไว้อันดับแรก และ loop ไปเรื่อยๆ
                    richTextBox3.Text += pri[i] + "\n"; // เอา list pri ตำแหน่งที่ i มาไว้อันดับแรก และ loop ไปเรื่อยๆ
                }

                int total = 0;
                for (int i = 0; i < (pri.Count()-1); i++) // เอาราคาที่ลบสินค้าออกไปแล้ว มาบวกก็จะได้ total ตัวใหม่
                {
                    if (pri[i] != "")
                    {
                        int pric = int.Parse(pri[i]);
                        total += pric;
                    }
                
                }
                textBox4.Text = total.ToString();
                MessageBox.Show("Deleted the Item","DELETE");
                num_load();

                MySqlConnection conn = databaseConnection();
                MySqlCommand cmd = conn.CreateCommand();
                conn.Open();
                cmd.CommandText = $"SELECT stock FROM product WHERE nameproduct = \"{nameproductstock}\"";
                MySqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    int stockk = Convert.ToInt32(dr.GetValue(0).ToString());
                    stockk += 1;
                    MySqlConnection conn2 = databaseConnection();
                    MySqlCommand cmd2 = conn2.CreateCommand();
                    conn2.Open();
                    cmd2.CommandText = $"UPDATE product SET stock = \"{stockk}\" WHERE nameproduct = \"{nameproductstock}\"";
                    int rows = cmd2.ExecuteNonQuery();
                    if (rows > 0)
                    {
                    
                    }
                    conn2.Close();

                }
                conn.Close();
                textBox6.Clear();
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            Login pickup = new Login();
            this.Hide();
            pickup.Show();
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            Login pickup = new Login();
            this.Hide();
            pickup.Show();
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && (e.KeyChar != 8))
            {
                e.Handled = true;
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && (e.KeyChar != 8))
            {
                e.Handled = true;
            }
        }

        private void price_TextChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            MySqlConnection conn = databaseConnection();

            MySqlCommand cmd2 = conn.CreateCommand();
            conn.Open();
            cmd2.CommandText = $"SELECT address FROM login WHERE username = \"{namez}\"";// นำเอาชื่อของลูกค้ามาใช้ใน Bill
            MySqlDataReader dr = cmd2.ExecuteReader();
            if (dr.Read())
            {
                addresstrue = Convert.ToString(dr.GetValue(0).ToString());


            }
            conn.Close();
            
                // หากชำระเงินเรียบร้อย จะนำข้อมูลลูกค้าที่ซื้อลงใน database
                String sql = "INSERT INTO history2 ( namecustomer,productcustomer,total,address2,date,time) VALUES('" + namez + "','" + richTextBox2.Text + "','" + textBox4.Text + "','" + addresstrue + "','" + day.Text + "','" + timer.Text + "')";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                conn.Close();
                pricee = richTextBox2.Text; // ประกาศชื่อเพื่อให้ข้อมูลเข้าไปอยู่ใน Bill ด้วย
                menu = richTextBox3.Text;

                richTextBox2.Clear();
                richTextBox3.Clear();

                
                
                textBox4.Clear();
                
                printPreviewDialog1.Document = printDocument1; // print Bill
                printPreviewDialog1.ShowDialog(); // shoe Bill ในการซื้อสินค้าครั้งนั้น
            
            num_load();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click_2(object sender, EventArgs e)
        {
            welcome pickup = new welcome();
            this.Hide();
            pickup.Show();
        }

        private void pictureBox3_Click_1(object sender, EventArgs e)
        {

        }

        private void next_Click(object sender, EventArgs e)
        {
            if (pictureBox2.Visible == true)
            {
                pictureBox3.Visible = true;
                pictureBox4.Visible = false;
                pictureBox2.Visible = false;
                pictureBox5.Visible = false;
                pictureBox6.Visible = true;
                pictureBox8.Visible = false;
            }
            else if (pictureBox3.Visible == true)
            {
                pictureBox4.Visible = true;
                pictureBox3.Visible = false;
                pictureBox2.Visible = false;
                pictureBox5.Visible = false;
                pictureBox6.Visible = false;
                pictureBox8.Visible = false;
            }
            else if (pictureBox4.Visible == true)
            {
                pictureBox2.Visible = false;
                pictureBox3.Visible = false;
                pictureBox4.Visible = false;
                pictureBox5.Visible = true;
                pictureBox6.Visible = false;
                pictureBox8.Visible = false;
            }
            else if (pictureBox5.Visible == true)
            {
                pictureBox2.Visible = false;
                pictureBox3.Visible = false;
                pictureBox4.Visible = false;
                pictureBox5.Visible = false;
                pictureBox6.Visible = true;
                pictureBox8.Visible = false;
            }
            else if (pictureBox6.Visible == true)
            {
                pictureBox2.Visible = true;
                pictureBox3.Visible = false;
                pictureBox4.Visible = false;
                pictureBox5.Visible = false;
                pictureBox6.Visible = false;
                pictureBox8.Visible = false;
            }
        }

        private void backbtn_Click(object sender, EventArgs e)
        {
            if (pictureBox2.Visible == true)
            {
                pictureBox3.Visible = false;
                pictureBox4.Visible = false;
                pictureBox2.Visible = false;
                pictureBox5.Visible = false;
                pictureBox6.Visible = true;
                pictureBox8.Visible = false;
            }
            else if (pictureBox3.Visible == true)
            {
                pictureBox4.Visible = false;
                pictureBox3.Visible = false;
                pictureBox2.Visible = true;
                pictureBox5.Visible = false;
                pictureBox6.Visible = false;
                pictureBox8.Visible = false;
            }
            else if (pictureBox4.Visible == true)
            {
                pictureBox2.Visible = false;
                pictureBox3.Visible = true;
                pictureBox4.Visible = false;
                pictureBox5.Visible = false;
                pictureBox6.Visible = false;
                pictureBox8.Visible = false;
            }
            else if (pictureBox5.Visible == true)
            {
                pictureBox2.Visible = false;
                pictureBox3.Visible = false;
                pictureBox4.Visible = true;
                pictureBox5.Visible = false;
                pictureBox6.Visible = false;
                pictureBox8.Visible = false;
            }
            else if (pictureBox6.Visible == true)
            {
                pictureBox2.Visible = false;
                pictureBox3.Visible = false;
                pictureBox4.Visible = false;
                pictureBox5.Visible = true;
                pictureBox6.Visible = false;
                pictureBox8.Visible = false;
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
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

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            welcome pickup = new welcome();
            this.Hide();
            pickup.Show();
        }

        private void button10_Click(object sender, EventArgs e)
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

        private void button12_Click(object sender, EventArgs e)
        {
            panel1.Hide();
            showdataGridView2();
        }

        private void label6_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click_1(object sender, EventArgs e)
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

        private void pictureBox11_Click(object sender, EventArgs e)
        {

        }
    }
}