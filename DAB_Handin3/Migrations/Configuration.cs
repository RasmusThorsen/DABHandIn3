using System.Collections.Generic;
using System.Web.UI.WebControls;
using DAB_Handin3.Models;

namespace DAB_Handin3.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DAB_Handin3.Models.DAB_Handin3Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DAB_Handin3.Models.DAB_Handin3Context context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            var list = new List<Person>();
            
            context.People.AddOrUpdate(p => p.Fornavn,
                new Person {Fornavn = "Rasmus", Efternavn = "Thorsen", Email = "rasmus@mail.dk", Type = "Studerende"},
                new Person { Fornavn = "Julie", Efternavn = "Steenshard", Email = "julie@mail.dk", Type = "Studerende"},
                new Person { Fornavn = "Nicolai", Efternavn = "Andersen", Email = "nicolai@mail.dk", Type = "Studerende" },
                new Person { Fornavn = "Claus", Efternavn = "Hansen", Email = "claus@mail.dk", Type = "Underviser" });

            list.Add(context.People.Single(r => r.PersonID == 1));
            context.SaveChanges();
            context.Adresses.AddOrUpdate(a => a.Vejnavn,
                new Adresse {Husnummer = "28", Vejnavn = "Fuglesangs Allé", Type = "Hjemme"},
                new Adresse {Husnummer = "9", Vejnavn = "Brendstupsgårdvej", Type = "Hjemme"},
                new Adresse
                {
                    Husnummer = "22",
                    Vejnavn = "Finlandsgade",
                    Type = "Studie",
                    Persons = list
                  
                });
            
            context.Telefons.AddOrUpdate(t => t.Nummer,
                new Telefon {Nummer = "94783721", Teleselskab = "TDC", Type = "Privat"},
                new Telefon { Nummer = "74839583", Teleselskab = "CBB", Type = "Arbejde" },
                new Telefon { Nummer = "37489673", Teleselskab = "Telia", Type = "Privat" });

            context.Bies.AddOrUpdate(t => t.Bynavn,
                new By {Bynavn = "Aarhus", Postnummer = "8100"},
                new By { Bynavn = "Aarhus V", Postnummer = "8210" },
                new By { Bynavn = "Aarhus N", Postnummer = "8200"});

        }
    }
}
