using Affecto.AuditTrail.Store.Model;
using Affecto.Mapping.AutoMapper;
using AutoMapper;

namespace Affecto.AuditTrail.Querying.Mapping
{
    internal class AuditTrailEntryMapper : OneWayMapper<AuditTrailEntry, Data.AuditTrailEntry>
    {
        protected override void ConfigureMaps()
        {
            Mapper.CreateMap<AuditTrailEntry, Data.AuditTrailEntry>();
        }
    }
}