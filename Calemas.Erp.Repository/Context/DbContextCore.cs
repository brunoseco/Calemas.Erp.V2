using Microsoft.EntityFrameworkCore;
using Calemas.Erp.Core.Data.Maps;
using Calemas.Erp.Core.Data.Model;

namespace Calemas.Erp.Core.Data.Context
{
    public class DbContextCore: DbContext
    {

        public DbContextCore(DbContextOptions<DbContextCore> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new ChangeLogMap(modelBuilder.Entity<ChangeLog>());

        }

    }
}