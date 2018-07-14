using Common.API;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using CalemasERP.Core.Services;
using CalemasERP.Core.Dto;
using CalemasERP.Core.Filters;
using CalemasERP.Core.Data.Repository;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace CalemasERP.Core.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class UnidadeMedidaController : UnidadeMedidaControllerBase
    {
        public UnidadeMedidaController(UnidadeMedidaService service, UnidadeMedidaRepository rep, ILoggerFactory logger)
            : base(service, rep, logger)
        { }
		
    }
}
