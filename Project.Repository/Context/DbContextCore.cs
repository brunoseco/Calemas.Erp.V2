using Microsoft.EntityFrameworkCore;
using CalemasERP.Core.Data.Maps;
using CalemasERP.Core.Data.Model;

namespace CalemasERP.Core.Data.Context
{
    public class DbContextCore: DbContext
    {

        public DbContextCore(DbContextOptions<DbContextCore> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new UnidadeMedidaMap(modelBuilder.Entity<UnidadeMedida>());
            new EstoqueMovimentacaoColaboradorMap(modelBuilder.Entity<EstoqueMovimentacaoColaborador>());
            new CategoriaEstoqueMap(modelBuilder.Entity<CategoriaEstoque>());
            new SolicitacaoEstoqueMap(modelBuilder.Entity<SolicitacaoEstoque>());
            new EstoqueMovimentacaoMap(modelBuilder.Entity<EstoqueMovimentacao>());
            new MotivoEstoqueMovimentacaoMap(modelBuilder.Entity<MotivoEstoqueMovimentacao>());
            new EstoqueMap(modelBuilder.Entity<Estoque>());

        }

    }
}