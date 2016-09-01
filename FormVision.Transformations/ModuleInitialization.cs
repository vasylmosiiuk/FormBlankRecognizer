using System.Threading.Tasks;
using FormVision.DO.Entities;
using FormVision.IoC;
using FormVision.Transformations.Mappers;
using FreshTinyIoC;

namespace FormVision.Transformations
{
    public class ModuleInitialization : IModuleInitialization
    {
        public Task Init()
        {
            return Task.Factory.StartNew(() =>
            {
                var ioc = FreshTinyIoCContainer.Current;
                ioc.Register<IEntityToModelMapper<RecognitionTask, Models.Models.RecognitionTask>,
                    GenericEntityToModelMapper<RecognitionTask, Models.Models.RecognitionTask>>().AsSingleton();
                ioc.Register<IModelToEntityMapper<Models.Models.RecognitionTask, RecognitionTask>,
                    GenericModelToEntityMapper<Models.Models.RecognitionTask, RecognitionTask>>().AsSingleton();
            });
        }
    }
}