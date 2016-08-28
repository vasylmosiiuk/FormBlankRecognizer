using Xamarin.Forms;

namespace FormVision.Pages.Common
{
    [ContentProperty(nameof(ContentContainerContent))]
    public abstract class XFormsPage : ContentPage
    {
        protected XFormsPage()
        {
            TopBarContainer = new ContentView
            {
                Padding = 0
            };
            ContentContainer = new ContentView
            {
                Padding = 0
            };
            BottomBarContainer = new ContentView
            {
                Padding = 0
            };

            var rootLayout = new StackLayout {Orientation = StackOrientation.Vertical, Spacing = 0};
#if __IOS__
            rootLayout.Children.Add(new BoxView
            {
                HeightRequest = 20,
                BackgroundColor = (Color) Application.Current.Resources["ColorShade700"]
            });
#endif
            var mainContent = 
                new Grid
                {
                    RowDefinitions =
                    {
                        new RowDefinition {Height = GridLength.Auto},
                        new RowDefinition(),
                        new RowDefinition {Height = GridLength.Auto}
                    },
                    VerticalOptions = LayoutOptions.FillAndExpand,
                    RowSpacing = 0,
                    Children = {{TopBarContainer, 0, 0}, {ContentContainer, 0, 1}, {BottomBarContainer, 0, 2}}
                };
            
            rootLayout.Children.Add(mainContent);
            base.Content = rootLayout;
            NavigationPage.SetHasNavigationBar(this, false);
        }

        public new View Content
        {
            get { return ContentContainerContent; }
            set { ContentContainerContent = value; }
        }

        public View TopBarContent
        {
            get { return TopBarContainer.Content; }
            set { TopBarContainer.Content = value; }
        }

        public View ContentContainerContent
        {
            get { return ContentContainer.Content; }
            set { ContentContainer.Content = value; }
        }

        public View BottomBarContent
        {
            get { return BottomBarContainer.Content; }
            set { BottomBarContainer.Content = value; }
        }

        protected ContentView BottomBarContainer { get; }

        protected ContentView ContentContainer { get; }

        protected ContentView TopBarContainer { get; }
    }
}