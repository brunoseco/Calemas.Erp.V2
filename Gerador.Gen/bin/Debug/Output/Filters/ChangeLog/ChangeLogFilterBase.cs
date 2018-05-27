using System;

namespace Calemas.Erp.Core.Filters
{
    public class ChangeLogFilterBase : Common.Domain.Base.FilterBase
    {
        public int ChangeLogId { get; set; } 
        public string Versao { get; set; } 
        public string Descricao { get; set; } 
        public int UserCreateId { get; set; } 
        public DateTime UserCreateDateStart { get; set; } 
        public DateTime UserCreateDateEnd { get; set; } 
        public DateTime UserCreateDate { get; set; } 
        public int? UserAlterId { get; set; } 
        public DateTime? UserAlterDateStart { get; set; } 
        public DateTime? UserAlterDateEnd { get; set; } 
        public DateTime? UserAlterDate { get; set; } 

    }
}
