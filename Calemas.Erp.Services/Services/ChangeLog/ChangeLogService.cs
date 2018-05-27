using Common.Domain.Interfaces;
using Common.Validation;
using Calemas.Erp.Core.Dto;
using Calemas.Erp.Core.Data.Repository;
using System.Threading.Tasks;
using Common.Domain.Model;

namespace Calemas.Erp.Core.Services
{
    public class ChangeLogService : ChangeLogServiceBase
    {
        public ChangeLogService(ChangeLogRepository rep, ValidationContract validation, CurrentUser user, IUnitOfWork uow)
            : base(rep, validation, user, uow)
        { }

    }
}
