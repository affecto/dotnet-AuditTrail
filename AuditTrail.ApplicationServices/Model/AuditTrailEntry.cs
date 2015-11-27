using System;
using Affecto.AuditTrail.Interfaces.Model;

namespace Affecto.AuditTrail.ApplicationServices.Model
{
    internal class AuditTrailEntry : IAuditTrailEntry
    {
        public Guid Id { get; set; }
        public Guid SubjectId { get; set; }
        public Guid UserId { get; set; }
        public DateTime Timestamp { get; set; }
        public string Summary { get; set; }
        public string SubjectName { get; set; }
        public string UserName { get; set; }
    }
}