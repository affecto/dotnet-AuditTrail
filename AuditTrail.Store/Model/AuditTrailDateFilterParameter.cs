using System;

namespace Affecto.AuditTrail.Store.Model
{
    public class AuditTrailDateFilterParameter
    {
        public AuditTrailDateFilterOperator FilterOperator { get; set; }
        public DateTime FilterValue { get; set; }
    }
}