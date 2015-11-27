using Affecto.AuditTrail.Interfaces.Model;
using Affecto.AuditTrail.WebApi.Model;
using Affecto.Mapping.AutoMapper;
using AutoMapper;

namespace Affecto.AuditTrail.WebApi.Mapping
{
    internal class AuditTrailEntryMapper : OneWayMapper<IAuditTrailEntry, AuditTrailEntry>
    {
        protected override void ConfigureMaps()
        {
            Mapper.CreateMap<IAuditTrailEntry, AuditTrailEntry>();
        }
    }
}