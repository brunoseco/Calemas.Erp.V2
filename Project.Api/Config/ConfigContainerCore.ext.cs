using Common.Cripto;
using Common.Domain.Interfaces;
using Common.Domain.Model;
using Common.Mail;
using Microsoft.Extensions.DependencyInjection;

namespace CalemasERP.Core.Api.Config
{
    public static partial class ConfigContainerCore
    {
        public static void RegisterOtherComponents(IServiceCollection services)
        {

            services.AddScoped<IEmail, Email>();

            services.AddScoped<CurrentUser>();

            services.AddScoped<ICripto, Cripto>();
        }
    }
}
