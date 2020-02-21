using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LoongEgg.KeyboardHook
{

    public class GlobalListenerOnKeyboard : BaseGlobalListener
    {
        /// <summary>
        ///     键盘状态记录表
        /// </summary>
        private static Dictionary<string, KeyAction> KeysStatus;
         
        public GlobalListenerOnKeyboard() : base(IdHooks.WH_KEYBOARD_LL) { }

        protected override IntPtr HookCallBack(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0) // 大于等于0才是正确的消息
            {
                // 虚拟键盘码转位WPF中的键盘值
                Key key = KeyInterop.KeyFromVirtualKey(Marshal.ReadInt32(lParam));
                string index = key.ToString();

                // 按下事件
                if (wParam == (IntPtr)WM.KEYDOWN || wParam == (IntPtr)WM.SYSKEYDOWN)
                {
                    if (KeysStatus[index] == KeyAction.Down)
                    {
                        KeysStatus[index] = KeyAction.Pressed;
                        //ListenerEvent?.Invoke(this, new GlobalKeyEventArgs(key, KeyAction.Pressed));
                    }
                    else if (KeysStatus[index] == KeyAction.Pressed)
                    {
                        // do nothing
                    }
                    else if (KeysStatus[index] == KeyAction.Up)
                    {
                        KeysStatus[index] = KeyAction.Down;
                        //ListenerEvent?.Invoke(this, new GlobalKeyEventArgs(key, KeyAction.Down));
                    }
                }

                // 抬起事件
                if (wParam == (IntPtr)WM.KEYUP || wParam == (IntPtr)WM.SYSKEYUP)
                {
                    KeysStatus[index] = KeyAction.Up;
                    //ListenerEvent?.Invoke(this, new GlobalKeyEventArgs(key, KeyAction.Up));
                }
            }

            return CallNextHookEx(nCode, wParam, lParam);
        }
    }
}
