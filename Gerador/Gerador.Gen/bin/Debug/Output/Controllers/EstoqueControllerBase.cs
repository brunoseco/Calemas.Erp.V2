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

namespace calemaserp.ui.Core.Api.Controllers
{
    public class EstoqueControllerBase : Controller
    {
        protected readonly EstoqueService _service;
        protected readonly EstoqueRepository _rep;
        protected readonly ILogger _logger;

        public EstoqueControllerBase(EstoqueService service, EstoqueRepository rep, ILoggerFactory logger)
        {
            this._service = service;
            this._rep = rep;
            this._logger = logger.CreateLogger<EstoqueController>();
        }

        #region Principals

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]EstoqueFilter filters)
        {
            var result = new HttpResult<EstoqueDto>(this._logger, this._service);
            try
            {
                var searchResult = await this._service.GetByFiltersPaging(filters);
                return result.ReturnCustomResponse(searchResult);
            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex, "Estoque", filters);
            }
        }

		[HttpGet("{id}")]
		public async Task<IActionResult> Get(int id, [FromQuery]EstoqueFilter filters)
		{
			var result = new HttpResult<EstoqueDto>(this._logger, this._service);
			try
			{
				filters.EstoqueId = id;
				var returnModel = await this._service.GetById(filters);
				return result.ReturnCustomResponse(returnModel);
			}
			catch (Exception ex)
			{
				return result.ReturnCustomException(ex, "Estoque", id);
			}
		}

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]EstoqueDtoSave dto)
        {
            var result = new HttpResult<EstoqueDto>(this._logger, this._service);
            try
            {
                var returnModel = await this._service.Save(dto);
                return result.ReturnCustomResponse(returnModel);

            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex, "Estoque", dto);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody]EstoqueDtoSave dto)
        {
            var result = new HttpResult<EstoqueDto>(this._logger, this._service);
            try
            {
                var returnModel = await this._service.SavePartial(dto);
                return result.ReturnCustomResponse(returnModel);

            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex, "Estoque", dto);
            }
        }
		
        [HttpDelete]
        public async Task<IActionResult> Delete(EstoqueDto dto)
        {
            var result = new HttpResult<EstoqueDto>(this._logger, this._service);
            try
            {
                await this._service.Remove(dto);
                return result.ReturnCustomResponse(dto);
            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex, "Estoque", dto);
            }
        }

        #endregion

		#region Others

        [HttpGet("DataItems")]
        public async Task<IActionResult> DataItems([FromQuery]EstoqueFilter filters)
        {
            var result = new HttpResult<dynamic>(this._logger, this._service);
            try
            {
                var items = await this._service.GetDataItems(filters);
                return result.ReturnCustomResponse(items);
            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex, "Assinatura", filters);
            }
        }

        #endregion

    }
}
