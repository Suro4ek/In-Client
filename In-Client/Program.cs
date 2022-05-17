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
        public static ApplicationSettings? applicationSettings;
        public static LocalSettings? localSettings;
        [STAThread]
        static void Main()
        {
            applicationSettings = new ApplicationSettings();
            localSettings = new LocalSettings();
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            if(applicationSettings.JwtToken != "")
            {
                auth.WebAuth.RequestGet("api/user", (res) =>
                {
                    var json = res.GetJsonAsync<auth.User>().Result;
                    localSettings.user = json;
                    Application.Run(new HomeForm());
                });
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

    }
}