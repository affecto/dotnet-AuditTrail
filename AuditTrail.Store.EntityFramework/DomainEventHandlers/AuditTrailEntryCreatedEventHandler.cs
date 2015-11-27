using System;
using Affecto.AuditTrail.Domain.Events;
using Affecto.AuditTrail.Store.Model;
using Affecto.Patterns.Domain.UnitOfWork;

namespace Affecto.AuditTrail.Store.EntityFramework.DomainEventHandlers
{
    internal class AuditTrailEntryCreatedEventHandler : IUnitOfWorkDomainEventHandler<AuditTrailEntryCreatedEvent, IDbContext>
    {
        public void Execute(AuditTrailEntryCreatedEvent @event, IDbContext unitOfWork)
        {
            if (@event == null)
            {
                throw new ArgumentNullException("event");
            }
            if (unitOfWork == null)
            {
                throw new ArgumentNullException("unitOfWork");
            }

            var auditTrailEntry = new AuditTrailEntry
            {
                Id = @event.EntityId,
                SubjectId =  @event.SubjectId,
                UserId = @event.UserId,
                Summary = @event.Summary,
                Timestamp = @event.Timestamp,
                SubjectName = @event.SubjectName,
                UserName = @event.UserName
            };

            unitOfWork.AuditTrailEntries.Add(auditTrailEntry);
        }
    }
}