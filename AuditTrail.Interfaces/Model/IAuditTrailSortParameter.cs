namespace Affecto.AuditTrail.Interfaces.Model
{
    public interface IAuditTrailSortParameter
    {
        AuditTrailSortDirection SortDirection { get; set; }
        AuditTrailSortField SortField { get; set; }
    }
}