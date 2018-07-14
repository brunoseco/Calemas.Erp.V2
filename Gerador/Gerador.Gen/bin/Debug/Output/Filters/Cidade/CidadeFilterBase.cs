using System;

namespace superacrm.ui.Core.Filters
{
    public class CidadeFilterBase : Common.Domain.Base.FilterBase
    {
        public int CidadeId { get; set; } 
        public string Nome { get; set; } 
        public string UF { get; set; } 

    }
}
