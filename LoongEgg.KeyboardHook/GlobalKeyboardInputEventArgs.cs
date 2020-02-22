using System;

namespace LoongEgg.KeyboardHook
{
    public class GlobalKeyboardInputEventArgs : EventArgs
    {
        public string Key { get; private set; }

        public KeyAction KeyAction { get; private set; }

        public GlobalKeyboardInputEventArgs(string key, KeyAction action)
        {
            Key = key;
            KeyAction = action;
        }
    }
}
