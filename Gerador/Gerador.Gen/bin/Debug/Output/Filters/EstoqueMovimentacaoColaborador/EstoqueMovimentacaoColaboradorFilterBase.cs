using System;

namespace calemaserp.ui.Core.Filters
{
    public class EstoqueMovimentacaoColaboradorFilterBase : Common.Domain.Base.FilterBase
    {
        public int EstoqueMovimentacaoColaboradorId { get; set; } 
        public int ColaboradorId { get; set; } 
        public int EstoqueMovimentacaoId { get; set; } 
        public bool? Entrada { get; set; } 
        public string Descricao { get; set; } 
        public decimal Quantidade { get; set; } 

    }
}
