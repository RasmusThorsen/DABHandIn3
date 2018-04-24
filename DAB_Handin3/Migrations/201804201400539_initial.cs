namespace DAB_Handin3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Adresses",
                c => new
                    {
                        AdresseID = c.Int(nullable: false, identity: true),
                        Vejnavn = c.String(),
                        Husnummer = c.String(),
                        Type = c.String(),
                        By_Postnummer = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.AdresseID)
                .ForeignKey("dbo.Bies", t => t.By_Postnummer)
                .Index(t => t.By_Postnummer);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        PersonID = c.Int(nullable: false, identity: true),
                        Fornavn = c.String(),
                        Mellemnavn = c.String(),
                        Efternavn = c.String(),
                        Type = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.PersonID);
            
            CreateTable(
                "dbo.Telefons",
                c => new
                    {
                        Nummer = c.String(nullable: false, maxLength: 128),
                        Type = c.String(),
                        Teleselskab = c.String(),
                        Person_PersonID = c.Int(),
                    })
                .PrimaryKey(t => t.Nummer)
                .ForeignKey("dbo.People", t => t.Person_PersonID)
                .Index(t => t.Person_PersonID);
            
            CreateTable(
                "dbo.Bies",
                c => new
                    {
                        Postnummer = c.String(nullable: false, maxLength: 128),
                        Bynavn = c.String(),
                    })
                .PrimaryKey(t => t.Postnummer);
            
            CreateTable(
                "dbo.PersonAdresses",
                c => new
                    {
                        Person_PersonID = c.Int(nullable: false),
                        Adresse_AdresseID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Person_PersonID, t.Adresse_AdresseID })
                .ForeignKey("dbo.People", t => t.Person_PersonID, cascadeDelete: true)
                .ForeignKey("dbo.Adresses", t => t.Adresse_AdresseID, cascadeDelete: true)
                .Index(t => t.Person_PersonID)
                .Index(t => t.Adresse_AdresseID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Adresses", "By_Postnummer", "dbo.Bies");
            DropForeignKey("dbo.Telefons", "Person_PersonID", "dbo.People");
            DropForeignKey("dbo.PersonAdresses", "Adresse_AdresseID", "dbo.Adresses");
            DropForeignKey("dbo.PersonAdresses", "Person_PersonID", "dbo.People");
            DropIndex("dbo.PersonAdresses", new[] { "Adresse_AdresseID" });
            DropIndex("dbo.PersonAdresses", new[] { "Person_PersonID" });
            DropIndex("dbo.Telefons", new[] { "Person_PersonID" });
            DropIndex("dbo.Adresses", new[] { "By_Postnummer" });
            DropTable("dbo.PersonAdresses");
            DropTable("dbo.Bies");
            DropTable("dbo.Telefons");
            DropTable("dbo.People");
            DropTable("dbo.Adresses");
        }
    }
}
