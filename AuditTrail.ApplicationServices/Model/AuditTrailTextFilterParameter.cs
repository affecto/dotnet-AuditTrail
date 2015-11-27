using Affecto.AuditTrail.Interfaces.Model;

namespace Affecto.AuditTrail.ApplicationServices.Model
{
    internal class AuditTrailTextFilterParameter : IAuditTrailTextFilterParameter
    {
        public AuditTrailTextFilterOperator FilterOperator { get; set; }
        public string FilterValue { get; set; }
    }
}