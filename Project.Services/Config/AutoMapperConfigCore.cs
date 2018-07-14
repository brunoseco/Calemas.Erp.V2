using AutoMapper;

namespace CalemasERP.Core.Services.Config
{
	public class AutoMapperConfigCore
    {
		public static void RegisterMappings()
		{

			Mapper.Initialize(x =>
			{
				x.AddProfile<ModelToDtoCoreBase>();
				x.AddProfile<ModelToDtoCore>();
			});

		}
	}
}
