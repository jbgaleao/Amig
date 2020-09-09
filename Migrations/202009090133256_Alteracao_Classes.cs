namespace Amigurumis.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Alteracao_Classes : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Foto", "VReceita_Id", "dbo.Receita");
            DropIndex("dbo.Foto", new[] { "VReceita_Id" });
            CreateTable(
                "dbo.Pedidoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdLinha = c.Int(nullable: false),
                        Data = c.DateTime(nullable: false),
                        Quantidade = c.Int(nullable: false),
                        ValorUnitario = c.Decimal(nullable: false, precision: 18, scale: 2),
                        VLinha_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Linha", t => t.VLinha_Id)
                .Index(t => t.VLinha_Id);
            
            AddColumn("dbo.Receita", "foto", c => c.Binary(nullable: false));
            AddColumn("dbo.Receita", "IdRevista", c => c.Int(nullable: false));
            AddColumn("dbo.Revista", "Tema", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Revista", "FotoCapa", c => c.Binary(nullable: false));
            DropColumn("dbo.Revista", "TituloTema");
            DropTable("dbo.Foto");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Foto",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PathFoto = c.String(nullable: false, maxLength: 300),
                        IdReceita = c.Int(nullable: false),
                        VReceita_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Revista", "TituloTema", c => c.String(nullable: false, maxLength: 100));
            DropForeignKey("dbo.Pedidoes", "VLinha_Id", "dbo.Linha");
            DropIndex("dbo.Pedidoes", new[] { "VLinha_Id" });
            AlterColumn("dbo.Revista", "FotoCapa", c => c.String(nullable: false));
            DropColumn("dbo.Revista", "Tema");
            DropColumn("dbo.Receita", "IdRevista");
            DropColumn("dbo.Receita", "foto");
            DropTable("dbo.Pedidoes");
            CreateIndex("dbo.Foto", "VReceita_Id");
            AddForeignKey("dbo.Foto", "VReceita_Id", "dbo.Receita", "Id");
        }
    }
}
