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
                iconButton1.Visible = true;
                iconButton2.Visible = false;
                iconButton3.Visible = false;
                iconButton4.Visible = false;
                iconButton5.Visible = false;
            }
        }

        private void onLoad(object sender, EventArgs e)
        {
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


        private void iconButton1_Click(object sender, EventArgs e)
        {
            newItemForm form = new newItemForm((item) =>
            {
                poisonDataGridView1.Rows.Add(item.ID, item.name, item.productName, item.serialNumber, "");
            });
            form.ShowDialog();
        }

        private void iconButton2_Click(object sender, EventArgs e)
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

        private void iconButton3_Click(object sender, EventArgs e)
        {
            int currentIndex = poisonDataGridView1.CurrentRow.Index;
            if (poisonDataGridView1[0, currentIndex].Value != null)
            {
                int id = (int)poisonDataGridView1[0, currentIndex].Value;
                if(MessageBox.Show("Вы действительно хотите удалить?", "Подтвердите", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) 
                    == DialogResult.Yes)
                {
                    auth.WebAuth.RequestDeleteAsync("item/" + id, (req) =>
                    {
                        poisonDataGridView1.Rows.RemoveAt(currentIndex);
                    });
                }
            }
        }

        private void iconButton4_Click(object sender, EventArgs e)
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

        private void printDocument1_PrintPage_1(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            //create Bitmap and add/draw datagridview to it 
            Bitmap dataGridViewBitmap = new Bitmap(this.poisonDataGridView1.Width, this.poisonDataGridView1.Height);

            poisonDataGridView1.DrawToBitmap(dataGridViewBitmap, new Rectangle(0, 0, poisonDataGridView1.Width, poisonDataGridView1.Height));

            e.Graphics.DrawImage(dataGridViewBitmap, 0, 0);
        }

        private void iconButton5_Click(object sender, EventArgs e)
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
