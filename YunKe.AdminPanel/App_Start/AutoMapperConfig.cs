using AutoMapper;
using WebGrease.Css.Extensions;
using YunKe.AdminPanelCore.Services;
using YunKe.AppService.Core;
using YunKe.Infrastructure;

namespace YunKe.AdminPanel
{
    /// <summary>
    /// AutoMapperConfig
    /// </summary>
    public class AutoMapperConfig
    {
        private static MapperConfiguration _mapperConfiguration;

        /// <summary>
        /// 
        /// </summary>
        public static void Register()
        {
            var moduleInitializers = new ModuleInitializer[]
            {
                new AdminCoreModuleInitializer(),
                new YunKeModuleInitializer(),
            };

            _mapperConfiguration = new MapperConfiguration(cfg =>
            {
                moduleInitializers.ForEach(m => m.LoadAutoMapper(cfg));
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static MapperConfiguration GetMapperConfiguration()
        {
            if(_mapperConfiguration == null)
                Register();

            return _mapperConfiguration;
        }
    }
}