using LoongEgg.KeyboardHook;
using LoongEgg.ViewModelBase;
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

        /// <summary>
        ///     翻转<see cref="ButtonIsEnabled"/>命令
        /// </summary>
        public ICommand CommandFlipButtonIsEnabled =>
            _CommandFlipButtonIsEnabled
            ?? (_CommandFlipButtonIsEnabled = new RelayCommand((e) => ButtonIsEnabled = !ButtonIsEnabled));
        private RelayCommand _CommandFlipButtonIsEnabled;

        readonly GlobalListenerOnKeyboard listenerOnKeyboard;

        public MainContentViewModel()
        {
            listenerOnKeyboard = new GlobalListenerOnKeyboard();
            listenerOnKeyboard.SetHook();
        }

    }
}
