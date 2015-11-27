using System;
using Affecto.Patterns.Cqrs;

namespace Affecto.AuditTrail.Commanding.Commands
{
    public class CreateAuditTrailEntryCommand : ICommand
    {
        public Guid AuditTrailEntryId { get; private set; }
        public Guid SubjectId { get; private set; }
        public Guid? UserId { get; private set; }
        public string Summary { get; private set; }

        public string SubjectName { get; private set; }
        public string UserName { get; private set; }

        public CreateAuditTrailEntryCommand(Guid auditTrailEntryId, Guid subjectId, Guid userId, string summary, string subjectName, string userName)
            : this(auditTrailEntryId, subjectId, summary, subjectName, userName)
        {
            if (userId.Equals(Guid.Empty))
            {
                throw new ArgumentException("userId");
            }
            UserId = userId;
        }

        public CreateAuditTrailEntryCommand(Guid auditTrailEntryId, Guid subjectId, string summary, string subjectName, string userName)
        {
            if (Guid.Empty.Equals(auditTrailEntryId))
            {
                throw new ArgumentException("auditTrailEntryId");
            }
            if (Guid.Empty.Equals(subjectId))
            {
                throw new ArgumentException("subjectId");
            }
            if (string.IsNullOrEmpty(summary))
            {
                throw new ArgumentNullException("summary");
            }
            if (string.IsNullOrEmpty(subjectName))
            {
                throw new ArgumentNullException("subjectName");
            }
            if (string.IsNullOrEmpty(userName))
            {
                throw new ArgumentNullException("userName");
            }
            AuditTrailEntryId = auditTrailEntryId;
            SubjectId = subjectId;
            Summary = summary;

            SubjectName = subjectName;
            UserName = userName;
        }
    }
}