using AutoMapper;
using SimpleInjector;
using YunKe.Infrastructure;
using YunKe.Infrastructure.Caching;

namespace YunKe.Infrastructure.RedisCacheProvider
{
    public class RedisCacheModuleInitializer : ModuleInitializer
    {
        public override void LoadAutoMapper(IMapperConfiguration cofig)
        {

        }

        public override void LoadIoc(Container container)
        {
            container.Register<ICacheProvider, RedisCacheService>(Lifestyle.Scoped);
        }
    }
}
