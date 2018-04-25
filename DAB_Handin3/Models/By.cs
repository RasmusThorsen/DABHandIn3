using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DAB_Handin3.Models
{
    public class By
    {
        [Key]
        public int ById { get; set; }
        public string Postnummer { get; set; }
        public string Bynavn { get; set; }
        public List<Adresse> ByAdresses { get; set; }

        public By()
        {
            ByAdresses = new List<Adresse>();
        }
    }
}