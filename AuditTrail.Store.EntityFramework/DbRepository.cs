using System;
using System.Collections.Generic;
using System.Linq;
using Affecto.AuditTrail.Store.EntityFramework.Queries;
using Affecto.AuditTrail.Store.Model;

namespace Affecto.AuditTrail.Store.EntityFramework
{
    internal class DbRepository : IDbRepository
    {
        private readonly IDbContext dbContext;

        public DbRepository(IDbContext dbContext)
        {
            if (dbContext == null)
            {
                throw new ArgumentNullException("dbContext");
            }
            this.dbContext = dbContext;
        }

        public IReadOnlyCollection<AuditTrailEntry> FindEntries()
        {
            return dbContext.AuditTrailEntries.ToList();
        }

        public AuditTrailResult FindEntriesForFilter(AuditTrailFilter filter)
        {
            AuditTrailEntriesByFilterQuery query = new AuditTrailEntriesByFilterQuery(dbContext.AuditTrailEntries);
            List<AuditTrailEntry> filteredResult = query.Execute(filter).ToList();

            AuditTrailResult result = new AuditTrailResult();
            result.ResultCount = filteredResult.Count();
            result.Items.AddRange(filteredResult.Skip((int) filter.Skip).Take((int) filter.Take));
            return result;
        }

        public IReadOnlyCollection<AuditTrailEntry> FindEntriesForSubject(Guid subjectId)
        {
            AuditTrailEntriesBySubjectQuery query = new AuditTrailEntriesBySubjectQuery(dbContext.AuditTrailEntries);
            return query.Execute(subjectId).ToList();
        }

        public AuditTrailEntry FindEntry(Guid auditTrailEntryId)
        {
            AuditTrailEntryQuery query = new AuditTrailEntryQuery(dbContext.AuditTrailEntries);
            return query.Execute(auditTrailEntryId);
        }
    }
}