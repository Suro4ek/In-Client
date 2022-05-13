namespace In_Client
{
    partial class ListItems
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
            this.components = new System.ComponentModel.Container();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.изменитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.назначитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 15;
            this.listBox1.Location = new System.Drawing.Point(36, 46);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(501, 229);
            this.listBox1.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.изменитьToolStripMenuItem,
            this.удалитьToolStripMenuItem,
            this.назначитьToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(133, 70);
            // 
            // изменитьToolStripMenuItem
            // 
            this.изменитьToolStripMenuItem.Name = "изменитьToolStripMenuItem";
            this.изменитьToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.изменитьToolStripMenuItem.Text = "Изменить";
            // 
            // удалитьToolStripMenuItem
            // 
            this.удалитьToolStripMenuItem.Name = "удалитьToolStripMenuItem";
            this.удалитьToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.удалитьToolStripMenuItem.Text = "Удалить";
            // 
            // назначитьToolStripMenuItem
            // 
            this.назначитьToolStripMenuItem.Name = "назначитьToolStripMenuItem";
            this.назначитьToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.назначитьToolStripMenuItem.Text = "Назначить";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(36, 321);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(127, 61);
            this.button1.TabIndex = 1;
            this.button1.Text = "Добавить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.addItem_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(193, 321);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(127, 61);
            this.button2.TabIndex = 2;
            this.button2.Text = "Удалить";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.DeleteItem_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(345, 321);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(127, 61);
            this.button3.TabIndex = 3;
            this.button3.Text = "Изменить";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.EditItem_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(491, 321);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(127, 61);
            this.button4.TabIndex = 4;
            this.button4.Text = "Задать";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.SetOwner_Click);
            // 
            // ListItems
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listBox1);
            this.Name = "ListItems";
            this.Text = "ListItems";
            this.Load += new System.EventHandler(this.ListItems_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ListBox listBox1;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem изменитьToolStripMenuItem;
        private ToolStripMenuItem удалитьToolStripMenuItem;
        private ToolStripMenuItem назначитьToolStripMenuItem;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
    }
}