using Common.Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace superacrm.ui.Core.Data.Model
{
    public class CidadeBase : DomainBase
    {
        public CidadeBase()
        {

        }

        public int CidadeId { get; set; } 
        public string Nome { get; set; } 
        public string UF { get; set; } 


    }
}