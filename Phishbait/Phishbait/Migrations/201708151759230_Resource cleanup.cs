namespace Phishbait.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Resourcecleanup : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Resources", "PhishingUrlProbability");
            DropColumn("dbo.Resources", "PhishingFrequentProbability");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Resources", "PhishingFrequentProbability", c => c.Double(nullable: false));
            AddColumn("dbo.Resources", "PhishingUrlProbability", c => c.Double(nullable: false));
        }
    }
}
