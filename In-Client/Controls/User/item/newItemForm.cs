using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace In_Client.Controls.User
{
    public partial class newItemForm : Form
    {
        Action<items.Item> func;
        bool mouseDown;
        private Point offset;
        public newItemForm(Action<items.Item> func)
        {
            InitializeComponent();
            this.func = func;
        }

        private void foxButton1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("Поля не могут быть пустыми", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            auth.WebAuth.RequestPostAsync("admin/item", (req) =>
            {
                var item = req.GetJsonAsync<items.Item>().Result;
                func(item);
            }, new
            {

                name = textBox1.Text.Trim(),
                productName = textBox2.Text.Trim(),
                serialNumber = textBox3.Text.Trim()
            }) ;
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            offset.X = e.X;
            offset.Y = e.Y;
            mouseDown = true;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                Point currentScreenPos = PointToScreen(e.Location);
                Location = new Point(currentScreenPos.X - offset.X, currentScreenPos.Y - offset.Y);
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }
    }
}
