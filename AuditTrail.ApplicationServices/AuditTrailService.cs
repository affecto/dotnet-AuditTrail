using System;
using System.Collections.Generic;
using Affecto.AuditTrail.ApplicationServices.Mapping;
using Affecto.AuditTrail.Commanding.Commands;
using Affecto.AuditTrail.Interfaces;
using Affecto.AuditTrail.Interfaces.Model;
using Affecto.AuditTrail.Querying;
using Affecto.Mapping;
using Affecto.Patterns.Cqrs;

namespace Affecto.AuditTrail.ApplicationServices
{
    internal class AuditTrailService : IAuditTrailService
    {
        private readonly IAuditTrailQueryService queryService;
        private readonly ICommandBus commandBus;
        private readonly MapperFactory mapperFactory;

        public AuditTrailService(IAuditTrailQueryService queryService, ICommandBus commandBus)
        {
            if (queryService == null)
            {
                throw new ArgumentException("queryService");
            }
            if (commandBus == null)
            {
                throw new ArgumentNullException("commandBus");
            }

            this.queryService = queryService;
            this.commandBus = commandBus;
            mapperFactory = new MapperFactory();
        }

        public IEnumerable<IAuditTrailEntry> GetEntries()
        {
            var mapper = mapperFactory.CreateAuditTrailEntryMapper();
            return mapper.Map(queryService.GetEntries());
        }

        public IAuditTrailResult GetEntries(IAuditTrailFilter filter)
        {
            var queryFilter = mapperFactory.CreateAuditTrailFilterMapper().Map(filter);

            var mapper = mapperFactory.CreateAuditTrailResultMapper();
            return mapper.Map(queryService.GetEntries(queryFilter));
        }

        public IEnumerable<IAuditTrailEntry> GetEntriesForSubject(Guid subjectId)
        {
            var mapper = mapperFactory.CreateAuditTrailEntryMapper();
            return mapper.Map(queryService.GetEntriesForSubject(subjectId));
        }

        public IAuditTrailEntry GetEntry(Guid auditTrailEntryId)
        {
            var mapper = mapperFactory.CreateAuditTrailEntryMapper();
            return mapper.Map(queryService.GetEntry(auditTrailEntryId));
        }

        public IAuditTrailEntry CreateEntry(Guid subjectId, string summary, string subjectName, string userName)
        {
            Guid id = Guid.NewGuid();
            var command = new CreateAuditTrailEntryCommand(id, subjectId, summary, subjectName, userName);
            commandBus.Send(Envelope.Create(command));
            var mapper = mapperFactory.CreateAuditTrailEntryMapper();
            return mapper.Map(queryService.GetEntry(id));
        }

        public IAuditTrailEntry CreateEntry(Guid subjectId, Guid userId, string summary, string subjectName, string userName)
        {
            Guid id = Guid.NewGuid();
            var command = new CreateAuditTrailEntryCommand(id, subjectId, userId, summary, subjectName, userName);
            commandBus.Send(Envelope.Create(command));
            var mapper = mapperFactory.CreateAuditTrailEntryMapper();
            return mapper.Map(queryService.GetEntry(id));
        }
    }
}