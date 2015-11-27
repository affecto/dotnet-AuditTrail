using System;

namespace Affecto.AuditTrail.Interfaces.Model
{
    public interface IAuditTrailDateFilterParameter
    {
        AuditTrailDateFilterOperator FilterOperator { get; set; }
        DateTime FilterValue { get; set; }
    }
}