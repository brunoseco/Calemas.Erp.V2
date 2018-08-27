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
    public class CategoriaEstoqueControllerBase : Controller
    {
        protected readonly CategoriaEstoqueService _service;
        protected readonly CategoriaEstoqueRepository _rep;
        protected readonly ILogger _logger;

        public CategoriaEstoqueControllerBase(CategoriaEstoqueService service, CategoriaEstoqueRepository rep, ILoggerFactory logger)
        {
            this._service = service;
            this._rep = rep;
            this._logger = logger.CreateLogger<CategoriaEstoqueController>();
        }

        #region Principals

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]CategoriaEstoqueFilter filters)
        {
            var result = new HttpResult<CategoriaEstoqueDto>(this._logger, this._service);
            try
            {
                var searchResult = await this._service.GetByFiltersPaging(filters);
                return result.ReturnCustomResponse(searchResult);
            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex, "CategoriaEstoque", filters);
            }
        }

		[HttpGet("{id}")]
		public async Task<IActionResult> Get(int id, [FromQuery]CategoriaEstoqueFilter filters)
		{
			var result = new HttpResult<CategoriaEstoqueDto>(this._logger, this._service);
			try
			{
				filters.CategoriaEstoqueId = id;
				var returnModel = await this._service.GetById(filters);
				return result.ReturnCustomResponse(returnModel);
			}
			catch (Exception ex)
			{
				return result.ReturnCustomException(ex, "CategoriaEstoque", id);
			}
		}

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CategoriaEstoqueDtoSave dto)
        {
            var result = new HttpResult<CategoriaEstoqueDto>(this._logger, this._service);
            try
            {
                var returnModel = await this._service.Save(dto);
                return result.ReturnCustomResponse(returnModel);

            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex, "CategoriaEstoque", dto);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody]CategoriaEstoqueDtoSave dto)
        {
            var result = new HttpResult<CategoriaEstoqueDto>(this._logger, this._service);
            try
            {
                var returnModel = await this._service.SavePartial(dto);
                return result.ReturnCustomResponse(returnModel);

            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex, "CategoriaEstoque", dto);
            }
        }
		
        [HttpDelete]
        public async Task<IActionResult> Delete(CategoriaEstoqueDto dto)
        {
            var result = new HttpResult<CategoriaEstoqueDto>(this._logger, this._service);
            try
            {
                await this._service.Remove(dto);
                return result.ReturnCustomResponse(dto);
            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex, "CategoriaEstoque", dto);
            }
        }

        #endregion

		#region Others

        [HttpGet("DataItems")]
        public async Task<IActionResult> DataItems([FromQuery]CategoriaEstoqueFilter filters)
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
