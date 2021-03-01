namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateGeneTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT into Genres(GenreName) Values('Action')");

            Sql("INSERT into Genres(GenreName) Values('Romance')");

            Sql("INSERT into Genres(GenreName) Values('Family')");

            Sql("INSERT into Genres(GenreName) Values('Comedy')");
        }
        
        public override void Down()
        {
        }
    }
}
