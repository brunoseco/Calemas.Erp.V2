using Common.Domain.Base;
using Common.Domain.Interfaces;
using Common.Domain.Model;
using Common.Validation;
using Calemas.Erp.Core.Dto;
using Calemas.Erp.Core.Filters;
using Calemas.Erp.Core.Data.Model;
using Calemas.Erp.Core.Data.Repository;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Calemas.Erp.Core.Services
{
    public class ChangeLogServiceBase : ServiceBase<ChangeLog, ChangeLogDto, ChangeLogFilter>, IService
    {
        protected ChangeLogRepository _rep;
        protected CurrentUser _user;

        public ChangeLogServiceBase(ChangeLogRepository rep, ValidationContract validation, CurrentUser user, IUnitOfWork uow)
            : base(rep, uow, validation)
        {
            this._rep = rep;
            this._user = user;
        }

		public virtual async Task<IEnumerable<dynamic>> GetDataItems(ChangeLogFilter filters)
        {
            return await Task.Run(() =>
            {
                return this._rep.GetDataItems(filters);
            });
        }

        public virtual async Task<SearchResult<ChangeLogDto>> GetByFiltersPaging(ChangeLogFilter filters)
        {
            var queryBase = this._rep.GetByFilters(filters);
            var paginated = await this._rep.PagingAndOrdering(filters, queryBase);
            return await this.SearchResult(filters, paginated, queryBase);
        }

        public virtual async Task<ChangeLogDto> GetById(ChangeLogFilter filters)
        {
            var alvo = this._rep.GetById(filters);
            var result = await MapperDomainToDto<ChangeLogDto>(alvo);
            return result;
        }
		
        public override ChangeLog Save(ChangeLog model)
        {
            var alvo = this._rep.GetByModel(model);

            this.Audit(model, alvo);

            this.MakeValidations(model, alvo);

            if (!this.IsValid())
                return model;

            if (alvo.IsNull())
                this._rep.Add(model);
            else
                this._rep.Update(model);

            return alvo;
        }

        public virtual void Audit(ChangeLog model, ChangeLog modelOld)
        {
            if (modelOld.IsNull())
            {
                model.UserCreateDate = DateTime.Now;
                model.UserCreateId = this._user.GetUserId();
            }
            else
            {
                model.UserAlterDate = DateTime.Now;
                model.UserAlterId = this._user.GetUserId();
            }
        }

        public virtual void MakeValidations(ChangeLog model, ChangeLog modelOld)
        {
            if (model.IsNull())
                this._validation.AddNotification("ITEM_ENVIADO", "Item enviado não contém propriedades");
        }

    }
}
