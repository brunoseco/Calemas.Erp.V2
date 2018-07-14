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

namespace CalemasERP.Core.Api.Controllers
{
    public class UnidadeMedidaControllerBase : Controller
    {
        protected readonly UnidadeMedidaService _service;
        protected readonly UnidadeMedidaRepository _rep;
        protected readonly ILogger _logger;

        public UnidadeMedidaControllerBase(UnidadeMedidaService service, UnidadeMedidaRepository rep, ILoggerFactory logger)
        {
            this._service = service;
            this._rep = rep;
            this._logger = logger.CreateLogger<UnidadeMedidaController>();
        }

        #region Principals

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]UnidadeMedidaFilter filters)
        {
            var result = new HttpResult<UnidadeMedidaDto>(this._logger, this._service);
            try
            {
                var searchResult = await this._service.GetByFiltersPaging(filters);
                return result.ReturnCustomResponse(searchResult);
            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex, "UnidadeMedida", filters);
            }
        }

		[HttpGet("{id}")]
		public async Task<IActionResult> Get(int id, [FromQuery]UnidadeMedidaFilter filters)
		{
			var result = new HttpResult<UnidadeMedidaDto>(this._logger, this._service);
			try
			{
				filters.UnidadeMedidaId = id;
				var returnModel = await this._service.GetById(filters);
				return result.ReturnCustomResponse(returnModel);
			}
			catch (Exception ex)
			{
				return result.ReturnCustomException(ex, "UnidadeMedida", id);
			}
		}

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]UnidadeMedidaDtoSave dto)
        {
            var result = new HttpResult<UnidadeMedidaDto>(this._logger, this._service);
            try
            {
                var returnModel = await this._service.Save(dto);
                return result.ReturnCustomResponse(returnModel);

            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex, "UnidadeMedida", dto);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody]UnidadeMedidaDtoSave dto)
        {
            var result = new HttpResult<UnidadeMedidaDto>(this._logger, this._service);
            try
            {
                var returnModel = await this._service.SavePartial(dto);
                return result.ReturnCustomResponse(returnModel);

            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex, "UnidadeMedida", dto);
            }
        }
		
        [HttpDelete]
        public async Task<IActionResult> Delete(UnidadeMedidaDto dto)
        {
            var result = new HttpResult<UnidadeMedidaDto>(this._logger, this._service);
            try
            {
                await this._service.Remove(dto);
                return result.ReturnCustomResponse(dto);
            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex, "UnidadeMedida", dto);
            }
        }

        #endregion

		#region Others

        [HttpGet("DataItems")]
        public async Task<IActionResult> DataItems([FromQuery]UnidadeMedidaFilter filters)
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
