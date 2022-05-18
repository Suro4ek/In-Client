using System.Net;


namespace In_Client
{
    public partial class LoginForm : Form
    {
        public ApplicationSettings application;
        bool mouseDown;
        private Point offset;
        public LoginForm(ApplicationSettings applicationSettings)
        {
            InitializeComponent();
            this.application = applicationSettings;
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Login(string username, string password)
        {
            auth.WebAuth.RequestNoAuthPostAsync("login", (res) =>
            {

                if (res.StatusCode == 400)
                {
                    MessageBox.Show("Такого пользователя нет", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (res.StatusCode == 401)
                {
                    MessageBox.Show("Неправильный пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (res.StatusCode == 200)
                {
                    var json = res.GetJsonAsync<auth.JWTJson>().Result;
                    application.JwtToken = json.token;
                    application.Save();
                    DialogResult = DialogResult.OK;
                }
            }, new
            {
                username = username,
                password = password
            });
        }

        private void setupServerString(object sender, EventArgs e)
        {
            Program.setupServer();
        }

        private void Close(object sender, EventArgs e)
        {
            Close();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void hopeButton1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Вы не ввели имя пользователя", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Focus();
                return;
            }
            if (textBox2.Text == "")
            {
                MessageBox.Show("Вы не ввели пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox2.Focus();
                return;
            }
            Login(textBox1.Text.Trim(), textBox2.Text.Trim());
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void mouseMove_event(object sender, MouseEventArgs e)
        {
            if(mouseDown)
            {
                Point currentScreenPos = PointToScreen(e.Location);
                Location = new Point(currentScreenPos.X - offset.X, currentScreenPos.Y - offset.Y);
            }
        }

        private void mouseDown_event(object sender, MouseEventArgs e)
        {
            offset.X = e.X;
            offset.Y = e.Y;
            mouseDown = true;
        }

        private void mouseUp_event(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void iconButton2_MouseDown(object sender, MouseEventArgs e)
        {
            textBox2.UseSystemPasswordChar = false;
        }

        private void iconButton2_MouseUp(object sender, MouseEventArgs e)
        {
            textBox2.UseSystemPasswordChar = true;
        }
    }
}