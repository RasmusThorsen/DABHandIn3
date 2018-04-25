using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DAB_Handin3.Models
{
    public class ByDTO
    {
        public int ById { get; set; }
        public string Postnummer { get; set; }
        public string Bynavn { get; set; }
        public List<AdresseDTO> ByAdresses { get; set; }

        public ByDTO(By by)
        {
            ById = by.ById;
            Postnummer = by.Postnummer;
            Bynavn = by.Bynavn;
            ByAdresses = new List<AdresseDTO>();

            foreach (var adr in by.ByAdresses)
            {
                ByAdresses.Add(new AdresseDTO(adr));
            }
        }
    }
}