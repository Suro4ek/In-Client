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
        public newUserForm(Action<auth.User> func)
        {
            InitializeComponent();
            this.func = func;
        }

        private void foxButton1_Click(object sender, EventArgs e)
        {
            if(bigTextBox1.Text == "" || bigTextBox2.Text == "" || bigTextBox3.Text == "" || bigTextBox4.Text == "" )
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
                }
                var user = req.GetJsonAsync<auth.User>().Result;
                func(user);
            }, new
            {
                familia = bigTextBox1.Text.Trim(),
                name = bigTextBox2.Text.Trim(),
                username = bigTextBox3.Text.Trim(),
                password = bigTextBox4.Text.Trim()
            }) ;
        }

    }
}
