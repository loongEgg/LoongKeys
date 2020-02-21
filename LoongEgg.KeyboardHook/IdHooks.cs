namespace LoongEgg.KeyboardHook
{
    /// <summary>
    ///     [int] The type of hook procedure to be installed. 
    /// </summary>
    /// <remarks>
    ///     https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-setwindowshookexa
    /// </remarks>
    public enum IdHooks
    {
        /// <summary>
        ///     Installs a hook procedure that monitors keystroke messages
        /// </summary>
        WH_KEYBOARD = 2,

        /// <summary>
        ///     Installs a hook procedure that monitors mouse messages. 
        /// </summary>
        WH_MOUSE = 7,

        /// <summary>
        ///     在计算机上全局监控键盘
        ///     Installs a hook procedure that monitors low-level keyboard input events.
        /// </summary>
        WH_KEYBOARD_LL = 13,

        /// <summary>
        ///     在计算机上全局监控鼠标
        ///     Installs a hook procedure that monitors low-level mouse input events. 
        /// </summary>
        WH_MOUSE_LL = 14
    }

}
