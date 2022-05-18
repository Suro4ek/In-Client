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
    public partial class newUserForm : Form
    {
        Action<auth.User> func;
        bool mouseDown;
        private Point offset;
        public newUserForm(Action<auth.User> func)
        {
            InitializeComponent();
            this.func = func;
        }

        private void foxButton1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" )
            {
                MessageBox.Show("Поля не могут быть пустыми", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            auth.WebAuth.RequestPostAsync("admin/register", (req) =>
            {
                if(req.StatusCode == 500)
                {
                    var error = req.GetJsonAsync<auth.ErrorJson>().Result;
                    if(error.message == "error user is duplicate") {
                        MessageBox.Show("Такое имя пользователя уже занято", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }else if(error.message == "wrong username")
                    {
                        MessageBox.Show("Некоректное имя пользователя\n" +
                            "Имя пользователя должно содеражать больше 3 символов\n" +
                            "и только буквы", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }else if(error.message == "wrong password")
                    {
                        MessageBox.Show("Некоректное пароль\n" +
                            "Паоль должно содеражать больше 5 символов", 
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
                username = textBox4.Text.Trim(),
                password = textBox3.Text.Trim()
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
