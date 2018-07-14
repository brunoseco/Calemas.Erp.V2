using System.Collections.Generic;
using System.Globalization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Cors.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using CalemasERP.Core.Api.Config;
using CalemasERP.Core.Data.Context;
using CalemasERP.Core.Services.Config;
using Common.API;
using Common.API.Extensions;
using Common.Domain.Base;

namespace Project.Api
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; }
        private readonly IHostingEnvironment _env;

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();
            _env = env;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddMvc()
                .AddJsonOptions(options =>
                {
                    options.SerializerSettings.ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver();
                    options.SerializerSettings.Culture = CultureInfo.CurrentCulture;
                });

            services.AddDbContext<DbContextCore>(options => options.UseSqlServer(Configuration.GetSection("EFCoreConnStrings:Core").Value));

            services.AddSingleton<IConfiguration>(Configuration);
            services.AddSingleton(new EnviromentInfo
            {
                RootPath = this._env.ContentRootPath
            });

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAnyOrigin",
                    builder => builder
                    .AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod());
            });

            services.Configure<MvcOptions>(options =>
            {
                options.Filters.Add(new CorsAuthorizationFilterFactory("AllowAnyOrigin"));
            });

            services.Configure<ConfigEmailBase>(Configuration.GetSection("ConfigEmail"));
            services.Configure<ConfigConnectionBase>(Configuration.GetSection("EFCoreConnStrings"));

            services
                .AddAuthentication("Bearer")
                .AddIdentityServerAuthentication(options =>
                {
                    options.Authority = Configuration.GetSection("ConfigSettings:AuthorityEndPoint").Value;
                    options.RequireHttpsMetadata = false;
                    options.ApiName = "calemaserp";
                });


            services
                .AddMvc(options => { options.ModelBinderProviders.Insert(0, new DateTimePtBrModelBinderProvider()); })
                .AddJsonOptions(options =>
                {
                    options.SerializerSettings.Converters.Add(new DateTimePtBrConverter());
                });

            services.Configure<MvcOptions>(options =>
            {
                options.Filters.Add(new CorsAuthorizationFilterFactory("AllowAnyOrigin"));
            });

            ConfigContainerCore.Config(services);

        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(LogLevel.Debug);

            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
            loggerFactory.AddFile("Logs/api-log-{Date}.log");

            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture(new CultureInfo("pt-BR")),
                SupportedCultures = new List<CultureInfo>
                {
                    new CultureInfo("pt-BR")
                },
                SupportedUICultures = new List<CultureInfo>
                {
                    new CultureInfo("pt")
                }
            });

            app.UseAuthentication();
            app.AddTokenMiddleware();
            app.UseDeveloperExceptionPage();
            
            app.UseCors("AllowAnyOrigin");

            app.UseMvc();

            AutoMapperConfigCore.RegisterMappings();


        }
    }
}
