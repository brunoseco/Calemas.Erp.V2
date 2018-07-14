using Common.Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace superacrm.ui.Core.Data.Model
{
    public class RegiaoBase : DomainBase
    {
        public RegiaoBase()
        {

        }

        public int RegiaoId { get; set; } 
        public string Nome { get; set; } 


    }
}