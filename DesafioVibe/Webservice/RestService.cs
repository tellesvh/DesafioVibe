using System;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using DesafioVibe.Models;
using Newtonsoft.Json;

namespace DesafioVibe.Webservice
{
    public class RestService
    {
        HttpClient _client;

        public RestService()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri(Constants.VibeSelecaoEndpoint);
        }

        public async Task<LoginResponse> LogUserIn(LoginModel login)
        {
            LoginResponse loginResponse = null;
            try
            {
                string serializedObject = JsonConvert.SerializeObject(login);
                HttpContent contentPost = new StringContent(serializedObject, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await _client.PostAsync("Autenticacao", contentPost);

                string data = await response.Content.ReadAsStringAsync();
                loginResponse = JsonConvert.DeserializeObject<LoginResponse>(data);
                loginResponse.StatusCode = (int)response.StatusCode;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\tERROR {0}", ex.Message);
            }

            return loginResponse;
        }
    }
}
