using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace In_Client.auth
{
    internal class WebAuth
    {

        public static void RequestGet(string request, Func<HttpResponseMessage, object> successfull) 
        {

            using (HttpClient client = new HttpClient())
            {
                client.Timeout = TimeSpan.FromSeconds(1);
                try
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Program.applicationSettings.JwtToken);
                    HttpResponseMessage res;
                    var webRequest = new HttpRequestMessage(HttpMethod.Get, Program.applicationSettings.ServerURL + "api/" + request);
                    res = client.Send(webRequest);
                    
                    if (res.StatusCode == HttpStatusCode.NotFound)
                    {
                        var stream = res.Content.ReadAsStream();
                        var json = System.Text.Json.JsonSerializer.Deserialize<object>(stream);
                        MessageBox.Show(json.ToString(), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (res.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        Program.onLogin();
                    }
                    else if (res.StatusCode == HttpStatusCode.OK)
                    {
                        successfull(res);
                    }
                }
                catch (TaskCanceledException ex)
                {
                    MessageBox.Show("Сервер не отвечает", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public static async void RequestPostAsync(string request, Func<HttpResponseMessage, object> successfull, Dictionary<string,string> vars) 
        {

            using (HttpClient client = new HttpClient())
            {
                client.Timeout = TimeSpan.FromSeconds(1);
                try
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Program.applicationSettings.JwtToken);
                    var res = await client.PostAsync(Program.applicationSettings.ServerURL + "api/" + request, new FormUrlEncodedContent(vars));
                    
                    if (res.StatusCode == HttpStatusCode.NotFound)
                    {
                        var stream = res.Content.ReadAsStream();
                        var json = System.Text.Json.JsonSerializer.Deserialize<object>(stream);
                        MessageBox.Show(json.ToString(), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (res.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        Program.onLogin();
                    }
                    else if (res.StatusCode == HttpStatusCode.OK)
                    {
                        successfull(res);
                    }
                }
                catch (TaskCanceledException ex)
                {
                    MessageBox.Show("Сервер не отвечает", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        public static async void RequestGetAsync(string request,Func<HttpResponseMessage, object> successfull)
        {

            using (HttpClient client = new HttpClient())
            {
                client.Timeout = TimeSpan.FromSeconds(1);
                try
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Program.applicationSettings.JwtToken);
                    var res = await client.GetAsync(Program.applicationSettings.ServerURL + "api/" + request);

                    if (res.StatusCode == HttpStatusCode.NotFound)
                    {
                        var stream = res.Content.ReadAsStream();
                        var json = System.Text.Json.JsonSerializer.Deserialize<object>(stream);
                        MessageBox.Show(json.ToString(), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (res.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        Program.onLogin();
                    }
                    else if (res.StatusCode == HttpStatusCode.OK)
                    {
                        successfull(res);
                    }
                }
                catch (TaskCanceledException ex)
                {
                    MessageBox.Show("Сервер не отвечает", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
