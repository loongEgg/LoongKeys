using System;
using System.Runtime.InteropServices;

namespace LoongEgg.KeyboardHook
{
    /// <summary>
    ///     [委托]钩子捕获到消息时调用
    /// </summary>
    ///     <param name="nCode">
    ///         键盘的虚拟码
    ///     </param>
    ///     <param name="wParam">
    ///         事件，按键按下/弹起
    ///     </param>
    ///     <param name="lParam">
    ///         应该是其它的参数
    ///     </param>
    /// <returns></returns>
    public delegate IntPtr LowLevelHookProc(int nCode, IntPtr wParam, IntPtr lParam);
     
    /// <summary>
    ///     Native Win32 API
    /// </summary>
    public class User32Dll
    {
               /// <summary>
        ///     安装钩子函数
        ///     钩子实际上是一个处理消息的程序段，通过系统调用，把它挂入系统。每当特定的消息发出，在没有到达目的窗口前，钩子
        ///     程序就先捕获该消息，亦即钩子函数先得到控制权。这时钩子函数即可以加工处理（改变）该消息，也可以不作处理而继续
        ///     传递该消息，还可以强制结束消息的传递。
        ///     Installs an application-defined hook procedure into a hook chain. You would install a hook 
        ///     procedure to monitor the system for certain types of events. These events are associated 
        ///     either with a specific thread or with all threads in the same desktop as the calling thread.
        /// </summary>
        ///     <param name="idHook">
        ///         钩子类型 <see cref="IdHooks"/>
        ///     </param>
        ///     <param name="lpfn">
        ///         [HookProc] 回调函数地址
        ///         A pointer to the hook procedure. If the dwThreadId parameter is zero or 
        ///         specifies the identifier of a thread created by a different process, the lpfn parameter 
        ///         must point to a hook procedure in a DLL. Otherwise, lpfn can point to a hook procedure 
        ///         in the code associated with the current process.
        ///     </param>
        ///     <param name="hMod">
        ///         实例句柄
        ///         A handle to the DLL containing the hook procedure pointed to by the lpfn parameter. 
        ///         The hMod parameter must be set to NULL if the dwThreadId parameter specifies a thread 
        ///         created by the current process and if the hook procedure is within the code associated 
        ///         with the current process.
        ///     </param>
        ///     <param name="dwThreadId">
        ///         线程ID
        ///         [Intptr] 用于表示指针或句柄的特定于平台的类型。在32位计算机中为32位，在64位计算机中位64位。
        ///                  通常用于本机资源，如窗口句柄、系统的指针
        ///         <remarks>
        ///                 https://docs.microsoft.com/zh-cn/dotnet/api/system.intptr?view=netframework-4.8
        ///         </remarks>
        ///         The identifier of the thread with which the hook procedure is to be associated. For 
        ///         desktop apps, if this parameter is zero, the hook procedure is associated with all 
        ///         existing threads running in the same desktop as the calling thread. 
        ///     </param>
        /// <returns>
        ///     此函数执行成功,则返回值就是该挂钩处理过程的句柄;若此函数执行失败,则返回值为NULL(0).
        ///     [HHOOK] -> [Intptr]
        ///     If the function succeeds, the return value is the handle to the hook procedure.
        ///     If the function fails, the return value is NULL. To get extended error 
        ///     information, call GetLastError.
        /// </returns>
        /// <remarks>
        ///     https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-setwindowshookexa
        /// </remarks>
        [DllImport("user32.dll",          // C:\Windows\System32\user32.dll
           CharSet = CharSet.Auto,// 指定重整以及将字符串参数封送到函数中的方式， 默认值位CharSet.Ansi
           SetLastError = true)]  // 允许调用方使用Marshal.GetLastWin32Error API来确定执行该方法时是否发生了错误。 
        internal static extern IntPtr SetWindowsHookEx(
            int idHook,
            LowLevelHookProc lpfn,
            IntPtr hMod,
            uint dwThreadId);

