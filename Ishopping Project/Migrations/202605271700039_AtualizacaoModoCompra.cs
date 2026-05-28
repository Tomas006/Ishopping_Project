namespace Ishopping_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AtualizacaoModoCompra : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.ItemCompras", new[] { "ArtigoId" });
            AddColumn("dbo.ItemCompras", "PreviaComprar", c => c.Boolean(nullable: false));
            AddColumn("dbo.ItemCompras", "Adquirido", c => c.Boolean(nullable: false));
            AlterColumn("dbo.ItemCompras", "ArtigoId", c => c.Int(nullable: false));
            CreateIndex("dbo.ItemCompras", "ArtigoId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.ItemCompras", new[] { "ArtigoId" });
            AlterColumn("dbo.ItemCompras", "ArtigoId", c => c.Int());
            DropColumn("dbo.ItemCompras", "Adquirido");
            DropColumn("dbo.ItemCompras", "PreviaComprar");
            CreateIndex("dbo.ItemCompras", "ArtigoId");
        }
    }
}
