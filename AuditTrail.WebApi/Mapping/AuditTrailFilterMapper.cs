using Affecto.AuditTrail.WebApi.Model;
using Affecto.Mapping.AutoMapper;
using AutoMapper;

namespace Affecto.AuditTrail.WebApi.Mapping
{
    internal class AuditTrailFilterMapper : OneWayMapper<AuditTrailFilter, Interfaces.Model.IAuditTrailFilter>
    {
        protected override void ConfigureMaps()
        {
            Mapper.CreateMap<AuditTrailDateFilterOperator, Interfaces.Model.AuditTrailDateFilterOperator>();
            Mapper.CreateMap<AuditTrailDateFilterParameter, Interfaces.Model.IAuditTrailDateFilterParameter>();

            Mapper.CreateMap<AuditTrailTextFilterOperator, Interfaces.Model.AuditTrailTextFilterOperator>();
            Mapper.CreateMap<AuditTrailTextFilterParameter, Interfaces.Model.IAuditTrailTextFilterParameter>();

            Mapper.CreateMap<AuditTrailSortDirection, Interfaces.Model.AuditTrailSortDirection>();
            Mapper.CreateMap<AuditTrailSortField, Interfaces.Model.AuditTrailSortField>();
            Mapper.CreateMap<AuditTrailSortParameter, Interfaces.Model.IAuditTrailSortParameter>();

            Mapper.CreateMap<AuditTrailFilter, Interfaces.Model.IAuditTrailFilter>();
        }
    }
}