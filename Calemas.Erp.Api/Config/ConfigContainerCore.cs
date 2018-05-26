using Common.Domain.Interfaces;
using Common.Orm;
using Common.Validation;
using Microsoft.Extensions.DependencyInjection;
using Calemas.Erp.Core.Services;
using Calemas.Erp.Core.Data.Context;
using Calemas.Erp.Core.Data.Repository;

namespace Calemas.Erp.Core.Api.Config
{
    public static partial class ConfigContainerCore
    {
        public static void Config(IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork<DbContextCore>>();

            services.AddScoped<ValidationContract>();
            

            RegisterOtherComponents(services);
        }
    }
}
