namespace project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mina1 : DbMigration
    {
        public override void Up()
        {

        }
        
        public override void Down()
        {
            AlterColumn("dbo.Complaint", "comStatus", c => c.Boolean());
            AlterColumn("dbo.Complaint", "comNumber", c => c.Long());
            DropTable("dbo.__MigrationHistory");
        }
    }
}
