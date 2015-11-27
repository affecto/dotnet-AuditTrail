using Affecto.AuditTrail.Interfaces.Model;
using Affecto.AuditTrail.WebApi.Model;
using Affecto.Mapping.AutoMapper;
using AutoMapper;

namespace Affecto.AuditTrail.WebApi.Mapping
{
    internal class AuditTrailResultMapper : OneWayMapper<IAuditTrailResult, AuditTrailResult>
    {
        protected override void ConfigureMaps()
        {
            Mapper.CreateMap<IAuditTrailEntry, AuditTrailEntry>();
            Mapper.CreateMap<IAuditTrailResult, AuditTrailResult>();
        }
    }
}