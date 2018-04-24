using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DAB_Handin3.Models
{
    public class Person
    {
        [Key]
        public int PersonID { get; set; }
        public List<Adresse> Adresse { get; set; }
        public List<Telefon> Telefon { get; set; }
        public string Fornavn { get; set; }
        public string Mellemnavn { get; set; }
        public string Efternavn { get; set; }
        public string Type { get; set; }
        public string Email { get; set; }

        public Person()
        {
            Adresse = new List<Adresse>();
            Telefon = new List<Telefon>();
        }        
    }
}