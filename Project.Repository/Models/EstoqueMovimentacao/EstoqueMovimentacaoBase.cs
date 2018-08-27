using Common.Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalemasERP.Core.Data.Model
{
    public class EstoqueMovimentacaoBase : DomainBase
    {
        public EstoqueMovimentacaoBase()
        {

        }

        public int EstoqueMovimentacaoId { get; set; } 
        public int EstoqueId { get; set; } 
        public bool Entrada { get; set; } 
        public string Descricao { get; set; } 
        public decimal Quantidade { get; set; } 
        public int? MotivoEstoqueMovimentacaoId { get; set; } 
        public int ResponsavelId { get; set; } 
        public int UserCreateId { get; set; } 
        public DateTime UserCreateDate { get; set; } 
        public int? UserAlterId { get; set; } 
        public DateTime? UserAlterDate { get; set; } 


    }
}