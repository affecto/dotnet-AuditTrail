using System;
using System.Collections.Generic;
using Affecto.AuditTrail.Querying.Data;
using Affecto.AuditTrail.Querying.Model;

namespace Affecto.AuditTrail.Querying
{
    public interface IAuditTrailQueryService
    {
        IEnumerable<AuditTrailEntry> GetEntries();
        AuditTrailResult GetEntries(AuditTrailFilter filter);
        IEnumerable<AuditTrailEntry> GetEntriesForSubject(Guid subjectId);
        AuditTrailEntry GetEntry(Guid auditTrailEntryId);
    }
}