namespace Amigurumis.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Altera_Campo_Foro_para_string : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Receita", "foto", c => c.String(nullable: false));
            AlterColumn("dbo.Revista", "FotoCapa", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Revista", "FotoCapa", c => c.Binary(nullable: false));
            AlterColumn("dbo.Receita", "foto", c => c.Binary(nullable: false));
        }
    }
}
