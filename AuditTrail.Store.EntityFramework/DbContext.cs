using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Affecto.AuditTrail.Store.Model;
using Affecto.Patterns.Domain.UnitOfWork;

namespace Affecto.AuditTrail.Store.EntityFramework
{
    internal class DbContext : System.Data.Entity.DbContext, IDbContext
    {
        public DbContext()
            : base("AuditTrailDbContext")
        {
            Configuration.LazyLoadingEnabled = false;
        }

        public IDbSet<AuditTrailEntry> AuditTrailEntries { get; set; }

        void IUnitOfWork.SaveChanges()
        {
            SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            SpecifyAuditTrailEntry(modelBuilder);
        }

        private static void SpecifyAuditTrailEntry(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AuditTrailEntry>().HasKey(auditTrailEntry => auditTrailEntry.Id);
            modelBuilder.Entity<AuditTrailEntry>().Property(auditTrailEntry => auditTrailEntry.Timestamp).IsRequired();
        }
    }
}