using LoongEgg.ViewModelBase;

namespace LoongEgg.ViewBase.Controls
{
    class TextBlockCountDesignModel :BaseViewModel
    {

        public string Text {
            get => _Text;
            set => Set(ref _Text, value);
        }
        private string _Text;
         
        public int Count {
            get => _Count;
            set => Set(ref _Count, value);
        }
        private int _Count;

        public static TextBlockCountDesignModel Instance => _Instance ?? (_Instance = new TextBlockCountDesignModel());
        private static TextBlockCountDesignModel _Instance;

        public TextBlockCountDesignModel()
        {
            Text = "K";
            Count = 11;
        }
    }
}
