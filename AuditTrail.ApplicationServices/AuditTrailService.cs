using System;
using System.Collections.Generic;
using Affecto.AuditTrail.ApplicationServices.Mapping;
using Affecto.AuditTrail.Commanding.Commands;
using Affecto.AuditTrail.Interfaces;
using Affecto.AuditTrail.Interfaces.Model;
using Affecto.AuditTrail.Querying;
using Affecto.Authentication.Claims;
using Affecto.Mapping;
using Affecto.Patterns.Cqrs;

namespace Affecto.AuditTrail.ApplicationServices
{
    internal class AuditTrailService : IAuditTrailService
    {
        private readonly IAuditTrailQueryService queryService;
        private readonly ICommandBus commandBus;
        private readonly IAuthenticatedUserContext userContext;
        private readonly MapperFactory mapperFactory;

        public AuditTrailService(IAuditTrailQueryService queryService, ICommandBus commandBus, IAuthenticatedUserContext userContext)
        {
            if (queryService == null)
            {
                throw new ArgumentException("queryService");
            }
            if (commandBus == null)
            {
                throw new ArgumentNullException("commandBus");
            }
            if (userContext == null)
            {
                throw new ArgumentNullException(nameof(userContext));
            }

            this.queryService = queryService;
            this.commandBus = commandBus;
            this.userContext = userContext;
            mapperFactory = new MapperFactory();
        }

        public IEnumerable<IAuditTrailEntry> GetEntries()
        {
            CheckPermission(Permissions.ViewAudittrail);
            var mapper = mapperFactory.CreateAuditTrailEntryMapper();
            return mapper.Map(queryService.GetEntries());
        }

        public IAuditTrailResult GetEntries(IAuditTrailFilter filter)
        {
            CheckPermission(Permissions.ViewAudittrail);
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

        private void CheckPermission(string permission)
        {
            userContext.CheckPermission(permission);
        }
    }
}