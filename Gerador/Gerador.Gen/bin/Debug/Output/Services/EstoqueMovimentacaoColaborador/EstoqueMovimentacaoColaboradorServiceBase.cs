using Common.Domain.Base;
using Common.Domain.Interfaces;
using Common.Domain.Model;
using Common.Validation;
using calemaserp.ui.Core.Dto;
using calemaserp.ui.Core.Filters;
using calemaserp.ui.Core.Data.Model;
using calemaserp.ui.Core.Data.Repository;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System;

namespace calemaserp.ui.Core.Services
{
    public class EstoqueMovimentacaoColaboradorServiceBase : ServiceBase<EstoqueMovimentacaoColaborador, EstoqueMovimentacaoColaboradorDto, EstoqueMovimentacaoColaboradorFilter>, IService
    {
        protected EstoqueMovimentacaoColaboradorRepository _rep;
        protected CurrentUser _user;

        public EstoqueMovimentacaoColaboradorServiceBase(EstoqueMovimentacaoColaboradorRepository rep, ValidationContract validation, CurrentUser user, IUnitOfWork uow)
            : base(rep, uow, validation)
        {
            this._rep = rep;
            this._user = user;
        }

		public virtual async Task<IEnumerable<dynamic>> GetDataItems(EstoqueMovimentacaoColaboradorFilter filters)
        {
            return await Task.Run(() =>
            {
                return this._rep.GetDataItems(filters);
            });
        }

        public virtual async Task<SearchResult<EstoqueMovimentacaoColaboradorDto>> GetByFiltersPaging(EstoqueMovimentacaoColaboradorFilter filters)
        {
            var queryBase = this._rep.GetByFilters(filters);
            var paginated = await this._rep.PagingAndOrdering(filters, queryBase);
            return await this.SearchResult(filters, paginated, queryBase);
        }

        public virtual async Task<EstoqueMovimentacaoColaboradorDto> GetById(EstoqueMovimentacaoColaboradorFilter filters)
        {
            var alvo = this._rep.GetById(filters);
            var result = await MapperDomainToDto<EstoqueMovimentacaoColaboradorDtoDetail>(alvo);
            return result;
        }
		
        public virtual EstoqueMovimentacaoColaborador GetByModel(EstoqueMovimentacaoColaborador model)
        {
            var alvo = this._rep.GetByModel(model);
            return alvo;
        }

        public override EstoqueMovimentacaoColaborador Save(EstoqueMovimentacaoColaborador model)
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



        public virtual void MakeValidations(EstoqueMovimentacaoColaborador model, EstoqueMovimentacaoColaborador modelOld)
        {
            if (model.IsNull())
                this._validation.AddNotification("ITEM_ENVIADO", "Item enviado não contém propriedades");
        }

    }
}
