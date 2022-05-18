using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Sockets;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;
using Flurl;
using Flurl.Http;

namespace In_Client.auth
{
    internal class WebAuth
    {

        public static void RequestGet(string request, Action<IFlurlResponse> successfull) 
        {

            try
            {
                var url = new Url(Program.applicationSettings.ServerURL + request + "?token=" + Program.applicationSettings.JwtToken);
                var result = url.AllowHttpStatus("400-404,6xx").WithTimeout(1).GetAsync().GetAwaiter().GetResult();
                if (result.StatusCode == 200)
                {
                    successfull(result);
                }
                else if (result.StatusCode == 400)
                {
                    var json = result.GetJsonAsync();
                    MessageBox.Show(json.ToString(), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }else if(result.StatusCode == 401)
                {
                    Program.onLogin();
                }
            }
            catch (Exception ex)
            {
                if(ex is FlurlHttpTimeoutException)
                {
                    var result = MessageBox.Show("Соединение с сервером провалена, не желаете поменять сервер?", "Ошибка", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                    if(result == DialogResult.Yes)
                    {
                        Program.setupServer();
                    }
                }else
                {
                    MessageBox.Show("Обратитесь к системному администратору", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public static async void RequestNoAuthPostAsync(string request1, Action<IFlurlResponse> responce, object vars)
        {
            try
            {
                var url = new Url(Program.applicationSettings.ServerURL + request1);
                var result = await url.PostUrlEncodedAsync(vars);
                responce(result);
            }
            catch(FlurlHttpException ex)
            {
                if(ex.StatusCode == 401)
                {
                    var error = await ex.GetResponseJsonAsync<auth.ErrorJson>();
                    if(error.message == "incorrect Username or Password")
                    {
                        MessageBox.Show("Неправильный логин или пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if(error.message == "missing Username or Password")
                    {
                        MessageBox.Show("Вы не ввели логин или пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Ошибка на стороне сервера", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }


        public static async void RequestPostAsync(string request1, Action<IFlurlResponse> responce, object vars) 
        {
            try
            {
                var url = new Url(Program.applicationSettings.ServerURL + request1 + "?token=" + Program.applicationSettings.JwtToken);
                var result = await url.AllowHttpStatus("400-404,5xx,6xx").PostUrlEncodedAsync(vars);
                responce(result);
            }
            catch(Exception)
            {
                MessageBox.Show("Со стороны сервера", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static async void RequestDeleteAsync(string request1, Action<IFlurlResponse> responce)
        {
            try
            {
                var url = new Url(Program.applicationSettings.ServerURL + request1 + "?token=" + Program.applicationSettings.JwtToken);
                var result = await url.DeleteAsync();
                responce(result);
            }
            catch (Exception)
            {
                MessageBox.Show("Со стороны сервера", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static async void RequestPatchAsync(string request1, Action<IFlurlResponse> successfull, object vars)
        {
            try
            {
                var url = new Url(Program.applicationSettings.ServerURL + request1 + "?token=" + Program.applicationSettings.JwtToken);
                var responce = await url.PatchJsonAsync(vars);
                successfull(responce);

            }
            catch (Exception)
            {
                MessageBox.Show("Со стороны сервера", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static async void RequestGetAsync(string request, Action<IFlurlResponse> successfull)
        {
            try
            {
                var url = new Url(Program.applicationSettings.ServerURL + request + "?token=" + Program.applicationSettings.JwtToken);
                var result = await url.GetAsync();
                if (result.StatusCode == 200)
                {
                    successfull(result);
                }
                else if (result.StatusCode == 400)
                {
                    var json = result.GetJsonAsync();
                    MessageBox.Show(json.ToString(), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (result.StatusCode == 401)
                {
                    Program.onLogin();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Со стороны сервера", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
