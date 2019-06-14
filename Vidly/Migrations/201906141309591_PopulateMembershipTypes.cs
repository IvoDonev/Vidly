namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMembershipTypes : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO MembershipTypes (DurationInMonths, Price, Discount) VALUES (0, 0, 0)");
            Sql("INSERT INTO MembershipTypes (DurationInMonths, Price, Discount) VALUES (1, 30, 10)");
            Sql("INSERT INTO MembershipTypes (DurationInMonths, Price, Discount) VALUES (3, 90, 15)");
            Sql("INSERT INTO MembershipTypes (DurationInMonths, Price, Discount) VALUES (12, 300, 20)");
        }

        public override void Down()
        {
        }
    }
}
