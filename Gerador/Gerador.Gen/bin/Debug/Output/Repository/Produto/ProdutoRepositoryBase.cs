using Common.Orm;
using superacrm.ui.Core.Filters;
using superacrm.ui.Core.Data.Context;
using superacrm.ui.Core.Data.Model;
using System.Linq;
using System.Collections.Generic;

namespace superacrm.ui.Core.Data.Repository
{
    public class ProdutoRepositoryBase : Repository<Produto>
    {
        public ProdutoRepositoryBase(DbContextCore ctx) : base(ctx)
        {

        }
				
		public virtual IEnumerable<dynamic> GetDataItems(ProdutoFilter filters)
        {
            var querybase = this.GetAll();
            return this.GetAll().Select(_ => new { Id = _.ProdutoId, Name = _.Codigo });
        }

        protected IQueryable<Produto> SimpleFilters(ProdutoFilter filters, IQueryable<Produto> queryBase)
        {
			var queryFilter = queryBase;
            
            if (filters.ProdutoId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.ProdutoId == filters.ProdutoId);
			}
            if (filters.AssinaturaId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.AssinaturaId != null && _.AssinaturaId.Value == filters.AssinaturaId);
			}
            if (filters.Codigo.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.Codigo.Contains(filters.Codigo));
			}
            if (filters.Nome.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.Nome.Contains(filters.Nome));
			}
            if (filters.Ativo.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.Ativo == filters.Ativo);
			}
            if (filters.DataCadastroStart.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.DataCadastro >= filters.DataCadastroStart );
			}
            if (filters.DataCadastroEnd.IsSent()) 
			{ 
				filters.DataCadastroEnd = filters.DataCadastroEnd.AddDays(1).AddMilliseconds(-1);
				queryFilter = queryFilter.Where(_ => _.DataCadastro <= filters.DataCadastroEnd);
			}

            if (filters.VisibilidadeId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.VisibilidadeId == filters.VisibilidadeId);
			}
            if (filters.Preco.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.Preco == filters.Preco);
			}
            if (filters.Unidade.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.Unidade.Contains(filters.Unidade));
			}
            if (filters.ValorImpostos.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.ValorImpostos == filters.ValorImpostos);
			}


            return queryFilter;
        }
        
    }
}
