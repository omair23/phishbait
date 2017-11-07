namespace Phishbait.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Layer1_Changes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Resources", "DigitCount", c => c.Int(nullable: false));
            AddColumn("dbo.Resources", "URLLength", c => c.Int(nullable: false));
            AddColumn("dbo.Resources", "NumberOfSubDomains", c => c.Int(nullable: false));
            AddColumn("dbo.Resources", "CommonTLD", c => c.Boolean(nullable: false));
            DropColumn("dbo.Resources", "NumberOfFullStops");
            DropColumn("dbo.Resources", "NumberOfAtSymbols");
            DropColumn("dbo.Resources", "NumberOfForwardSlashes");
            DropColumn("dbo.Resources", "NumberOfMultipleForwardSlashes");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Resources", "NumberOfMultipleForwardSlashes", c => c.Int(nullable: false));
            AddColumn("dbo.Resources", "NumberOfForwardSlashes", c => c.Int(nullable: false));
            AddColumn("dbo.Resources", "NumberOfAtSymbols", c => c.Int(nullable: false));
            AddColumn("dbo.Resources", "NumberOfFullStops", c => c.Int(nullable: false));
            DropColumn("dbo.Resources", "CommonTLD");
            DropColumn("dbo.Resources", "NumberOfSubDomains");
            DropColumn("dbo.Resources", "URLLength");
            DropColumn("dbo.Resources", "DigitCount");
        }
    }
}
