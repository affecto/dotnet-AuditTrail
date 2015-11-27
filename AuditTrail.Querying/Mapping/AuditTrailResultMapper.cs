using Affecto.AuditTrail.Store.Model;
using Affecto.Mapping.AutoMapper;
using AutoMapper;

namespace Affecto.AuditTrail.Querying.Mapping
{
    internal class AuditTrailResultMapper : OneWayMapper<AuditTrailResult, Data.AuditTrailResult>
    {
        protected override void ConfigureMaps()
        {
            Mapper.CreateMap<AuditTrailEntry, Data.AuditTrailEntry>();
            Mapper.CreateMap<AuditTrailResult, Data.AuditTrailResult>();
        }
    }
}