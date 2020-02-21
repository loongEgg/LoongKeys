using System;

namespace LoongEgg.KeyboardHook
{
    public class GlobalKeyboardInputEvent : EventArgs
    {
        public string Key { get; private set; }

        public KeyAction KeyAction { get; private set; }

        public GlobalKeyboardInputEvent(string key, KeyAction action)
        {
            Key = key;
            KeyAction = action;
        }
    }
}
