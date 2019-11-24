using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using DesafioVibe.Models;
using MonkeyCache.LiteDB;
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

        public async Task<LoginResponse> SignUserUp(UserModel user)
        {
            LoginResponse signupResponse = null;
            try
            {
                string serializedObject = JsonConvert.SerializeObject(user);
                HttpContent contentPost = new StringContent(serializedObject, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await _client.PostAsync("Usuario", contentPost);

                string data = await response.Content.ReadAsStringAsync();
                signupResponse = JsonConvert.DeserializeObject<LoginResponse>(data);

                if (!string.IsNullOrEmpty(data))
                    signupResponse.StatusCode = (int)response.StatusCode;
                else
                    signupResponse = new LoginResponse
                    {
                        StatusCode = 200
                    };

            }
            catch (Exception ex)
            {
                Debug.WriteLine("\tERROR {0}", ex.Message);
            }

            return signupResponse;
        }

        public async Task<UserResponse> GetUserInfo()
        {
            UserResponse userResponse = null;
            try
            {
                string userKey = Barrel.Current.Get<string>(Constants.USER_KEY);
                string userCPF = Barrel.Current.Get<string>(Constants.USER_CPF);

                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", userKey);
                HttpResponseMessage response = await _client.GetAsync($"Usuario/{userCPF}");

                string data = await response.Content.ReadAsStringAsync();
                userResponse = JsonConvert.DeserializeObject<UserResponse>(data);
                userResponse.StatusCode = (int)response.StatusCode;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\tERROR {0}", ex.Message);
            }

            return userResponse;
        }

        public async Task<List<ClientResponse>> GetClientList()
        {
            List<ClientResponse> clientResponse = null;
            try
            {
                string userKey = Barrel.Current.Get<string>(Constants.USER_KEY);
                string userCPF = Barrel.Current.Get<string>(Constants.USER_CPF);

                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", userKey);
                HttpResponseMessage response = await _client.GetAsync($"Cliente");

                string data = await response.Content.ReadAsStringAsync();
                clientResponse = JsonConvert.DeserializeObject<List<ClientResponse>>(data);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\tERROR {0}", ex.Message);
            }

            return clientResponse;
        }
    }
}
