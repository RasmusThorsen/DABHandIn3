using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DAB_Handin3.Models
{
    public class Adresse
    {
        [Key]
        public int AdresseID { get; set; }
        public string Vejnavn { get; set; }
        public string Husnummer { get; set; }
        public string Type { get; set; }
        public List<Person> Persons { get; set; }

        public Adresse()
        {
            Persons = new List<Person>();
        }
    }
}