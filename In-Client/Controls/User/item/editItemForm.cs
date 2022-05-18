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
    public partial class editItemForm : Form
    {
        Action<items.Item> func;
        bool mouseDown;
        private Point offset;
        int id;
        public editItemForm(int id, string name, string productName, string serialNumber, Action<items.Item> func)
        {
            this.id = id;
            InitializeComponent();
            this.func = func;
            textBox1.Text = name;
            textBox2.Text = productName;
            textBox3.Text = serialNumber;
        }

        private void foxButton1_Click(object sender, EventArgs e)
        {
            auth.WebAuth.RequestPatchAsync("api/item/"+id, (req) =>
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

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                Point currentScreenPos = PointToScreen(e.Location);
                Location = new Point(currentScreenPos.X - offset.X, currentScreenPos.Y - offset.Y);
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            offset.X = e.X;
            offset.Y = e.Y;
            mouseDown = true;
        }
    }
}
