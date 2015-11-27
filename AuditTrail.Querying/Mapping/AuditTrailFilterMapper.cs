using Affecto.Mapping.AutoMapper;
using AutoMapper;

namespace Affecto.AuditTrail.Querying.Mapping
{
    internal class AuditTrailFilterMapper : OneWayMapper<Model.AuditTrailFilter, Store.Model.AuditTrailFilter>
    {
        protected override void ConfigureMaps()
        {
            Mapper.CreateMap<Model.AuditTrailDateFilterOperator, Store.Model.AuditTrailDateFilterOperator>();
            Mapper.CreateMap<Model.AuditTrailDateFilterParameter, Store.Model.AuditTrailDateFilterParameter>();

            Mapper.CreateMap<Model.AuditTrailTextFilterOperator, Store.Model.AuditTrailTextFilterOperator>();
            Mapper.CreateMap<Model.AuditTrailTextFilterParameter, Store.Model.AuditTrailTextFilterParameter>();

            Mapper.CreateMap<Model.AuditTrailSortDirection, Store.Model.AuditTrailSortDirection>();
            Mapper.CreateMap<Model.AuditTrailSortField, Store.Model.AuditTrailSortField>();
            Mapper.CreateMap<Model.AuditTrailSortParameter, Store.Model.AuditTrailSortParameter>();

            Mapper.CreateMap<Model.AuditTrailFilter, Store.Model.AuditTrailFilter>();
        }
    }
}