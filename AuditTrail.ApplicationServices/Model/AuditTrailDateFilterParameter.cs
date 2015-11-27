using System;
using Affecto.AuditTrail.Interfaces.Model;

namespace Affecto.AuditTrail.ApplicationServices.Model
{
    internal class AuditTrailDateFilterParameter:IAuditTrailDateFilterParameter
    {
        public AuditTrailDateFilterOperator FilterOperator { get; set; }
        public DateTime FilterValue { get; set; }
    }
}