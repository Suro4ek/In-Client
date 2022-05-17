using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace In_Client.Controls.User.item
{
    public partial class SetOwner : Form
    {
        public int userId;
        public int index = 0;
        public List<auth.User> users;
        public int itemId;
        public Action<items.Item> func;
        public SetOwner(int userId, int itemId, Action<items.Item> func)
        {
            InitializeComponent();
            this.userId = userId;
            this.itemId = itemId;
            this.func = func;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(users[hopeComboBox1.SelectedIndex].ID == null)
            {
                return;
            }
            auth.WebAuth.RequestPatchAsync("api/item/" + itemId, (req) =>
            {
                var item = req.GetJsonAsync<items.Item>().Result;
                func(item);
            }, new
            {
                ownerid = users[hopeComboBox1.SelectedIndex].ID
            });
        }

        private void SetOwner_Load(object sender, EventArgs e)
        {
            auth.WebAuth.RequestGet("admin/users", (res) =>
            {
                var users = res.GetJsonAsync<List<auth.User>>().Result;
                for(int i = 0; i < users.Count; i++)
                {
                    if (users[i].ID == this.userId)
                    {
                        index = i;
                    }
                }
                this.users = users;
            });
            hopeComboBox1.DataSource = users;
            hopeComboBox1.DisplayMember = "toString";
            hopeComboBox1.SelectedIndex = index;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            auth.WebAuth.RequestPatchAsync("api/item/" + itemId, (req) =>
            {
                var item = req.GetJsonAsync<items.Item>().Result;
                func(item);
            }, new
            {
                ownerid = -1
            });
        }
    }
}
