using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;
using Point = NGraphics.Point;

namespace FormVision.Views
{
    public class RoundButton : Panel.Panel
    {
        public static readonly BindableProperty CommandProperty = BindableProperty.Create(nameof(Command),
            typeof (ICommand), typeof (RoundButton), null, propertyChanged: (b, o, n) => ((RoundButton)b).SubscribeOnCommandEvents((ICommand)o, (ICommand)n));
        
        public static readonly BindableProperty TextProperty = BindableProperty.Create(nameof(Text), typeof (string),
            typeof (RoundButton), null, propertyChanged: (b, o, n) => ((RoundButton) b)._label.Text = n as string);

        public static readonly BindableProperty TextAlignmentProperty = BindableProperty.Create(nameof(TextAlignment),
            typeof (TextAlignment),
            typeof (RoundButton), TextAlignment.Center,
            propertyChanged: (b, o, n) => ((RoundButton) b)._label.HorizontalTextAlignment = (TextAlignment) n);

        public static readonly BindableProperty TextColorProperty = BindableProperty.Create(nameof(TextColor),
            typeof (Color), typeof (RoundButton), Color.White,
            propertyChanged: (b, o, n) => ((RoundButton) b)._label.TextColor = (Color) n);

        public static readonly BindableProperty IsPressedProperty = BindableProperty.Create(nameof(IsPressed),
            typeof(bool), typeof(RoundButton), false, BindingMode.TwoWay,
            propertyChanged: (b, o, n) => ((RoundButton)b).Invalidate());

        private readonly Label _label;

        public RoundButton()
        {
            BackgroundColor = Color.Transparent;
            var rowTop = new RowDefinition {Height = new GridLength(0, GridUnitType.Star)};
            var rowMiddle = new RowDefinition {Height = new GridLength(1.0, GridUnitType.Star)};
            var rowBottom = new RowDefinition {Height = new GridLength(0, GridUnitType.Star)};
            _label = new Label
            {
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center,
                TextColor = Color.White
            };
            var grid = new Grid
            {
                RowDefinitions = new RowDefinitionCollection {rowTop, rowMiddle, rowBottom},
                Children = {{_label, 0, 1}}
            };
            Content = grid;
            IsEnabled = false;
        }

        public Color TextColor
        {
            get { return (Color) GetValue(TextColorProperty); }
            set { SetValue(TextColorProperty, value); }
        }

        public TextAlignment TextAlignment
        {
            get { return (TextAlignment) GetValue(TextAlignmentProperty); }
            set { SetValue(TextAlignmentProperty, value); }
        }

        public string Text
        {
            get { return (string) GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public ICommand Command
        {
            get { return (ICommand) GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        public bool IsPressed
        {
            get { return (bool) GetValue(IsPressedProperty); }
            set { SetValue(IsPressedProperty, value); }
        }

        public override bool TouchesBegan(IEnumerable<Point> points)
        {
            if (Command?.CanExecute(null) ?? false)
            {
                IsPressed = true;
                return true;
            }
            return base.TouchesBegan(points);
        }

        public override bool TouchesCancelled(IEnumerable<Point> points)
        {
            IsPressed = false;
            return base.TouchesCancelled(points);
        }

        public override bool TouchesEnded(IEnumerable<Point> points)
        {
            if (Command?.CanExecute(null) ?? false)
            {
                IsPressed = false;
                Invalidate();
                Command?.Execute(null);
            }
            return base.TouchesEnded(points);
        }
        private void SubscribeOnCommandEvents(ICommand oldValue, ICommand newValue)
        {
            if (oldValue != null)
                oldValue.CanExecuteChanged -= OnCommandCanExecuteChanged;
            if (newValue != null)
                newValue.CanExecuteChanged += OnCommandCanExecuteChanged;
            IsEnabled = newValue?.CanExecute(null) ?? false;
        }

        private void OnCommandCanExecuteChanged(object sender, EventArgs e)
        {
            IsEnabled = Command?.CanExecute(null)??false;
        }
    }
}