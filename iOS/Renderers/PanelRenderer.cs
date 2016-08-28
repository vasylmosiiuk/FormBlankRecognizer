using System;
using System.ComponentModel;
using CoreGraphics;
using FormVision.iOS.Renderers;
using FormVision.Views.Panel;
using NControl.iOS;
using UIKit;
using Xamarin.Forms;

[assembly: ExportRenderer(typeof (Panel), typeof (PanelRenderer))]

namespace FormVision.iOS.Renderers
{
    public class PanelRenderer : NControlViewRenderer
    {
        protected Panel Panel => Element as Panel;

        public override void Draw(CGRect rect)
        {
            Layer.MasksToBounds = false;
            var contentRect = new CGRect(Panel.ShadowRadius, Math.Max(0, Panel.ShadowOffset),
                rect.Width - 2*Panel.ShadowRadius,
                rect.Height - 2*Panel.ShadowRadius - Panel.ShadowOffset);
            Layer.ShadowOffset = new CGSize(0, Panel.ShadowOffset);
            Layer.ShadowOpacity = 0.6f;
            Layer.ShadowRadius = Panel.ShadowRadius;
            Layer.ShadowColor = Panel.HasShadow ? UIColor.Black.CGColor : UIColor.Clear.CGColor;

            base.Draw(contentRect);
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            switch (e.PropertyName)
            {
                case nameof(Panel.HasShadow):
                case nameof(Panel.ShadowOffset):
                case nameof(Panel.ShadowRadius):
                    SetNeedsDisplay();
                    break;
            }
        }
    }
}