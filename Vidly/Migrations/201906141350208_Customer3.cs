namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Customer3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customer2",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        MembershipTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MembershipTypes", t => t.MembershipTypeId, cascadeDelete: true)
                .Index(t => t.MembershipTypeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customer2", "MembershipTypeId", "dbo.MembershipTypes");
            DropIndex("dbo.Customer2", new[] { "MembershipTypeId" });
            DropTable("dbo.Customer2");
        }
    }
}
