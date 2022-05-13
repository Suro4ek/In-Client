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
            label1.Text = Program.localSettings.user.familia + " " + Program.localSettings.user.name;
            if (Program.localSettings.user.role.Equals("user"))
            {
                button2.Visible = true;
            }
        }

        private void HomeForm_Load(object sender, EventArgs e)
        {
            
        }

        private void ClickItems(object sender, EventArgs e)
        {
            ListItems listItems = new ListItems();
            listItems.Show();
        }

        private void ListUsersClick(object sender, EventArgs e)
        {

        }

        private void ExitClick(object sender, EventArgs e)
        {
            Program.applicationSettings.JwtToken = "";
            Close();
        }
    } 
}
