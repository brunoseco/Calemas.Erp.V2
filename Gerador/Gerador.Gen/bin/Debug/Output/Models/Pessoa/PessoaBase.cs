using Common.Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace superacrm.ui.Core.Data.Model
{
    public class PessoaBase : DomainBase
    {
        public PessoaBase()
        {

        }

        public int PessoaId { get; set; } 
        public int AssinaturaId { get; set; } 
        public string Nome { get; set; } 
        public DateTime DataCriacao { get; set; } 
        public int VisibilidadeId { get; set; } 


    }
}