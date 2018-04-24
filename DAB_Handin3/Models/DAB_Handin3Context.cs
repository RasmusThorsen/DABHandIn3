using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DAB_Handin3.Models
{
    public class DAB_Handin3Context : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public DAB_Handin3Context() : base("name=DAB_Handin3Context")
        {
        }

        public System.Data.Entity.DbSet<DAB_Handin3.Models.Adresse> Adresses { get; set; }

        public System.Data.Entity.DbSet<DAB_Handin3.Models.By> Bies { get; set; }

        public System.Data.Entity.DbSet<DAB_Handin3.Models.Person> People { get; set; }

        public System.Data.Entity.DbSet<DAB_Handin3.Models.Telefon> Telefons { get; set; }
    }
}
