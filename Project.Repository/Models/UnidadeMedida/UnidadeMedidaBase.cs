using Common.Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalemasERP.Core.Data.Model
{
    public class UnidadeMedidaBase : DomainBase
    {
        public UnidadeMedidaBase()
        {

        }

        public int UnidadeMedidaId { get; set; } 
        public string Nome { get; set; } 


    }
}