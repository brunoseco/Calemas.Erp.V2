using Common.Domain.Interfaces;
using Common.Validation;
using System.Threading.Tasks;
using System.Collections.Generic;
using Calemas.Erp.Core.Dto;
using Calemas.Erp.Core.Data.Repository;
using Calemas.Erp.Core.Data.Model;

namespace Calemas.Erp.Core.Services
{
    public class ChangeLogService : ChangeLogServiceBase
    {
        public ChangeLogService(ChangeLogRepository rep, ValidationContract validation, IUnitOfWork uow)
            : base(rep, validation, uow)
        { }

		protected override async Task<IEnumerable<TDS>> MapperDomainToDto<TDS>(IEnumerable<ChangeLog> models)
        {
            return await base.MapperDomainToDto<ChangeLogDtoResult>(models) as IEnumerable<TDS>;
        }

    }
}
