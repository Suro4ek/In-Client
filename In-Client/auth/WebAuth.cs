using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;
using Flurl;
using Flurl.Http;

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

        public static async void RequestPostAsync(string request1, Func<IFlurlResponse,object> successfull, object vars) 
        {
            try
            {
                var url = new Url(Program.applicationSettings.ServerURL + "api/" + request1 + "?token=" + Program.applicationSettings.JwtToken);
                var test = await url.PostUrlEncodedAsync(vars);
                if(test.StatusCode == 200)
                {
                    successfull(test);
                }
                
            }
            catch(Exception e)
            {
                MessageBox.Show("Со стороны сервера", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static async void RequestDeleteAsync(string request1, Func<IFlurlResponse, object> successfull)
        {
            try
            {
                var url = new Url(Program.applicationSettings.ServerURL + "api/" + request1 + "?token=" + Program.applicationSettings.JwtToken);
                var test = await url.DeleteAsync();
                if (test.StatusCode == 200)
                {
                    successfull(test);
                }

            }
            catch (Exception e)
            {
                MessageBox.Show("Со стороны сервера", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static async void RequestPatchAsync(string request1, Func<IFlurlResponse, object> successfull, object vars)
        {
            try
            {
                var url = new Url(Program.applicationSettings.ServerURL + "api/" + request1 + "?token=" + Program.applicationSettings.JwtToken);
                var test = await url.PatchJsonAsync(vars);
                if (test.StatusCode == 200)
                {
                    successfull(test);
                }

            }
            catch (Exception e)
            {
                MessageBox.Show("Со стороны сервера", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
