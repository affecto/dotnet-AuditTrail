using Affecto.AuditTrail.ApplicationServices.Model;
using Affecto.AuditTrail.Interfaces.Model;
using Affecto.Mapping.AutoMapper;
using AutoMapper;

namespace Affecto.AuditTrail.ApplicationServices.Mapping
{
    internal class AuditTrailResultMapper : OneWayMapper<Querying.Data.AuditTrailResult, AuditTrailResult>
    {
        protected override void ConfigureMaps()
        {
            Mapper.CreateMap<Querying.Data.AuditTrailEntry, AuditTrailEntry>();
            Mapper.CreateMap<Querying.Data.AuditTrailEntry, IAuditTrailEntry>()
                .ConstructUsing(Mapper.Map<Querying.Data.AuditTrailEntry, AuditTrailEntry>);
            Mapper.CreateMap<Querying.Data.AuditTrailResult, AuditTrailResult>();
        }
    }
}