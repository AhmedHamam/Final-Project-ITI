namespace project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mina : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admin_Roles",
                c => new
                    {
                        id = c.Int(nullable: false),
                        adminId = c.Int(nullable: false),
                        Role_name = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => new { t.id, t.adminId })
                .ForeignKey("dbo.Admin", t => t.adminId)
                .Index(t => t.adminId);
            
            CreateTable(
                "dbo.Admin",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        fName = c.String(nullable: false, maxLength: 50),
                        mName = c.String(nullable: false, maxLength: 50),
                        lName = c.String(nullable: false, maxLength: 50),
                        email = c.String(nullable: false, maxLength: 50),
                        userName = c.String(nullable: false, maxLength: 50),
                        password = c.String(nullable: false, maxLength: 50),
                        phone = c.String(maxLength: 11),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Citzen",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        fName = c.String(nullable: false, maxLength: 50),
                        lName = c.String(nullable: false, maxLength: 50),
                        mName = c.String(nullable: false, maxLength: 50),
                        nationailnumber = c.String(nullable: false, maxLength: 14),
                        nationalNumberImage = c.String(nullable: false, maxLength: 500),
                        gender = c.String(nullable: false, maxLength: 50),
                        userName = c.String(nullable: false, maxLength: 50),
                        email = c.String(nullable: false, maxLength: 50),
                        password = c.String(nullable: false, maxLength: 500),
                        address = c.String(maxLength: 500),
                        phone = c.String(maxLength: 11),
                        mobile = c.String(maxLength: 11),
                        reg_date = c.DateTime(storeType: "date"),
                        works_on = c.String(maxLength: 50),
                        accpted = c.Boolean(),
                        deleated = c.Boolean(),
                        blocked = c.Boolean(),
                        cityId = c.Int(),
                        accptedBy = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.cities", t => t.cityId)
                .ForeignKey("dbo.Admin", t => t.accptedBy)
                .Index(t => t.cityId)
                .Index(t => t.accptedBy);
            
            CreateTable(
                "dbo.cities",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 500),
                        gov_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Governments", t => t.gov_id, cascadeDelete: true)
                .Index(t => t.gov_id);
            
            CreateTable(
                "dbo.Complaint",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        comNumber = c.Long(),
                        comTitle = c.String(nullable: false, maxLength: 500),
                        comDescription = c.String(nullable: false),
                        comEntitybranch_id = c.Int(),
                        comEntity_id = c.Int(),
                        comFile = c.String(maxLength: 500),
                        comDate = c.DateTime(storeType: "date"),
                        comStatus = c.Boolean(),
                        comCity = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Entity_Branchs", t => t.comEntity_id, cascadeDelete: true)
                .ForeignKey("dbo.cities", t => t.comCity)
                .Index(t => t.comEntity_id)
                .Index(t => t.comCity);
            
            CreateTable(
                "dbo.Entity_Branchs",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        title = c.String(maxLength: 500),
                        entity_id = c.Int(),
                        is_deleted = c.Boolean(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Entity", t => t.entity_id, cascadeDelete: true)
                .Index(t => t.entity_id);
            
            CreateTable(
                "dbo.Entity",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 500),
                        address = c.String(maxLength: 500),
                        phone = c.String(maxLength: 11),
                        fax = c.String(maxLength: 11),
                        is_deleted = c.Boolean(),
                        mangerId = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Officials", t => t.mangerId)
                .Index(t => t.mangerId);
            
            CreateTable(
                "dbo.Officials",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        fName = c.String(maxLength: 50),
                        mName = c.String(maxLength: 50),
                        lName = c.String(maxLength: 50),
                        userName = c.String(maxLength: 50),
                        passWord = c.String(maxLength: 500),
                        email = c.String(maxLength: 50),
                        phone = c.String(maxLength: 11),
                        mobile = c.String(nullable: false, maxLength: 11),
                        job = c.String(maxLength: 50),
                        jobDesciption = c.String(maxLength: 500),
                        isLeader = c.Boolean(),
                        leaderId = c.Int(),
                        entityId = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Officials", t => t.leaderId)
                .ForeignKey("dbo.Entity", t => t.entityId)
                .Index(t => t.leaderId)
                .Index(t => t.entityId);
            
            CreateTable(
                "dbo.Governments",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 500),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.sysdiagrams",
                c => new
                    {
                        diagram_id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 128),
                        principal_id = c.Int(nullable: false),
                        version = c.Int(),
                        definition = c.Binary(),
                    })
                .PrimaryKey(t => t.diagram_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Citzen", "accptedBy", "dbo.Admin");
            DropForeignKey("dbo.cities", "gov_id", "dbo.Governments");
            DropForeignKey("dbo.Complaint", "comCity", "dbo.cities");
            DropForeignKey("dbo.Officials", "entityId", "dbo.Entity");
            DropForeignKey("dbo.Officials", "leaderId", "dbo.Officials");
            DropForeignKey("dbo.Entity", "mangerId", "dbo.Officials");
            DropForeignKey("dbo.Entity_Branchs", "entity_id", "dbo.Entity");
            DropForeignKey("dbo.Complaint", "comEntity_id", "dbo.Entity_Branchs");
            DropForeignKey("dbo.Citzen", "cityId", "dbo.cities");
            DropForeignKey("dbo.Admin_Roles", "adminId", "dbo.Admin");
            DropIndex("dbo.Officials", new[] { "entityId" });
            DropIndex("dbo.Officials", new[] { "leaderId" });
            DropIndex("dbo.Entity", new[] { "mangerId" });
            DropIndex("dbo.Entity_Branchs", new[] { "entity_id" });
            DropIndex("dbo.Complaint", new[] { "comCity" });
            DropIndex("dbo.Complaint", new[] { "comEntity_id" });
            DropIndex("dbo.cities", new[] { "gov_id" });
            DropIndex("dbo.Citzen", new[] { "accptedBy" });
            DropIndex("dbo.Citzen", new[] { "cityId" });
            DropIndex("dbo.Admin_Roles", new[] { "adminId" });
            DropTable("dbo.sysdiagrams");
            DropTable("dbo.Governments");
            DropTable("dbo.Officials");
            DropTable("dbo.Entity");
            DropTable("dbo.Entity_Branchs");
            DropTable("dbo.Complaint");
            DropTable("dbo.cities");
            DropTable("dbo.Citzen");
            DropTable("dbo.Admin");
            DropTable("dbo.Admin_Roles");
        }
    }
}
