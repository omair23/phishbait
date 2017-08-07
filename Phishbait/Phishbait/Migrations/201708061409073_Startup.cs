namespace Phishbait.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Startup : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Configurations",
                c => new
                    {
                        UID = c.Long(nullable: false, identity: true),
                        Parameter = c.String(),
                        Value = c.String(),
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
                "dbo.Resources",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 38),
                        UID = c.Long(nullable: false, identity: true),
                        Url = c.String(),
                        PageContent = c.String(),
                        PhishingUrlProbability = c.Double(nullable: false),
                        PhishingFrequentProbability = c.Double(nullable: false),
                        ItemType = c.Int(nullable: false),
                        IsPhishing = c.Boolean(nullable: false),
                        ResourceSource = c.Int(nullable: false),
                        NumberOfFullStops = c.Int(nullable: false),
                        NumberOfAtSymbols = c.Int(nullable: false),
                        NumberOfForwardSlashes = c.Int(nullable: false),
                        NumberOfMultipleForwardSlashes = c.Int(nullable: false),
                        HasIPAddress = c.Boolean(nullable: false),
                        HasPortNumber = c.Boolean(nullable: false),
                        HasHttps = c.Boolean(nullable: false),
                        HasValidSSL = c.Boolean(nullable: false),
                        IsBadHttps = c.Boolean(nullable: false),
                        DetectionAnalysisConducted = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(),
                        DeletedAt = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
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
        
        public override void Down()
        {
            DropTable("dbo.UrlStatistics");
            DropTable("dbo.Resources");
            DropTable("dbo.IgnoreRules");
            DropTable("dbo.FrequentItems");
            DropTable("dbo.Configurations");
        }
    }
}
