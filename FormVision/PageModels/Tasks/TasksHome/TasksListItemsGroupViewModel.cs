using System.Collections.Generic;
using System.Collections.ObjectModel;
using PropertyChanged;
using Xamarin.Forms;

namespace FormVision.PageModels.Tasks.TasksHome
{
    [ImplementPropertyChanged]
    public class TasksListItemsGroupViewModel : ObservableCollection<TasksListItemViewModel>
    {
        public TasksListItemsGroupViewModel()
        {
        }

        public TasksListItemsGroupViewModel(IEnumerable<TasksListItemViewModel> items) : base(items)
        {
        }

        public string Title { get; set; }
        public string Description { get; set; }
        public Color BackgroundColor { get; set; }
    }
}