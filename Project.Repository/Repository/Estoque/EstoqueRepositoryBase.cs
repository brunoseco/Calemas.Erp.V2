using Common.Orm;
using CalemasERP.Core.Filters;
using CalemasERP.Core.Data.Context;
using CalemasERP.Core.Data.Model;
using System.Linq;
using System.Collections.Generic;

namespace CalemasERP.Core.Data.Repository
{
    public class EstoqueRepositoryBase : Repository<Estoque>
    {
        public EstoqueRepositoryBase(DbContextCore ctx) : base(ctx)
        {

        }
				
		public virtual IEnumerable<dynamic> GetDataItems(EstoqueFilter filters)
        {
            var querybase = this.GetAll();
            return this.GetAll().Select(_ => new { Id = _.EstoqueId, Name = _.Nome });
        }

        protected IQueryable<Estoque> SimpleFilters(EstoqueFilter filters, IQueryable<Estoque> queryBase)
        {
			var queryFilter = queryBase;
            
            if (filters.EstoqueId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.EstoqueId == filters.EstoqueId);
			}
            if (filters.Nome.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.Nome.Contains(filters.Nome));
			}
            if (filters.Descricao.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.Descricao.Contains(filters.Descricao));
			}
            if (filters.Modelo.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.Modelo.Contains(filters.Modelo));
			}
            if (filters.Fabricante.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.Fabricante.Contains(filters.Fabricante));
			}
            if (filters.Referencia.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.Referencia.Contains(filters.Referencia));
			}
            if (filters.UnidadeMedidaId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.UnidadeMedidaId == filters.UnidadeMedidaId);
			}
            if (filters.CategoriaEstoqueId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.CategoriaEstoqueId == filters.CategoriaEstoqueId);
			}
            if (filters.Observacao.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.Observacao.Contains(filters.Observacao));
			}
            if (filters.QuantidadeMinima.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.QuantidadeMinima == filters.QuantidadeMinima);
			}
            if (filters.Quantidade.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.Quantidade == filters.Quantidade);
			}
            if (filters.ValorVenda.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.ValorVenda != null && _.ValorVenda.Value == filters.ValorVenda);
			}
            if (filters.ValorCompra.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.ValorCompra != null && _.ValorCompra.Value == filters.ValorCompra);
			}
            if (filters.Ativo.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.Ativo == filters.Ativo);
			}
            if (filters.Localizacao.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.Localizacao.Contains(filters.Localizacao));
			}
            if (filters.UserCreateId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.UserCreateId == filters.UserCreateId);
			}
            if (filters.UserCreateDateStart.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.UserCreateDate >= filters.UserCreateDateStart );
			}
            if (filters.UserCreateDateEnd.IsSent()) 
			{ 
				filters.UserCreateDateEnd = filters.UserCreateDateEnd.AddDays(1).AddMilliseconds(-1);
				queryFilter = queryFilter.Where(_ => _.UserCreateDate <= filters.UserCreateDateEnd);
			}

            if (filters.UserAlterId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.UserAlterId != null && _.UserAlterId.Value == filters.UserAlterId);
			}
            if (filters.UserAlterDateStart.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.UserAlterDate != null && _.UserAlterDate.Value >= filters.UserAlterDateStart.Value);
			}
            if (filters.UserAlterDateEnd.IsSent()) 
			{ 
				filters.UserAlterDateEnd = filters.UserAlterDateEnd.Value.AddDays(1).AddMilliseconds(-1);
				queryFilter = queryFilter.Where(_ => _.UserAlterDate != null &&  _.UserAlterDate.Value <= filters.UserAlterDateEnd);
			}



            return queryFilter;
        }
        
    }
}
