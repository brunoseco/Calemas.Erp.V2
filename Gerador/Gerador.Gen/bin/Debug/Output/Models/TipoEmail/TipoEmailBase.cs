using Common.Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace superacrm.ui.Core.Data.Model
{
    public class TipoEmailBase : DomainBase
    {
        public TipoEmailBase()
        {

        }

        public int TipoEmailId { get; set; } 
        public string Nome { get; set; } 


    }
}