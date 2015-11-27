using System;
using Affecto.AuditTrail.Domain.Events;
using Affecto.Patterns.Domain;

namespace Affecto.AuditTrail.Domain.Entities
{
    public class AuditTrailEntry : AggregateRoot
    {
        public Guid SubjectId { get; private set; }
        public Guid? UserId { get; private set; }
        public string Summary { get; private set; }
        public DateTime Timestamp { get; private set; }

        public string SubjectName { get; private set; }
        public string UserName { get; private set; }

        protected AuditTrailEntry(Guid id, Guid subjectId, Guid? userId, string summary, DateTime timestamp, string subjectName, string userName)
            : base(id)
        {
            if (id.Equals(Guid.Empty))
            {
                throw new ArgumentException("Audit trail entry id must be defined.", "id");
            }

            SubjectId = subjectId;
            UserId = userId;
            Summary = summary;
            Timestamp = timestamp;
            SubjectName = subjectName;
            UserName = userName;
        }

        public static AuditTrailEntry Create(Guid id, Guid subjectId, Guid? userId, string summary, string subjectName, string userName)
        {
            var auditTrailEntry = new AuditTrailEntry(id, subjectId, userId, summary, DateTime.Now, subjectName, userName);
            var entryCreatedEvent = new AuditTrailEntryCreatedEvent(auditTrailEntry.Id, auditTrailEntry.SubjectId, auditTrailEntry.UserId,
                auditTrailEntry.Summary, auditTrailEntry.Timestamp, auditTrailEntry.SubjectName, auditTrailEntry.UserName);

            auditTrailEntry.ApplyEvent(entryCreatedEvent);

            return auditTrailEntry;
        }

        public static AuditTrailEntry Restore(Guid id, Guid subjectId, Guid userId, string summary, DateTime timestamp, string subjectName, string userName)
        {
            return new AuditTrailEntry(id, subjectId, userId, summary, timestamp, subjectName, userName);
        }
    }
}