using Calemas.Erp.Core.Dto;
using Calemas.Erp.Core.Data.Model;

namespace Calemas.Erp.Core.Services.Config
{
    public class ModelToDtoCoreBase : AutoMapper.Profile
    {

        public ModelToDtoCoreBase()
        {
            CreateMap(typeof(Contrato), typeof(ContratoDto)).ReverseMap();
            CreateMap(typeof(Contrato), typeof(ContratoDtoSave)).ReverseMap();
            CreateMap(typeof(Contrato), typeof(ContratoDtoResult)).ReverseMap();

        }

    }
}
