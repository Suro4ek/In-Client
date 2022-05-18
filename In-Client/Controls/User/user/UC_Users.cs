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
    public partial class UC_Users : UserControl
    {

        List<auth.User> users = new List<auth.User>();
        public UC_Users()
        {
            InitializeComponent();
        }

        private void onLoad(object sender, EventArgs e)
        {
            auth.WebAuth.RequestGet("admin/users", (res) =>
            {
                var users = res.GetJsonAsync<List<auth.User>>().Result;
                this.users = users;

            });
            foreach (var user in users)
            {
                poisonDataGridView1.Rows.Add(user.ID, user.familia, user.name, user.username);
            }
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            int currentIndex = poisonDataGridView1.CurrentRow.Index;
            if (poisonDataGridView1[0, currentIndex].Value != null)
            {
                int id = (int)poisonDataGridView1[0, currentIndex].Value;
                if (id == Program.localSettings.user.ID)
                {
                    MessageBox.Show("Вы не можете удалить себя", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (MessageBox.Show("Вы действительно хотите удалить?", "Подтвердите", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                    == DialogResult.Yes)
                {
                    auth.WebAuth.RequestDeleteAsync("admin/user/" + id, (req) =>
                    {
                        poisonDataGridView1.Rows.RemoveAt(currentIndex);
                    });
                }
            }
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            int currentIndex = poisonDataGridView1.CurrentRow.Index;
            if (poisonDataGridView1[0, currentIndex].Value != null)
            {
                int id = (int)poisonDataGridView1[0, currentIndex].Value;
                editUserForm form = new editUserForm((user) =>
                {
                    poisonDataGridView1[1, currentIndex].Value = user.familia;
                    poisonDataGridView1[2, currentIndex].Value = user.name;
                }, (int)poisonDataGridView1[0, currentIndex].Value, (string)poisonDataGridView1[1, currentIndex].Value, (string)poisonDataGridView1[2, currentIndex].Value);
                form.ShowDialog();
            }
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            newUserForm form = new newUserForm((user) =>
            {
                poisonDataGridView1.Rows.Add(user.ID, user.familia, user.name, user.username);
            });
            form.ShowDialog();
        }
    }
}
