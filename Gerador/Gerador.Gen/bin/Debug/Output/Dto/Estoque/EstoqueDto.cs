using System;
using Common.Dto;

namespace calemaserp.ui.Core.Dto
{
	public class EstoqueDto  : DtoBase
	{	
        public int EstoqueId { get; set; } 
        public string Nome { get; set; } 
        public string Descricao { get; set; } 
        public string Modelo { get; set; } 
        public string Fabricante { get; set; } 
        public string Referencia { get; set; } 
        public int UnidadeMedidaId { get; set; } 
        public int CategoriaEstoqueId { get; set; } 
        public string Observacao { get; set; } 
        public decimal QuantidadeMinima { get; set; } 
        public decimal Quantidade { get; set; } 
        public decimal? ValorVenda { get; set; } 
        public decimal? ValorCompra { get; set; } 
        public bool Ativo { get; set; } 
        public string Localizacao { get; set; } 
		
	}
}