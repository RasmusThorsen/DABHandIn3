using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DAB_Handin3.Models
{
    public class TelefonDTO
    {
        public int TelefonId { get; set; }
        public string Nummer { get; set; }
        public string Type { get; set; }
        public string Teleselskab { get; set; }

        public TelefonDTO(Telefon t)
        {
            TelefonId = t.TelefonId;
            Nummer = t.Nummer;
            Type = t.Type;
            Teleselskab = t.Teleselskab;
        }

    }
}