using System.Data.Entity.Migrations;

namespace Affecto.AuditTrail.Store.EntityFramework.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<DbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }
    }
}