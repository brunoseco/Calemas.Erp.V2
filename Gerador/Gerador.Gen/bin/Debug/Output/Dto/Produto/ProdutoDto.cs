using System;
using Common.Dto;

namespace superacrm.ui.Core.Dto
{
	public class ProdutoDto  : DtoBase
	{	
        public int ProdutoId { get; set; } 
        public int? AssinaturaId { get; set; } 
        public string Codigo { get; set; } 
        public string Nome { get; set; } 
        public bool Ativo { get; set; } 
        public DateTime DataCadastro { get; set; } 
        public int VisibilidadeId { get; set; } 
        public decimal Preco { get; set; } 
        public string Unidade { get; set; } 
        public decimal ValorImpostos { get; set; } 
		
	}
}