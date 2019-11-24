using System;
using Newtonsoft.Json;

namespace DesafioVibe.Webservice
{
    public class ClientDetailResponse
    {
        [JsonProperty("urlImagem")]
        public string ImgUrl { get; set; }

        [JsonProperty("empresa")]
        public string Company { get; set; }

        [JsonProperty("endereco")]
        public Address Address { get; set; }
    }

    public class Address
    {
        [JsonProperty("endereco")]
        public string Street { get; set; }

        [JsonProperty("numero")]
        public string Number { get; set; }

        [JsonProperty("complemento")]
        public string Complement { get; set; }

        [JsonProperty("cidade")]
        public string City { get; set; }
    }
}
