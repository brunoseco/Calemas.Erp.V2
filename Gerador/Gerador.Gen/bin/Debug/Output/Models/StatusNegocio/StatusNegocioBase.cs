using Common.Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace superacrm.ui.Core.Data.Model
{
    public class StatusNegocioBase : DomainBase
    {
        public StatusNegocioBase()
        {

        }

        public int StatusNegocioId { get; set; } 
        public string Nome { get; set; } 
        public int? AssinaturaId { get; set; } 


    }
}