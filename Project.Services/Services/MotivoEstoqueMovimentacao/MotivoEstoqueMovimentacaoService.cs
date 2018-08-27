using Common.Domain.Interfaces;
using Common.Validation;
using System.Threading.Tasks;
using System.Collections.Generic;
using CalemasERP.Core.Dto;
using CalemasERP.Core.Data.Repository;
using CalemasERP.Core.Data.Model;
using Common.Domain.Model;

namespace CalemasERP.Core.Services
{
    public class MotivoEstoqueMovimentacaoService : MotivoEstoqueMovimentacaoServiceBase
    {
        public MotivoEstoqueMovimentacaoService(MotivoEstoqueMovimentacaoRepository rep, ValidationContract validation, CurrentUser user, IUnitOfWork uow)
            : base(rep, validation, user, uow)
        { }

		protected override async Task<IEnumerable<TDS>> MapperDomainToDto<TDS>(IEnumerable<MotivoEstoqueMovimentacao> models)
        {
            return await base.MapperDomainToDto<MotivoEstoqueMovimentacaoDtoResult>(models) as IEnumerable<TDS>;
        }

    }
}
