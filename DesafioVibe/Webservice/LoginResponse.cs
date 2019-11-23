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

        //[JsonProperty("weather")]
        //public Weather[] Weather { get; set; }

        //[JsonProperty("main")]
        //public Main Main { get; set; }

        //[JsonProperty("visibility")]
        //public long Visibility { get; set; }

        //[JsonProperty("wind")]
        //public Wind Wind { get; set; }
    }
}
