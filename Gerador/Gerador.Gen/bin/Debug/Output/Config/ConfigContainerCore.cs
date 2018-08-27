using Common.Domain.Interfaces;
using Common.Orm;
using Common.Validation;
using Microsoft.Extensions.DependencyInjection;
using calemaserp.ui.Core.Services;
using calemaserp.ui.Core.Data.Context;
using calemaserp.ui.Core.Data.Repository;

namespace calemaserp.ui.Core.Api.Config
{
    public static partial class ConfigContainerCore
    {
        public static void Config(IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork<DbContextCore>>();

            services.AddScoped<ValidationContract>();

            services.AddScoped<UnidadeMedidaRepository>();
            services.AddScoped<UnidadeMedidaService>();
            services.AddScoped<EstoqueMovimentacaoColaboradorRepository>();
            services.AddScoped<EstoqueMovimentacaoColaboradorService>();
            services.AddScoped<CategoriaEstoqueRepository>();
            services.AddScoped<CategoriaEstoqueService>();
            services.AddScoped<SolicitacaoEstoqueRepository>();
            services.AddScoped<SolicitacaoEstoqueService>();
            services.AddScoped<EstoqueMovimentacaoRepository>();
            services.AddScoped<EstoqueMovimentacaoService>();
            services.AddScoped<MotivoEstoqueMovimentacaoRepository>();
            services.AddScoped<MotivoEstoqueMovimentacaoService>();
            services.AddScoped<EstoqueRepository>();
            services.AddScoped<EstoqueService>();

            
            RegisterOtherComponents(services);
        }
    }
}
