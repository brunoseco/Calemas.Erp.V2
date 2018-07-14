using Common.Domain.Interfaces;
using Common.Validation;
using System.Threading.Tasks;
using System.Collections.Generic;
using superacrm.ui.Core.Dto;
using superacrm.ui.Core.Data.Repository;
using superacrm.ui.Core.Data.Model;
using Common.Domain.Model;

namespace superacrm.ui.Core.Services
{
    public class TipoEnderecoService : TipoEnderecoServiceBase
    {
        public TipoEnderecoService(TipoEnderecoRepository rep, ValidationContract validation, CurrentUser user, IUnitOfWork uow)
            : base(rep, validation, user, uow)
        { }

		protected override async Task<IEnumerable<TDS>> MapperDomainToDto<TDS>(IEnumerable<TipoEndereco> models)
        {
            return await base.MapperDomainToDto<TipoEnderecoDtoResult>(models) as IEnumerable<TDS>;
        }

    }
}
