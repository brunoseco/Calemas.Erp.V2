using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using superacrm.ui.Core.Data.Model;

namespace superacrm.ui.Core.Data.Maps
{
    public abstract class ProdutoMapBase
    {
        protected abstract void CustomConfig(EntityTypeBuilder<Produto> type);

        public ProdutoMapBase(EntityTypeBuilder<Produto> type)
        {
            type.ToTable("Produto");

            type.Property(t => t.ProdutoId).HasColumnName("Id");


            type.Property(t => t.AssinaturaId).HasColumnName("AssinaturaId");
            type.Property(t => t.Codigo).HasColumnName("Codigo").HasColumnType("varchar(255)");
            type.Property(t => t.Nome).HasColumnName("Nome").HasColumnType("varchar(255)");
            type.Property(t => t.Ativo).HasColumnName("Ativo");
            type.Property(t => t.DataCadastro).HasColumnName("DataCadastro");
            type.Property(t => t.VisibilidadeId).HasColumnName("VisibilidadeId");
            type.Property(t => t.Preco).HasColumnName("Preco");
            type.Property(t => t.Unidade).HasColumnName("Unidade").HasColumnType("varchar(50)");
            type.Property(t => t.ValorImpostos).HasColumnName("ValorImpostos");


            type.HasKey(d => new { d.ProdutoId, }); 

			CustomConfig(type);

        }
    }
}
