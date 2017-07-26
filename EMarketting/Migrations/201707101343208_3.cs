namespace EMarketting.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _3 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.ReklamliUrunler", "AltUrunlerID");
            CreateIndex("dbo.SezonSonuUrunler", "AltUrunlerID");
            AddForeignKey("dbo.ReklamliUrunler", "AltUrunlerID", "dbo.AltUrunler", "AltUrunlerID", cascadeDelete: true);
            AddForeignKey("dbo.SezonSonuUrunler", "AltUrunlerID", "dbo.AltUrunler", "AltUrunlerID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SezonSonuUrunler", "AltUrunlerID", "dbo.AltUrunler");
            DropForeignKey("dbo.ReklamliUrunler", "AltUrunlerID", "dbo.AltUrunler");
            DropIndex("dbo.SezonSonuUrunler", new[] { "AltUrunlerID" });
            DropIndex("dbo.ReklamliUrunler", new[] { "AltUrunlerID" });
        }
    }
}
