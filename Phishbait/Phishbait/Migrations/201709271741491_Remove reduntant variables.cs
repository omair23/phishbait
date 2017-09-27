namespace Phishbait.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Removereduntantvariables : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Resources", "UrlAnalysisPercentage");
            DropColumn("dbo.Resources", "UrlFrequentPercentage");
            DropColumn("dbo.Resources", "OverallRiskPercentage");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Resources", "OverallRiskPercentage", c => c.Double(nullable: false));
            AddColumn("dbo.Resources", "UrlFrequentPercentage", c => c.Double(nullable: false));
            AddColumn("dbo.Resources", "UrlAnalysisPercentage", c => c.Double(nullable: false));
        }
    }
}
