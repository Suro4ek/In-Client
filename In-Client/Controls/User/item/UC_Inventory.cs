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
    public partial class UC_Inventory : UserControl
    {
        public List<items.Item>? items;
        public UC_Inventory()
        {
            InitializeComponent();
            if (Program.localSettings.user.role != "admin")
            {
                nightButton5.Visible = true;
                nightButton1.Visible = false;
                nightButton2.Visible = false;
                nightButton3.Visible = false;
                nightButton4.Visible = false;
            }
        }

        private void nightButton1_Click(object sender, EventArgs e)
        {
            newItemForm form = new newItemForm((item) =>
            {
                poisonDataGridView1.Rows.Add(item.ID, item.name, item.productName, item.serialNumber, "");
            });
            form.ShowDialog();
        }

        private void nightButton2_Click(object sender, EventArgs e)
        {
            int currentIndex = poisonDataGridView1.CurrentRow.Index;
            if (poisonDataGridView1[0, currentIndex].Value != null)
            {
                int id = (int)poisonDataGridView1[0, currentIndex].Value;
                string name = (string)poisonDataGridView1[1, currentIndex].Value;
                string productName = (string)poisonDataGridView1[2, currentIndex].Value;
                string serialNumber = (string)poisonDataGridView1[3, currentIndex].Value;
                editItemForm form = new editItemForm(id, name, productName, serialNumber,
                    (item) =>
                    {
                        poisonDataGridView1[0, currentIndex].Value = item.ID;
                        poisonDataGridView1[1, currentIndex].Value = item.name;
                        poisonDataGridView1[2, currentIndex].Value = item.productName;
                        poisonDataGridView1[3, currentIndex].Value = item.serialNumber;
                        poisonDataGridView1[4, currentIndex].Value = "нету";
                    });
                form.ShowDialog();
            }
        }

        private void nightButton3_Click(object sender, EventArgs e)
        {
            int currentIndex = poisonDataGridView1.CurrentRow.Index;
            if (poisonDataGridView1[0, currentIndex].Value != null)
            {
                int id = (int)poisonDataGridView1[0, currentIndex].Value;
                auth.WebAuth.RequestDeleteAsync("item/" + id, (req) =>
                {
                    poisonDataGridView1.Rows.RemoveAt(currentIndex);
                });
            }
        }

        private void onLoad(object sender, EventArgs e)
        {
            var column1 = new DataGridViewColumn();
            column1.HeaderText = "ID"; //текст в шапке
            column1.Width = 100; //ширина колонки
            column1.ReadOnly = true; //значение в этой колонке нельзя править
            column1.Name = "id"; //текстовое имя колонки, его можно использовать вместо обращений по индексу
            column1.Frozen = true; //флаг, что данная колонка всегда отображается на своем месте
            column1.CellTemplate = new DataGridViewTextBoxCell(); //тип нашей колонки

            var column2 = new DataGridViewColumn();
            column2.HeaderText = "Название"; //текст в шапке
            column2.Width = 200; //ширина колонки
            column2.ReadOnly = true; //значение в этой колонке нельзя править
            column2.Name = "name"; //текстовое имя колонки, его можно использовать вместо обращений по индексу
            column2.Frozen = true; //флаг, что данная колонка всегда отображается на своем месте
            column2.CellTemplate = new DataGridViewTextBoxCell(); //тип нашей колонки


            var column3 = new DataGridViewColumn();
            column3.HeaderText = "Название продукта"; //текст в шапке
            column3.Width = 200; //ширина колонки
            column3.ReadOnly = true; //значение в этой колонке нельзя править
            column3.Name = "nameProduct"; //текстовое имя колонки, его можно использовать вместо обращений по индексу
            column3.Frozen = true; //флаг, что данная колонка всегда отображается на своем месте
            column3.CellTemplate = new DataGridViewTextBoxCell(); //тип нашей колонки

            var column4 = new DataGridViewColumn();
            column4.HeaderText = "Серийный номер"; //текст в шапке
            column4.Width = 200; //ширина колонки
            column4.ReadOnly = true; //значение в этой колонке нельзя править
            column4.Name = "serialNumber"; //текстовое имя колонки, его можно использовать вместо обращений по индексу
            column4.Frozen = true; //флаг, что данная колонка всегда отображается на своем месте
            column4.CellTemplate = new DataGridViewTextBoxCell(); //тип нашей колонки

            var column5 = new DataGridViewColumn();
            column5.HeaderText = "Владелец"; //текст в шапке
            column5.Width = 200; //ширина колонки
            column5.ReadOnly = true; //значение в этой колонке нельзя править
            column5.Name = "owner"; //текстовое имя колонки, его можно использовать вместо обращений по индексу
            column5.Frozen = true; //флаг, что данная колонка всегда отображается на своем месте
            column5.CellTemplate = new DataGridViewTextBoxCell(); //тип нашей колонки

            poisonDataGridView1.Columns.Add(column1);
            poisonDataGridView1.Columns.Add(column2);
            poisonDataGridView1.Columns.Add(column3);
            poisonDataGridView1.Columns.Add(column4);
            poisonDataGridView1.Columns.Add(column5);
            poisonDataGridView1.AllowUserToAddRows = false;
            auth.WebAuth.RequestGet("api/items", (res) =>
            {
                var items = res.GetJsonAsync<List<items.Item>>().Result;
                this.items = items;
            });
            foreach (var item in items)
            {
                if (item.owner == null)
                {
                    poisonDataGridView1.Rows.Add(item.ID, item.name, item.productName, item.serialNumber, "нету");
                }
                else
                {
                    poisonDataGridView1.Rows.Add(item.ID, item.name, item.productName, item.serialNumber, item.owner.familia + " " + item.owner.name);
                }
            }
        }

        private void nightButton4_Click(object sender, EventArgs e)
        {
            int currentIndex = poisonDataGridView1.CurrentRow.Index;
            if (poisonDataGridView1[0, currentIndex].Value != null)
            {
                item.SetOwner setOwner = new item.SetOwner(items[currentIndex].owner != null ? (int)items[currentIndex].owner.ID : 0,
                    (int)poisonDataGridView1[0, currentIndex].Value, (item) =>
                    {
                        if (item.owner == null)
                        {
                            poisonDataGridView1[4, currentIndex].Value = "нету";
                        }
                        else
                        {
                            poisonDataGridView1[4, currentIndex].Value = item.owner.familia + " " + item.owner.name;
                        }
                    });
                setOwner.ShowDialog();
            }
        }

        private void nightButton5_Click(object sender, EventArgs e)
        {
            int currentIndex = poisonDataGridView1.CurrentRow.Index;
            if (poisonDataGridView1[0, currentIndex].Value != null)
            {
                var itemId = (int)poisonDataGridView1[0, currentIndex].Value;
                auth.WebAuth.RequestPatchAsync("api/item/" + itemId, (req) =>
                {
                    var item = req.GetJsonAsync<items.Item>().Result;
                    poisonDataGridView1[4, currentIndex].Value = item.owner.familia + " " + item.owner.name;
                }, new
                {
                    ownerid = Program.localSettings.user.ID
                });
            }
        }

        private void printDocument1_PrintPage_1(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            //create Bitmap and add/draw datagridview to it 
            Bitmap dataGridViewBitmap = new Bitmap(this.poisonDataGridView1.Width, this.poisonDataGridView1.Height);

            poisonDataGridView1.DrawToBitmap(dataGridViewBitmap, new System.Drawing.Rectangle(0, 0, this.poisonDataGridView1.Width, this.poisonDataGridView1.Height));

            e.Graphics.DrawImage(dataGridViewBitmap, 0, 0);
        }

        private void nightButton6_Click(object sender, EventArgs e)
        {
            PrintPreviewDialog print = new PrintPreviewDialog();
            System.Drawing.Printing.PrintDocument document = new System.Drawing.Printing.PrintDocument();
            document.PrintPage +=
        new System.Drawing.Printing.PrintPageEventHandler
        (printDocument1_PrintPage_1);
            print.Document = document;
            print.ShowDialog();
        }
    }
}
