using System;
using Affecto.AuditTrail.Commanding.Commands;
using Affecto.AuditTrail.Domain.Entities;
using Affecto.Patterns.Cqrs;
using Affecto.Patterns.Domain;

namespace Affecto.AuditTrail.Commanding.CommandHandlers
{
    internal class CreateAuditTrailEntryCommandHandler : ICommandHandler<CreateAuditTrailEntryCommand>
    {
        private readonly IDomainRepository<AuditTrailEntry> auditTrailEntryRepository;

        public CreateAuditTrailEntryCommandHandler(IDomainRepository<AuditTrailEntry> auditTrailEntryRepository)
        {
            if (auditTrailEntryRepository == null)
            {
                throw new ArgumentNullException("auditTrailEntryRepository");
            }
            this.auditTrailEntryRepository = auditTrailEntryRepository;
        }

        public void Execute(CreateAuditTrailEntryCommand command)
        {
            var auditTrailEntry = AuditTrailEntry.Create(command.AuditTrailEntryId, command.SubjectId, command.UserId, command.Summary, command.SubjectName, command.UserName);
            auditTrailEntryRepository.ApplyChanges(auditTrailEntry);
        }
    }
}