using Common.Domain.Interfaces;
using Common.Validation;
using System.Threading.Tasks;
using System.Collections.Generic;
using calemaserp.ui.Core.Dto;
using calemaserp.ui.Core.Data.Repository;
using calemaserp.ui.Core.Data.Model;
using Common.Domain.Model;

namespace calemaserp.ui.Core.Services
{
    public class EstoqueService : EstoqueServiceBase
    {
        public EstoqueService(EstoqueRepository rep, ValidationContract validation, CurrentUser user, IUnitOfWork uow)
            : base(rep, validation, user, uow)
        { }

		protected override async Task<IEnumerable<TDS>> MapperDomainToDto<TDS>(IEnumerable<Estoque> models)
        {
            return await base.MapperDomainToDto<EstoqueDtoResult>(models) as IEnumerable<TDS>;
        }

    }
}
