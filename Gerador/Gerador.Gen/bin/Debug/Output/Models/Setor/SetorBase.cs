using Common.Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace superacrm.ui.Core.Data.Model
{
    public class SetorBase : DomainBase
    {
        public SetorBase()
        {

        }

        public int SetorId { get; set; } 
        public string Nome { get; set; } 


    }
}