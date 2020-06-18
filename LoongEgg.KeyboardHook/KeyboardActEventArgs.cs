using System;

namespace LoongEgg.KeyboardHook
{
    public class KeyboardActEventArgs : EventArgs
    {
        public string Key { get; private set; }

        public KeyAction KeyAction { get; private set; }

        public KeyboardActEventArgs(string key, KeyAction action)
        {
            Key = key;
            KeyAction = action;
        }
    }
}
