using System.Threading.Tasks;
using FormVision.DO.Entities;
using FormVision.IoC;
using FormVision.Services.Abstractions.Repositories;
using FormVision.Services.Implementation.Repositories;
using FreshTinyIoC;

namespace FormVision.Services.Implementation
{
    public class ModuleInitialization : IModuleInitialization
    {
        public Task Init()
        {
            return Task.Factory.StartNew(() =>
            {
                var ioc = FreshTinyIoCContainer.Current;

                ioc.Register<IUnitOfWork, RealmUnitOfWork>();

                ioc.Register<IRepository<RecognitionTask, Models.Models.RecognitionTask>,
                    GenericRealmRepository<RecognitionTask, Models.Models.RecognitionTask>>().AsSingleton();
            });
        }
    }
}