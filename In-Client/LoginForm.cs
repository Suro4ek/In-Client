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
            InputForm inputForm = new InputForm();
            inputForm.Controls.Add(inputForm.addLabel("Введите адресс сервера"));
            TextBox textBox = inputForm.addTextBox();
            textBox.Text = application.ServerURL;
            inputForm.Controls.Add(textBox);
            inputForm.button.Text = "Сохранить";
            inputForm.button.Click += new EventHandler((object sender, EventArgs e) =>
            {
                string textboxString =  textBox.Text;
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

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void hopeButton1_Click(object sender, EventArgs e)
        {
            if (bigTextBox1.Text == "")
            {
                MessageBox.Show("Вы не ввели имя пользователя", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bigTextBox1.Focus();
                return;
            }
            if (bigTextBox2.Text == "")
            {
                MessageBox.Show("Вы не ввели пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bigTextBox2.Focus();
                return;
            }
            Login(bigTextBox1.Text.Trim(), bigTextBox2.Text.Trim());
        }
    }
}