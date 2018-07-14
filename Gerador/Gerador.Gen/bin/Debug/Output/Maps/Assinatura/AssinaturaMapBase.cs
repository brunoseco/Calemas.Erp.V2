using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using superacrm.ui.Core.Data.Model;

namespace superacrm.ui.Core.Data.Maps
{
    public abstract class AssinaturaMapBase
    {
        protected abstract void CustomConfig(EntityTypeBuilder<Assinatura> type);

        public AssinaturaMapBase(EntityTypeBuilder<Assinatura> type)
        {
            type.ToTable("Assinatura");

            type.Property(t => t.AssinaturaId).HasColumnName("Id");


            type.Property(t => t.Nome).HasColumnName("Nome").HasColumnType("varchar(255)");
            type.Property(t => t.Empresa).HasColumnName("Empresa").HasColumnType("varchar(255)");
            type.Property(t => t.SetorId).HasColumnName("SetorId");
            type.Property(t => t.Telefone).HasColumnName("Telefone").HasColumnType("varchar(50)");
            type.Property(t => t.Senha).HasColumnName("Senha").HasColumnType("varchar(50)");
            type.Property(t => t.CpfCnpj).HasColumnName("CpfCnpj").HasColumnType("varchar(50)");
            type.Property(t => t.Logradouro).HasColumnName("Logradouro").HasColumnType("varchar(255)");
            type.Property(t => t.Numero).HasColumnName("Numero").HasColumnType("varchar(255)");
            type.Property(t => t.Complemento).HasColumnName("Complemento").HasColumnType("varchar(255)");
            type.Property(t => t.Bairro).HasColumnName("Bairro").HasColumnType("varchar(255)");
            type.Property(t => t.CidadeId).HasColumnName("CidadeId");
            type.Property(t => t.UF).HasColumnName("UF").HasColumnType("varchar(2)");
            type.Property(t => t.PaisId).HasColumnName("PaisId");


            type.HasKey(d => new { d.AssinaturaId, }); 

			CustomConfig(type);

        }
    }
}
