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
        ///     按键可用标志
        /// </summary>
        public bool ButtonIsEnabled {
            get => _ButtonIsEnabled;
            set => Set(ref _ButtonIsEnabled, value);
        }
        private bool _ButtonIsEnabled;


        public string Temp {
            get => _Temp;
            set => Set(ref _Temp, value); 
        }
        private string _Temp;
         
        /// <summary>
        ///     翻转<see cref="ButtonIsEnabled"/>命令
        /// </summary>
        public ICommand CommandFlipButtonIsEnabled =>
            _CommandFlipButtonIsEnabled
            ?? (_CommandFlipButtonIsEnabled = new RelayCommand((e) => ButtonIsEnabled = !ButtonIsEnabled));
        private RelayCommand _CommandFlipButtonIsEnabled;

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
            Temp = $"{e.Key} {e.KeyAction}";
        }
    }
}
