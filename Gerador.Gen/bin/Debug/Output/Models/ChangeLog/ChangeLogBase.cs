using System;
using System.Collections.Generic;
using System.Text;

namespace Calemas.Erp.Core.Data.Model
{
    public class ChangeLogBase
    {
        public ChangeLogBase()
        {

        }

        public int ChangeLogId { get; set; } 
        public string Versao { get; set; } 
        public string Descricao { get; set; } 
        public int UserCreateId { get; set; } 
        public DateTime UserCreateDate { get; set; } 
        public int? UserAlterId { get; set; } 
        public DateTime? UserAlterDate { get; set; } 


    }
}