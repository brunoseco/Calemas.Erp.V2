using System;
using Common.Dto;

namespace CalemasERP.Core.Dto
{
	public class SolicitacaoEstoqueDto  : DtoBase
	{	
        public int SolicitacaoEstoqueId { get; set; } 
        public string Descricao { get; set; } 
        public int SolicitanteId { get; set; } 
        public DateTime DataSolicitacao { get; set; } 
        public DateTime DataPrevista { get; set; } 
        public int StatusSolicitacaoEstoqueMovimentacaoId { get; set; } 
		
	}
}