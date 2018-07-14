using System;
using Common.Dto;

namespace superacrm.ui.Core.Dto
{
	public class StatusNegocioDto  : DtoBase
	{	
        public int StatusNegocioId { get; set; } 
        public string Nome { get; set; } 
        public int? AssinaturaId { get; set; } 
		
	}
}