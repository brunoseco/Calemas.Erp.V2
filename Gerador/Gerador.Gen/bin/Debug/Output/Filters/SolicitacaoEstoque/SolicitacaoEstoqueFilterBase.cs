using System;

namespace calemaserp.ui.Core.Filters
{
    public class SolicitacaoEstoqueFilterBase : Common.Domain.Base.FilterBase
    {
        public int SolicitacaoEstoqueId { get; set; } 
        public string Descricao { get; set; } 
        public int SolicitanteId { get; set; } 
        public DateTime DataSolicitacaoStart { get; set; } 
        public DateTime DataSolicitacaoEnd { get; set; } 
        public DateTime DataSolicitacao { get; set; } 
        public DateTime DataPrevistaStart { get; set; } 
        public DateTime DataPrevistaEnd { get; set; } 
        public DateTime DataPrevista { get; set; } 
        public int StatusSolicitacaoEstoqueMovimentacaoId { get; set; } 
        public int UserCreateId { get; set; } 
        public DateTime UserCreateDateStart { get; set; } 
        public DateTime UserCreateDateEnd { get; set; } 
        public DateTime UserCreateDate { get; set; } 
        public int? UserAlterId { get; set; } 
        public DateTime? UserAlterDateStart { get; set; } 
        public DateTime? UserAlterDateEnd { get; set; } 
        public DateTime? UserAlterDate { get; set; } 

    }
}
