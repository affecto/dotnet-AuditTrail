using System;

namespace Affecto.AuditTrail.WebApi.Model
{
    public class AuditTrailEntry
    {
        public Guid Id { get; set; }
        public DateTime Timestamp { get; set; }
        public string Summary { get; set; }

        public string SubjectName { get; set; }
        public string UserName { get; set; }
    }
}