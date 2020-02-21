using LoongEgg.KeyboardHook;
using LoongEgg.ViewModelBase;
using System;
using System.Diagnostics;
using System.Windows.Input;

namespace LoongEgg.LoongKeys
{
    public class MainContentViewModel : BaseViewModel
    {
        /// <summary>
        ///     IsCtrlEnabled
        /// </summary>
        public bool IsCtrlEnabled {
            get => _IsCtrlEnabled;
            set => Set(ref _IsCtrlEnabled, value);
        }
        private bool _IsCtrlEnabled;

        // IsShiftEnabled

        public bool IsShiftEnabled {
            get => _IsShiftEnabled;
            set => Set(ref _IsShiftEnabled, value);
        }
        private bool _IsShiftEnabled;

        // IsAltEnabled

        public bool IsAltEnabled {
            get => _IsAltEnabled;
            set => Set(ref _IsAltEnabled, value);
        }
        private bool _IsAltEnabled;

        // IsTabEnabled 
        public bool IsTabEnabled {
            get => _IsTabEnabled;
            set => Set(ref _IsTabEnabled, value);
        }
        private bool _IsTabEnabled;


        /// <summary>
        ///     全局键盘监控器
        /// </summary>
        readonly GlobalKeyboardListener listenerOnKeyboard;

        public MainContentViewModel()
        {
            listenerOnKeyboard = new GlobalKeyboardListener();
            listenerOnKeyboard.SetHook();
            listenerOnKeyboard.GlobalKeyboardInputEvent += GlobalKeyboard_InputEvent;
        }

        private void GlobalKeyboard_InputEvent(object sender, GlobalKeyboardInputEvent e)
        {
            KeyInputHelper.ModifierCheck(this, e.Key, e.KeyAction);
        }
    }
}
