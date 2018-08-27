using Common.Orm;
using calemaserp.ui.Core.Filters;
using calemaserp.ui.Core.Data.Context;
using calemaserp.ui.Core.Data.Model;
using System.Linq;

namespace calemaserp.ui.Core.Data.Repository
{
    public class CategoriaEstoqueRepository : CategoriaEstoqueRepositoryBase
    {
        public CategoriaEstoqueRepository(DbContextCore ctx) : base(ctx)
        {

        }

        public IQueryable<CategoriaEstoque> GetByFilters(CategoriaEstoqueFilter filters)
        {
            var querybase = this.GetAll();

            var queryFilter = this.SimpleFilters(filters, querybase);

            return queryFilter;
        }

        public CategoriaEstoque GetById(CategoriaEstoqueFilter filters)
        {
            var querybase = this.GetByFilters(filters);
            return querybase.SingleOrDefault();
        }

		public CategoriaEstoque GetByModel(CategoriaEstoque model)
        {
            return this.GetAll().Where(_ => _.CategoriaEstoqueId == model.CategoriaEstoqueId).SingleOrDefault();
        }

    }
}
