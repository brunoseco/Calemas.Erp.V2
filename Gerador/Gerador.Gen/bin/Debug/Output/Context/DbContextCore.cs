using Microsoft.EntityFrameworkCore;
using calemaserp.ui.Core.Data.Maps;
using calemaserp.ui.Core.Data.Model;

namespace calemaserp.ui.Core.Data.Context
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