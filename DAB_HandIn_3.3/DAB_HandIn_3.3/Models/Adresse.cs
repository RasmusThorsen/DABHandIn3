using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace DAB_HandIn_3._3.Models
{
    public class Adresse
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        public string Vejnavn { get; set; }
        public string Husnummer { get; set; }
        public string Type { get; set; }
        public By By { get; set; }
    }
}