using LoongEgg.MvvmCore;
using System.Windows;
using System.Windows.Input;

/* 
 | 个人微信：InnerGeeker
 | 联系邮箱：LoongEgg@163.com 
 | 创建时间：2020/6/18 10:31:24
 | 主要用途：
 | 更改记录：
 | 时间	       版本        更改
 */
namespace LoongEgg.ViewBase.Controls
{
    /// <summary>
    ///     负责控制Windows的最大/最小化/还原和关闭窗口
    ///     NOTE: 使用语法
    ///         1.设置父级DataContext="{x:static DemoWindowStateManager.Instance}"
    ///         2.Button的Command="{Binding CommandClose}", CommandParameter="{Binding ElementName=thisWindow}"
    ///         3.thisWindow为要关闭的窗体名字
    ///         4.或者 CommandParameter="{Binding RelativeSource={RelativeSource AncestorType=Window}}"
    /// </summary>
    public class WindowStateViewModel: ViewModel
    {
        /// <summary>
        ///     所有窗口引用的都是同一个实例
        /// </summary>
        public static WindowStateViewModel Instance => _Instance ?? (_Instance = new WindowStateViewModel());
        private static WindowStateViewModel _Instance = null;

        public ICommand CommandMinimze { get; protected set; }
        public ICommand CommandMaximize { get; protected set; }
        public ICommand CommandClose { get; protected set; }

        private WindowStateViewModel()
        {
            CommandMinimze = new DelegateCommand<Window>((win) => win.WindowState = WindowState.Minimized);
            CommandMaximize = new DelegateCommand<Window>((win) => win.WindowState ^= WindowState.Maximized);
            CommandClose = new DelegateCommand<Window>((wind) => wind.Close());
        }
    }
}
