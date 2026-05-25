namespace Ishopping_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Artigoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        TipoArtigoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TipoArtigoes", t => t.TipoArtigoId, cascadeDelete: true)
                .Index(t => t.TipoArtigoId);
            
            CreateTable(
                "dbo.TipoArtigoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Compras",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        DataCriacao = c.DateTime(nullable: false),
                        DataAlteracao = c.DateTime(),
                        DataFecho = c.DateTime(),
                        EstaFechada = c.Boolean(nullable: false),
                        CriadoPorId = c.Int(nullable: false),
                        AlteradoPorId = c.Int(),
                        FechadoPorId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Utilizadores", t => t.CriadoPorId, cascadeDelete: true)
                .ForeignKey("dbo.Utilizadores", t => t.AlteradoPorId)
                .ForeignKey("dbo.Utilizadores", t => t.FechadoPorId)
                .Index(t => t.CriadoPorId)
                .Index(t => t.AlteradoPorId)
                .Index(t => t.FechadoPorId);
            
            CreateTable(
                "dbo.Utilizadores",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Username = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ItemCompras",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        QuantidadeComprada = c.Int(nullable: false),
                        PrecoUnitario = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CriadoPorId = c.Int(nullable: false),
                        AlteradoPorId = c.Int(),
                        CompraId = c.Int(nullable: false),
                        DataCriacao = c.DateTime(nullable: false),
                        DataAlteracao = c.DateTime(),
                        Observacoes = c.String(),
                        ArtigoId = c.Int(),
                        QuantidadePrevista = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Utilizadores", t => t.AlteradoPorId)
                .ForeignKey("dbo.Compras", t => t.CompraId, cascadeDelete: true)
                .ForeignKey("dbo.Utilizadores", t => t.CriadoPorId)
                .ForeignKey("dbo.Artigoes", t => t.ArtigoId, cascadeDelete: true)
                .Index(t => t.CriadoPorId)
                .Index(t => t.AlteradoPorId)
                .Index(t => t.CompraId)
                .Index(t => t.ArtigoId);
            
            CreateTable(
                "dbo.Orcamentoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Mes = c.Int(nullable: false),
                        Ano = c.Int(nullable: false),
                        ValorMaximo = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CriadoPorId = c.Int(nullable: false),
                        AlteradoPorId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Utilizadores", t => t.AlteradoPorId)
                .ForeignKey("dbo.Utilizadores", t => t.CriadoPorId, cascadeDelete: true)
                .Index(t => t.CriadoPorId)
                .Index(t => t.AlteradoPorId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orcamentoes", "CriadoPorId", "dbo.Utilizadores");
            DropForeignKey("dbo.Orcamentoes", "AlteradoPorId", "dbo.Utilizadores");
            DropForeignKey("dbo.ItemCompras", "ArtigoId", "dbo.Artigoes");
            DropForeignKey("dbo.ItemCompras", "CriadoPorId", "dbo.Utilizadores");
            DropForeignKey("dbo.ItemCompras", "CompraId", "dbo.Compras");
            DropForeignKey("dbo.ItemCompras", "AlteradoPorId", "dbo.Utilizadores");
            DropForeignKey("dbo.Compras", "FechadoPorId", "dbo.Utilizadores");
            DropForeignKey("dbo.Compras", "AlteradoPorId", "dbo.Utilizadores");
            DropForeignKey("dbo.Compras", "CriadoPorId", "dbo.Utilizadores");
            DropForeignKey("dbo.Artigoes", "TipoArtigoId", "dbo.TipoArtigoes");
            DropIndex("dbo.Orcamentoes", new[] { "AlteradoPorId" });
            DropIndex("dbo.Orcamentoes", new[] { "CriadoPorId" });
            DropIndex("dbo.ItemCompras", new[] { "ArtigoId" });
            DropIndex("dbo.ItemCompras", new[] { "CompraId" });
            DropIndex("dbo.ItemCompras", new[] { "AlteradoPorId" });
            DropIndex("dbo.ItemCompras", new[] { "CriadoPorId" });
            DropIndex("dbo.Compras", new[] { "FechadoPorId" });
            DropIndex("dbo.Compras", new[] { "AlteradoPorId" });
            DropIndex("dbo.Compras", new[] { "CriadoPorId" });
            DropIndex("dbo.Artigoes", new[] { "TipoArtigoId" });
            DropTable("dbo.Orcamentoes");
            DropTable("dbo.ItemCompras");
            DropTable("dbo.Utilizadores");
            DropTable("dbo.Compras");
            DropTable("dbo.TipoArtigoes");
            DropTable("dbo.Artigoes");
        }
    }
}
