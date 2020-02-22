using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace LoongEgg.ViewBase.Controls
{
    /// <summary>
    /// TextBlockCount.xaml 的交互逻辑
    /// </summary>
    public partial class TextBlockCount : UserControl
    {
        public TextBlockCount()
        {
            InitializeComponent();
        }

        [Description("输入的文本"), Category("LoongEgg")]
        public string Text {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register(
                nameof(Text), 
                typeof(string), 
                typeof(TextBlockCount), new PropertyMetadata("?"));

        [Description("计数菌"), Category("LoongEgg")]
        public int Count {
            get { return (int)GetValue(CountProperty); }
            set { SetValue(CountProperty, value); }
        }
        public static readonly DependencyProperty CountProperty =
            DependencyProperty.Register(
                nameof(Count), 
                typeof(int), 
                typeof(TextBlockCount), 
                new PropertyMetadata(0, OnCountChanged));

        private static void OnCountChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is TextBlockCount self)
            {
                self.count.Visibility = (self.Count > 1)?Visibility.Visible : Visibility.Hidden;
            }
        }
    }
}
