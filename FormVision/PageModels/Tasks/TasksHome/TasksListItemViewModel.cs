using PropertyChanged;

namespace FormVision.PageModels.Tasks.TasksHome
{
    [ImplementPropertyChanged]
    public class TasksListItemViewModel
    {
        public string Title { get; set; }
        public string Comment { get; set; }
    }
}