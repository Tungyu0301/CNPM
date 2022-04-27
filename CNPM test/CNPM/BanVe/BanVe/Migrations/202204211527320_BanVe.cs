namespace BanVe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BanVe : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TblAdminLogin",
                c => new
                    {
                        AdminId = c.Int(nullable: false, identity: true),
                        AdName = c.String(nullable: false, maxLength: 15),
                        Password = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.AdminId);
            
            CreateTable(
                "dbo.AeroPlaneInfoes",
                c => new
                    {
                        Planeid = c.Int(nullable: false, identity: true),
                        APlaneName = c.String(nullable: false, maxLength: 20),
                        SeatingCapacity = c.Int(nullable: false),
                        price = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Planeid);
            
            CreateTable(
                "dbo.TblFlightBook",
                c => new
                    {
                        bid = c.Int(nullable: false, identity: true),
                        From = c.String(nullable: false, maxLength: 40),
                        To = c.String(nullable: false, maxLength: 40),
                        DDate = c.DateTime(nullable: false),
                        Time = c.DateTime(nullable: false),
                        Planeid = c.Int(nullable: false),
                        SeatType = c.String(maxLength: 25),
                    })
                .PrimaryKey(t => t.bid)
                .ForeignKey("dbo.AeroPlaneInfoes", t => t.Planeid, cascadeDelete: true)
                .Index(t => t.Planeid);
            
            CreateTable(
                "dbo.TblUserAccount",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        FistName = c.String(nullable: false, maxLength: 20),
                        LastName = c.String(nullable: false, maxLength: 20),
                        Email = c.String(nullable: false, maxLength: 20),
                        Password = c.String(nullable: false, maxLength: 20),
                        CPassword = c.String(nullable: false, maxLength: 20),
                        Age = c.String(nullable: false),
                        Phone = c.String(nullable: false, maxLength: 11),
                        NIC = c.String(nullable: false, maxLength: 13),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TblFlightBook", "Planeid", "dbo.AeroPlaneInfoes");
            DropIndex("dbo.TblFlightBook", new[] { "Planeid" });
            DropTable("dbo.TblUserAccount");
            DropTable("dbo.TblFlightBook");
            DropTable("dbo.AeroPlaneInfoes");
            DropTable("dbo.TblAdminLogin");
        }
    }
}
