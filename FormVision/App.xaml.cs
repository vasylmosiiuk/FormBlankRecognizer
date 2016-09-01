using System.Threading.Tasks;
using Acr.Settings;
using AutoMapper;
using AutoMapper.Mappers;
using FormVision.IoC;
using FormVision.PageModels;
using FreshMvvm;
using FreshTinyIoC;
using Realms;
using Xamarin.Forms;

namespace FormVision
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            var page = FreshPageModelResolver.ResolvePageModel<HomePageModel>();
            var basicNavContainer = new FreshNavigationContainer(page);
            basicNavContainer.SetValue(NavigationPage.BarTextColorProperty, Color.White);
            MainPage = basicNavContainer;
        }

        protected override async void OnStart()
        {
            InitMapper();
            FreshTinyIoCContainer.Current.Register(Realm.GetInstance());
            FreshTinyIoCContainer.Current.Register(Settings.Local);

            FreshTinyIoCContainer.Current.AutoRegister(new[] {typeof(App).Assembly});

            var modulesInitializer = new ModulesInitializer();
            await modulesInitializer.InitModules();
        }

        private void InitMapper()
        {
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}