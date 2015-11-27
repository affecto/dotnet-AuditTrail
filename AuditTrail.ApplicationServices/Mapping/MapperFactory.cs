using Affecto.AuditTrail.ApplicationServices.Model;
using Affecto.AuditTrail.Interfaces.Model;
using Affecto.Mapping;

namespace Affecto.AuditTrail.ApplicationServices.Mapping
{
    internal class MapperFactory
    {
        public virtual IMapper<Querying.Data.AuditTrailEntry, AuditTrailEntry> CreateAuditTrailEntryMapper()
        {
            return new AuditTrailEntryMapper();
        }

        public virtual IMapper<IAuditTrailFilter, Querying.Model.AuditTrailFilter> CreateAuditTrailFilterMapper()
        {
            return new AuditTrailFilterMapper();
        }

        public virtual IMapper<Querying.Data.AuditTrailResult, AuditTrailResult> CreateAuditTrailResultMapper()
        {
            return new AuditTrailResultMapper();
        }
    }
}