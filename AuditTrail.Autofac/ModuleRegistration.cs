using Affecto.AuditTrail.Commanding.CommandHandlers;
using Affecto.AuditTrail.Interfaces;
using Affecto.AuditTrail.Querying;
using Affecto.Patterns.Cqrs.Autofac;
using Affecto.Patterns.Domain.UnitOfWork.Autofac;
using Autofac;

namespace Affecto.AuditTrail.Autofac
{
    public class ModuleRegistration : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterModule<CqrsModule>();
            builder.RegisterModule<UnitOfWorkDomainModule>();
            builder.RegisterModule<Store.EntityFramework.ModuleRegistration>();

            builder.RegisterType<ApplicationServices.AuditTrailService>().As<IAuditTrailService>();
            builder.RegisterType<AuditTrailQueryService>().As<IAuditTrailQueryService>();

            builder.RegisterType<CreateAuditTrailEntryCommandHandler>().AsImplementedInterfaces();
        }
    }
}