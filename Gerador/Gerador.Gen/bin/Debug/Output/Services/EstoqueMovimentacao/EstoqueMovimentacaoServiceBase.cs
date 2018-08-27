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
    public class EstoqueMovimentacaoServiceBase : ServiceBase<EstoqueMovimentacao, EstoqueMovimentacaoDto, EstoqueMovimentacaoFilter>, IService
    {
        protected EstoqueMovimentacaoRepository _rep;
        protected CurrentUser _user;

        public EstoqueMovimentacaoServiceBase(EstoqueMovimentacaoRepository rep, ValidationContract validation, CurrentUser user, IUnitOfWork uow)
            : base(rep, uow, validation)
        {
            this._rep = rep;
            this._user = user;
        }

		public virtual async Task<IEnumerable<dynamic>> GetDataItems(EstoqueMovimentacaoFilter filters)
        {
            return await Task.Run(() =>
            {
                return this._rep.GetDataItems(filters);
            });
        }

        public virtual async Task<SearchResult<EstoqueMovimentacaoDto>> GetByFiltersPaging(EstoqueMovimentacaoFilter filters)
        {
            var queryBase = this._rep.GetByFilters(filters);
            var paginated = await this._rep.PagingAndOrdering(filters, queryBase);
            return await this.SearchResult(filters, paginated, queryBase);
        }

        public virtual async Task<EstoqueMovimentacaoDto> GetById(EstoqueMovimentacaoFilter filters)
        {
            var alvo = this._rep.GetById(filters);
            var result = await MapperDomainToDto<EstoqueMovimentacaoDtoDetail>(alvo);
            return result;
        }
		
        public virtual EstoqueMovimentacao GetByModel(EstoqueMovimentacao model)
        {
            var alvo = this._rep.GetByModel(model);
            return alvo;
        }

        public override EstoqueMovimentacao Save(EstoqueMovimentacao model)
        {
            var alvo = this.GetByModel(model);

            this.Audit(model, alvo);

            this.MakeValidations(model, alvo);

            if (!this.IsValid())
                return model;

            if (alvo.IsNull())
                alvo = this._rep.Add(model);
            else
                alvo = this._rep.Update(model);

            return alvo;
        }

        public virtual void Audit(EstoqueMovimentacao model, EstoqueMovimentacao modelOld)
        {
            if (modelOld.IsNull())
            {
                model.UserCreateDate = DateTime.Now;
                model.UserCreateId = this._user.GetUserId();
            }
            else
            {
				model.UserCreateDate = modelOld.UserCreateDate;
                model.UserCreateId = modelOld.UserCreateId;
                model.UserAlterDate = DateTime.Now;
                model.UserAlterId = this._user.GetUserId();
            }
        }

        public virtual void MakeValidations(EstoqueMovimentacao model, EstoqueMovimentacao modelOld)
        {
            if (model.IsNull())
                this._validation.AddNotification("ITEM_ENVIADO", "Item enviado não contém propriedades");
        }

    }
}
