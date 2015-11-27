using Affecto.AuditTrail.ApplicationServices.Model;
using Affecto.Mapping.AutoMapper;
using AutoMapper;

namespace Affecto.AuditTrail.ApplicationServices.Mapping
{
    internal class AuditTrailEntryMapper : OneWayMapper<Querying.Data.AuditTrailEntry, AuditTrailEntry>
    {
        protected override void ConfigureMaps()
        {
            Mapper.CreateMap<Querying.Data.AuditTrailEntry, AuditTrailEntry>();
        }
    }
}