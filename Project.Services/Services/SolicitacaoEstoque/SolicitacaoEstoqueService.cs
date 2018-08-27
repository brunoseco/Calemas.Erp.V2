using Common.Domain.Interfaces;
using Common.Validation;
using System.Threading.Tasks;
using System.Collections.Generic;
using CalemasERP.Core.Dto;
using CalemasERP.Core.Data.Repository;
using CalemasERP.Core.Data.Model;
using Common.Domain.Model;
using System;

namespace CalemasERP.Core.Services
{
    public class SolicitacaoEstoqueService : SolicitacaoEstoqueServiceBase
    {
        public SolicitacaoEstoqueService(SolicitacaoEstoqueRepository rep, ValidationContract validation, CurrentUser user, IUnitOfWork uow)
            : base(rep, validation, user, uow)
        { }

		protected override async Task<IEnumerable<TDS>> MapperDomainToDto<TDS>(IEnumerable<SolicitacaoEstoque> models)
        {
            return await base.MapperDomainToDto<SolicitacaoEstoqueDtoResult>(models) as IEnumerable<TDS>;
        }

        public override SolicitacaoEstoque Save(SolicitacaoEstoque model)
        {
            var alvo = this.GetByModel(model);

            model.SolicitanteId = _user.GetUserId();
            model.DataSolicitacao = DateTime.Now;

            if (!this.IsValid())
                return model;

            if (alvo.IsNull())
                alvo = this._rep.Add(model);
            else
                alvo = this._rep.Update(model);

            return alvo;
        }

    }
}
