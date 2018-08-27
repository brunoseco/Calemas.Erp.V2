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
    public class EstoqueServiceBase : ServiceBase<Estoque, EstoqueDto, EstoqueFilter>, IService
    {
        protected EstoqueRepository _rep;
        protected CurrentUser _user;

        public EstoqueServiceBase(EstoqueRepository rep, ValidationContract validation, CurrentUser user, IUnitOfWork uow)
            : base(rep, uow, validation)
        {
            this._rep = rep;
            this._user = user;
        }

		public virtual async Task<IEnumerable<dynamic>> GetDataItems(EstoqueFilter filters)
        {
            return await Task.Run(() =>
            {
                return this._rep.GetDataItems(filters);
            });
        }

        public virtual async Task<SearchResult<EstoqueDto>> GetByFiltersPaging(EstoqueFilter filters)
        {
            var queryBase = this._rep.GetByFilters(filters);
            var paginated = await this._rep.PagingAndOrdering(filters, queryBase);
            return await this.SearchResult(filters, paginated, queryBase);
        }

        public virtual async Task<EstoqueDto> GetById(EstoqueFilter filters)
        {
            var alvo = this._rep.GetById(filters);
            var result = await MapperDomainToDto<EstoqueDtoDetail>(alvo);
            return result;
        }
		
        public virtual Estoque GetByModel(Estoque model)
        {
            var alvo = this._rep.GetByModel(model);
            return alvo;
        }

        public override Estoque Save(Estoque model)
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

        public virtual void Audit(Estoque model, Estoque modelOld)
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

        public virtual void MakeValidations(Estoque model, Estoque modelOld)
        {
            if (model.IsNull())
                this._validation.AddNotification("ITEM_ENVIADO", "Item enviado não contém propriedades");
        }

    }
}
