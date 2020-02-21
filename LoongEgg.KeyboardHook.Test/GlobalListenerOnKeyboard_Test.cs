using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LoongEgg.KeyboardHook.Test
{
    [TestClass]
    public class GlobalListenerOnKeyboard_Test
    {
        GlobalKeyboardListener listener;
        [TestInitialize]
        public void Init()
        {
            listener = new GlobalKeyboardListener();
        }

        [TestMethod]
        public void SetHook()
        {
            listener.SetHook();
            Assert.AreNotEqual(listener.HookId, IntPtr.Zero);
        }

        [TestMethod]
        public void UnHook()
        {
            listener.UnHook();
            Assert.AreEqual(listener.HookId, IntPtr.Zero);
        }
    }
}
