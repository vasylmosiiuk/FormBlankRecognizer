using System;
using System.Threading.Tasks;
using FreshMvvm;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace FormVision.Platform
{
    public class PopupCoreMethods
    {
        private Page _currentPage;
        private FreshBasePageModel _currentPageModel;

        public PopupCoreMethods(Page currentPage, FreshBasePageModel pageModel)
        {
            _currentPage = currentPage;
            _currentPageModel = pageModel;
        }

        public async Task PushPageModel<T>(object data = null, bool animate = true) where T : FreshBasePageModel
        {
            var pageModel = FreshIOC.Container.Resolve<T>();

            await PushPageModel(pageModel, data, animate);
        }

        public async Task PushPageModel<T, TPopupPage>(object data = null, bool animate = true)
            where T : FreshBasePageModel where TPopupPage : PopupPage
        {
            var pageModel = FreshIOC.Container.Resolve<T>();
            var page = FreshIOC.Container.Resolve<TPopupPage>();
            FreshPageModelResolver.BindingPageModel(data, page, pageModel);
            await PushPageModelWithPage(page, animate);
        }

        public Task PushPageModel(Type pageModelType, bool animate = true)
        {
            return PushPageModel(pageModelType, null, animate);
        }

        public Task PushPageModel(Type pageModelType, object data = null, bool animate = true)
        {
            var pageModel = FreshIOC.Container.Resolve(pageModelType) as FreshBasePageModel;

            return PushPageModel(pageModel, data, animate);
        }

        private async Task PushPageModel(FreshBasePageModel pageModel, object data = null, bool animate = true)
        {
            var page = FreshPageModelResolver.ResolvePageModel(data, pageModel);
            FreshPageModelResolver.BindingPageModel(data, page, pageModel);

            if (page is PopupPage)
                await PushPageModelWithPage((PopupPage) page, animate);
            else
                throw new InvalidOperationException("Resolved page type is not PopupPage");
        }

        private async Task PushPageModelWithPage(PopupPage page, bool animate = true)
        {
            await PopupNavigation.PushAsync(page, animate);
        }

        public async Task PopPageModel(bool animate = true)
        {
           await PopupNavigation.PopAsync(animate);
        }

        public void PopAll()
        {
            PopupNavigation.PopAll();
        }
    }
}