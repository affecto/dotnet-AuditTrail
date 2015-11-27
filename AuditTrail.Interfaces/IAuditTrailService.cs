using System;
using System.Collections.Generic;
using Affecto.AuditTrail.Interfaces.Model;

namespace Affecto.AuditTrail.Interfaces
{
    public interface IAuditTrailService
    {
        IEnumerable<IAuditTrailEntry> GetEntries();
        IAuditTrailResult GetEntries(IAuditTrailFilter filter);
        IEnumerable<IAuditTrailEntry> GetEntriesForSubject(Guid subjectId);
        IAuditTrailEntry GetEntry(Guid auditTrailEntryId);
        IAuditTrailEntry CreateEntry(Guid subjectId, string summary, string subjectName, string userName);
        IAuditTrailEntry CreateEntry(Guid subjectId, Guid userId, string summary, string subjectName, string userName);
    }
}