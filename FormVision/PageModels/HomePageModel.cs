using System.Windows.Input;
using Xamarin.Forms;

namespace FormVision.PageModels
{
    public class HomePageModel : PageModel
    {
        public HomePageModel()
        {
            NavigateToSettingsCommand = new Command(NavigateToSettings, CanNavigateToSettingsCommand);
        }

        private bool CanNavigateToSettingsCommand()
        {
            return true;
        }

        private void NavigateToSettings()
        {
            
        }

        public ICommand NavigateToSettingsCommand { get; }
    }
}