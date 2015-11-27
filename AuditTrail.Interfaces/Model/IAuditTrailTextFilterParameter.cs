namespace Affecto.AuditTrail.Interfaces.Model
{
    public interface IAuditTrailTextFilterParameter
    {
        AuditTrailTextFilterOperator FilterOperator { get; set; }
        string FilterValue { get; set; }
    }
}