using System.Net;


namespace In_Client
{
    public partial class LoginForm : Form
    {
        public ApplicationSettings application;
        public LoginForm(ApplicationSettings applicationSettings)
        {
            InitializeComponent();
            this.application = applicationSettings;
        }




        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (username.Text == "")
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
                client.Timeout = TimeSpan.FromSeconds(1);
                try
                {
                    var res = await client.PostAsync(application.ServerURL + "login", new FormUrlEncodedContent(data));

                    if (res.StatusCode == HttpStatusCode.NotFound)
                    {
                        MessageBox.Show("Такого пользователя нет", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (res.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        MessageBox.Show("Неправильный пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }else if(res.StatusCode == HttpStatusCode.OK)
                    {
                        var stream = res.Content.ReadAsStream();
                        var json = await System.Text.Json.JsonSerializer.DeserializeAsync<auth.JWTJson>(stream);
                        application.JwtToken = json.token;
                        application.Save();
                        this.DialogResult = DialogResult.OK;
                    }
                }
                catch (TaskCanceledException ex)
                {
                    MessageBox.Show("Сервер не отвечает", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void setupServerString(object sender, EventArgs e)
        {
            InputForm inputForm = new InputForm("Введите адресс сервера");
            inputForm.button.Text = "Сохранить";
            inputForm.button.Click += new EventHandler((object s, EventArgs e1) =>
            {
                string textboxString = inputForm.textBox.Text;
                if (textboxString == "" || !Uri.IsWellFormedUriString(textboxString, UriKind.Absolute))
                {
                    MessageBox.Show("Введите корректный адресс", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                application.ServerURL = textboxString;
                application.Save();
                inputForm.Close();
            });

            inputForm.ShowDialog();
        }

        private void Close(object sender, EventArgs e)
        {
            Close();
        }
    }
}