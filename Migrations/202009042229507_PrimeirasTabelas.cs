namespace Amigurumis.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PrimeirasTabelas : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Fabricante",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Linha",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CodigoCor = c.Int(nullable: false),
                        DescricaoCor = c.String(nullable: false, maxLength: 50),
                        QtdFechada = c.Int(nullable: false),
                        QtdAberta = c.Int(nullable: false),
                        VFabricante_Id = c.Int(),
                        VReceita_Id = c.Int(),
                        VTipoLinha_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Fabricante", t => t.VFabricante_Id)
                .ForeignKey("dbo.Receita", t => t.VReceita_Id)
                .ForeignKey("dbo.TipoLinha", t => t.VTipoLinha_Id)
                .Index(t => t.VFabricante_Id)
                .Index(t => t.VReceita_Id)
                .Index(t => t.VTipoLinha_Id);
            
            CreateTable(
                "dbo.Receita",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descricao = c.String(nullable: false, maxLength: 200),
                        VRevista_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Revista", t => t.VRevista_Id)
                .Index(t => t.VRevista_Id);
            
            CreateTable(
                "dbo.Foto",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PathFoto = c.String(nullable: false, maxLength: 300),
                        IdReceita = c.Int(nullable: false),
                        VReceita_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Receita", t => t.VReceita_Id)
                .Index(t => t.VReceita_Id);
            
            CreateTable(
                "dbo.Revista",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TituloTema = c.String(nullable: false, maxLength: 100),
                        NumeroEdicao = c.Int(nullable: false),
                        Ano = c.Int(nullable: false),
                        MesPublicacao = c.Int(nullable: false),
                        FotoCapa = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TipoLinha",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descricao = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Linha", "VTipoLinha_Id", "dbo.TipoLinha");
            DropForeignKey("dbo.Receita", "VRevista_Id", "dbo.Revista");
            DropForeignKey("dbo.Linha", "VReceita_Id", "dbo.Receita");
            DropForeignKey("dbo.Foto", "VReceita_Id", "dbo.Receita");
            DropForeignKey("dbo.Linha", "VFabricante_Id", "dbo.Fabricante");
            DropIndex("dbo.Foto", new[] { "VReceita_Id" });
            DropIndex("dbo.Receita", new[] { "VRevista_Id" });
            DropIndex("dbo.Linha", new[] { "VTipoLinha_Id" });
            DropIndex("dbo.Linha", new[] { "VReceita_Id" });
            DropIndex("dbo.Linha", new[] { "VFabricante_Id" });
            DropTable("dbo.TipoLinha");
            DropTable("dbo.Revista");
            DropTable("dbo.Foto");
            DropTable("dbo.Receita");
            DropTable("dbo.Linha");
            DropTable("dbo.Fabricante");
        }
    }
}
