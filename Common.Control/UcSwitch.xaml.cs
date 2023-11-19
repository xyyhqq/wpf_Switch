using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Common.Control
{
    /// <summary>
    /// UcSwitch.xaml 的交互逻辑
    /// </summary>
    public partial class UcSwitch : UserControl
    {
        public UcSwitch()
        {
            InitializeComponent();
            PinChange();
        }

        public bool IsOn
        {
            get { return (bool)GetValue(IsOnProperty); }
            set { SetValue(IsOnProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsOn.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsOnProperty =
            DependencyProperty.Register("IsOn", typeof(bool), typeof(UcSwitch), new PropertyMetadata(false, new PropertyChangedCallback(ValueChangedCallback)));

        private static void ValueChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var ucSwitch = d as UcSwitch;

            ucSwitch.PinChange();
        }

        public string CloseText
        {
            get { return (string)GetValue(CloseTextProperty); }
            set { SetValue(CloseTextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CloseText.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CloseTextProperty =
            DependencyProperty.Register("CloseText", typeof(string), typeof(UcSwitch), new PropertyMetadata("关闭", new PropertyChangedCallback(ValueChangedCallback)));

        public string OpenText
        {
            get { return (string)GetValue(OpenTextProperty); }
            set { SetValue(OpenTextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for OpenText.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty OpenTextProperty =
            DependencyProperty.Register("OpenText", typeof(string), typeof(UcSwitch), new PropertyMetadata("开启", new PropertyChangedCallback(ValueChangedCallback)));

        public double OpenAngle
        {
            get { return (double)GetValue(OpenAngleProperty); }
            set { SetValue(OpenAngleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for OpenAngle.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty OpenAngleProperty =
            DependencyProperty.Register("OpenAngle", typeof(double), typeof(UcSwitch), new PropertyMetadata(-60d, new PropertyChangedCallback(ValueChangedCallback)));

        public double CloseAngle
        {
            get { return (double)GetValue(CloseAngleProperty); }
            set { SetValue(CloseAngleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CloseAngle.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CloseAngleProperty =
            DependencyProperty.Register("CloseAngle", typeof(double), typeof(UcSwitch), new PropertyMetadata(-120d, new PropertyChangedCallback(ValueChangedCallback)));

        public string OpenStatusColor
        {
            get { return (string)GetValue(OpenStatusColorProperty); }
            set { SetValue(OpenStatusColorProperty, value); }
        }

        // Using a DependencyProperty as the backing store for OpenStatusColor.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty OpenStatusColorProperty =
            DependencyProperty.Register("OpenStatusColor", typeof(string), typeof(UcSwitch), new PropertyMetadata("#0000ff", new PropertyChangedCallback(ValueChangedCallback)));

        public string CloseStatusColor
        {
            get { return (string)GetValue(CloseStatusColorProperty); }
            set { SetValue(CloseStatusColorProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CloseStatusColor.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CloseStatusColorProperty =
            DependencyProperty.Register("CloseStatusColor", typeof(string), typeof(UcSwitch), new PropertyMetadata("#ff0000", new PropertyChangedCallback(ValueChangedCallback)));

        public ICommand ActionCommand
        {
            get { return (ICommand)GetValue(ActionCommandProperty); }
            set { SetValue(ActionCommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ActionCommand.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ActionCommandProperty =
            DependencyProperty.Register("ActionCommand", typeof(ICommand), typeof(UcSwitch), new PropertyMetadata(default));

        private void PinChange()
        {
            //开启状态
            if (IsOn)
            {
                DoubleAnimation doubleAnimation = new DoubleAnimation(OpenAngle, TimeSpan.FromMilliseconds(500));
                this.ratedPin.BeginAnimation(RotateTransform.AngleProperty, doubleAnimation);

                this.pinText.Text = OpenText;
                statusEllipse.Fill = new SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString(OpenStatusColor));
                statusEllipseOutter.Fill = new SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString(OpenStatusColor));
            }
            else
            {
                DoubleAnimation doubleAnimation = new DoubleAnimation(CloseAngle, TimeSpan.FromMilliseconds(500));
                this.ratedPin.BeginAnimation(RotateTransform.AngleProperty, doubleAnimation);
                //关闭状态

                this.pinText.Text = CloseText;
                statusEllipse.Fill = new SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString(CloseStatusColor));
                statusEllipseOutter.Fill = new SolidColorBrush((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString(CloseStatusColor));
            }
        }

        private void Grid_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            this.IsOn = !this.IsOn;
            PinChange();
            ActionCommand?.Execute(this.IsOn);
        }
    }
}