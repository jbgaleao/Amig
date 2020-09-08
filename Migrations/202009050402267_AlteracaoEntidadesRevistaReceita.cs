namespace Amigurumis.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlteracaoEntidadesRevistaReceita : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Receita", "Nome", c => c.String(nullable: false, maxLength: 64));
            AlterColumn("dbo.Receita", "Descricao", c => c.String(nullable: false, maxLength: 256));
            DropColumn("dbo.Revista", "Ano");
            DropColumn("dbo.Revista", "MesPublicacao");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Revista", "MesPublicacao", c => c.Int(nullable: false));
            AddColumn("dbo.Revista", "Ano", c => c.Int(nullable: false));
            AlterColumn("dbo.Receita", "Descricao", c => c.String(nullable: false, maxLength: 200));
            DropColumn("dbo.Receita", "Nome");
        }
    }
}
