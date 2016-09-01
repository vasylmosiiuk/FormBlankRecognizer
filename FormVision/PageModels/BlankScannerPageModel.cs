using System;
using System.Threading.Tasks;
using Rg.Plugins.Popup.Services;

namespace FormVision
{
	public class BlankScannerPageModel : PageModel
	{
		public BlankScannerPageModel()
		{
		}

		public override async void Init(object initData)
		{
			base.Init(initData);
			await Task.Delay(1000);
		    await PopupCoreMethods.PushPageModel<DemoPopupPageModel>();
		}

	    public override string PageTitle =>"";
	}
}

