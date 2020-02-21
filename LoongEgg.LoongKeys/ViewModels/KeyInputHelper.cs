using LoongEgg.KeyboardHook;

namespace LoongEgg.LoongKeys
{
    public static class KeyInputHelper
    {
        public static bool ModifierCheck(MainContentViewModel vm, string key, KeyAction action)
        {

            if (key.ToLower().Contains("ctrl"))
            {
                vm.IsCtrlEnabled = (action == KeyAction.Pressed || action == KeyAction.Down);
                return true; 
            }
            else if (key.ToLower().Contains("shift"))
            {
                vm.IsShiftEnabled = (action == KeyAction.Pressed || action == KeyAction.Down);
                return true; 
            }
            else if (key.ToLower().Contains("alt"))
            {
                vm.IsAltEnabled = (action == KeyAction.Pressed || action == KeyAction.Down);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
