using System.Net;
using System.Net.Http.Headers;

namespace In_Client
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        /// 
        static ApplicationSettings applicationSettings;
        [STAThread]
        static void Main()
        {

            applicationSettings = new ApplicationSettings();
           
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.ApplicationExit += new EventHandler(OnApplicationExit);
            if(applicationSettings.JwtToken != "")
            {
                using (HttpClient client = new HttpClient())
                {
                    client.Timeout = TimeSpan.FromSeconds(1);
                    try
                    {
                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", applicationSettings.JwtToken);
                        var webRequest = new HttpRequestMessage(HttpMethod.Post, applicationSettings.ServerURL + "api/user");
                        var res = client.Send(webRequest);

                        if (res.StatusCode == HttpStatusCode.NotFound)
                        {
                            var stream = res.Content.ReadAsStream();
                            var json = System.Text.Json.JsonSerializer.Deserialize<object>(stream);
                            MessageBox.Show(json.ToString(), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else if (res.StatusCode == HttpStatusCode.Unauthorized)
                        {
                            onLogin();
                        }
                        else if (res.StatusCode == HttpStatusCode.OK)
                        {
                            var stream = res.Content.ReadAsStream();
                            var json = System.Text.Json.JsonSerializer.Deserialize<auth.JWTJson>(stream);
                            Application.Run(new HomeForm());
                        }
                    }
                    catch (TaskCanceledException ex)
                    {
                        MessageBox.Show("Сервер не отвечает", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
            else
            {
                onLogin();
            }
        }

        public static void onLogin()
        {
            LoginForm loginForm = new LoginForm(applicationSettings);
            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                Application.Run(new HomeForm());
            }
            else
            {
                Application.Exit();
            }
        }
        public static void OnApplicationExit(object sender, EventArgs e)
        {
            applicationSettings.Save();
        }
    }
}