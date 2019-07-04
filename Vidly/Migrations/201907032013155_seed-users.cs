namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seedusers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
            INSERT INTO[dbo].[AspNetUsers]
                 ([Id], [DrivingLicense], [Phone], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES(N'1c7531cb-aa3b-4218-b2cb-c9ea59598b37', N'123123', N'123123', N'admin@Vidly.com', 0, N'AMK9FvvsYvhAtAlQh2zUYvtthxbjG70brX6exMTmm0sYsXmulZnz8poEPR8Kmdzs8Q==', N'5db26672-cf7e-48fb-8267-560852d3d9db', NULL, 0, 0, NULL, 1, 0, N'admin@Vidly.com')
            INSERT INTO[dbo].[AspNetUsers]
                ([Id], [DrivingLicense], [Phone], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES(N'97e029ce-0994-4c5d-841e-e409abbc5d28', N'121212', N'121212', N'guest@vidly.com', 0, N'ABeXAikwMC+H6iP5J0PVOb1UcW9buFqPtnOTAOirC6dx9yF/5eB7STv7Dww9Lkc9+Q==', N'b2f3f7fe-c1c6-42c5-919f-3798ccc3bc15', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')");
            Sql(@"INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'68a23a6f-5793-4dba-89ce-1c61148d406b', N'CanManageMovies')");
            Sql(@"INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'1c7531cb-aa3b-4218-b2cb-c9ea59598b37', N'68a23a6f-5793-4dba-89ce-1c61148d406b')");
        }

    public override void Down()
        {
        }
    }
}
