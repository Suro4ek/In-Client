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

        private void nightButton1_Click(object sender, EventArgs e)
        {
            newUserForm form = new newUserForm((user) =>
            {
                poisonDataGridView1.Rows.Add(user.ID, user.familia, user.name, user.username);
            });
            form.ShowDialog();
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
            column2.HeaderText = "Фамилия"; //текст в шапке
            column2.Width = 200; //ширина колонки
            column2.ReadOnly = true; //значение в этой колонке нельзя править
            column2.Name = "familia"; //текстовое имя колонки, его можно использовать вместо обращений по индексу
            column2.Frozen = true; //флаг, что данная колонка всегда отображается на своем месте
            column2.CellTemplate = new DataGridViewTextBoxCell(); //тип нашей колонки


            var column3 = new DataGridViewColumn();
            column3.HeaderText = "Имя"; //текст в шапке
            column3.Width = 200; //ширина колонки
            column3.ReadOnly = true; //значение в этой колонке нельзя править
            column3.Name = "name"; //текстовое имя колонки, его можно использовать вместо обращений по индексу
            column3.Frozen = true; //флаг, что данная колонка всегда отображается на своем месте
            column3.CellTemplate = new DataGridViewTextBoxCell(); //тип нашей колонки

            var column4 = new DataGridViewColumn();
            column4.HeaderText = "Никнейм"; //текст в шапке
            column4.Width = 200; //ширина колонки
            column4.ReadOnly = true; //значение в этой колонке нельзя править
            column4.Name = "username"; //текстовое имя колонки, его можно использовать вместо обращений по индексу
            column4.Frozen = true; //флаг, что данная колонка всегда отображается на своем месте
            column4.CellTemplate = new DataGridViewTextBoxCell(); //тип нашей колонки

            poisonDataGridView1.Columns.Add(column1);
            poisonDataGridView1.Columns.Add(column2);
            poisonDataGridView1.Columns.Add(column3);
            poisonDataGridView1.Columns.Add(column4);

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

        private void nightButton2_Click(object sender, EventArgs e)
        {
            int currentIndex = poisonDataGridView1.CurrentRow.Index;
            if (poisonDataGridView1[0, currentIndex].Value != null)
            {
                int id = (int)poisonDataGridView1[0, currentIndex].Value;
                if(id == Program.localSettings.user.ID)
                {
                    MessageBox.Show("Вы не можете удалить себя", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                auth.WebAuth.RequestDeleteAsync("admin/user/" + id, (req) =>
                {
                    poisonDataGridView1.Rows.RemoveAt(currentIndex);
                });
            }
        }

        private void nightButton3_Click(object sender, EventArgs e)
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
    }
}
