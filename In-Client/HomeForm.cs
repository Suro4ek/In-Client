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
    public partial class HomeForm : Form
    {
        public HomeForm()
        {
            InitializeComponent();

            if (Program.localSettings.user == null)
            {
                auth.WebAuth.RequestGet("api/user", (res) =>
                {
                    var json = res.GetJsonAsync<auth.User>().Result;
                    Program.localSettings.user = json;
                });
            }
            if(Program.localSettings.user.role != "admin")
            {
                panel2.Visible = false;
            }
            Controls.User.UC_Inventory inventory = new Controls.User.UC_Inventory();
            addUserControl(inventory);

        }
        private void addUserControl(UserControl user)
        {
            user.Dock = DockStyle.Fill;
            panelContainer.Controls.Clear();
            panelContainer.Controls.Add(user);
            user.BringToFront();
        }

        private void ExitClick(object sender, EventArgs e)
        {
            ApplicationSettings? applicationSettings = Program.applicationSettings;
            applicationSettings.JwtToken = "";
            Close();
        }


        private void airButton1_Click(object sender, EventArgs e)
        {
            Controls.User.UC_Inventory inventory = new Controls.User.UC_Inventory();
            addUserControl(inventory);
        }

        private void airButton2_Click(object sender, EventArgs e)
        {
            Controls.User.user.UC_Users users = new Controls.User.user.UC_Users();
            addUserControl(users);
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            Program.applicationSettings.JwtToken = "";
            Program.applicationSettings.Save();
            Close();
        }
    } 
}
