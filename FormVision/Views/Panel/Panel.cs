using FormVision.Helpers;
using NControl.Abstractions;
using NGraphics;
using Xamarin.Forms;
using Color = Xamarin.Forms.Color;
using Size = NGraphics.Size;

namespace FormVision.Views.Panel
{
    public class Panel : NControlView
    {
        public static readonly BindableProperty BorderColorProperty = BindableProperty.Create(nameof(BorderColor),
            typeof (Color), typeof (Panel),
            Color.Transparent, propertyChanged: (b, o, n) => ((Panel) b).InvalidatePen());

        public static readonly BindableProperty FillColorProperty = BindableProperty.Create(nameof(FillColor),
            typeof (Color), typeof (Panel),
            Color.Transparent, propertyChanged: (b, o, n) => ((Panel) b).InvalidateBrush());

        public static readonly BindableProperty BorderWidthProperty = BindableProperty.Create(nameof(BorderWidth),
            typeof (double), typeof (Panel),
            0.0, propertyChanged: (b, o, n) => ((Panel) b).InvalidatePen());

        public static readonly BindableProperty CornerRadiusProperty = BindableProperty.Create(nameof(CornerRadius),
            typeof (double), typeof (Panel),
            0.0, propertyChanged: (b, o, n) => ((Panel) b).Invalidate());

        public static BindableProperty HasShadowProperty =
            BindableProperty.Create(nameof(HasShadow), typeof (bool), typeof (Panel), false);

        public static BindableProperty ShadowOffsetProperty =
            BindableProperty.Create(nameof(ShadowOffset), typeof (int), typeof (Panel), 0);

        public static BindableProperty ShadowRadiusProperty =
            BindableProperty.Create(nameof(ShadowRadius), typeof (int), typeof (Panel), 0);

        private Pen _borderPen;
        private Brush _fillBrush;

        public Panel()
        {
            _borderPen = new Pen(BorderColor.ToNColor(), BorderWidth);
            _fillBrush = new SolidBrush(FillColor.ToNColor());
        }

        public Color FillColor
        {
            get { return (Color) GetValue(FillColorProperty); }
            set { SetValue(FillColorProperty, value); }
        }

        public Color BorderColor
        {
            get { return (Color) GetValue(BorderColorProperty); }
            set { SetValue(BorderColorProperty, value); }
        }

        public double BorderWidth
        {
            get { return (double) GetValue(BorderWidthProperty); }
            set { SetValue(BorderWidthProperty, value); }
        }

        public double CornerRadius
        {
            get { return (double) GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        public bool HasShadow
        {
            get { return (bool) GetValue(HasShadowProperty); }
            set { SetValue(HasShadowProperty, value); }
        }

        public int ShadowOffset
        {
            get { return (int) GetValue(ShadowOffsetProperty); }
            set { SetValue(ShadowOffsetProperty, value); }
        }

        public int ShadowRadius
        {
            get { return (int) GetValue(ShadowRadiusProperty); }
            set { SetValue(ShadowRadiusProperty, value); }
        }

        public override void Draw(ICanvas canvas, Rect rect)
        {
            canvas.DrawRectangle(rect, new Size(CornerRadius), _borderPen, _fillBrush);

            base.Draw(canvas, rect);
        }

        private void InvalidatePen()
        {
            _borderPen = new Pen(BorderColor.ToNColor(), BorderWidth);
            Invalidate();
        }

        private void InvalidateBrush()
        {
            _fillBrush = new SolidBrush(FillColor.ToNColor());
            Invalidate();
        }
    }
}