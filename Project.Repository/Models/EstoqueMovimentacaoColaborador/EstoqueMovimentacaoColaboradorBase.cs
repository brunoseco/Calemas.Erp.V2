using Common.Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalemasERP.Core.Data.Model
{
    public class EstoqueMovimentacaoColaboradorBase : DomainBase
    {
        public EstoqueMovimentacaoColaboradorBase()
        {

        }

        public int EstoqueMovimentacaoColaboradorId { get; set; } 
        public int ColaboradorId { get; set; } 
        public int EstoqueMovimentacaoId { get; set; } 
        public bool Entrada { get; set; } 
        public string Descricao { get; set; } 
        public decimal Quantidade { get; set; } 


    }
}