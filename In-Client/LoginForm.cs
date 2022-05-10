using System.Net;

namespace In_Client
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        const string loginUrl = "http://localhost:8080/login/";

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(username.Text == "")
            {
                MessageBox.Show("Вы не имя пользователя", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                username.Focus();
                return;
            }
            if (password.Text == "")
            {
                MessageBox.Show("Вы не пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                password.Focus();
                return;
            }
            Login(username.Text, password.Text);
        }

        private async void Login(string username, string password)
        {
            using (HttpClient client = new HttpClient())
            {
                var data = new Dictionary<string, string>()
                {
                    {"username", username},
                    {"password", password},
                };
                var res = await client.PostAsync(loginUrl, new FormUrlEncodedContent(data));
                if(res != null)
                {
                    if (res.StatusCode == HttpStatusCode.NotFound)
                    {
                        MessageBox.Show("Такого пользователя нет", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (res.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        MessageBox.Show("Неправильный пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}