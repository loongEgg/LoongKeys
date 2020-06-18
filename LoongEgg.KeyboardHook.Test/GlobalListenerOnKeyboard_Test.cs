using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LoongEgg.KeyboardHook.Test
{
    [TestClass]
    public class GlobalListenerOnKeyboard_Test
    {
        KeyboardListener listener;
        [TestInitialize]
        public void Init()
        {
            listener = new KeyboardListener();
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
