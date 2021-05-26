namespace GeneralStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedUPCToString : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "UPC", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "UPC", c => c.Int(nullable: false));
        }
    }
}
