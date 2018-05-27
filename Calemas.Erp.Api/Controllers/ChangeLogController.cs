using Common.API;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using Calemas.Erp.Core.Services;
using Calemas.Erp.Core.Dto;
using Calemas.Erp.Core.Filters;
using Calemas.Erp.Core.Data.Repository;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace Calemas.Erp.Core.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class ChangeLogController : ChangeLogControllerBase
    {
        public ChangeLogController(ChangeLogService service, ChangeLogRepository rep, ILoggerFactory logger)
            : base(service, rep, logger)
        { }
		
    }
}
