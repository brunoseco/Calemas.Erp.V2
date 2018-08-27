using Common.Orm;
using CalemasERP.Core.Filters;
using CalemasERP.Core.Data.Context;
using CalemasERP.Core.Data.Model;
using System.Linq;
using System.Collections.Generic;

namespace CalemasERP.Core.Data.Repository
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
