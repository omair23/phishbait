namespace Phishbait.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveURLStat : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.UrlStatistics");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UrlStatistics",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 38),
                        UID = c.Long(nullable: false, identity: true),
                        Type = c.Int(nullable: false),
                        FullStopAverage = c.Double(nullable: false),
                        AtSymbolsAverage = c.Double(nullable: false),
                        ForwardSlashAverage = c.Double(nullable: false),
                        MultipleForwardSlashAverage = c.Double(nullable: false),
                        AverageIPAddress = c.Double(nullable: false),
                        AveragePortNumbers = c.Double(nullable: false),
                        AverageBadHttps = c.Double(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(),
                        DeletedAt = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
