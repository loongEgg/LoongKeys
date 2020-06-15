using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace LoongEgg.ViewBase.Styles
{
    public partial class BaseWindowStyle : ResourceDictionary
    {
        public BaseWindowStyle()
        {
            InitializeComponent();
        }

        private void Title_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Window win = (Window)((FrameworkElement)sender).TemplatedParent;
            win.DragMove();
        }
    }
}
