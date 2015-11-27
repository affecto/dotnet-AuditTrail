using Affecto.AuditTrail.Domain.Entities;
using Affecto.AuditTrail.Store.EntityFramework.DomainEventHandlers;
using Affecto.AuditTrail.Store.EntityFramework.DomainRepositories;
using Affecto.Patterns.Domain;
using Autofac;

namespace Affecto.AuditTrail.Store.EntityFramework
{
    public class ModuleRegistration : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            builder.RegisterType<DbContext>().As<IDbContext>();
            builder.RegisterType<DbRepository>().As<IDbRepository>();
            builder.RegisterType<AuditTrailEntryDomainRepository>().As<IDomainRepository<AuditTrailEntry>>();

            RegisterEventHandlers(builder);
        }

        private static void RegisterEventHandlers(ContainerBuilder builder)
        {
            builder.RegisterType<AuditTrailEntryCreatedEventHandler>().AsImplementedInterfaces();
        }
    }
}