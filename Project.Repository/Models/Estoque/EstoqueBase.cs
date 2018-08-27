using Common.Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalemasERP.Core.Data.Model
{
    public class EstoqueBase : DomainBase
    {
        public EstoqueBase()
        {

        }

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
        public bool Ativo { get; set; } 
        public string Localizacao { get; set; } 
        public int UserCreateId { get; set; } 
        public DateTime UserCreateDate { get; set; } 
        public int? UserAlterId { get; set; } 
        public DateTime? UserAlterDate { get; set; } 


    }
}