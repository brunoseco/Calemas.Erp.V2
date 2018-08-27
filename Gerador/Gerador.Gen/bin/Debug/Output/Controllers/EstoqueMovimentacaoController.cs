using Common.API;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using calemaserp.ui.Core.Services;
using calemaserp.ui.Core.Dto;
using calemaserp.ui.Core.Filters;
using calemaserp.ui.Core.Data.Repository;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace calemaserp.ui.Core.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class EstoqueMovimentacaoController : EstoqueMovimentacaoControllerBase
    {
        public EstoqueMovimentacaoController(EstoqueMovimentacaoService service, EstoqueMovimentacaoRepository rep, ILoggerFactory logger)
            : base(service, rep, logger)
        { }
		
    }
}
