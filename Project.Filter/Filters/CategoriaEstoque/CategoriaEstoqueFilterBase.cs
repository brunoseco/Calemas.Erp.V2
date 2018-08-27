using System;

namespace CalemasERP.Core.Filters
{
    public class CategoriaEstoqueFilterBase : Common.Domain.Base.FilterBase
    {
        public int CategoriaEstoqueId { get; set; } 
        public string Nome { get; set; } 

    }
}
