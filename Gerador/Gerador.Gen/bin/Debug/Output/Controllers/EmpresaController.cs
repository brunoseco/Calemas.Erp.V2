using Common.API;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using superacrm.ui.Core.Services;
using superacrm.ui.Core.Dto;
using superacrm.ui.Core.Filters;
using superacrm.ui.Core.Data.Repository;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace superacrm.ui.Core.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class EmpresaController : EmpresaControllerBase
    {
        public EmpresaController(EmpresaService service, EmpresaRepository rep, ILoggerFactory logger)
            : base(service, rep, logger)
        { }
		
    }
}
