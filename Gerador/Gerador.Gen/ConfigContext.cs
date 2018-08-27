using Common.Gen;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gerador.Gen
{
    public class ConfigContext
    {
        #region Config Contexts

        private Context ConfigContextBack()
        {
            var contextName = "CalemasERP";

            return new Context
            {

                ConnectionString = ConfigurationManager.ConnectionStrings["CalemasERP"].ConnectionString,

                Namespace = contextName,
                Module = "Core",
                ContextName = contextName,
                ShowKeysInFront = true,
                LengthBigField = 250,

                OutputClassDomain = ConfigurationManager.AppSettings[string.Format("outputClassDomain")],
                OutputClassDto = ConfigurationManager.AppSettings[string.Format("outputClassDto")],
                OutputClassApp = ConfigurationManager.AppSettings[string.Format("outputClassApp")],
                OutputClassApi = ConfigurationManager.AppSettings[string.Format("outputClassApi")],
                OutputClassFilter = ConfigurationManager.AppSettings[string.Format("outputClassFilter")],

                OverrideFiles = false,

                Arquiteture = ArquitetureType.TableModel,

                TableInfo = new UniqueListTableInfo
                {
                    new TableInfo { TableName = "UnidadeMedida" },
                    new TableInfo { TableName = "EstoqueMovimentacaoColaborador" },
                    new TableInfo { TableName = "CategoriaEstoque" },
                    new TableInfo { TableName = "SolicitacaoEstoque" },
                    new TableInfo { TableName = "EstoqueMovimentacao" },
                    new TableInfo { TableName = "MotivoEstoqueMovimentacao" },
                    new TableInfo { TableName = "Estoque" },
                    

                }
            };
        }

        private Context ConfigContextFront()
        {
            return new Context
            {

                ConnectionString = ConfigurationManager.ConnectionStrings["CalemasERP"].ConnectionString,

                Namespace = "calemaserp.ui",
                Module = "Core",
                ContextName = "calemaserp.ui",

                OutputFrontend = ConfigurationManager.AppSettings["outputClassFrontend"],
                CamelCasing = true,
                MakeFront = true,
                AlertNotFoundTable = true,

                TableInfo = new UniqueListTableInfo
                {

                    new TableInfo { TableName = "UnidadeMedida", ClassNameFormated = "Unidade de Medida", MakeFront = true },
                    new TableInfo { TableName = "EstoqueMovimentacaoColaborador", ClassNameFormated = "Colaborador", MakeFront = true },
                    new TableInfo { TableName = "CategoriaEstoque", ClassNameFormated = "Categoria de Estoque", MakeFront = true },
                    new TableInfo { TableName = "SolicitacaoEstoque", ClassNameFormated = "Solicitação de Estoque", MakeFront = true },
                    new TableInfo { TableName = "EstoqueMovimentacao", ClassNameFormated = "Movimentação de Estoque", MakeFront = true },
                    new TableInfo { TableName = "MotivoEstoqueMovimentacao", ClassNameFormated = "Motivo de Movimentação de Estoque", MakeFront = true },
                    new TableInfo { TableName = "Estoque", ClassNameFormated = "Estoque", MakeFront = true },


                }
            };
        }


        public IEnumerable<Context> GetConfigContext()
        {
            return new List<Context>
            {
                ConfigContextBack(),
                ConfigContextFront()
            };
        }

        #endregion
    }
}
