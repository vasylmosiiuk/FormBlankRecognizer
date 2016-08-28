using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

namespace FormVision.iOS
{
	[Register("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		public override bool FinishedLaunching(UIApplication app, NSDictionary options)
		{
		    Plugin.Iconize.Iconize.With(new Plugin.Iconize.Fonts.MaterialModule());

            UIApplication.SharedApplication.SetStatusBarStyle(UIStatusBarStyle.LightContent, true);

            Rg.Plugins.Popup.IOS.Popup.Init();
            global::Xamarin.Forms.Forms.Init();
            FormsPlugin.Iconize.iOS.IconControls.Init();

            LoadApplication(new App());
			return base.FinishedLaunching(app, options);
		}
	}
}

