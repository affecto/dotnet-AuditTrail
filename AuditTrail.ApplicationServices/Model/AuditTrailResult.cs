using System.Collections.Generic;
using Affecto.AuditTrail.Interfaces.Model;

namespace Affecto.AuditTrail.ApplicationServices.Model
{
    internal class AuditTrailResult : IAuditTrailResult
    {
        public List<IAuditTrailEntry> Items { get; set; }
        public long ResultCount { get; set; }

        public AuditTrailResult()
        {
            Items = new List<IAuditTrailEntry>();
        }
    }
}