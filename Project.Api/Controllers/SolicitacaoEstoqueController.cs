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
    public class SolicitacaoEstoqueController : SolicitacaoEstoqueControllerBase
    {
        public SolicitacaoEstoqueController(SolicitacaoEstoqueService service, SolicitacaoEstoqueRepository rep, ILoggerFactory logger)
            : base(service, rep, logger)
        { }
		
    }
}
