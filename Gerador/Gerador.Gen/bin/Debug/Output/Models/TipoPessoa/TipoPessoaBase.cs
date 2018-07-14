using Common.Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace superacrm.ui.Core.Data.Model
{
    public class TipoPessoaBase : DomainBase
    {
        public TipoPessoaBase()
        {

        }

        public int TipoPessoaId { get; set; } 
        public string Nome { get; set; } 


    }
}