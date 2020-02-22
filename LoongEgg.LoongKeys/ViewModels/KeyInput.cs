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
         
        public int Flags {
            get => _Count;
            set => Set(ref _Count, value);
        }
        private int _Count;

    }
}