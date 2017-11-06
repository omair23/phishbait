namespace Phishbait.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Cleanup : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.FrequentItems");
            DropTable("dbo.IgnoreRules");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.IgnoreRules",
                c => new
                    {
                        UID = c.Long(nullable: false, identity: true),
                        Term = c.String(),
                        Type = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UID);
            
            CreateTable(
                "dbo.FrequentItems",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 38),
                        UID = c.Long(nullable: false, identity: true),
                        Term = c.String(),
                        Frequency = c.Int(nullable: false),
                        MinimumFrequency = c.Int(nullable: false),
                        ItemType = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(),
                        DeletedAt = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
