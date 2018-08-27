using System;
using Common.Dto;

namespace CalemasERP.Core.Dto
{
	public class EstoqueMovimentacaoDto  : DtoBase
	{	
        public int EstoqueMovimentacaoId { get; set; } 
        public int EstoqueId { get; set; } 
        public bool Entrada { get; set; } 
        public string Descricao { get; set; } 
        public decimal Quantidade { get; set; } 
        public int? MotivoEstoqueMovimentacaoId { get; set; } 
        public int ResponsavelId { get; set; } 
		
	}
}