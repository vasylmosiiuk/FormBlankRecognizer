using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using FormVision.Enums;
using FormVision.Models.Models;
using FormVision.PageModels.Tasks.TasksHome;
using FormVision.Resources.Localization;
using FormVision.Services.Abstractions.Repositories;
using FreshMvvm;
using FreshTinyIoC;
using PropertyChanged;
using Xamarin.Forms;

namespace FormVision.PageModels
{
    [ImplementPropertyChanged]
    public class TasksPageModel : PageModel
    {
        private readonly IRepository<DO.Entities.RecognitionTask, RecognitionTask> _tasksRepository;
        private readonly Command _createNewTaskCommand;

        public TasksPageModel(IRepository<DO.Entities.RecognitionTask, RecognitionTask> tasksRepository)
        {
            _tasksRepository = tasksRepository;
            _createNewTaskCommand = new Command(CreateNewTask, CanCreateNewTask);
        }

        public ObservableCollection<TasksListItemsGroupViewModel> TasksGroups { get; set; }

        public override string PageTitle => Strings.TasksPage_PageTitle;

        public ICommand CreateNewTaskCommand => _createNewTaskCommand;

        private bool CanCreateNewTask()
        {
            return true;
        }

        private void CreateNewTask()
        {
        }

        public override async void Init(object initData)
        {
            base.Init(initData);

            await LoadUserTasks();
        }

        private async Task LoadUserTasks()
        {
            var uow = FreshTinyIoCContainer.Current.Resolve<IUnitOfWork>();
            uow.ExecuteInTransactionScope(() =>
            {
                RecognitionTask taskToAdd = new RecognitionTask() {Title = "Test task 1", Comment = "this is test task 1 comment", Group = TaskGroupKind.Archived};
                var savedTask =_tasksRepository.Save(taskToAdd);
            });
            var tasks = (await _tasksRepository.Query()).ToArray();
        }
    }
}