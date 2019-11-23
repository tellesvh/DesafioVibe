using System;
using Newtonsoft.Json;

namespace DesafioVibe.Webservice
{
    public class UserResponse
    {
        [JsonProperty("cpf")]
        public string CPF { get; set; }

        [JsonProperty("nome")]
        public string Name { get; set; }

        [JsonProperty("nascimento")]
        public string Birthday { get; set; }

        public int StatusCode { get; set; }
    }
}
