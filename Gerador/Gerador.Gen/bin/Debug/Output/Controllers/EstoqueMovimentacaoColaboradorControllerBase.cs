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
    public class EstoqueMovimentacaoColaboradorControllerBase : Controller
    {
        protected readonly EstoqueMovimentacaoColaboradorService _service;
        protected readonly EstoqueMovimentacaoColaboradorRepository _rep;
        protected readonly ILogger _logger;

        public EstoqueMovimentacaoColaboradorControllerBase(EstoqueMovimentacaoColaboradorService service, EstoqueMovimentacaoColaboradorRepository rep, ILoggerFactory logger)
        {
            this._service = service;
            this._rep = rep;
            this._logger = logger.CreateLogger<EstoqueMovimentacaoColaboradorController>();
        }

        #region Principals

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]EstoqueMovimentacaoColaboradorFilter filters)
        {
            var result = new HttpResult<EstoqueMovimentacaoColaboradorDto>(this._logger, this._service);
            try
            {
                var searchResult = await this._service.GetByFiltersPaging(filters);
                return result.ReturnCustomResponse(searchResult);
            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex, "EstoqueMovimentacaoColaborador", filters);
            }
        }

		[HttpGet("{id}")]
		public async Task<IActionResult> Get(int id, [FromQuery]EstoqueMovimentacaoColaboradorFilter filters)
		{
			var result = new HttpResult<EstoqueMovimentacaoColaboradorDto>(this._logger, this._service);
			try
			{
				filters.EstoqueMovimentacaoColaboradorId = id;
				var returnModel = await this._service.GetById(filters);
				return result.ReturnCustomResponse(returnModel);
			}
			catch (Exception ex)
			{
				return result.ReturnCustomException(ex, "EstoqueMovimentacaoColaborador", id);
			}
		}

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]EstoqueMovimentacaoColaboradorDtoSave dto)
        {
            var result = new HttpResult<EstoqueMovimentacaoColaboradorDto>(this._logger, this._service);
            try
            {
                var returnModel = await this._service.Save(dto);
                return result.ReturnCustomResponse(returnModel);

            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex, "EstoqueMovimentacaoColaborador", dto);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody]EstoqueMovimentacaoColaboradorDtoSave dto)
        {
            var result = new HttpResult<EstoqueMovimentacaoColaboradorDto>(this._logger, this._service);
            try
            {
                var returnModel = await this._service.SavePartial(dto);
                return result.ReturnCustomResponse(returnModel);

            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex, "EstoqueMovimentacaoColaborador", dto);
            }
        }
		
        [HttpDelete]
        public async Task<IActionResult> Delete(EstoqueMovimentacaoColaboradorDto dto)
        {
            var result = new HttpResult<EstoqueMovimentacaoColaboradorDto>(this._logger, this._service);
            try
            {
                await this._service.Remove(dto);
                return result.ReturnCustomResponse(dto);
            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex, "EstoqueMovimentacaoColaborador", dto);
            }
        }

        #endregion

		#region Others

        [HttpGet("DataItems")]
        public async Task<IActionResult> DataItems([FromQuery]EstoqueMovimentacaoColaboradorFilter filters)
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
