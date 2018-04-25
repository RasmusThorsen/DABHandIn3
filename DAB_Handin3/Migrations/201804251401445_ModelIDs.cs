namespace DAB_Handin3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelIDs : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Adresses", "By_Postnummer", "dbo.Bies");
            DropIndex("dbo.Adresses", new[] { "By_Postnummer" });
            RenameColumn(table: "dbo.Adresses", name: "By_Postnummer", newName: "By_ById");
            DropPrimaryKey("dbo.Telefons");
            DropPrimaryKey("dbo.Bies");
            AddColumn("dbo.Telefons", "TelefonId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Bies", "ById", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Adresses", "By_ById", c => c.Int());
            AlterColumn("dbo.Telefons", "Nummer", c => c.String());
            AlterColumn("dbo.Bies", "Postnummer", c => c.String());
            AddPrimaryKey("dbo.Telefons", "TelefonId");
            AddPrimaryKey("dbo.Bies", "ById");
            CreateIndex("dbo.Adresses", "By_ById");
            AddForeignKey("dbo.Adresses", "By_ById", "dbo.Bies", "ById");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Adresses", "By_ById", "dbo.Bies");
            DropIndex("dbo.Adresses", new[] { "By_ById" });
            DropPrimaryKey("dbo.Bies");
            DropPrimaryKey("dbo.Telefons");
            AlterColumn("dbo.Bies", "Postnummer", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Telefons", "Nummer", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Adresses", "By_ById", c => c.String(maxLength: 128));
            DropColumn("dbo.Bies", "ById");
            DropColumn("dbo.Telefons", "TelefonId");
            AddPrimaryKey("dbo.Bies", "Postnummer");
            AddPrimaryKey("dbo.Telefons", "Nummer");
            RenameColumn(table: "dbo.Adresses", name: "By_ById", newName: "By_Postnummer");
            CreateIndex("dbo.Adresses", "By_Postnummer");
            AddForeignKey("dbo.Adresses", "By_Postnummer", "dbo.Bies", "Postnummer");
        }
    }
}
