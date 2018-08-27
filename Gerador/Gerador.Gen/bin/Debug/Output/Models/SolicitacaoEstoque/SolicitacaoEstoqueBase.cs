using Common.Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace calemaserp.ui.Core.Data.Model
{
    public class SolicitacaoEstoqueBase : DomainBase
    {
        public SolicitacaoEstoqueBase()
        {

        }

        public int SolicitacaoEstoqueId { get; set; } 
        public string Descricao { get; set; } 
        public int SolicitanteId { get; set; } 
        public DateTime DataSolicitacao { get; set; } 
        public DateTime DataPrevista { get; set; } 
        public int StatusSolicitacaoEstoqueMovimentacaoId { get; set; } 
        public int UserCreateId { get; set; } 
        public DateTime UserCreateDate { get; set; } 
        public int? UserAlterId { get; set; } 
        public DateTime? UserAlterDate { get; set; } 


    }
}