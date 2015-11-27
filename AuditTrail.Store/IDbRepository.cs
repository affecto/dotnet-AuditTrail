using System;
using System.Collections.Generic;
using Affecto.AuditTrail.Store.Model;

namespace Affecto.AuditTrail.Store
{
    public interface IDbRepository
    {
        IReadOnlyCollection<AuditTrailEntry> FindEntries();
        AuditTrailResult FindEntriesForFilter(AuditTrailFilter filter);
        IReadOnlyCollection<AuditTrailEntry> FindEntriesForSubject(Guid subjectId);
        AuditTrailEntry FindEntry(Guid auditTrailEntryId);
    }
}