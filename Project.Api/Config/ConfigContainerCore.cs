using Common.Domain.Interfaces;
using Common.Orm;
using Common.Validation;
using Microsoft.Extensions.DependencyInjection;
using CalemasERP.Core.Services;
using CalemasERP.Core.Data.Context;
using CalemasERP.Core.Data.Repository;

namespace CalemasERP.Core.Api.Config
{
    public static partial class ConfigContainerCore
    {
        public static void Config(IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork<DbContextCore>>();

            services.AddScoped<ValidationContract>();

            services.AddScoped<UnidadeMedidaRepository>();
            services.AddScoped<UnidadeMedidaService>();

            
            RegisterOtherComponents(services);
        }
    }
}
