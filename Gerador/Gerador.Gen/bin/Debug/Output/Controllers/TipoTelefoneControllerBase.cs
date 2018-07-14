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

namespace superacrm.ui.Core.Api.Controllers
{
    public class TipoTelefoneControllerBase : Controller
    {
        protected readonly TipoTelefoneService _service;
        protected readonly TipoTelefoneRepository _rep;
        protected readonly ILogger _logger;

        public TipoTelefoneControllerBase(TipoTelefoneService service, TipoTelefoneRepository rep, ILoggerFactory logger)
        {
            this._service = service;
            this._rep = rep;
            this._logger = logger.CreateLogger<TipoTelefoneController>();
        }

        #region Principals

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]TipoTelefoneFilter filters)
        {
            var result = new HttpResult<TipoTelefoneDto>(this._logger, this._service);
            try
            {
                var searchResult = await this._service.GetByFiltersPaging(filters);
                return result.ReturnCustomResponse(searchResult);
            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex, "TipoTelefone", filters);
            }
        }

		[HttpGet("{id}")]
		public async Task<IActionResult> Get(int id, [FromQuery]TipoTelefoneFilter filters)
		{
			var result = new HttpResult<TipoTelefoneDto>(this._logger, this._service);
			try
			{
				filters.TipoTelefoneId = id;
				var returnModel = await this._service.GetById(filters);
				return result.ReturnCustomResponse(returnModel);
			}
			catch (Exception ex)
			{
				return result.ReturnCustomException(ex, "TipoTelefone", id);
			}
		}

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]TipoTelefoneDtoSave dto)
        {
            var result = new HttpResult<TipoTelefoneDto>(this._logger, this._service);
            try
            {
                var returnModel = await this._service.Save(dto);
                return result.ReturnCustomResponse(returnModel);

            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex, "TipoTelefone", dto);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody]TipoTelefoneDtoSave dto)
        {
            var result = new HttpResult<TipoTelefoneDto>(this._logger, this._service);
            try
            {
                var returnModel = await this._service.SavePartial(dto);
                return result.ReturnCustomResponse(returnModel);

            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex, "TipoTelefone", dto);
            }
        }
		
        [HttpDelete]
        public async Task<IActionResult> Delete(TipoTelefoneDto dto)
        {
            var result = new HttpResult<TipoTelefoneDto>(this._logger, this._service);
            try
            {
                await this._service.Remove(dto);
                return result.ReturnCustomResponse(dto);
            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex, "TipoTelefone", dto);
            }
        }

        #endregion

		#region Others

        [HttpGet("DataItems")]
        public async Task<IActionResult> DataItems([FromQuery]TipoTelefoneFilter filters)
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
