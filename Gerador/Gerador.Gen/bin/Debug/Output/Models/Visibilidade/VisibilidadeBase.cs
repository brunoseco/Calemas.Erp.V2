using Common.Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace superacrm.ui.Core.Data.Model
{
    public class VisibilidadeBase : DomainBase
    {
        public VisibilidadeBase()
        {

        }

        public int VisibilidadeId { get; set; } 
        public string Nome { get; set; } 


    }
}