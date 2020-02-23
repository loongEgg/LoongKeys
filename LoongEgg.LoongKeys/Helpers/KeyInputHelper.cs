using LoongEgg.KeyboardHook;
using System;
using System.Collections.ObjectModel;

namespace LoongEgg.LoongKeys
{
    public static class KeyInputHelper
    {
        /// <summary>
        ///     检查，并修改功能键状态
        /// </summary>
        ///     <param name="vm">
        ///     </param>
        ///     <param name="key">
        ///     </param>
        ///     <param name="action">
        ///     </param>
        /// <returns></returns>
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
            else if (key.ToLower().Contains("win"))
            {
                vm.IsWinEnabled = (action == KeyAction.Pressed || action == KeyAction.Down);
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        ///     检查是否是字母键
        /// </summary>
        ///     <param name="vm">
        ///     </param>
        ///     <param name="key">
        ///     </param>
        ///     <param name="action">
        ///     </param>
        /// <returns>
        ///     true if it is a Latter
        /// </returns>
        public static bool LatterCheck(MainContentViewModel vm, string key, KeyAction action)
        {
            if (key.Length == 1 && action == KeyAction.Down)
            { 
                int last = vm.Items.Count - 1;
                if (last >= 11)
                {
                    vm.Items = new ObservableCollection<KeyInput>();
                    last = -1 ;
                }
                if (last == -1 || key!= vm.Items[last].Text)
                {
                    vm.Items.Add(new KeyInput {Text= key, Flags = 1 }); 
                }
                else
                {
                    vm.Items[last].Flags += 1;
                    vm.Items[last].Text = "";
                    vm.Items[last].Text = key;
                }
                return true;
            }
            return false;
        }

        public static bool Undo(MainContentViewModel vm, string key, KeyAction keyAction)
        {
            if (key.ToLower() == "back" && keyAction == KeyAction.Down)
            { 
                if (vm.Items.Count >= 1)
                {
                    int last = vm.Items.Count - 1;
                    if (vm.Items[last].Flags > 1)
                    {
                        vm.Items[last].Flags -= 1;
                    }
                    else
                    {
                        vm.Items.RemoveAt(last);
                    }
                    return true;
                } 
            }
            return false;
        }
    }
}
