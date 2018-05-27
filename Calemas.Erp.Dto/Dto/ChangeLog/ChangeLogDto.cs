using System;
using Common.Dto;

namespace Calemas.Erp.Core.Dto
{
	public class ChangeLogDto  : DtoBase
	{	
        public int ChangeLogId { get; set; } 
        public string Versao { get; set; } 
        public string Descricao { get; set; } 
		
	}
}