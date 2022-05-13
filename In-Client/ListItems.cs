using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace In_Client
{
    public partial class ListItems : Form
    {

        public List<items.Item> items;
        BindingSource bindingSource;
        public ListItems()
        {
            InitializeComponent();
            auth.WebAuth.RequestGet("items", (res) =>
            {
                var stream = res.Content.ReadAsStream();
                var items = System.Text.Json.JsonSerializer.Deserialize<List<items.Item>>(stream);
                this.items = items;
                return null;
            });
            bindingSource = new BindingSource();
            bindingSource.DataSource = items;
            listBox1.DataSource = bindingSource;
        }

        private void addItem_Click(object sender, EventArgs e)
        {
            InputForm inputForm = new InputForm();
            inputForm.Controls.Add(inputForm.addLabel("Название"));
            TextBox name = inputForm.addTextBox();
            inputForm.Controls.Add(name);

            inputForm.Controls.Add(inputForm.addLabel("Название продукта"));
            TextBox nameProduct = inputForm.addTextBox();
            inputForm.Controls.Add(nameProduct);

            inputForm.Controls.Add(inputForm.addLabel("Серийный номер"));
            TextBox serialNumber = inputForm.addTextBox();
            inputForm.Controls.Add(serialNumber);

            inputForm.button.Text = "Сохранить";
            inputForm.button.Click += new EventHandler((object s, EventArgs e1) =>
            {
                auth.WebAuth.RequestPostAsync("item", (res) =>
                {

                    return null;
                }, new Dictionary<string, string>
                {
                    {"name", name.Text },
                    {"productName", nameProduct.Text },
                    {"serialNumber", serialNumber.Text },
                });
                inputForm.Close();
            });

            inputForm.ShowDialog();

        }

        private void DeleteItem_Click(object sender, EventArgs e)
        {

        }

        private void EditItem_Click(object sender, EventArgs e)
        {

        }

        private void SetOwner_Click(object sender, EventArgs e)
        {

        }

        private void ListItems_Load(object sender, EventArgs e)
        {

        }
    }
}
