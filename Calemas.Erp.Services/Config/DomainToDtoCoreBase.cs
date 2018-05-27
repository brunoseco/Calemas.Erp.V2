using Calemas.Erp.Core.Dto;
using Calemas.Erp.Core.Data.Model;

namespace Calemas.Erp.Core.Services.Config
{
    public class ModelToDtoCoreBase : AutoMapper.Profile
    {

        public ModelToDtoCoreBase()
        {
            CreateMap(typeof(ChangeLog), typeof(ChangeLogDto)).ReverseMap();
            CreateMap(typeof(ChangeLog), typeof(ChangeLogDtoSave)).ReverseMap();
            CreateMap(typeof(ChangeLog), typeof(ChangeLogDtoResult)).ReverseMap();

        }

    }
}
