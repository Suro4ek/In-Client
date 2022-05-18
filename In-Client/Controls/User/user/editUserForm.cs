using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace In_Client.Controls.User.user
{
    public partial class editUserForm : Form
    {
        Action<auth.User> func;
        int userId;
        bool mouseDown;
        private Point offset;
        public editUserForm(Action<auth.User> func, int userId, string familia, string name)
        {
            InitializeComponent();
            this.func = func;
            this.userId = userId;
            textBox1.Text = familia;
            textBox2.Text = name;
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            Close();
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

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            offset.X = e.X;
            offset.Y = e.Y;
            mouseDown = true;
        }

        private void foxButton1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" )
            {
                MessageBox.Show("Поля не могут быть пустыми", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            auth.WebAuth.RequestPatchAsync("admin/user/"+ userId, (req) =>
            {
                if(req.StatusCode == 500)
                {
                    var error = req.GetJsonAsync<auth.ErrorJson>().Result;
                    if(error.message == "wrong password")
                    {
                        MessageBox.Show("Некоректное пароль\n" +
                            "Пароль должно содеражать больше 5 символов", 
                            "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    return;
                }
                var user = req.GetJsonAsync<auth.User>().Result;
                func(user);
            }, new
            {
                familia = textBox1.Text.Trim(),
                name = textBox2.Text.Trim(),
                password = textBox3.Text.Trim()
            }) ;
        }

    }
}
