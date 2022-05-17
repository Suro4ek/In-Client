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
        public newItemForm(Action<items.Item> func)
        {
            InitializeComponent();
            this.func = func;
        }

        private void foxButton1_Click(object sender, EventArgs e)
        {
            if(bigTextBox1.Text == "" || bigTextBox2.Text == "" || bigTextBox3.Text == "")
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

                name = bigTextBox1.Text.Trim(),
                productName = bigTextBox2.Text.Trim(),
                serialNumber = bigTextBox3.Text.Trim()
            }) ;
        }

    }
}
