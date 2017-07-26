namespace EMarketting.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Siparis", "SiparisID", "dbo.SiparisDetay");
            DropIndex("dbo.Siparis", new[] { "SiparisID" });
            DropPrimaryKey("dbo.Siparis");
            AlterColumn("dbo.Siparis", "SiparisID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Siparis", "SiparisID");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Siparis");
            AlterColumn("dbo.Siparis", "SiparisID", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Siparis", "SiparisID");
            CreateIndex("dbo.Siparis", "SiparisID");
            AddForeignKey("dbo.Siparis", "SiparisID", "dbo.SiparisDetay", "SiparisDetayID");
        }
    }
}
