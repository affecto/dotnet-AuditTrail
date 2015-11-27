using System.Data.Entity.Migrations;

namespace Affecto.AuditTrail.Store.EntityFramework.Migrations
{
    public partial class NullableUserId : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AuditTrailEntry", "UserId", c => c.Guid());
        }

        public override void Down()
        {
            AlterColumn("dbo.AuditTrailEntry", "UserId", c => c.Guid(nullable: false));
        }
    }
}