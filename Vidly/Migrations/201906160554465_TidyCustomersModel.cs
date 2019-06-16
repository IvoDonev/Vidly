namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TidyCustomersModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customer2", "MembershipTypeId", "dbo.MembershipTypes");
            DropIndex("dbo.Customer2", new[] { "MembershipTypeId" });
            AddColumn("dbo.Customers", "BirthDate", c => c.DateTime());
            DropTable("dbo.Customer2");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Customer2",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        MembershipTypeId = c.Int(nullable: false),
                        BirthDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropColumn("dbo.Customers", "BirthDate");
            CreateIndex("dbo.Customer2", "MembershipTypeId");
            AddForeignKey("dbo.Customer2", "MembershipTypeId", "dbo.MembershipTypes", "Id", cascadeDelete: true);
        }
    }
}
