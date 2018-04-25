using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DAB_Handin3.Models
{
    public class AdresseDTO
    {
        public int AdresseID { get; set; }
        public string Vejnavn { get; set; }
        public string Husnummer { get; set; }
        public string Type { get; set; }
        public List<PersonDTO> Persons { get; set; }

        public AdresseDTO(Adresse adresse)
        {
            AdresseID = adresse.AdresseID;
            Vejnavn = adresse.Vejnavn;
            Husnummer = adresse.Husnummer;
            Type = adresse.Type;
            Persons = new List<PersonDTO>();
            foreach (var ap in adresse.Persons)
            {
                Persons.Add(new PersonDTO(ap));
            }
        }
    }

    public class PersonAdresseDTO
    {
        public int AdresseID { get; set; }
        public string Vejnavn { get; set; }
        public string Husnummer { get; set; }
        public string Type { get; set; }

        public PersonAdresseDTO(Adresse adresse)
        {
            AdresseID = adresse.AdresseID;
            Vejnavn = adresse.Vejnavn;
            Husnummer = adresse.Husnummer;
            Type = adresse.Type;
        }
    }
}