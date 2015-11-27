using Affecto.AuditTrail.Interfaces.Model;
using Affecto.AuditTrail.WebApi.Model;
using Affecto.Mapping;

namespace Affecto.AuditTrail.WebApi.Mapping
{
    internal class MapperFactory
    {
        public virtual IMapper<IAuditTrailEntry, AuditTrailEntry> CreateAuditTrailEntryMapper()
        {
            return new AuditTrailEntryMapper();
        }

        public virtual IMapper<IAuditTrailResult, AuditTrailResult> CreateAuditTrailResultMapper()
        {
            return new AuditTrailResultMapper();
        }

        public virtual IMapper<AuditTrailFilter, IAuditTrailFilter> CreateAuditTrailFilterMapper()
        {
            return new AuditTrailFilterMapper();
        }
    }
}