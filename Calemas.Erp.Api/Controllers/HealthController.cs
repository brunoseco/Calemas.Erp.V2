using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Calemas.Erp.Api.Controllers
{
    [Route("api/Health")]
    public class HealthController : Controller
    {
        [HttpGet]
        public string Get()
        {
            return string.Format("is live at now {0}", DateTime.Now.ToTimeZone());
        }
    }
}