using System;

namespace Affecto.AuditTrail.Store.Exceptions
{
    public class AuditTrailEntryNotFoundException : Exception
    {
        public AuditTrailEntryNotFoundException(Guid auditTrailEntryId, Exception innerException)
            : base(string.Format("Audit trail entry not found with id: '{0}'.", auditTrailEntryId), innerException)
        {
        }
    }
}