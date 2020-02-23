using LoongEgg.ViewModelBase;

namespace LoongEgg.LoongKeys
{
    public class KeyInput : BaseViewModel
    {
        public string Text {
            get => _Text;
            set => Set(ref _Text, value);
        }
        private string _Text;
         
        /// <summary>
        ///     使用者对View Model的命名规则不应有被控件设计者限定
        /// </summary>
        public int Flags {
            get => _Count;
            set => Set(ref _Count, value);
        }
        private int _Count;

    }
}