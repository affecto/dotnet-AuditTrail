using System;
using Affecto.Patterns.Domain;

namespace Affecto.AuditTrail.Domain.Events
{
    public class AuditTrailEntryCreatedEvent : DomainEvent
    {
        public Guid SubjectId { get; private set; }
        public Guid? UserId { get; private set; }
        public string Summary { get; private set; }
        public DateTime Timestamp { get; private set; }
        public string SubjectName { get; private set; }
        public string UserName { get; private set; }

        public AuditTrailEntryCreatedEvent(Guid id, Guid subjectId, Guid? userId, string summary, DateTime timestamp, string subjectName, string userName)
            : base(id)
        {
            SubjectId = subjectId;
            UserId = userId;
            Summary = summary;
            Timestamp = timestamp;
            SubjectName = subjectName;
            UserName = userName;
        }
    }
}