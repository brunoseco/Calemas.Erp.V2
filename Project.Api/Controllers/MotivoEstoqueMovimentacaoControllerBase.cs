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
    public class MotivoEstoqueMovimentacaoControllerBase : Controller
    {
        protected readonly MotivoEstoqueMovimentacaoService _service;
        protected readonly MotivoEstoqueMovimentacaoRepository _rep;
        protected readonly ILogger _logger;

        public MotivoEstoqueMovimentacaoControllerBase(MotivoEstoqueMovimentacaoService service, MotivoEstoqueMovimentacaoRepository rep, ILoggerFactory logger)
        {
            this._service = service;
            this._rep = rep;
            this._logger = logger.CreateLogger<MotivoEstoqueMovimentacaoController>();
        }

        #region Principals

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]MotivoEstoqueMovimentacaoFilter filters)
        {
            var result = new HttpResult<MotivoEstoqueMovimentacaoDto>(this._logger, this._service);
            try
            {
                var searchResult = await this._service.GetByFiltersPaging(filters);
                return result.ReturnCustomResponse(searchResult);
            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex, "MotivoEstoqueMovimentacao", filters);
            }
        }

		[HttpGet("{id}")]
		public async Task<IActionResult> Get(int id, [FromQuery]MotivoEstoqueMovimentacaoFilter filters)
		{
			var result = new HttpResult<MotivoEstoqueMovimentacaoDto>(this._logger, this._service);
			try
			{
				filters.MotivoEstoqueMovimentacaoId = id;
				var returnModel = await this._service.GetById(filters);
				return result.ReturnCustomResponse(returnModel);
			}
			catch (Exception ex)
			{
				return result.ReturnCustomException(ex, "MotivoEstoqueMovimentacao", id);
			}
		}

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]MotivoEstoqueMovimentacaoDtoSave dto)
        {
            var result = new HttpResult<MotivoEstoqueMovimentacaoDto>(this._logger, this._service);
            try
            {
                var returnModel = await this._service.Save(dto);
                return result.ReturnCustomResponse(returnModel);

            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex, "MotivoEstoqueMovimentacao", dto);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody]MotivoEstoqueMovimentacaoDtoSave dto)
        {
            var result = new HttpResult<MotivoEstoqueMovimentacaoDto>(this._logger, this._service);
            try
            {
                var returnModel = await this._service.SavePartial(dto);
                return result.ReturnCustomResponse(returnModel);

            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex, "MotivoEstoqueMovimentacao", dto);
            }
        }
		
        [HttpDelete]
        public async Task<IActionResult> Delete(MotivoEstoqueMovimentacaoDto dto)
        {
            var result = new HttpResult<MotivoEstoqueMovimentacaoDto>(this._logger, this._service);
            try
            {
                await this._service.Remove(dto);
                return result.ReturnCustomResponse(dto);
            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex, "MotivoEstoqueMovimentacao", dto);
            }
        }

        #endregion

		#region Others

        [HttpGet("DataItems")]
        public async Task<IActionResult> DataItems([FromQuery]MotivoEstoqueMovimentacaoFilter filters)
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
