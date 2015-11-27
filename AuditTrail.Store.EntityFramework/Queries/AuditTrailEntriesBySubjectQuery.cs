using System;
using System.Linq;
using Affecto.AuditTrail.Store.Model;

namespace Affecto.AuditTrail.Store.EntityFramework.Queries
{
    internal class AuditTrailEntriesBySubjectQuery
    {
        private readonly IQueryable<AuditTrailEntry> auditTrailEntries;

        public AuditTrailEntriesBySubjectQuery(IQueryable<AuditTrailEntry> auditTrailEntries)
        {
            if (auditTrailEntries == null)
            {
                throw new ArgumentNullException("auditTrailEntries");
            }
            this.auditTrailEntries = auditTrailEntries;
        }

        public IQueryable<AuditTrailEntry> Execute(Guid subjectId)
        {
            return auditTrailEntries.Where(e => e.SubjectId.Equals(subjectId));
        }
    }
}