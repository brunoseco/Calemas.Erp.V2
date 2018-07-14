using Common.Orm;
using calemaserp.ui.Core.Filters;
using calemaserp.ui.Core.Data.Context;
using calemaserp.ui.Core.Data.Model;
using System.Linq;
using System.Collections.Generic;

namespace calemaserp.ui.Core.Data.Repository
{
    public class UnidadeMedidaRepositoryBase : Repository<UnidadeMedida>
    {
        public UnidadeMedidaRepositoryBase(DbContextCore ctx) : base(ctx)
        {

        }
				
		public virtual IEnumerable<dynamic> GetDataItems(UnidadeMedidaFilter filters)
        {
            var querybase = this.GetAll();
            return this.GetAll().Select(_ => new { Id = _.UnidadeMedidaId, Name = _.Nome });
        }

        protected IQueryable<UnidadeMedida> SimpleFilters(UnidadeMedidaFilter filters, IQueryable<UnidadeMedida> queryBase)
        {
			var queryFilter = queryBase;
            
            if (filters.UnidadeMedidaId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.UnidadeMedidaId == filters.UnidadeMedidaId);
			}
            if (filters.Nome.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.Nome.Contains(filters.Nome));
			}


            return queryFilter;
        }
        
    }
}
