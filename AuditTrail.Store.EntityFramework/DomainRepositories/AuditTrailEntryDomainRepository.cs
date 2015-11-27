using System;
using Affecto.AuditTrail.Domain.Entities;
using Affecto.Patterns.Domain;
using Affecto.Patterns.Domain.UnitOfWork;

namespace Affecto.AuditTrail.Store.EntityFramework.DomainRepositories
{
    internal class AuditTrailEntryDomainRepository : UnitOfWorkDomainRepository<IDbContext, AuditTrailEntry>
    {
        public AuditTrailEntryDomainRepository(IDomainEventHandlerResolver eventHandlerResolver,
            IUnitOfWorkDomainEventHandlerResolver unitOfWorkEventHandlerResolver, IDbContext unitOfWork)
            : base(eventHandlerResolver, unitOfWorkEventHandlerResolver, unitOfWork)
        {
        }

        public override AuditTrailEntry Find(Guid id)
        {
            //TODO
            return null;
        }
    }
}