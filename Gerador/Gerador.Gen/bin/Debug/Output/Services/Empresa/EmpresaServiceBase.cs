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
    public class EmpresaServiceBase : ServiceBase<Empresa, EmpresaDto, EmpresaFilter>, IService
    {
        protected EmpresaRepository _rep;
        protected CurrentUser _user;

        public EmpresaServiceBase(EmpresaRepository rep, ValidationContract validation, CurrentUser user, IUnitOfWork uow)
            : base(rep, uow, validation)
        {
            this._rep = rep;
            this._user = user;
        }

		public virtual async Task<IEnumerable<dynamic>> GetDataItems(EmpresaFilter filters)
        {
            return await Task.Run(() =>
            {
                return this._rep.GetDataItems(filters);
            });
        }

        public virtual async Task<SearchResult<EmpresaDto>> GetByFiltersPaging(EmpresaFilter filters)
        {
            var queryBase = this._rep.GetByFilters(filters);
            var paginated = await this._rep.PagingAndOrdering(filters, queryBase);
            return await this.SearchResult(filters, paginated, queryBase);
        }

        public virtual async Task<EmpresaDto> GetById(EmpresaFilter filters)
        {
            var alvo = this._rep.GetById(filters);
            var result = await MapperDomainToDto<EmpresaDtoDetail>(alvo);
            return result;
        }
		
        public virtual Empresa GetByModel(Empresa model)
        {
            var alvo = this._rep.GetByModel(model);
            return alvo;
        }

        public override Empresa Save(Empresa model)
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



        public virtual void MakeValidations(Empresa model, Empresa modelOld)
        {
            if (model.IsNull())
                this._validation.AddNotification("ITEM_ENVIADO", "Item enviado não contém propriedades");
        }

    }
}
