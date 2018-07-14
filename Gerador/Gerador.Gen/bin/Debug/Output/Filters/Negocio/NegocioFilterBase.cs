using System;

namespace superacrm.ui.Core.Filters
{
    public class NegocioFilterBase : Common.Domain.Base.FilterBase
    {
        public int NegocioId { get; set; } 
        public string Titulo { get; set; } 
        public int EmpresaId { get; set; } 
        public int AssinaturaId { get; set; } 
        public int? UsuarioId { get; set; } 
        public int? ProprietarioId { get; set; } 
        public decimal? Valor { get; set; } 
        public int? FunilId { get; set; } 
        public int? EtapaAtual { get; set; } 
        public decimal? Probabilidade { get; set; } 
        public DateTime? DataProximaAtividadeStart { get; set; } 
        public DateTime? DataProximaAtividadeEnd { get; set; } 
        public DateTime? DataProximaAtividade { get; set; } 
        public DateTime? DataUltimaAtividadeStart { get; set; } 
        public DateTime? DataUltimaAtividadeEnd { get; set; } 
        public DateTime? DataUltimaAtividade { get; set; } 
        public DateTime? DataGanhoStart { get; set; } 
        public DateTime? DataGanhoEnd { get; set; } 
        public DateTime? DataGanho { get; set; } 
        public DateTime? DataPerdaStart { get; set; } 
        public DateTime? DataPerdaEnd { get; set; } 
        public DateTime? DataPerda { get; set; } 
        public DateTime? DataFechamentoNegocioStart { get; set; } 
        public DateTime? DataFechamentoNegocioEnd { get; set; } 
        public DateTime? DataFechamentoNegocio { get; set; } 
        public int? MotivoPerdaId { get; set; } 
        public int VisibilidadeId { get; set; } 
        public DateTime? DataFechamentoEsperadaStart { get; set; } 
        public DateTime? DataFechamentoEsperadaEnd { get; set; } 
        public DateTime? DataFechamentoEsperada { get; set; } 
        public int StatusNegocioId { get; set; } 
        public DateTime DataCriacaoStart { get; set; } 
        public DateTime DataCriacaoEnd { get; set; } 
        public DateTime DataCriacao { get; set; } 
        public DateTime? DataAtualizacaoStart { get; set; } 
        public DateTime? DataAtualizacaoEnd { get; set; } 
        public DateTime? DataAtualizacao { get; set; } 

    }
}
