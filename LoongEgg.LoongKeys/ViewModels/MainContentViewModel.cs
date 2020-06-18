using LoongEgg.KeyboardHook;
using LoongEgg.ViewModelBase;
using System;
using System.Collections.ObjectModel;

namespace LoongEgg.LoongKeys
{
    /// <summary>
    ///     The View Model of Main Content in <see cref="MainWindow"/>
    /// </summary>
    public class MainContentViewModel : BaseViewModel
    {
        /// <summary>
        ///     Ctrl键按下？
        /// </summary>
        public bool IsCtrlEnabled {
            get => _IsCtrlEnabled;
            set => Set(ref _IsCtrlEnabled, value);
        }
        private bool _IsCtrlEnabled;

        /// <summary>
        ///  Shift键按下？
        /// </summary>
        public bool IsShiftEnabled {
            get => _IsShiftEnabled;
            set => Set(ref _IsShiftEnabled, value);
        }
        private bool _IsShiftEnabled;

        /// <summary>
        ///     Alt键按下？
        /// </summary>
        public bool IsAltEnabled {
            get => _IsAltEnabled;
            set => Set(ref _IsAltEnabled, value);
        }
        private bool _IsAltEnabled;

        /// <summary>
        ///     Tab键按下？
        /// </summary>
        public bool IsTabEnabled {
            get => _IsTabEnabled;
            set => Set(ref _IsTabEnabled, value);
        }
        private bool _IsTabEnabled;

        /// <summary>
        ///     Windows键按下？
        /// </summary>
        public bool IsWinEnabled {
            get => _IsWinEnabled;
            set => Set(ref _IsWinEnabled, value);
        }
        private bool _IsWinEnabled;
         
        /// <summary>
        ///     Should just add the flags?
        /// </summary>
        public bool IsContinueInput {
            get => _IsContinueInput;
            set => Set(ref _IsContinueInput, value);
        }
        private bool _IsContinueInput = false;


        public string KeyClicked
        {
            get { return _KeyClicked; }
            set { Set(ref _KeyClicked, value); }
        }
        private string _KeyClicked;

        /// <summary>
        ///     输入列表
        /// </summary>
        public ObservableCollection<KeyInput> Items {
            get => _Items;
            set => Set(ref _Items, value);
        } 
        private ObservableCollection<KeyInput> _Items = new ObservableCollection<KeyInput>();

        /// <summary>
        ///     全局键盘监控器
        /// </summary>
        readonly KeyboardListener listenerOnKeyboard;

        /// <summary>
        ///  The Constructor of <see cref="MainContentViewModel"/>
        /// </summary>
        public MainContentViewModel()
        {
            Console.WriteLine("Hook");
            listenerOnKeyboard = new KeyboardListener();
            listenerOnKeyboard.SetHook();
            listenerOnKeyboard.KeyboardActed += OnKeyboardActed; 
        }

        /// <summary>
        ///     Raised when a keybord input happen
        /// </summary>
        ///     <param name="sender">
        ///         The <see cref="KeyboardListener"/>
        ///     </param>
        ///     <param name="e">
        ///         A Event Args Defined in name space <see cref="KeyboardHook"/>
        ///     </param>
        private void OnKeyboardActed(object sender, KeyboardActEventArgs e)
        {
            KeyClicked = e.Key;
            Console.WriteLine(KeyClicked);
            var flag = 
                    KeyInputHelper.ModifierCheck(this, e.Key, e.KeyAction) 
                    ? true 
                    : KeyInputHelper.LatterCheck(this, e.Key, e.KeyAction)
                        ? true
                        : KeyInputHelper.Undo(this, e.Key, e.KeyAction)
                         ?true
                            :KeyInputHelper.CleanUp(this, e.Key, e.KeyAction)
                                ? true:
                                KeyInputHelper.TranslateOtherKeys(this, e.Key, e.KeyAction);
        }

    }
     
}
