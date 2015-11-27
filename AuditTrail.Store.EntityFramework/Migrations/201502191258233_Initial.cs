using System.Data.Entity.Migrations;

namespace Affecto.AuditTrail.Store.EntityFramework.Migrations
{
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AuditTrailEntry",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        SubjectId = c.Guid(nullable: false),
                        UserId = c.Guid(nullable: false),
                        Timestamp = c.DateTime(nullable: false),
                        Summary = c.String(),
                        SubjectName = c.String(),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AuditTrailEntry");
        }
    }
}