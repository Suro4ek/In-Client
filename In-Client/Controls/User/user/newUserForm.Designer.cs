namespace In_Client.Controls.User.user
{
    partial class newUserForm
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
            this.foxLabel1 = new ReaLTaiizor.Controls.FoxLabel();
            this.foxLabel2 = new ReaLTaiizor.Controls.FoxLabel();
            this.foxLabel4 = new ReaLTaiizor.Controls.FoxLabel();
            this.foxButton1 = new ReaLTaiizor.Controls.FoxButton();
            this.bigLabel1 = new ReaLTaiizor.Controls.BigLabel();
            this.bigTextBox1 = new ReaLTaiizor.Controls.BigTextBox();
            this.bigTextBox2 = new ReaLTaiizor.Controls.BigTextBox();
            this.bigTextBox3 = new ReaLTaiizor.Controls.BigTextBox();
            this.bigTextBox4 = new ReaLTaiizor.Controls.BigTextBox();
            this.foxLabel3 = new ReaLTaiizor.Controls.FoxLabel();
            this.SuspendLayout();
            // 
            // foxLabel1
            // 
            this.foxLabel1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.foxLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(88)))), ((int)(((byte)(100)))));
            this.foxLabel1.Location = new System.Drawing.Point(12, 64);
            this.foxLabel1.Name = "foxLabel1";
            this.foxLabel1.Size = new System.Drawing.Size(216, 30);
            this.foxLabel1.TabIndex = 1;
            this.foxLabel1.Text = "Фамилия";
            // 
            // foxLabel2
            // 
            this.foxLabel2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.foxLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(88)))), ((int)(((byte)(100)))));
            this.foxLabel2.Location = new System.Drawing.Point(12, 147);
            this.foxLabel2.Name = "foxLabel2";
            this.foxLabel2.Size = new System.Drawing.Size(216, 30);
            this.foxLabel2.TabIndex = 3;
            this.foxLabel2.Text = "Имя";
            // 
            // foxLabel4
            // 
            this.foxLabel4.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.foxLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(88)))), ((int)(((byte)(100)))));
            this.foxLabel4.Location = new System.Drawing.Point(12, 230);
            this.foxLabel4.Name = "foxLabel4";
            this.foxLabel4.Size = new System.Drawing.Size(216, 30);
            this.foxLabel4.TabIndex = 7;
            this.foxLabel4.Text = "Никнейм";
            // 
            // foxButton1
            // 
            this.foxButton1.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.foxButton1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(193)))), ((int)(((byte)(193)))));
            this.foxButton1.DisabledBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.foxButton1.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(209)))), ((int)(((byte)(209)))));
            this.foxButton1.DisabledTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(178)))), ((int)(((byte)(190)))));
            this.foxButton1.DownColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(232)))), ((int)(((byte)(232)))));
            this.foxButton1.EnabledCalc = true;
            this.foxButton1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.foxButton1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(78)))), ((int)(((byte)(90)))));
            this.foxButton1.Location = new System.Drawing.Point(35, 447);
            this.foxButton1.Name = "foxButton1";
            this.foxButton1.OverColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.foxButton1.Size = new System.Drawing.Size(290, 60);
            this.foxButton1.TabIndex = 8;
            this.foxButton1.Text = "Добавить";
            this.foxButton1.Click += new ReaLTaiizor.Util.FoxBase.ButtonFoxBase.ClickEventHandler(this.foxButton1_Click);
            // 
            // bigLabel1
            // 
            this.bigLabel1.AutoSize = true;
            this.bigLabel1.BackColor = System.Drawing.Color.Transparent;
            this.bigLabel1.Font = new System.Drawing.Font("Segoe UI", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.bigLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.bigLabel1.Location = new System.Drawing.Point(12, 15);
            this.bigLabel1.Name = "bigLabel1";
            this.bigLabel1.Size = new System.Drawing.Size(347, 46);
            this.bigLabel1.TabIndex = 9;
            this.bigLabel1.Text = "Новый пользователь";
            // 
            // bigTextBox1
            // 
            this.bigTextBox1.BackColor = System.Drawing.Color.Transparent;
            this.bigTextBox1.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.bigTextBox1.ForeColor = System.Drawing.Color.DimGray;
            this.bigTextBox1.Image = null;
            this.bigTextBox1.Location = new System.Drawing.Point(12, 100);
            this.bigTextBox1.MaxLength = 32767;
            this.bigTextBox1.Multiline = false;
            this.bigTextBox1.Name = "bigTextBox1";
            this.bigTextBox1.ReadOnly = false;
            this.bigTextBox1.Size = new System.Drawing.Size(339, 41);
            this.bigTextBox1.TabIndex = 10;
            this.bigTextBox1.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.bigTextBox1.UseSystemPasswordChar = false;
            // 
            // bigTextBox2
            // 
            this.bigTextBox2.BackColor = System.Drawing.Color.Transparent;
            this.bigTextBox2.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.bigTextBox2.ForeColor = System.Drawing.Color.DimGray;
            this.bigTextBox2.Image = null;
            this.bigTextBox2.Location = new System.Drawing.Point(12, 183);
            this.bigTextBox2.MaxLength = 32767;
            this.bigTextBox2.Multiline = false;
            this.bigTextBox2.Name = "bigTextBox2";
            this.bigTextBox2.ReadOnly = false;
            this.bigTextBox2.Size = new System.Drawing.Size(339, 41);
            this.bigTextBox2.TabIndex = 11;
            this.bigTextBox2.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.bigTextBox2.UseSystemPasswordChar = false;
            // 
            // bigTextBox3
            // 
            this.bigTextBox3.BackColor = System.Drawing.Color.Transparent;
            this.bigTextBox3.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.bigTextBox3.ForeColor = System.Drawing.Color.DimGray;
            this.bigTextBox3.Image = null;
            this.bigTextBox3.Location = new System.Drawing.Point(12, 266);
            this.bigTextBox3.MaxLength = 32767;
            this.bigTextBox3.Multiline = false;
            this.bigTextBox3.Name = "bigTextBox3";
            this.bigTextBox3.ReadOnly = false;
            this.bigTextBox3.Size = new System.Drawing.Size(339, 41);
            this.bigTextBox3.TabIndex = 12;
            this.bigTextBox3.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.bigTextBox3.UseSystemPasswordChar = false;
            // 
            // bigTextBox4
            // 
            this.bigTextBox4.BackColor = System.Drawing.Color.Transparent;
            this.bigTextBox4.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.bigTextBox4.ForeColor = System.Drawing.Color.DimGray;
            this.bigTextBox4.Image = null;
            this.bigTextBox4.Location = new System.Drawing.Point(12, 361);
            this.bigTextBox4.MaxLength = 32767;
            this.bigTextBox4.Multiline = false;
            this.bigTextBox4.Name = "bigTextBox4";
            this.bigTextBox4.ReadOnly = false;
            this.bigTextBox4.Size = new System.Drawing.Size(339, 41);
            this.bigTextBox4.TabIndex = 14;
            this.bigTextBox4.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.bigTextBox4.UseSystemPasswordChar = true;
            // 
            // foxLabel3
            // 
            this.foxLabel3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.foxLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(88)))), ((int)(((byte)(100)))));
            this.foxLabel3.Location = new System.Drawing.Point(12, 325);
            this.foxLabel3.Name = "foxLabel3";
            this.foxLabel3.Size = new System.Drawing.Size(216, 30);
            this.foxLabel3.TabIndex = 13;
            this.foxLabel3.Text = "Пароль";
            // 
            // newUserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(375, 535);
            this.Controls.Add(this.bigTextBox4);
            this.Controls.Add(this.foxLabel3);
            this.Controls.Add(this.bigTextBox3);
            this.Controls.Add(this.bigTextBox2);
            this.Controls.Add(this.bigTextBox1);
            this.Controls.Add(this.bigLabel1);
            this.Controls.Add(this.foxButton1);
            this.Controls.Add(this.foxLabel4);
            this.Controls.Add(this.foxLabel2);
            this.Controls.Add(this.foxLabel1);
            this.Name = "newUserForm";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private ReaLTaiizor.Controls.FoxLabel foxLabel1;
        private ReaLTaiizor.Controls.FoxLabel foxLabel2;
        private ReaLTaiizor.Controls.FoxLabel foxLabel4;
        private ReaLTaiizor.Controls.FoxButton foxButton1;
        private ReaLTaiizor.Controls.BigLabel bigLabel1;
        private ReaLTaiizor.Controls.BigTextBox bigTextBox1;
        private ReaLTaiizor.Controls.BigTextBox bigTextBox2;
        private ReaLTaiizor.Controls.BigTextBox bigTextBox3;
        private ReaLTaiizor.Controls.BigTextBox bigTextBox4;
        private ReaLTaiizor.Controls.FoxLabel foxLabel3;
    }
}