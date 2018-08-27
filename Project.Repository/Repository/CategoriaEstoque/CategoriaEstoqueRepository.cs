using Common.Orm;
using CalemasERP.Core.Filters;
using CalemasERP.Core.Data.Context;
using CalemasERP.Core.Data.Model;
using System.Linq;

namespace CalemasERP.Core.Data.Repository
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
