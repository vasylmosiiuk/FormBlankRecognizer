using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using FreshTinyIoC;
using PCLExt.AppDomain;

namespace FormVision.IoC
{
    public class ModulesInitializer
    {
        public async Task InitModules()
        {
            var moduleInterfaceTypeInfo = typeof (IModuleInitialization).GetTypeInfo();
            var modules =
                AppDomain.GetAssemblies()
                    .SelectMany(assembly => assembly.ExportedTypes.Select(x => x.GetTypeInfo()))
                    .Where(typeInfo => typeInfo.IsClass && !typeInfo.IsAbstract && moduleInterfaceTypeInfo.IsAssignableFrom(typeInfo))
                    .Select(typeInfo=>typeInfo.AsType()).ToArray();
            foreach (var module in modules)
            {
                var instance = (IModuleInitialization)FreshTinyIoCContainer.Current.Resolve(module);
                await instance.Init();
            }
        }
    }
}