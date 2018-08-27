using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CalemasERP.Core.Data.Model;

namespace CalemasERP.Core.Data.Maps
{
    public abstract class EstoqueMapBase
    {
        protected abstract void CustomConfig(EntityTypeBuilder<Estoque> type);

        public EstoqueMapBase(EntityTypeBuilder<Estoque> type)
        {
            type.ToTable("Estoque");

            type.Property(t => t.EstoqueId).HasColumnName("Id");


            type.Property(t => t.Nome).HasColumnName("Nome").HasColumnType("varchar(500)");
            type.Property(t => t.Descricao).HasColumnName("Descricao").HasColumnType("varchar(500)");
            type.Property(t => t.Modelo).HasColumnName("Modelo").HasColumnType("varchar(100)");
            type.Property(t => t.Fabricante).HasColumnName("Fabricante").HasColumnType("varchar(100)");
            type.Property(t => t.Referencia).HasColumnName("Referencia").HasColumnType("varchar(100)");
            type.Property(t => t.UnidadeMedidaId).HasColumnName("UnidadeMedidaId");
            type.Property(t => t.CategoriaEstoqueId).HasColumnName("CategoriaEstoqueId");
            type.Property(t => t.Observacao).HasColumnName("Observacao").HasColumnType("varchar(500)");
            type.Property(t => t.QuantidadeMinima).HasColumnName("QuantidadeMinima");
            type.Property(t => t.Quantidade).HasColumnName("Quantidade");
            type.Property(t => t.ValorVenda).HasColumnName("ValorVenda");
            type.Property(t => t.ValorCompra).HasColumnName("ValorCompra");
            type.Property(t => t.Ativo).HasColumnName("Ativo");
            type.Property(t => t.Localizacao).HasColumnName("Localizacao").HasColumnType("varchar(50)");
            type.Property(t => t.UserCreateId).HasColumnName("UserCreateId");
            type.Property(t => t.UserCreateDate).HasColumnName("UserCreateDate");
            type.Property(t => t.UserAlterId).HasColumnName("UserAlterId");
            type.Property(t => t.UserAlterDate).HasColumnName("UserAlterDate");


            type.HasKey(d => new { d.EstoqueId, }); 

			CustomConfig(type);

        }
    }
}
