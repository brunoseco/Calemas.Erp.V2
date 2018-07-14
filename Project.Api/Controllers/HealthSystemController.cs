using System;
using System.Linq;
using Common.Domain;
using Common.Domain.Base;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Common.API;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using CalemasERP.Core.Services;
using CalemasERP.Core.Dto;
using CalemasERP.Core.Filters;
using CalemasERP.Core.Data.Repository;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace CalemasERP.Core.Api.Controllers
{
    [Route("api/[controller]")]
    public class HealthSystemController : Controller
    {
        private IOptions<ConfigConnectionBase> _settings;
        private readonly IHostingEnvironment _env;

        public HealthSystemController(IOptions<ConfigConnectionBase> configSettings, IHostingEnvironment env)
        {
            _settings = configSettings;
            _env = env;
        }

        [HttpGet]
        public string Get()
        {
            return string.Format("is live at now {0} - ConnectionString={1} - ASPNETCORE_ENVIRONMENT={2}", DateTime.Now.ToTimeZone(), ExtractCns(), _env.EnvironmentName);
        }

        private string ExtractCns()
        {

            if (this._settings.Value.IsNull())
                return "not load settings";

            var cns = this._settings.Value.Core;

            if (cns.IsNullOrEmpaty())
                return "not load cns";


            return string.Join("-", this._settings.Value.Core.Split(';').Where(_ => !_.Contains("password")));
        }
    }
}