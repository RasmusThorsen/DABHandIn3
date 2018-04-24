using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DAB_Handin3.Models
{
    public class Telefon
    {
        [Key]
        public string Nummer { get; set; }
        public string Type { get; set; }
        public string Teleselskab { get; set; }
    }
}