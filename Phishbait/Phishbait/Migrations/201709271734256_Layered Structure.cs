namespace Phishbait.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LayeredStructure : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Resources", "LayerDetected", c => c.Int(nullable: false));
            DropColumn("dbo.Resources", "IsPhishing");
            DropColumn("dbo.Resources", "ResourceSource");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Resources", "ResourceSource", c => c.Int(nullable: false));
            AddColumn("dbo.Resources", "IsPhishing", c => c.Boolean(nullable: false));
            DropColumn("dbo.Resources", "LayerDetected");
        }
    }
}
