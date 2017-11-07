namespace Phishbait.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Layer4_Changes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Resources", "RegistrantNameHidden", c => c.Boolean(nullable: false));
            AddColumn("dbo.Resources", "DaysSinceDomainRegistered", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Resources", "DaysSinceDomainRegistered");
            DropColumn("dbo.Resources", "RegistrantNameHidden");
        }
    }
}
