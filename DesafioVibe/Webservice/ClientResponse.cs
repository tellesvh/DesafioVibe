using System;
using Newtonsoft.Json;

namespace DesafioVibe.Webservice
{
    public class ClientResponse
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("cpf")]
        public string CPF { get; set; }

        [JsonProperty("nome")]
        public string Name { get; set; }

        [JsonProperty("especial")]
        public bool IsSpecial { get; set; }
    }
}
