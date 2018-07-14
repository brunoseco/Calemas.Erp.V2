using System;

namespace superacrm.ui.Core.Filters
{
    public class EmpresaFilterBase : Common.Domain.Base.FilterBase
    {
        public int EmpresaId { get; set; } 
        public int? AssinaturaId { get; set; } 
        public string Nome { get; set; } 
        public int? ProprietarioId { get; set; } 
        public DateTime DataCriacaoStart { get; set; } 
        public DateTime DataCriacaoEnd { get; set; } 
        public DateTime DataCriacao { get; set; } 
        public DateTime? DataAtualizacaoStart { get; set; } 
        public DateTime? DataAtualizacaoEnd { get; set; } 
        public DateTime? DataAtualizacao { get; set; } 
        public int VisibilidadeId { get; set; } 

    }
}
