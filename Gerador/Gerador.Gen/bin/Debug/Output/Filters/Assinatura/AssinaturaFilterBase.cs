using System;

namespace superacrm.ui.Core.Filters
{
    public class AssinaturaFilterBase : Common.Domain.Base.FilterBase
    {
        public int AssinaturaId { get; set; } 
        public string Nome { get; set; } 
        public string Empresa { get; set; } 
        public int SetorId { get; set; } 
        public string Telefone { get; set; } 
        public string Senha { get; set; } 
        public string CpfCnpj { get; set; } 
        public string Logradouro { get; set; } 
        public string Numero { get; set; } 
        public string Complemento { get; set; } 
        public string Bairro { get; set; } 
        public int CidadeId { get; set; } 
        public string UF { get; set; } 
        public int PaisId { get; set; } 

    }
}
