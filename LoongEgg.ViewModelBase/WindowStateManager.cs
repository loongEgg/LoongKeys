using System.Windows;
using System.Windows.Input;

namespace LoongEgg.ViewModelBase
{
    /// <summary>
    ///     负责控制Windows的最大/最小化/还原和关闭窗口
    ///     NOTE: 使用语法
    ///         1.设置父级DataContext="{x:static DemoWindowStateManager.Instance}"
    ///         2.Button的Command="{Binding CommandClose}", CommandParameter="{Binding ElementName=thisWindow}"
    ///         3.thisWindow为要关闭的窗体名字
    ///         4.或者 CommandParameter="{Binding RelativeSource={RelativeSource AncestorType=Window}}"
    /// </summary>
    public class WindowStateManager : _WindowStateManager
    {
        /// <summary>
        ///     所有窗口引用的都是同一个实例
        /// </summary>
        public static WindowStateManager Instance => _Instance ?? (_Instance = new WindowStateManager());
        private static WindowStateManager _Instance = null;

        private WindowStateManager()
        {
            CommandMinimze = new RelayCommand<Window>((win) => win.WindowState = WindowState.Minimized);
            CommandMaximize = new RelayCommand<Window>((win) => win.WindowState ^= WindowState.Maximized);
            CommandClose = new RelayCommand<Window>((wind) => wind.Close());
        }
    }

    /// <summary>
    ///  随个人喜好增减功能
    /// </summary>
    public abstract class _WindowStateManager
    { 
        public ICommand CommandMinimze { get; protected set; }
        public ICommand CommandMaximize { get; protected set; }
        public ICommand CommandClose { get; protected set; } 
    }
}
