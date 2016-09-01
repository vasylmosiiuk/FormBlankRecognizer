using System.Windows.Input;
using FormVision.Resources.Localization;
using Xamarin.Forms;

namespace FormVision.PageModels
{
    public class HomePageModel : PageModel
    {
        private readonly Command _navigateToDataCommand;
        private readonly Command _navigateToProfileCommand;
        private readonly Command _navigateToSettingsCommand;
        private readonly Command _navigateToTasksCommand;

        public HomePageModel()
        {
            _navigateToSettingsCommand = new Command(NavigateToSettings, CanNavigateToSettingsCommand);
            _navigateToDataCommand = new Command(NavigateToData, CanNavigateToData);
            _navigateToTasksCommand = new Command(NavigateToTasks, CanNavigateToTasks);
            _navigateToProfileCommand = new Command(NavigateToProfile, CanNavigateToProfile);
        }

        public override string PageTitle => Strings.HomePage_PageTitle;

        public ICommand NavigateToSettingsCommand => _navigateToSettingsCommand;
        public ICommand NavigateToDataCommand => _navigateToDataCommand;
        public ICommand NavigateToTasksCommand => _navigateToTasksCommand;
        public ICommand NavigateToProfileCommand => _navigateToProfileCommand;

        private bool CanNavigateToProfile()
        {
            return true;
        }

        private void NavigateToProfile()
        {
            CoreMethods.PushPageModel<ProfilePageModel>();
        }

        private bool CanNavigateToTasks()
        {
            return true;
        }

        private void NavigateToTasks()
        {
            CoreMethods.PushPageModel<TasksPageModel>();
        }

        private bool CanNavigateToData()
        {
            return true;
        }

        private void NavigateToData()
        {
            CoreMethods.PushPageModel<DataPageModel>();
        }

        private bool CanNavigateToSettingsCommand()
        {
            return true;
        }

        private void NavigateToSettings()
        {
            CoreMethods.PushPageModel<SettingsPageModel>();
        }
    }
}