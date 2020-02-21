using System.Windows;

namespace LoongEgg.LoongKeys
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainContentViewModel { ButtonIsEnabled = true };
        }

        // Step: 00.项目结构
        // Step: 01.在程序集间引用样式
        // Step: 02.最大化、最小化和关闭窗口
        // Step: 03.无边框、自定义可拖动标题栏和透明窗体
        // Step: 04.半透明化的置顶窗体
        // Step: 05.自动隐藏的标题 
        // Step: 06.通过EnventTrigger和Animation改变边框圆角、大小和消隐
        // Step: 07.在样式中设置EventTrigger，实现事件驱动的按键的放大效果
        // TODO: 08.属性变化驱动的Animation，再次拥抱ViewModel
        // TODO: 09.CodeSnippet代码片段的创建

        // TODO: 10.截获键盘输入的底层实现User32.dll

        // TODO: 键盘截获事件 
        // TODO: 把键盘事件发送的消息正确处理
        // TODO: 完成前后端的最后绑定与界面设计
        // TODO: TextBlock的放大效果
    }
}
