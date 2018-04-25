using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DAB_Handin3.Models
{
    public class PersonDetailsDTO
    {
        public int PersonID { get; set; }
        public List<AdresseDTO> Adresse { get; set; }
        public List<TelefonDTO> Telefon { get; set; }
        public string Fornavn { get; set; }
        public string Mellemnavn { get; set; }
        public string Efternavn { get; set; }
        public string Type { get; set; }
        public string Email { get; set; }

        public PersonDetailsDTO(Person p)
        {
            PersonID = p.PersonID;
            Fornavn = p.Fornavn;
            Mellemnavn = p.Mellemnavn;
            Efternavn = p.Efternavn;
            Type = p.Type;
            Email = p.Email;
            Adresse = new List<AdresseDTO>();
            Telefon = new List<TelefonDTO>();

            foreach (var telefon in p.Telefon)
            {
                Telefon.Add(new TelefonDTO(telefon));
            }
        }

    }
}