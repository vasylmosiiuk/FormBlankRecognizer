using FormVision.PageModels;
using FreshMvvm;
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

		protected override void OnStart()
		{
			// Handle when your app starts
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

