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
        string familia, name;
        public editUserForm(Action<auth.User> func, int userId, string familia, string name)
        {
            InitializeComponent();
            this.func = func;
            this.userId = userId;
            this.familia = familia;
            this.name = name;
            bigTextBox1.Text = familia;
            bigTextBox2.Text = name;
        }

        private void foxButton1_Click(object sender, EventArgs e)
        {
            if(bigTextBox1.Text == "" || bigTextBox2.Text == "" || bigTextBox4.Text == "" )
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
                password = bigTextBox4.Text.Trim()
            }) ;
        }

    }
}
