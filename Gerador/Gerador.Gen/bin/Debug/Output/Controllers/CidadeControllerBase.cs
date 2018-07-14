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
    public class CidadeControllerBase : Controller
    {
        protected readonly CidadeService _service;
        protected readonly CidadeRepository _rep;
        protected readonly ILogger _logger;

        public CidadeControllerBase(CidadeService service, CidadeRepository rep, ILoggerFactory logger)
        {
            this._service = service;
            this._rep = rep;
            this._logger = logger.CreateLogger<CidadeController>();
        }

        #region Principals

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]CidadeFilter filters)
        {
            var result = new HttpResult<CidadeDto>(this._logger, this._service);
            try
            {
                var searchResult = await this._service.GetByFiltersPaging(filters);
                return result.ReturnCustomResponse(searchResult);
            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex, "Cidade", filters);
            }
        }

		[HttpGet("{id}")]
		public async Task<IActionResult> Get(int id, [FromQuery]CidadeFilter filters)
		{
			var result = new HttpResult<CidadeDto>(this._logger, this._service);
			try
			{
				filters.CidadeId = id;
				var returnModel = await this._service.GetById(filters);
				return result.ReturnCustomResponse(returnModel);
			}
			catch (Exception ex)
			{
				return result.ReturnCustomException(ex, "Cidade", id);
			}
		}

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CidadeDtoSave dto)
        {
            var result = new HttpResult<CidadeDto>(this._logger, this._service);
            try
            {
                var returnModel = await this._service.Save(dto);
                return result.ReturnCustomResponse(returnModel);

            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex, "Cidade", dto);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody]CidadeDtoSave dto)
        {
            var result = new HttpResult<CidadeDto>(this._logger, this._service);
            try
            {
                var returnModel = await this._service.SavePartial(dto);
                return result.ReturnCustomResponse(returnModel);

            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex, "Cidade", dto);
            }
        }
		
        [HttpDelete]
        public async Task<IActionResult> Delete(CidadeDto dto)
        {
            var result = new HttpResult<CidadeDto>(this._logger, this._service);
            try
            {
                await this._service.Remove(dto);
                return result.ReturnCustomResponse(dto);
            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex, "Cidade", dto);
            }
        }

        #endregion

		#region Others

        [HttpGet("DataItems")]
        public async Task<IActionResult> DataItems([FromQuery]CidadeFilter filters)
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
