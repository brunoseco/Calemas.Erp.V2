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
    public class StatusNegocioServiceBase : ServiceBase<StatusNegocio, StatusNegocioDto, StatusNegocioFilter>, IService
    {
        protected StatusNegocioRepository _rep;
        protected CurrentUser _user;

        public StatusNegocioServiceBase(StatusNegocioRepository rep, ValidationContract validation, CurrentUser user, IUnitOfWork uow)
            : base(rep, uow, validation)
        {
            this._rep = rep;
            this._user = user;
        }

		public virtual async Task<IEnumerable<dynamic>> GetDataItems(StatusNegocioFilter filters)
        {
            return await Task.Run(() =>
            {
                return this._rep.GetDataItems(filters);
            });
        }

        public virtual async Task<SearchResult<StatusNegocioDto>> GetByFiltersPaging(StatusNegocioFilter filters)
        {
            var queryBase = this._rep.GetByFilters(filters);
            var paginated = await this._rep.PagingAndOrdering(filters, queryBase);
            return await this.SearchResult(filters, paginated, queryBase);
        }

        public virtual async Task<StatusNegocioDto> GetById(StatusNegocioFilter filters)
        {
            var alvo = this._rep.GetById(filters);
            var result = await MapperDomainToDto<StatusNegocioDtoDetail>(alvo);
            return result;
        }
		
        public virtual StatusNegocio GetByModel(StatusNegocio model)
        {
            var alvo = this._rep.GetByModel(model);
            return alvo;
        }

        public override StatusNegocio Save(StatusNegocio model)
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



        public virtual void MakeValidations(StatusNegocio model, StatusNegocio modelOld)
        {
            if (model.IsNull())
                this._validation.AddNotification("ITEM_ENVIADO", "Item enviado não contém propriedades");
        }

    }
}
