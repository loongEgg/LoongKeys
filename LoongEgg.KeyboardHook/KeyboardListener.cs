using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LoongEgg.KeyboardHook
{

    /// <summary>
    ///     全局键盘监听器
    ///     Global Keyboard Listener
    /// </summary>
    public class KeyboardListener : BaseListener
    {
        public EventHandler<KeyboardActEventArgs> KeyboardActed { get; set; }

        /// <summary>
        ///     键盘状态记录表
        /// </summary>
        private static Dictionary<string, KeyAction> KeysStatus;

        /// <summary>
        ///     初始化键盘记录表
        ///     Initialize KeysStatus
        /// </summary>
        static KeyboardListener()
        {
            if (KeysStatus == null)
            {
                KeysStatus = new Dictionary<string, KeyAction>();

                // (Enum => Array => List).ForEach()
                Enum.GetValues(typeof(Key)).OfType<Key>().ToList()
                    .ForEach(
                       key =>
                       {
                           // NOTE: WPF的Key中有使用同一个索引号的键值：）
                           if (!KeysStatus.ContainsKey(key.ToString()))
                               KeysStatus.Add(key.ToString(), KeyAction.Up);
                       }

                    );
            }
        }

        /// <summary>
        ///     Constructor of <see cref="KeyboardListener"/>
        /// </summary>
        public KeyboardListener() : base(IdHooks.WH_KEYBOARD_LL) { }

        /// <summary>
        ///     当发生键盘输入时钩子会自动调用此方法
        ///     Called when a keyboard input happen
        /// </summary>
        ///     <param name="nCode">
        ///         哪一个键发生了输入
        ///         Which key is raising a message
        ///     </param>
        ///     <param name="wParam">
        ///         事件类型，抬起/按下？
        ///         up / down?
        ///     </param>
        ///     <param name="lParam">
        ///     </param>
        /// <returns>
        /// </returns>
        /// <remarks>
        ///     <see cref="BaseListener"/> for more infomation
        /// </remarks>
        protected override IntPtr HookCallBack(int nCode, IntPtr wParam, IntPtr lParam)
        {
            Debug.WriteLine(nCode);
            if (nCode >= 0) // 大于等于0才是正确的消息
            {
                // 虚拟键盘码转位WPF中的键盘值
                Key key = KeyInterop.KeyFromVirtualKey(Marshal.ReadInt32(lParam));
                string index = key.ToString();
                KeyAction action = KeyAction.Up; ;

                // 按下事件
                if (wParam == (IntPtr)WM.KEYDOWN || wParam == (IntPtr)WM.SYSKEYDOWN)
                {
                    if (KeysStatus[index] == KeyAction.Down)
                    {
                        action = KeyAction.Pressed;
                    }
                    else if (KeysStatus[index] == KeyAction.Pressed)
                    {
                        action = KeyAction.Pressed;
                    }
                    else if (KeysStatus[index] == KeyAction.Up)
                    {
                        action = KeyAction.Down;
                    }
                }
                else if (wParam == (IntPtr)WM.KEYUP || wParam == (IntPtr)WM.SYSKEYUP) // 抬起事件
                {
                    if (KeysStatus[index] != KeyAction.Up)
                    {
                        action = KeyAction.Up;
                    }
                }

                KeysStatus[index] = action;
                Debug.WriteLine($"{index} {KeysStatus[index]}");
                KeyboardActed?.Invoke(this, new KeyboardActEventArgs(index, KeysStatus[index])); 
            }

            return CallNextHookEx(nCode, wParam, lParam);
        }

    }
}
