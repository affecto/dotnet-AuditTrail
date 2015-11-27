using System;

namespace Affecto.AuditTrail.Interfaces.Model
{
    public interface IAuditTrailEntry
    {
        Guid Id { get; }
        Guid SubjectId { get; }
        Guid UserId { get; }
        DateTime Timestamp { get; }
        string Summary { get; }

        //FOR DEMO
        string SubjectName { get; }
        string UserName { get; }
    }
}