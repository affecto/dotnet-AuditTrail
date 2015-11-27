using System.Data.Entity;
using Affecto.AuditTrail.Store.Model;
using Affecto.Patterns.Domain.UnitOfWork;

namespace Affecto.AuditTrail.Store.EntityFramework
{
    internal interface IDbContext : IUnitOfWork
    {
        IDbSet<AuditTrailEntry> AuditTrailEntries { get; }
    }
}