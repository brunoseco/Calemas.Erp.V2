using System;

namespace superacrm.ui.Core.Filters
{
    public class PessoaFilterBase : Common.Domain.Base.FilterBase
    {
        public int PessoaId { get; set; } 
        public int AssinaturaId { get; set; } 
        public string Nome { get; set; } 
        public DateTime DataCriacaoStart { get; set; } 
        public DateTime DataCriacaoEnd { get; set; } 
        public DateTime DataCriacao { get; set; } 
        public int VisibilidadeId { get; set; } 

    }
}
