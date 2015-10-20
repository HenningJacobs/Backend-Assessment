namespace MusicBackend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20151018 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Artists",
                c => new
                    {
                        GUID = c.Guid(nullable: false),
                        ArtistName = c.String(nullable: false, maxLength: 60),
                        Counrty = c.String(nullable: false, maxLength: 2),
                        Aliases = c.String(),
                    })
                .PrimaryKey(t => t.GUID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Artists");
        }
    }
}
