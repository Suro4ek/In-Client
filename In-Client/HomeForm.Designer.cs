namespace In_Client
{
    partial class HomeForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panelContainer = new System.Windows.Forms.Panel();
            this.airButton1 = new ReaLTaiizor.Controls.AirButton();
            this.airButton2 = new ReaLTaiizor.Controls.AirButton();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.MediumPurple;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1061, 100);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Adobe Gothic Std B", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(50, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 40);
            this.label1.TabIndex = 0;
            this.label1.Text = "Inventory";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.airButton2);
            this.panel2.Controls.Add(this.airButton1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 100);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1061, 100);
            this.panel2.TabIndex = 1;
            // 
            // panelContainer
            // 
            this.panelContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContainer.Location = new System.Drawing.Point(0, 200);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Size = new System.Drawing.Size(1061, 450);
            this.panelContainer.TabIndex = 2;
            // 
            // airButton1
            // 
            this.airButton1.Customization = "7e3t//Ly8v/r6+v/5ubm/+vr6//f39//p6en/zw8PP8UFBT/gICA/w==";
            this.airButton1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.airButton1.Image = null;
            this.airButton1.Location = new System.Drawing.Point(0, 0);
            this.airButton1.Name = "airButton1";
            this.airButton1.NoRounding = false;
            this.airButton1.Size = new System.Drawing.Size(192, 100);
            this.airButton1.TabIndex = 0;
            this.airButton1.Text = "Инвентарь";
            this.airButton1.Transparent = false;
            this.airButton1.Click += new System.EventHandler(this.airButton1_Click);
            // 
            // airButton2
            // 
            this.airButton2.Customization = "7e3t//Ly8v/r6+v/5ubm/+vr6//f39//p6en/zw8PP8UFBT/gICA/w==";
            this.airButton2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.airButton2.Image = null;
            this.airButton2.Location = new System.Drawing.Point(192, 0);
            this.airButton2.Name = "airButton2";
            this.airButton2.NoRounding = false;
            this.airButton2.Size = new System.Drawing.Size(192, 100);
            this.airButton2.TabIndex = 1;
            this.airButton2.Text = "Пользователи";
            this.airButton2.Transparent = false;
            // 
            // HomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1061, 650);
            this.Controls.Add(this.panelContainer);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "HomeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HomeForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Panel panel2;
        private Panel panelContainer;
        private ReaLTaiizor.Controls.AirButton airButton1;
        private ReaLTaiizor.Controls.AirButton airButton2;
    }
}