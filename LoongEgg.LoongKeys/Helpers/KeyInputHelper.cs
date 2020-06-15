using LoongEgg.KeyboardHook;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace LoongEgg.LoongKeys
{
    public static class KeyInputHelper
    {
        /// <summary>
        ///     检查，并修改功能键状态
        ///     Check, and Update the Modifier Enabled Status in the <see cref="MainContentViewModel"/>
        /// </summary>
        ///     <param name="vm">
        ///     </param>
        ///     <param name="key">
        ///     </param>
        ///     <param name="action">
        ///     </param>
        /// <returns>
        ///     [True]: it is a modifier(Ctrl / Shift / Alt / Win)
        /// </returns>
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
        ///     Check, if it a A~B
        /// </summary>
        ///     <param name="vm">
        ///     </param>
        ///     <param name="key">
        ///     </param>
        ///     <param name="action">
        ///     </param>
        /// <returns>
        ///     [True]: it is a Latter
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
                if (last == -1 || key!= vm.Items[last].Text || !vm.IsContinueInput)
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

        /// <summary>
        ///     如果是[Backspace]回删一个字符
        ///     If it is [Backspace] Delete the Last Input
        /// </summary>
        ///     <param name="vm">
        ///     </param>
        ///     <param name="key">
        ///     </param>
        ///     <param name="action">
        ///     </param>
        /// <returns>
        ///     [True] :It is a [Backspace] and last input deleted
        ///     [False]:It is no a [Backspace] 
        /// </returns>
        public static bool Undo(MainContentViewModel vm, string key, KeyAction action)
        {
            if (key.ToLower() == "back" && action == KeyAction.Down)
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

        /// <summary>
        ///     Happend when [Delete] [Return] is pressed
        /// </summary>
        /// <param name="vm"></param>
        /// <param name="key"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public static bool CleanUp (MainContentViewModel vm, string key, KeyAction action)
        {
            if ((key.ToLower() == "delete" || key.ToLower() == "return") && action == KeyAction.Up)
            { 
                vm.Items = new ObservableCollection<KeyInput>();
                return true;
            }
            return false;
        }
        // TODO: Finish the TranslateTable, for example [OemOpenBrackets] to "["

        /// <summary>
        ///     转义表
        ///     Translate Table NOT Finished yet
        /// </summary>
        private readonly static Dictionary<string, string> TranslateTable =
            new Dictionary<string, string>() { 
                { Key.OemOpenBrackets.ToString().ToLower(), "[" }, // Just some example 
                { "Space".ToLower(),           " "}, // Pre Method it to long, you can find the string in debug output
                { "Oem6".ToLower(),            "]"},
                { "Oem5".ToLower(),           "\\"},

                { "Oem3".ToLower(),           "`"}, // Pre Method it to long, you can find the string in debug output

                { "OemMinus".ToLower(),      "-"},
                { "OemPlus".ToLower(),       "="}, 

                { "Oem1".ToLower(),         ";"},
                { "OemQuotes".ToLower(),    "'"}, 

                { "OemComma".ToLower(),    ","},
                { "OemPeriod".ToLower(),   "."},
                { "OemQuestion".ToLower(), "/"},

                { "Left".ToLower(),  "<-"},
                { "Right".ToLower(), "->"},

                { "Down".ToLower(), "DW"},
                { "Up".ToLower(),   "UP"},

                { "Divide".ToLower(),    "/"},
                { "Multiply".ToLower(),  "*"},
                { "Subtract".ToLower(),  "-"},
                { "Add".ToLower(),       "+"},

                { "PageUp".ToLower(),     "PU"},
                { "Next".ToLower(),       "PD"},
            };

        /// <summary>
        ///     如果是其它按键，进行转义
        ///     If it is the other, transtale it, for example [OemOpenBrackets] to "["
        /// </summary>
        ///     <param name="vm">
        ///     </param>
        ///     <param name="key">
        ///     </param>
        ///     <param name="keyAction">
        ///     </param>
        /// <returns></returns>
        public static bool TranslateOtherKeys(MainContentViewModel vm, string key, KeyAction action)
        { 
            if (TranslateTable.ContainsKey(key.ToLower()) && action == KeyAction.Down)
            {
                int last = vm.Items.Count - 1;
                string input = TranslateTable[key.ToLower()];
                if (last >= 11)
                {
                    vm.Items = new ObservableCollection<KeyInput>();
                    last = -1;
                }
                if (last == -1 || input != vm.Items[last].Text || !vm.IsContinueInput)
                {
                    vm.Items.Add(new KeyInput { Text = input, Flags = 1 });
                }
                else
                {
                    vm.Items[last].Flags += 1;
                    vm.Items[last].Text = "";
                    vm.Items[last].Text = input;
                }
                return true;
            }
            return false;
        }
    }
}
