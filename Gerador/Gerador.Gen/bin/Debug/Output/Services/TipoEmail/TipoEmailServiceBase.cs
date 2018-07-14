using Common.Domain.Base;
using Common.Domain.Interfaces;
using Common.Domain.Model;
using Common.Validation;
using superacrm.ui.Core.Dto;
using superacrm.ui.Core.Filters;
using superacrm.ui.Core.Data.Model;
using superacrm.ui.Core.Data.Repository;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System;

namespace superacrm.ui.Core.Services
{
    public class TipoEmailServiceBase : ServiceBase<TipoEmail, TipoEmailDto, TipoEmailFilter>, IService
    {
        protected TipoEmailRepository _rep;
        protected CurrentUser _user;

        public TipoEmailServiceBase(TipoEmailRepository rep, ValidationContract validation, CurrentUser user, IUnitOfWork uow)
            : base(rep, uow, validation)
        {
            this._rep = rep;
            this._user = user;
        }

		public virtual async Task<IEnumerable<dynamic>> GetDataItems(TipoEmailFilter filters)
        {
            return await Task.Run(() =>
            {
                return this._rep.GetDataItems(filters);
            });
        }

        public virtual async Task<SearchResult<TipoEmailDto>> GetByFiltersPaging(TipoEmailFilter filters)
        {
            var queryBase = this._rep.GetByFilters(filters);
            var paginated = await this._rep.PagingAndOrdering(filters, queryBase);
            return await this.SearchResult(filters, paginated, queryBase);
        }

        public virtual async Task<TipoEmailDto> GetById(TipoEmailFilter filters)
        {
            var alvo = this._rep.GetById(filters);
            var result = await MapperDomainToDto<TipoEmailDtoDetail>(alvo);
            return result;
        }
		
        public virtual TipoEmail GetByModel(TipoEmail model)
        {
            var alvo = this._rep.GetByModel(model);
            return alvo;
        }

        public override TipoEmail Save(TipoEmail model)
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



        public virtual void MakeValidations(TipoEmail model, TipoEmail modelOld)
        {
            if (model.IsNull())
                this._validation.AddNotification("ITEM_ENVIADO", "Item enviado não contém propriedades");
        }

    }
}
