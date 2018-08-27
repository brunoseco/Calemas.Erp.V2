using Common.Orm;
using calemaserp.ui.Core.Filters;
using calemaserp.ui.Core.Data.Context;
using calemaserp.ui.Core.Data.Model;
using System.Linq;
using System.Collections.Generic;

namespace calemaserp.ui.Core.Data.Repository
{
    public class CategoriaEstoqueRepositoryBase : Repository<CategoriaEstoque>
    {
        public CategoriaEstoqueRepositoryBase(DbContextCore ctx) : base(ctx)
        {

        }
				
		public virtual IEnumerable<dynamic> GetDataItems(CategoriaEstoqueFilter filters)
        {
            var querybase = this.GetAll();
            return this.GetAll().Select(_ => new { Id = _.CategoriaEstoqueId, Name = _.Nome });
        }

        protected IQueryable<CategoriaEstoque> SimpleFilters(CategoriaEstoqueFilter filters, IQueryable<CategoriaEstoque> queryBase)
        {
			var queryFilter = queryBase;
            
            if (filters.CategoriaEstoqueId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.CategoriaEstoqueId == filters.CategoriaEstoqueId);
			}
            if (filters.Nome.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.Nome.Contains(filters.Nome));
			}


            return queryFilter;
        }
        
    }
}
