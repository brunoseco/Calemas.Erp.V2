using CalemasERP.Core.Dto;
using CalemasERP.Core.Data.Model;

namespace CalemasERP.Core.Services.Config
{
    public class ModelToDtoCoreBase : AutoMapper.Profile
    {

        public ModelToDtoCoreBase()
        {
            CreateMap(typeof(UnidadeMedida), typeof(UnidadeMedidaDto)).ReverseMap();
            CreateMap(typeof(UnidadeMedida), typeof(UnidadeMedidaDtoSave)).ReverseMap();
            CreateMap(typeof(UnidadeMedida), typeof(UnidadeMedidaDtoResult)).ReverseMap();
            CreateMap(typeof(UnidadeMedida), typeof(UnidadeMedidaDtoDetail)).ReverseMap();

        }

    }
}
