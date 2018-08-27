using System;

namespace calemaserp.ui.Core.Filters
{
    public class EstoqueFilterBase : Common.Domain.Base.FilterBase
    {
        public int EstoqueId { get; set; } 
        public string Nome { get; set; } 
        public string Descricao { get; set; } 
        public string Modelo { get; set; } 
        public string Fabricante { get; set; } 
        public string Referencia { get; set; } 
        public int UnidadeMedidaId { get; set; } 
        public int CategoriaEstoqueId { get; set; } 
        public string Observacao { get; set; } 
        public decimal QuantidadeMinima { get; set; } 
        public decimal Quantidade { get; set; } 
        public decimal? ValorVenda { get; set; } 
        public decimal? ValorCompra { get; set; } 
        public bool? Ativo { get; set; } 
        public string Localizacao { get; set; } 
        public int UserCreateId { get; set; } 
        public DateTime UserCreateDateStart { get; set; } 
        public DateTime UserCreateDateEnd { get; set; } 
        public DateTime UserCreateDate { get; set; } 
        public int? UserAlterId { get; set; } 
        public DateTime? UserAlterDateStart { get; set; } 
        public DateTime? UserAlterDateEnd { get; set; } 
        public DateTime? UserAlterDate { get; set; } 

    }
}
