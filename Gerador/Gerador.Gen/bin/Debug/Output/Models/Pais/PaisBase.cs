using Common.Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace superacrm.ui.Core.Data.Model
{
    public class PaisBase : DomainBase
    {
        public PaisBase()
        {

        }

        public int PaisId { get; set; } 
        public string Nome { get; set; } 


    }
}