using System.Collections.Generic;

namespace Affecto.AuditTrail.Interfaces.Model
{
    public interface IAuditTrailResult
    {
        List<IAuditTrailEntry> Items { get; set; }
        long ResultCount { get; set; }
    }
}