        /// <summary>
        ///     卸下钩子函数
        ///     Removes a hook procedure installed in a hook chain by the 
        ///     <see cref="SetWindowsHookEx(int, LowLevelHookProc, IntPtr, uint)"/> function.
        /// </summary>
        ///     <param name="hhk">
        ///         要删除的钩子的句柄。这个参数是上一个函数SetWindowsHookEx的返回值.
        ///         A handle to the hook to be removed. This parameter is a hook handle obtained by
        ///         a previous call to <see cref="SetWindowsHookEx(int, LowLevelHookProc, IntPtr, uint)"/>
        ///     </param>
        /// <returns>
        ///     如果函数成功，返回值为非零值。
        ///     如果函数失败，返回值为零。
        ///     If the function succeeds, the return value is nonzero.
        ///     If the function fails, the return value is zero. To get extended error 
        ///     information, Call GetLastError.
        /// </returns>
        /// <remarks>
        ///     https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-unhookwindowshookex
        /// </remarks>
        [DllImport(
            "user32.dll",
            CharSet = CharSet.Auto,
            SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool UnhookWindowsHookEx(IntPtr hhk);

        /// <summary>
        ///     调用下一个钩子函数
        ///     将钩子信息传递到当前钩子链中的下一个子程，一个钩子程序可以调用这个函数之前或之后处理钩子信息。
        ///     Passes the hook information to the next hook procedure in the current hook chain. 
        ///     A hook procedure can call this function either before or after processing the hook 
        ///     information.
        /// </summary>
        ///     <param name="hhk">
        ///         This parameter is IGNORED.
        ///     </param>
        ///     <param name="nCode">
        ///         钩子代码; 就是给下一个钩子要交待的
        ///         The hook code passed to the current hook procedure. The next hook procedure
        ///         uses this code to determine how to process(处理) the hook information.
        ///     </param>
        ///     <param name="wParam">
        ///         消息参数？常常代表一些控件的ID或者高位底位组合起来分别表示鼠标的位置？
        ///         The wParam value passed to the current hook procedure. The meaning of this 
        ///         parameter depends on the type of hook associated with the current hook chain.
        ///     </param>
        ///     <param name="lParam">
        ///         习惯上用LPARAM来传递将某种结构的指针或者是某种类型的句柄，可以参考各种控件的通知消息
        ///         The lParam value passed to the current hook procedure. The meaning of this 
        ///         parameter depends on the type of hook associated with the current hook chain.
        ///     </param>
        /// <returns>
        ///     返回这个值链中的下一个钩子程序。
        ///     This value is returned by the next hook procedure in the chain. The current hook 
        ///     procedure must also return this value. The meaning of the return value depends on 
        ///     the hook type
        /// </returns>
        /// <remarks>
        ///     https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-callnexthookex
        /// </remarks>
        [DllImport("user32.dll",
            CharSet = CharSet.Auto,
            SetLastError = true)]
        internal static extern IntPtr CallNextHookEx(
            IntPtr hhk,
            int nCode,
            IntPtr wParam, // 消息参数？常常代表一些控件的ID或者高位底位组合起来分别表示鼠标的位置？
            IntPtr lParam);//习惯上用LPARAM来传递将某种结构的指针或者是某种类型的句柄，可以参考各种控件的通知消息


        /// <summary>
        ///     获取一个应用程序或动态链接库的模块句柄。只有在当前进程的场景中，这个句柄才会有效。
        /// </summary>
        ///     <param name="lpModuleName">
        ///         指定模块名，这通常是与模块的文件名相同的一个名字。例如，NOTEPAD.EXE程序的模块文件名就
        ///         叫作NOTEPAD。
        ///         NULL则返回调用进程本身的句柄。
        ///     </param>
        /// <returns>
        ///     如执行成功，则返回模块句柄。
        ///     零表示失败。
        /// </returns>
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        internal static extern IntPtr GetModuleHandle(string lpModuleName);
    }

}
