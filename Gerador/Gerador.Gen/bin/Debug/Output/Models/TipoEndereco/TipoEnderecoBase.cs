using Common.Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace superacrm.ui.Core.Data.Model
{
    public class TipoEnderecoBase : DomainBase
    {
        public TipoEnderecoBase()
        {

        }

        public int TipoEnderecoId { get; set; } 
        public string Nome { get; set; } 


    }
}