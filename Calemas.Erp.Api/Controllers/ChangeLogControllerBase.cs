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

namespace Calemas.Erp.Core.Api.Controllers
{
    public class ChangeLogControllerBase : Controller
    {
        protected readonly ChangeLogService _service;
        protected readonly ChangeLogRepository _rep;
        protected readonly ILogger _logger;

        public ChangeLogControllerBase(ChangeLogService service, ChangeLogRepository rep, ILoggerFactory logger)
        {
            this._service = service;
            this._rep = rep;
            this._logger = logger.CreateLogger<ChangeLogController>();
        }

        #region Principals

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]ChangeLogFilter filters)
        {
            var result = new HttpResult<ChangeLogDto>(this._logger, this._service);
            try
            {
                var searchResult = await this._service.GetByFiltersPaging(filters);
                return result.ReturnCustomResponse(searchResult);
            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex, "ChangeLog", filters);
            }
        }

		[HttpGet("{id}")]
		public async Task<IActionResult> Get(int id, [FromQuery]ChangeLogFilter filters)
		{
			var result = new HttpResult<ChangeLogDto>(this._logger, this._service);
			try
			{
				filters.ChangeLogId = id;
				var returnModel = await this._service.GetById(filters);
				return result.ReturnCustomResponse(returnModel);
			}
			catch (Exception ex)
			{
				return result.ReturnCustomException(ex, "ChangeLog", id);
			}
		}

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]ChangeLogDto dto)
        {
            var result = new HttpResult<ChangeLogDto>(this._logger, this._service);
            try
            {
                var returnModel = await this._service.Save(dto);
                return result.ReturnCustomResponse(returnModel);

            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex, "ChangeLog", dto);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody]ChangeLogDto dto)
        {
            var result = new HttpResult<ChangeLogDto>(this._logger, this._service);
            try
            {
                var returnModel = await this._service.SavePartial(dto);
                return result.ReturnCustomResponse(returnModel);

            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex, "ChangeLog", dto);
            }
        }
		
        [HttpDelete]
        public async Task<IActionResult> Delete(ChangeLogDto dto)
        {
            var result = new HttpResult<ChangeLogDto>(this._logger, this._service);
            try
            {
                await this._service.Remove(dto);
                return result.ReturnCustomResponse(dto);
            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex, "ChangeLog", dto);
            }
        }

        #endregion

		#region Others

        [HttpGet("DataItems")]
        public async Task<IActionResult> DataItems([FromQuery]ChangeLogFilter filters)
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
