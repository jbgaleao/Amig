namespace Amigurumis.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Adicao_Tabela_Pedido : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Pedidoes", newName: "Pedido");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Pedido", newName: "Pedidoes");
        }
    }
}
