using System;
using Common.Dto;

namespace calemaserp.ui.Core.Dto
{
	public class EstoqueMovimentacaoColaboradorDto  : DtoBase
	{	
        public int EstoqueMovimentacaoColaboradorId { get; set; } 
        public int ColaboradorId { get; set; } 
        public int EstoqueMovimentacaoId { get; set; } 
        public bool Entrada { get; set; } 
        public string Descricao { get; set; } 
        public decimal Quantidade { get; set; } 
		
	}
}