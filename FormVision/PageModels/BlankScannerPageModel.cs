using System;
using System.Threading.Tasks;

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
			await CoreMethods.PushPageModel<DemoPopupPageModel>(this, true);
		}
	}
}

