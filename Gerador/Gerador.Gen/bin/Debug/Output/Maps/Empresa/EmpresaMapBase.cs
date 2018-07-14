using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using superacrm.ui.Core.Data.Model;

namespace superacrm.ui.Core.Data.Maps
{
    public abstract class EmpresaMapBase
    {
        protected abstract void CustomConfig(EntityTypeBuilder<Empresa> type);

        public EmpresaMapBase(EntityTypeBuilder<Empresa> type)
        {
            type.ToTable("Empresa");

            type.Property(t => t.EmpresaId).HasColumnName("Id");


            type.Property(t => t.AssinaturaId).HasColumnName("AssinaturaId");
            type.Property(t => t.Nome).HasColumnName("Nome").HasColumnType("varchar(255)");
            type.Property(t => t.ProprietarioId).HasColumnName("ProprietarioId");
            type.Property(t => t.DataCriacao).HasColumnName("DataCriacao");
            type.Property(t => t.DataAtualizacao).HasColumnName("DataAtualizacao");
            type.Property(t => t.VisibilidadeId).HasColumnName("VisibilidadeId");


            type.HasKey(d => new { d.EmpresaId, }); 

			CustomConfig(type);

        }
    }
}
