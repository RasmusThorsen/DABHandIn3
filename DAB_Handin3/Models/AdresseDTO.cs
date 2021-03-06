﻿using System;
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

        public AdresseDTO(Adresse adresse)
        {
            AdresseID = adresse.AdresseID;
            Vejnavn = adresse.Vejnavn;
            Husnummer = adresse.Husnummer;
            Type = adresse.Type;
        }

    }
}