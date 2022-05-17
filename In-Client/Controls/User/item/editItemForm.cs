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
        int id;
        public editItemForm(int id, string name, string productName, string serialNumber, Action<items.Item> func)
        {
            this.id = id;
            InitializeComponent();
            this.func = func;
            bigTextBox1.Text = name;
            bigTextBox2.Text = productName;
            bigTextBox3.Text = serialNumber;
        }

        private void foxButton1_Click(object sender, EventArgs e)
        {
            if(bigTextBox1.Text == "" || bigTextBox2.Text == "" || bigTextBox3.Text == "")
            {
                MessageBox.Show("Поля не могут быть пустыми", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            auth.WebAuth.RequestPatchAsync("api/item/"+id, (req) =>
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
