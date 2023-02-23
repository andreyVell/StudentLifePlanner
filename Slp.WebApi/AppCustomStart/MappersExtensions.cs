using AutoMapper;
using Slp.Mappers;

namespace Slp.WebApi.AppCustomStart
{
    public static class MappersExtensions
    {
        public static void AddCustomAutoMapper(this IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new ApiMappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
