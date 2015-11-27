using System;
using System.Linq;
using Affecto.AuditTrail.Store.Exceptions;
using Affecto.AuditTrail.Store.Model;

namespace Affecto.AuditTrail.Store.EntityFramework.Queries
{
    internal class AuditTrailEntryQuery
    {
        private readonly IQueryable<AuditTrailEntry> auditTrailEntries;

        public AuditTrailEntryQuery(IQueryable<AuditTrailEntry> auditTrailEntries)
        {
            if (auditTrailEntries == null)
            {
                throw new ArgumentNullException("auditTrailEntries");
            }
            this.auditTrailEntries = auditTrailEntries;
        }

        public AuditTrailEntry Execute(Guid auditTrailEntryId)
        {
            try
            {
                return auditTrailEntries.Single(c => c.Id.Equals(auditTrailEntryId));
            }
            catch (Exception e)
            {
                throw new AuditTrailEntryNotFoundException(auditTrailEntryId, e);
            }
        }
    }
}