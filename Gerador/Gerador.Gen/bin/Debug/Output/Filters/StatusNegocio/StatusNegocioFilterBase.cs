using System;

namespace superacrm.ui.Core.Filters
{
    public class StatusNegocioFilterBase : Common.Domain.Base.FilterBase
    {
        public int StatusNegocioId { get; set; } 
        public string Nome { get; set; } 
        public int? AssinaturaId { get; set; } 

    }
}
