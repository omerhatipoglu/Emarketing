namespace EMarketting.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AltUrunler", "Resim2", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AltUrunler", "Resim2");
        }
    }
}
