using System;
using Common.Dto;

namespace superacrm.ui.Core.Dto
{
	public class CidadeDto  : DtoBase
	{	
        public int CidadeId { get; set; } 
        public string Nome { get; set; } 
        public string UF { get; set; } 
		
	}
}