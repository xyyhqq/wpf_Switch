using System;
using System.Collections.Generic;
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
    /// Thermometer.xaml 的交互逻辑
    /// </summary>
    public partial class Thermometer : UserControl
    {
        public Thermometer()
        {
            InitializeComponent();

            TickRepaint();
        }

        public int Minimun
        {
            get { return (int)GetValue(MinimunProperty); }
            set { SetValue(MinimunProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Minimun.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MinimunProperty =
            DependencyProperty.Register("Minimun", typeof(int), typeof(Thermometer), new PropertyMetadata(-20));

        public int Maximun
        {
            get { return (int)GetValue(MaximunProperty); }
            set { SetValue(MaximunProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Maximun.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MaximunProperty =
            DependencyProperty.Register("Maximun", typeof(int), typeof(Thermometer), new PropertyMetadata(50, new PropertyChangedCallback(ValueChanged)));

        public int DisplayValue
        {
            get { return (int)GetValue(DisplayValueProperty); }
            set { SetValue(DisplayValueProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DisplayValue.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DisplayValueProperty =
            DependencyProperty.Register("DisplayValue", typeof(int), typeof(Thermometer), new PropertyMetadata(0, new PropertyChangedCallback(ValueChanged)));

        public static void ValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Thermometer thermometer = d as Thermometer;
            thermometer.TickRepaint();
        }

        private void TickRepaint()
        {
            this.tickBorder.Children.Clear();
            //格子数量
            double allstep = (this.Maximun - this.Minimun) * 1.0 / 2;
            double allBoder = 121;
            //每隔刻度对于的boder长度
            double oneStep = allBoder * 1.0 / allstep;
            for (int i = 0; i <= allstep; i++)
            {
                Line line = new Line();
                line.X1 = 0;
                line.Y1 = i * oneStep;
                line.X2 = 10;
                line.Y2 = i * oneStep;
                line.Stroke = new SolidColorBrush(Colors.White);
                line.StrokeThickness = 1;
                this.tickBorder.Children.Add(line);
                if (i % 2.5 != 0)
                {
                    line.X2 = 4.5;
                }
                else
                {
                    TextBlock textBlock = new TextBlock();
                    textBlock.Text = (Maximun - i * 2).ToString();
                    textBlock.Width = 20;
                    textBlock.FontSize = 9;
                    textBlock.TextAlignment = TextAlignment.Right;
                    textBlock.Margin = new Thickness(11, i * oneStep - 5, 0, 0);

                    this.tickBorder.Children.Add(textBlock);
                }
            }
            if (DisplayValue > Maximun)
            {
                DisplayValue = Maximun;
            }
            if (DisplayValue < Minimun)
            {
                DisplayValue = Minimun;
            }
            //一个代表两个
            double val = (DisplayValue - Minimun) * (oneStep / 2) + 11;
            DoubleAnimation doubleAnimation = new DoubleAnimation(val, TimeSpan.FromMilliseconds(500));
            displayHeightBorder.BeginAnimation(HeightProperty, doubleAnimation);
        }
    }
}