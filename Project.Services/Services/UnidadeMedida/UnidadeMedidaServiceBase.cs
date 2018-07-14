using Common.Domain.Base;
using Common.Domain.Interfaces;
using Common.Domain.Model;
using Common.Validation;
using CalemasERP.Core.Dto;
using CalemasERP.Core.Filters;
using CalemasERP.Core.Data.Model;
using CalemasERP.Core.Data.Repository;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System;

namespace CalemasERP.Core.Services
{
    public class UnidadeMedidaServiceBase : ServiceBase<UnidadeMedida, UnidadeMedidaDto, UnidadeMedidaFilter>, IService
    {
        protected UnidadeMedidaRepository _rep;
        protected CurrentUser _user;

        public UnidadeMedidaServiceBase(UnidadeMedidaRepository rep, ValidationContract validation, CurrentUser user, IUnitOfWork uow)
            : base(rep, uow, validation)
        {
            this._rep = rep;
            this._user = user;
        }

		public virtual async Task<IEnumerable<dynamic>> GetDataItems(UnidadeMedidaFilter filters)
        {
            return await Task.Run(() =>
            {
                return this._rep.GetDataItems(filters);
            });
        }

        public virtual async Task<SearchResult<UnidadeMedidaDto>> GetByFiltersPaging(UnidadeMedidaFilter filters)
        {
            var queryBase = this._rep.GetByFilters(filters);
            var paginated = await this._rep.PagingAndOrdering(filters, queryBase);
            return await this.SearchResult(filters, paginated, queryBase);
        }

        public virtual async Task<UnidadeMedidaDto> GetById(UnidadeMedidaFilter filters)
        {
            var alvo = this._rep.GetById(filters);
            var result = await MapperDomainToDto<UnidadeMedidaDtoDetail>(alvo);
            return result;
        }
		
        public virtual UnidadeMedida GetByModel(UnidadeMedida model)
        {
            var alvo = this._rep.GetByModel(model);
            return alvo;
        }

        public override UnidadeMedida Save(UnidadeMedida model)
        {
            var alvo = this.GetByModel(model);

            

            this.MakeValidations(model, alvo);

            if (!this.IsValid())
                return model;

            if (alvo.IsNull())
                alvo = this._rep.Add(model);
            else
                alvo = this._rep.Update(model);

            return alvo;
        }



        public virtual void MakeValidations(UnidadeMedida model, UnidadeMedida modelOld)
        {
            if (model.IsNull())
                this._validation.AddNotification("ITEM_ENVIADO", "Item enviado não contém propriedades");
        }

    }
}
