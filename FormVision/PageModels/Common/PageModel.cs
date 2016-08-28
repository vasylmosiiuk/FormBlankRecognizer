using System.Threading.Tasks;
using FormVision.Platform;
using FreshMvvm;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;

namespace FormVision
{
    public class PageModel : FreshBasePageModel
    {
        public PageModel()
        {
            PopupCoreMethods = new PopupCoreMethods(CurrentPage, this);
        }

        public PopupCoreMethods PopupCoreMethods { get; set; }

        public async Task PushPopupPageModel<TPopupViewModel>(bool animate = true)
            where TPopupViewModel : FreshBasePageModel
        {
            var page = FreshPageModelResolver.ResolvePageModel<TPopupViewModel>() as PopupPage;
            if (page != null)
                await PopupNavigation.PushAsync(page, animate);
        }
    }
}