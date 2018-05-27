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

namespace Calemas.Erp.Core.Services
{
    public class ChangeLogServiceBase : ServiceBase<ChangeLog, ChangeLogDto, ChangeLogFilter>, IService
    {
        protected ChangeLogRepository _rep;

        public ChangeLogServiceBase(ChangeLogRepository rep, ValidationContract validation, IUnitOfWork uow)
            : base(rep, uow, validation)
        {
            this._rep = rep;
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

    }
}
