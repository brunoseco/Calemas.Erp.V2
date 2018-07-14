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
    public class VisibilidadeControllerBase : Controller
    {
        protected readonly VisibilidadeService _service;
        protected readonly VisibilidadeRepository _rep;
        protected readonly ILogger _logger;

        public VisibilidadeControllerBase(VisibilidadeService service, VisibilidadeRepository rep, ILoggerFactory logger)
        {
            this._service = service;
            this._rep = rep;
            this._logger = logger.CreateLogger<VisibilidadeController>();
        }

        #region Principals

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]VisibilidadeFilter filters)
        {
            var result = new HttpResult<VisibilidadeDto>(this._logger, this._service);
            try
            {
                var searchResult = await this._service.GetByFiltersPaging(filters);
                return result.ReturnCustomResponse(searchResult);
            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex, "Visibilidade", filters);
            }
        }

		[HttpGet("{id}")]
		public async Task<IActionResult> Get(int id, [FromQuery]VisibilidadeFilter filters)
		{
			var result = new HttpResult<VisibilidadeDto>(this._logger, this._service);
			try
			{
				filters.VisibilidadeId = id;
				var returnModel = await this._service.GetById(filters);
				return result.ReturnCustomResponse(returnModel);
			}
			catch (Exception ex)
			{
				return result.ReturnCustomException(ex, "Visibilidade", id);
			}
		}

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]VisibilidadeDtoSave dto)
        {
            var result = new HttpResult<VisibilidadeDto>(this._logger, this._service);
            try
            {
                var returnModel = await this._service.Save(dto);
                return result.ReturnCustomResponse(returnModel);

            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex, "Visibilidade", dto);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody]VisibilidadeDtoSave dto)
        {
            var result = new HttpResult<VisibilidadeDto>(this._logger, this._service);
            try
            {
                var returnModel = await this._service.SavePartial(dto);
                return result.ReturnCustomResponse(returnModel);

            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex, "Visibilidade", dto);
            }
        }
		
        [HttpDelete]
        public async Task<IActionResult> Delete(VisibilidadeDto dto)
        {
            var result = new HttpResult<VisibilidadeDto>(this._logger, this._service);
            try
            {
                await this._service.Remove(dto);
                return result.ReturnCustomResponse(dto);
            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex, "Visibilidade", dto);
            }
        }

        #endregion

		#region Others

        [HttpGet("DataItems")]
        public async Task<IActionResult> DataItems([FromQuery]VisibilidadeFilter filters)
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
