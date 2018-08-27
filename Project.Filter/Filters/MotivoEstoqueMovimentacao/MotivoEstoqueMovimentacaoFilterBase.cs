using System;

namespace CalemasERP.Core.Filters
{
    public class MotivoEstoqueMovimentacaoFilterBase : Common.Domain.Base.FilterBase
    {
        public int MotivoEstoqueMovimentacaoId { get; set; } 
        public string Nome { get; set; } 

    }
}
