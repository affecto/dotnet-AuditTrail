using System;
using System.Collections.Generic;
using System.Linq;
using Affecto.AuditTrail.Store.Model;

namespace Affecto.AuditTrail.Store.EntityFramework.Queries
{
    internal class AuditTrailEntriesQuery
    {
        private readonly IQueryable<AuditTrailEntry> auditTrailEntries;

        public AuditTrailEntriesQuery(IQueryable<AuditTrailEntry> auditTrailEntries)
        {
            if (auditTrailEntries == null)
            {
                throw new ArgumentNullException("auditTrailEntries");
            }
            this.auditTrailEntries = auditTrailEntries;
        }

        public IReadOnlyCollection<AuditTrailEntry> Execute()
        {
            try
            {
                return auditTrailEntries.OrderByDescending(i => i.Timestamp).ToList();
            }
            catch (Exception)
            {
                throw new Exception("auditTrailEntries.ToList()");
            }
        }
    }
}