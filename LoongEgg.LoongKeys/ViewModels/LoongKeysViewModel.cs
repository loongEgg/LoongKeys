using LoongEgg.KeyboardHook;
using LoongEgg.LoongLog;
using LoongEgg.MvvmCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

/* 
 | 个人微信：InnerGeeker
 | 联系邮箱：LoongEgg@163.com 
 | 创建时间：2020/6/18 10:38:28
 | 主要用途：
 | 更改记录：
 | 时间	       版本        更改
 */
namespace LoongEgg.LoongKeys
{

    public class LoongKeysViewModel: ViewModel
    {
        public bool IsCtrlPressed
        {
            get { return _IsCtrlPressed; }
            set { SetProperty(ref _IsCtrlPressed, value); }
        }
        private bool _IsCtrlPressed;

        public bool IsShiftPressed
        {
            get { return _IsShiftPressed; }
            set { SetProperty(ref _IsShiftPressed, value); }
        }
        private bool _IsShiftPressed;

        public bool IsAltPressed
        {
            get { return _IsAltPressed; }
            set { SetProperty(ref _IsAltPressed, value); }
        }
        private bool _IsAltPressed;

        public bool IsTablePressed
        {
            get { return _IsTablePressed; }
            set { SetProperty(ref _IsTablePressed, value); }
        }
        private bool _IsTablePressed;

        public bool IsLeftBtnDown
        {
            get { return _IsLeftBtnDown; }
            set { SetProperty(ref _IsLeftBtnDown, value); }
        }
        private bool _IsLeftBtnDown;

        public bool IsRightBtnDown
        {
            get { return _IsRightBtnDown; }
            set { SetProperty(ref _IsRightBtnDown, value); }
        }
        private bool _IsRightBtnDown;

        private static Dictionary<string, string> keyValuePairs = new Dictionary<string, string>
        {
            {"OEMPERIOD",   "." },
            {"OEMCOMMA",    "," },
            {"OEMQUESTION", "/" },
            {"OEM1",      ";" },
            {"OEM3",      "`" },
            {"OEMQUOTES", "'" },
            {"OEMOPENBRACKETS", "[" },
            {"OEM5", "\\" },
            {"OEM6", "]" },
            {"OEMMINUS",  "-" },
            {"OEMPLUS",   "=" },
            {"DIVIDE",    "/" },
            {"MUTIPLY",   "*" },
            {"SUBTRACT",  "-" },
            {"ADD",       "+" },
            {"NUMPAD9", "9" },
            {"NUMPAD8", "8" },
            {"NUMPAD7", "7" },
            {"NUMPAD6", "6" },
            {"NUMPAD5", "5" },
            {"NUMPAD4", "4" },
            {"NUMPAD3", "3" },
            {"NUMPAD2", "2" },
            {"NUMPAD1", "1" },
            {"NUMPAD0", "0" }
        };
        public string LastKeyClick
        {
            get { return _LastKeyClick; }
            set
            {
                if (keyValuePairs.ContainsKey(value))
                    _LastKeyClick = keyValuePairs[value];
                else
                    _LastKeyClick = value;
                RaisePropertyChanged();
            }
        }
        private string _LastKeyClick;

        public LoongKeysViewModel()
        {
            KeyboardListener keyboardListener = new KeyboardListener();
            keyboardListener.SetHook();
            keyboardListener.KeyboardActed += OnKeyboardActed;

            Logger.Info("Hook creat");
        }


        private void OnKeyboardActed(object sender, KeyboardActEventArgs e)
        {
            string key = e.Key;
            KeyAction keyAction = e.KeyAction;
            if (key == Key.LeftShift.ToString() || key == Key.RightShift.ToString())
            {
                IsShiftPressed = (keyAction == KeyAction.Down || keyAction == KeyAction.Pressed);
            }
            else if (key == Key.LeftCtrl.ToString() || key == Key.RightCtrl.ToString())
            {
                IsCtrlPressed = (keyAction == KeyAction.Down || keyAction == KeyAction.Pressed);
            }
            else if (key == Key.LeftAlt.ToString() || key == Key.RightAlt.ToString())
            {
                IsAltPressed = (keyAction == KeyAction.Down || keyAction == KeyAction.Pressed);
            }
            else if (key == Key.Tab.ToString())
            {
                IsTablePressed = (keyAction == KeyAction.Down || keyAction == KeyAction.Pressed);
            }
            else
            {
                LastKeyClick = key.ToString().ToUpper();
            }
            Logger.Debug($"{key} {keyAction.ToString()}");
        }
    }
}
