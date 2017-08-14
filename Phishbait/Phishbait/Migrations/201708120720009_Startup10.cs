namespace Phishbait.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Startup10 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Resources", "UrlAnalysisPercentage", c => c.Double(nullable: false));
            AddColumn("dbo.Resources", "UrlFrequentPercentage", c => c.Double(nullable: false));
            AddColumn("dbo.Resources", "OverallRiskPercentage", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Resources", "OverallRiskPercentage");
            DropColumn("dbo.Resources", "UrlFrequentPercentage");
            DropColumn("dbo.Resources", "UrlAnalysisPercentage");
        }
    }
}
