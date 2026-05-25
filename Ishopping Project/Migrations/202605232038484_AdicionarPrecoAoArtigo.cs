namespace Ishopping_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdicionarPrecoAoArtigo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Artigoes", "Preco", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Artigoes", "Preco");
        }
    }
}
