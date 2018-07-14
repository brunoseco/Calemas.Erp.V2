using Common.Orm;
using superacrm.ui.Core.Filters;
using superacrm.ui.Core.Data.Context;
using superacrm.ui.Core.Data.Model;
using System.Linq;

namespace superacrm.ui.Core.Data.Repository
{
    public class EmpresaRepository : EmpresaRepositoryBase
    {
        public EmpresaRepository(DbContextCore ctx) : base(ctx)
        {

        }

        public IQueryable<Empresa> GetByFilters(EmpresaFilter filters)
        {
            var querybase = this.GetAll();

            var queryFilter = this.SimpleFilters(filters, querybase);

            return queryFilter;
        }

        public Empresa GetById(EmpresaFilter filters)
        {
            var querybase = this.GetByFilters(filters);
            return querybase.SingleOrDefault();
        }

		public Empresa GetByModel(Empresa model)
        {
            return this.GetAll().Where(_ => _.EmpresaId == model.EmpresaId).SingleOrDefault();
        }

    }
}
