using Common.Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace superacrm.ui.Core.Data.Model
{
    public class EmpresaBase : DomainBase
    {
        public EmpresaBase()
        {

        }

        public int EmpresaId { get; set; } 
        public int? AssinaturaId { get; set; } 
        public string Nome { get; set; } 
        public int? ProprietarioId { get; set; } 
        public DateTime DataCriacao { get; set; } 
        public DateTime? DataAtualizacao { get; set; } 
        public int VisibilidadeId { get; set; } 


    }
}