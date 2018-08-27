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
    public class MotivoEstoqueMovimentacaoServiceBase : ServiceBase<MotivoEstoqueMovimentacao, MotivoEstoqueMovimentacaoDto, MotivoEstoqueMovimentacaoFilter>, IService
    {
        protected MotivoEstoqueMovimentacaoRepository _rep;
        protected CurrentUser _user;

        public MotivoEstoqueMovimentacaoServiceBase(MotivoEstoqueMovimentacaoRepository rep, ValidationContract validation, CurrentUser user, IUnitOfWork uow)
            : base(rep, uow, validation)
        {
            this._rep = rep;
            this._user = user;
        }

		public virtual async Task<IEnumerable<dynamic>> GetDataItems(MotivoEstoqueMovimentacaoFilter filters)
        {
            return await Task.Run(() =>
            {
                return this._rep.GetDataItems(filters);
            });
        }

        public virtual async Task<SearchResult<MotivoEstoqueMovimentacaoDto>> GetByFiltersPaging(MotivoEstoqueMovimentacaoFilter filters)
        {
            var queryBase = this._rep.GetByFilters(filters);
            var paginated = await this._rep.PagingAndOrdering(filters, queryBase);
            return await this.SearchResult(filters, paginated, queryBase);
        }

        public virtual async Task<MotivoEstoqueMovimentacaoDto> GetById(MotivoEstoqueMovimentacaoFilter filters)
        {
            var alvo = this._rep.GetById(filters);
            var result = await MapperDomainToDto<MotivoEstoqueMovimentacaoDtoDetail>(alvo);
            return result;
        }
		
        public virtual MotivoEstoqueMovimentacao GetByModel(MotivoEstoqueMovimentacao model)
        {
            var alvo = this._rep.GetByModel(model);
            return alvo;
        }

        public override MotivoEstoqueMovimentacao Save(MotivoEstoqueMovimentacao model)
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



        public virtual void MakeValidations(MotivoEstoqueMovimentacao model, MotivoEstoqueMovimentacao modelOld)
        {
            if (model.IsNull())
                this._validation.AddNotification("ITEM_ENVIADO", "Item enviado não contém propriedades");
        }

    }
}
