
namespace Project_Perfume
{
    partial class Login
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.Button exit;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.usernametext = new System.Windows.Forms.TextBox();
            this.passwordtext = new System.Windows.Forms.TextBox();
            this.loginbtn = new System.Windows.Forms.Button();
            this.adminbtn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            exit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // exit
            // 
            exit.BackColor = System.Drawing.Color.Black;
            exit.Cursor = System.Windows.Forms.Cursors.Hand;
            exit.FlatAppearance.BorderSize = 0;
            exit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            exit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            exit.Font = new System.Drawing.Font("Dungeon", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            exit.ForeColor = System.Drawing.Color.Transparent;
            exit.Location = new System.Drawing.Point(11, 712);
            exit.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            exit.Name = "exit";
            exit.Size = new System.Drawing.Size(56, 45);
            exit.TabIndex = 8;
            exit.Text = "Exit";
            exit.UseVisualStyleBackColor = false;
            exit.Click += new System.EventHandler(this.exit_Click);
            // 
            // usernametext
            // 
            this.usernametext.BackColor = System.Drawing.Color.Black;
            this.usernametext.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.usernametext.Font = new System.Drawing.Font("Dungeon", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernametext.ForeColor = System.Drawing.Color.White;
            this.usernametext.Location = new System.Drawing.Point(188, 307);
            this.usernametext.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.usernametext.Multiline = true;
            this.usernametext.Name = "usernametext";
            this.usernametext.Size = new System.Drawing.Size(267, 23);
            this.usernametext.TabIndex = 1;
            this.usernametext.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.usernametext.TextChanged += new System.EventHandler(this.usernametext_TextChanged);
            this.usernametext.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.usernametext_KeyPress);
            // 
            // passwordtext
            // 
            this.passwordtext.BackColor = System.Drawing.Color.Black;
            this.passwordtext.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.passwordtext.Font = new System.Drawing.Font("Dungeon", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordtext.ForeColor = System.Drawing.Color.White;
            this.passwordtext.Location = new System.Drawing.Point(188, 395);
            this.passwordtext.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.passwordtext.Multiline = true;
            this.passwordtext.Name = "passwordtext";
            this.passwordtext.PasswordChar = '*';
            this.passwordtext.Size = new System.Drawing.Size(267, 23);
            this.passwordtext.TabIndex = 2;
            this.passwordtext.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.passwordtext.TextChanged += new System.EventHandler(this.passwordtext_TextChanged);
            this.passwordtext.KeyDown += new System.Windows.Forms.KeyEventHandler(this.passwordtext_KeyDown);
            this.passwordtext.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.passwordtext_KeyPress);
            // 
            // loginbtn
            // 
            this.loginbtn.BackColor = System.Drawing.Color.Navy;
            this.loginbtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.loginbtn.Font = new System.Drawing.Font("Dungeon", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginbtn.ForeColor = System.Drawing.Color.Snow;
            this.loginbtn.Location = new System.Drawing.Point(278, 464);
            this.loginbtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.loginbtn.Name = "loginbtn";
            this.loginbtn.Size = new System.Drawing.Size(88, 51);
            this.loginbtn.TabIndex = 5;
            this.loginbtn.Text = "Log in";
            this.loginbtn.UseVisualStyleBackColor = false;
            this.loginbtn.Click += new System.EventHandler(this.loginbtn_Click);
            // 
            // adminbtn
            // 
            this.adminbtn.BackColor = System.Drawing.Color.Chocolate;
            this.adminbtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.adminbtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.adminbtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.adminbtn.FlatAppearance.BorderSize = 0;
            this.adminbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.adminbtn.Font = new System.Drawing.Font("Dungeon", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.adminbtn.ForeColor = System.Drawing.Color.Black;
            this.adminbtn.Location = new System.Drawing.Point(11, 663);
            this.adminbtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.adminbtn.Name = "adminbtn";
            this.adminbtn.Size = new System.Drawing.Size(56, 45);
            this.adminbtn.TabIndex = 7;
            this.adminbtn.Text = "Back";
            this.adminbtn.UseVisualStyleBackColor = false;
            this.adminbtn.Click += new System.EventHandler(this.adminbtn_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(139, 334);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(330, 8);
            this.panel1.TabIndex = 9;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Location = new System.Drawing.Point(139, 422);
            this.panel2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(330, 8);
            this.panel2.TabIndex = 10;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 1);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(652, 768);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(652, 768);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(exit);
            this.Controls.Add(this.adminbtn);
            this.Controls.Add(this.loginbtn);
            this.Controls.Add(this.passwordtext);
            this.Controls.Add(this.usernametext);
            this.Controls.Add(this.pictureBox1);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.SaddleBrown;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.TransparencyKey = System.Drawing.Color.Yellow;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox usernametext;
        private System.Windows.Forms.TextBox passwordtext;
        private System.Windows.Forms.Button loginbtn;
        private System.Windows.Forms.Button adminbtn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

