namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMembershipNameDataToMembershipType : DbMigration
    {
        public override void Up()
        {
            Sql("Update MembershipTypes set Name = 'Pay as you go' where DurationInMonths = 0");
            Sql("Update MembershipTypes set Name = 'Monthly' where DurationInMonths = 1");
            Sql("Update MembershipTypes set Name = 'Quarterly' where DurationInMonths = 3");
            Sql("Update MembershipTypes set Name = 'Yearly' where DurationInMonths = 12");
        }
        
        public override void Down()
        {
        }
    }
}
