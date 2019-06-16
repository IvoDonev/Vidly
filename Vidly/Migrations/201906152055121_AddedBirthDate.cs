namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedBirthDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customer2", "BirthDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customer2", "BirthDate");
        }
    }
}
