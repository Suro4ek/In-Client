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
            if(Program.localSettings.user == null)
            {
                auth.WebAuth.RequestGet("user", (res) =>
                {
                    var stream = res.Content.ReadAsStream();
                    var json = System.Text.Json.JsonSerializer.Deserialize<auth.User>(stream);
                    Program.localSettings.user = json;
                    return null;
                });
            }
            Controls.User.UC_Inventory inventory = new Controls.User.UC_Inventory();
            addUserControl(inventory);

            if (Program.localSettings.user.role.Equals("user"))
            {
           
            }
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
            Program.applicationSettings.JwtToken = "";
            Close();
        }


        private void airButton1_Click(object sender, EventArgs e)
        {
            Controls.User.UC_Inventory inventory = new Controls.User.UC_Inventory();
            addUserControl(inventory);
        }
    } 
}
