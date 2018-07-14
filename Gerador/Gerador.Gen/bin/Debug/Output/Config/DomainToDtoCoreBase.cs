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

        }

    }
}
