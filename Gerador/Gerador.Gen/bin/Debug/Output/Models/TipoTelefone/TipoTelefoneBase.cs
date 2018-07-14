using Common.Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace superacrm.ui.Core.Data.Model
{
    public class TipoTelefoneBase : DomainBase
    {
        public TipoTelefoneBase()
        {

        }

        public int TipoTelefoneId { get; set; } 
        public string Nome { get; set; } 


    }
}