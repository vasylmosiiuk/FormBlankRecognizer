using FormVision;
using FormVision.iOS;
using Xamarin.Forms;

[assembly: ExportRenderer(typeof(BlankScannerPage), typeof(BlankScannerPageRenderer))]
namespace FormVision.iOS
{
	public partial class BlankScannerPageRenderer : BasePageRenderer
	{
		public BlankScannerPageRenderer() : base(nameof(BlankScannerPageRenderer))
		{
		}

		protected override void OnElementPropertyChanged(string propertyName)
		{
			base.OnElementPropertyChanged(propertyName);
		}
	}
}


