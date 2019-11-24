using System;
using Newtonsoft.Json;

namespace DesafioVibe.Webservice
{
    public class LoginResponse
    {
        [JsonProperty("mensagem")]
        public string Message { get; set; }

        [JsonProperty("chave")]
        public string Key { get; set; }

        public int StatusCode { get; set; }
    }
}
