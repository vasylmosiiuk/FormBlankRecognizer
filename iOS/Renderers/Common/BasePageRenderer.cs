using System.ComponentModel;
using Foundation;
using Xamarin.Forms.Platform.iOS;

namespace FormVision.iOS
{
	public abstract class BasePageRenderer : PageRenderer
	{
        protected BasePageRenderer()
	    {
	        
	    }
		protected BasePageRenderer(string nibName)
		{
			NSBundle.MainBundle.LoadNib(nibName, this, null);
		}

		protected override void OnElementChanged(VisualElementChangedEventArgs e)
		{
			if (e.OldElement != null)
				e.OldElement.PropertyChanged -= OnElementPropertyChangedHandler;
			base.OnElementChanged(e);
			if (e.NewElement != null)
				e.NewElement.PropertyChanged += OnElementPropertyChangedHandler;
		}

		void OnElementPropertyChangedHandler(object sender, PropertyChangedEventArgs e)
		{
			OnElementPropertyChanged(e.PropertyName);
		}

		protected virtual void OnElementPropertyChanged(string propertyName)
		{
		}

		protected override void Dispose(bool disposing)
		{
			if (Element != null)
				Element.PropertyChanged -= OnElementPropertyChangedHandler;

			base.Dispose(disposing);
		}
	}
}

