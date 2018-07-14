using System;
using Common.Dto;

namespace superacrm.ui.Core.Dto
{
	public class EmpresaDto  : DtoBase
	{	
        public int EmpresaId { get; set; } 
        public int? AssinaturaId { get; set; } 
        public string Nome { get; set; } 
        public int? ProprietarioId { get; set; } 
        public DateTime DataCriacao { get; set; } 
        public DateTime? DataAtualizacao { get; set; } 
        public int VisibilidadeId { get; set; } 
		
	}
}