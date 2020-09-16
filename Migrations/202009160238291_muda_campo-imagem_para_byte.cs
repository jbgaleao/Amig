namespace Amigurumis.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class muda_campoimagem_para_byte : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Revista", "FotoCapa", c => c.Binary());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Revista", "FotoCapa", c => c.Binary(nullable: false));
        }
    }
}
