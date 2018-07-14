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
    public class PaisControllerBase : Controller
    {
        protected readonly PaisService _service;
        protected readonly PaisRepository _rep;
        protected readonly ILogger _logger;

        public PaisControllerBase(PaisService service, PaisRepository rep, ILoggerFactory logger)
        {
            this._service = service;
            this._rep = rep;
            this._logger = logger.CreateLogger<PaisController>();
        }

        #region Principals

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]PaisFilter filters)
        {
            var result = new HttpResult<PaisDto>(this._logger, this._service);
            try
            {
                var searchResult = await this._service.GetByFiltersPaging(filters);
                return result.ReturnCustomResponse(searchResult);
            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex, "Pais", filters);
            }
        }

		[HttpGet("{id}")]
		public async Task<IActionResult> Get(int id, [FromQuery]PaisFilter filters)
		{
			var result = new HttpResult<PaisDto>(this._logger, this._service);
			try
			{
				filters.PaisId = id;
				var returnModel = await this._service.GetById(filters);
				return result.ReturnCustomResponse(returnModel);
			}
			catch (Exception ex)
			{
				return result.ReturnCustomException(ex, "Pais", id);
			}
		}

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]PaisDtoSave dto)
        {
            var result = new HttpResult<PaisDto>(this._logger, this._service);
            try
            {
                var returnModel = await this._service.Save(dto);
                return result.ReturnCustomResponse(returnModel);

            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex, "Pais", dto);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody]PaisDtoSave dto)
        {
            var result = new HttpResult<PaisDto>(this._logger, this._service);
            try
            {
                var returnModel = await this._service.SavePartial(dto);
                return result.ReturnCustomResponse(returnModel);

            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex, "Pais", dto);
            }
        }
		
        [HttpDelete]
        public async Task<IActionResult> Delete(PaisDto dto)
        {
            var result = new HttpResult<PaisDto>(this._logger, this._service);
            try
            {
                await this._service.Remove(dto);
                return result.ReturnCustomResponse(dto);
            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex, "Pais", dto);
            }
        }

        #endregion

		#region Others

        [HttpGet("DataItems")]
        public async Task<IActionResult> DataItems([FromQuery]PaisFilter filters)
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
