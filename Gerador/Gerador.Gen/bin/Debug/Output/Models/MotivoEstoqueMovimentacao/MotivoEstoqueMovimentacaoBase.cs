using Common.Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace calemaserp.ui.Core.Data.Model
{
    public class MotivoEstoqueMovimentacaoBase : DomainBase
    {
        public MotivoEstoqueMovimentacaoBase()
        {

        }

        public int MotivoEstoqueMovimentacaoId { get; set; } 
        public string Nome { get; set; } 


    }
}