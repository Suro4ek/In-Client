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
        bool mouseDown;
        private Point offset;
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
                metroButton2.Visible = false;
                metroButton3.Visible = false;
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

        private void metroButton1_Click(object sender, EventArgs e)
        {
            Program.applicationSettings.JwtToken = "";
            Program.applicationSettings.Save();
            Close();
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            Controls.User.UC_Inventory inventory = new Controls.User.UC_Inventory();
            addUserControl(inventory);
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            Controls.User.user.UC_Users users = new Controls.User.user.UC_Users();
            addUserControl(users);
        }


        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            offset.X = e.X;
            offset.Y = e.Y;
            mouseDown = true;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                Point currentScreenPos = PointToScreen(e.Location);
                Location = new Point(currentScreenPos.X - offset.X, currentScreenPos.Y - offset.Y);
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Normal;
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
        }
    } 
}
