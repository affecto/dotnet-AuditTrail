using System.Collections.Generic;

namespace Affecto.AuditTrail.Store.Model
{
    public class AuditTrailResult
    {
        public List<AuditTrailEntry> Items { get; set; }
        public long ResultCount { get; set; }

        public AuditTrailResult()
        {
            Items = new List<AuditTrailEntry>();
        }
    }
}