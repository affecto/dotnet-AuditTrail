using System;
using System.Collections.Generic;
using Affecto.AuditTrail.Querying.Data;
using Affecto.AuditTrail.Querying.Mapping;
using Affecto.AuditTrail.Querying.Model;
using Affecto.AuditTrail.Store;
using Affecto.Mapping;

namespace Affecto.AuditTrail.Querying
{
    internal class AuditTrailQueryService : IAuditTrailQueryService
    {
        private readonly IDbRepository repository;

        public AuditTrailQueryService(IDbRepository repository)
        {
            if (repository == null)
            {
                throw new ArgumentException("repository");
            }

            this.repository = repository;
        }

        public IEnumerable<AuditTrailEntry> GetEntries()
        {
            return new AuditTrailEntryMapper().Map(repository.FindEntries());
        }

        public AuditTrailResult GetEntries(AuditTrailFilter filter)
        {
            var storeFilter = (new AuditTrailFilterMapper()).Map(filter);
            return new AuditTrailResultMapper().Map(repository.FindEntriesForFilter(storeFilter));
        }

        public IEnumerable<AuditTrailEntry> GetEntriesForSubject(Guid subjectId)
        {
            return new AuditTrailEntryMapper().Map(repository.FindEntriesForSubject(subjectId));
        }

        public AuditTrailEntry GetEntry(Guid auditTrailEntryId)
        {
            return new AuditTrailEntryMapper().Map(repository.FindEntry(auditTrailEntryId));
        }
    }
}