using System;
using Common.Dto;

namespace superacrm.ui.Core.Dto
{
	public class PessoaDto  : DtoBase
	{	
        public int PessoaId { get; set; } 
        public int AssinaturaId { get; set; } 
        public string Nome { get; set; } 
        public DateTime DataCriacao { get; set; } 
        public int VisibilidadeId { get; set; } 
		
	}
}