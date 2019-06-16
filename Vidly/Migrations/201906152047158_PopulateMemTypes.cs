namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMemTypes : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO MembershipTypes (Name, DurationInMonths, Price, Discount) VALUES ('Pay as you go', 0, 0, 0)");
            Sql("INSERT INTO MembershipTypes (Name, DurationInMonths, Price, Discount) VALUES ('Monthly', 1, 30, 10)");
            Sql("INSERT INTO MembershipTypes (Name, DurationInMonths, Price, Discount) VALUES ('Quaterly', 3, 90, 15)");
            Sql("INSERT INTO MembershipTypes (Name, DurationInMonths, Price, Discount) VALUES ('Annual', 12, 300, 20)");
        }

        public override void Down()
        {
        }
    }
}
