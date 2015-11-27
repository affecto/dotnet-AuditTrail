using Affecto.AuditTrail.Interfaces.Model;
using Affecto.Mapping.AutoMapper;
using AutoMapper;

namespace Affecto.AuditTrail.ApplicationServices.Mapping
{
    internal class AuditTrailFilterMapper : OneWayMapper<IAuditTrailFilter, Querying.Model.AuditTrailFilter>
    {
        protected override void ConfigureMaps()
        {
            Mapper.CreateMap<AuditTrailDateFilterOperator, Querying.Model.AuditTrailDateFilterOperator>();
            Mapper.CreateMap<IAuditTrailDateFilterParameter, Querying.Model.AuditTrailDateFilterParameter>();

            Mapper.CreateMap<AuditTrailTextFilterOperator, Querying.Model.AuditTrailTextFilterOperator>();
            Mapper.CreateMap<IAuditTrailTextFilterParameter, Querying.Model.AuditTrailTextFilterParameter>();

            Mapper.CreateMap<AuditTrailSortDirection, Querying.Model.AuditTrailSortDirection>();
            Mapper.CreateMap<AuditTrailSortField, Querying.Model.AuditTrailSortField>();
            Mapper.CreateMap<IAuditTrailSortParameter, Querying.Model.AuditTrailSortParameter>();

            Mapper.CreateMap<IAuditTrailFilter, Querying.Model.AuditTrailFilter>();
        }
    }
}