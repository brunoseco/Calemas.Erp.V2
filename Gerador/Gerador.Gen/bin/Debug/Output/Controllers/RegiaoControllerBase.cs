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
    public class RegiaoControllerBase : Controller
    {
        protected readonly RegiaoService _service;
        protected readonly RegiaoRepository _rep;
        protected readonly ILogger _logger;

        public RegiaoControllerBase(RegiaoService service, RegiaoRepository rep, ILoggerFactory logger)
        {
            this._service = service;
            this._rep = rep;
            this._logger = logger.CreateLogger<RegiaoController>();
        }

        #region Principals

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]RegiaoFilter filters)
        {
            var result = new HttpResult<RegiaoDto>(this._logger, this._service);
            try
            {
                var searchResult = await this._service.GetByFiltersPaging(filters);
                return result.ReturnCustomResponse(searchResult);
            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex, "Regiao", filters);
            }
        }

		[HttpGet("{id}")]
		public async Task<IActionResult> Get(int id, [FromQuery]RegiaoFilter filters)
		{
			var result = new HttpResult<RegiaoDto>(this._logger, this._service);
			try
			{
				filters.RegiaoId = id;
				var returnModel = await this._service.GetById(filters);
				return result.ReturnCustomResponse(returnModel);
			}
			catch (Exception ex)
			{
				return result.ReturnCustomException(ex, "Regiao", id);
			}
		}

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]RegiaoDtoSave dto)
        {
            var result = new HttpResult<RegiaoDto>(this._logger, this._service);
            try
            {
                var returnModel = await this._service.Save(dto);
                return result.ReturnCustomResponse(returnModel);

            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex, "Regiao", dto);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody]RegiaoDtoSave dto)
        {
            var result = new HttpResult<RegiaoDto>(this._logger, this._service);
            try
            {
                var returnModel = await this._service.SavePartial(dto);
                return result.ReturnCustomResponse(returnModel);

            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex, "Regiao", dto);
            }
        }
		
        [HttpDelete]
        public async Task<IActionResult> Delete(RegiaoDto dto)
        {
            var result = new HttpResult<RegiaoDto>(this._logger, this._service);
            try
            {
                await this._service.Remove(dto);
                return result.ReturnCustomResponse(dto);
            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex, "Regiao", dto);
            }
        }

        #endregion

		#region Others

        [HttpGet("DataItems")]
        public async Task<IActionResult> DataItems([FromQuery]RegiaoFilter filters)
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
