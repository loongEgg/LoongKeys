namespace LoongEgg.KeyboardHook
{
    /// <summary>
    ///     Windows messages?
    /// </summary>
    public enum WM
    {
        /// <summary>
        ///     当Alt键没有按下时的键盘输入
        ///     Posted to the window with the keyboard focus when a nonsystem key is pressed. A nonsystem 
        ///     key is a key that is pressed when the ALT key is not pressed.
        /// </summary>
        /// <remarks>
        ///     https://docs.microsoft.com/zh-cn/windows/win32/inputdev/wm-keydown?redirectedfrom=MSDN
        /// </remarks>
        KEYDOWN = 0x0100,

        KEYUP = 0x0101,

        /// <summary>
        ///     当Alt键同时按下时的键盘输入
        ///     posted to the window with the keyboard focus when the user presses the F10 key (which activates 
        ///     the menu bar) or holds down the ALT key and then presses another key. It also occurs when no 
        ///     window currently has the keyboard focus; in this case, the WM_SYSKEYDOWN message is sent to 
        ///     the active window. The window that receives the message can distinguish between these two contexts
        ///     by checking the context code in the lParam parameter.
        /// </summary>
        /// <remarks>
        ///     https://docs.microsoft.com/zh-cn/windows/win32/inputdev/wm-syskeydown
        /// </remarks>
        SYSKEYDOWN = 0x0104,

        SYSKEYUP = 0x0105,
    }
}
