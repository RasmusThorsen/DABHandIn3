using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace DAB_HandIn_3._3.Models
{
    public class By
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        public string Postnummer { get; set; }
        public string Bynavn { get; set; }
        public Adresse[] ByAdresses { get; set; }
    }
}