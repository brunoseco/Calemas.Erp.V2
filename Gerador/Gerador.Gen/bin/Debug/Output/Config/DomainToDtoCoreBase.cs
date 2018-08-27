using calemaserp.ui.Core.Dto;
using calemaserp.ui.Core.Data.Model;

namespace calemaserp.ui.Core.Services.Config
{
    public class ModelToDtoCoreBase : AutoMapper.Profile
    {

        public ModelToDtoCoreBase()
        {
            CreateMap(typeof(UnidadeMedida), typeof(UnidadeMedidaDto)).ReverseMap();
            CreateMap(typeof(UnidadeMedida), typeof(UnidadeMedidaDtoSave)).ReverseMap();
            CreateMap(typeof(UnidadeMedida), typeof(UnidadeMedidaDtoResult)).ReverseMap();
            CreateMap(typeof(UnidadeMedida), typeof(UnidadeMedidaDtoDetail)).ReverseMap();
            CreateMap(typeof(EstoqueMovimentacaoColaborador), typeof(EstoqueMovimentacaoColaboradorDto)).ReverseMap();
            CreateMap(typeof(EstoqueMovimentacaoColaborador), typeof(EstoqueMovimentacaoColaboradorDtoSave)).ReverseMap();
            CreateMap(typeof(EstoqueMovimentacaoColaborador), typeof(EstoqueMovimentacaoColaboradorDtoResult)).ReverseMap();
            CreateMap(typeof(EstoqueMovimentacaoColaborador), typeof(EstoqueMovimentacaoColaboradorDtoDetail)).ReverseMap();
            CreateMap(typeof(CategoriaEstoque), typeof(CategoriaEstoqueDto)).ReverseMap();
            CreateMap(typeof(CategoriaEstoque), typeof(CategoriaEstoqueDtoSave)).ReverseMap();
            CreateMap(typeof(CategoriaEstoque), typeof(CategoriaEstoqueDtoResult)).ReverseMap();
            CreateMap(typeof(CategoriaEstoque), typeof(CategoriaEstoqueDtoDetail)).ReverseMap();
            CreateMap(typeof(SolicitacaoEstoque), typeof(SolicitacaoEstoqueDto)).ReverseMap();
            CreateMap(typeof(SolicitacaoEstoque), typeof(SolicitacaoEstoqueDtoSave)).ReverseMap();
            CreateMap(typeof(SolicitacaoEstoque), typeof(SolicitacaoEstoqueDtoResult)).ReverseMap();
            CreateMap(typeof(SolicitacaoEstoque), typeof(SolicitacaoEstoqueDtoDetail)).ReverseMap();
            CreateMap(typeof(EstoqueMovimentacao), typeof(EstoqueMovimentacaoDto)).ReverseMap();
            CreateMap(typeof(EstoqueMovimentacao), typeof(EstoqueMovimentacaoDtoSave)).ReverseMap();
            CreateMap(typeof(EstoqueMovimentacao), typeof(EstoqueMovimentacaoDtoResult)).ReverseMap();
            CreateMap(typeof(EstoqueMovimentacao), typeof(EstoqueMovimentacaoDtoDetail)).ReverseMap();
            CreateMap(typeof(MotivoEstoqueMovimentacao), typeof(MotivoEstoqueMovimentacaoDto)).ReverseMap();
            CreateMap(typeof(MotivoEstoqueMovimentacao), typeof(MotivoEstoqueMovimentacaoDtoSave)).ReverseMap();
            CreateMap(typeof(MotivoEstoqueMovimentacao), typeof(MotivoEstoqueMovimentacaoDtoResult)).ReverseMap();
            CreateMap(typeof(MotivoEstoqueMovimentacao), typeof(MotivoEstoqueMovimentacaoDtoDetail)).ReverseMap();
            CreateMap(typeof(Estoque), typeof(EstoqueDto)).ReverseMap();
            CreateMap(typeof(Estoque), typeof(EstoqueDtoSave)).ReverseMap();
            CreateMap(typeof(Estoque), typeof(EstoqueDtoResult)).ReverseMap();
            CreateMap(typeof(Estoque), typeof(EstoqueDtoDetail)).ReverseMap();

        }

    }
}
