using Affecto.AuditTrail.Interfaces.Model;

namespace Affecto.AuditTrail.ApplicationServices.Model
{
    internal class AuditTrailSortParameter : IAuditTrailSortParameter
    {
        public AuditTrailSortDirection SortDirection { get; set; }
        public AuditTrailSortField SortField { get; set; }
    }
}