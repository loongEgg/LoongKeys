using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

/* 微信:  香辣恐龙蛋 InnerGeeker
 * B站:   香辣恐龙蛋
 * https://space.bilibili.com/14343016
 */

namespace LoongEgg.ViewModelBase
{
    /// <summary>
    ///     所有View Model的基类
    ///     The base class of all view model
    /// </summary>
    public class BaseViewModel : INotifyPropertyChanged
    {
        /// <summary>
        ///     通知前端属性改变事件
        ///     The event raised when any <see cref="BaseViewModel"/>'s property changed
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        ///     通知前端属性改变的方法
        ///     Raise event when property changed 
        /// </summary>
        ///     <param name="propertyName">
        ///         发生改变的属性的名称,如果留空会自动识别为前端属性的名字
        ///         the name of property which is changed
        ///         [default auto recognised as <see cref="CallerMemberNameAttribute"/>]
        ///     </param>
        protected virtual void RaisePropertyChanged([CallerMemberName]string propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        /// <summary>
        ///     属性设置器
        ///         如果新设置的属性值与原来的不同，会自动调用<see cref="RaisePropertyChanged(string)"/>
        ///         通知前端属性发生了改变 
        ///     Set target to the new value
        ///     if the value is different with the old value, raise a property changed event
        /// </summary>
        ///     <typeparam name="T">
        ///         the type of property
        ///     </typeparam>
        ///     <param name="target">
        ///         the target to set
        ///     </param>
        ///     <param name="value">
        ///         new value
        ///     </param>
        ///     <param name="propertyName">
        ///         the property name of raise event
        ///         [default auto recognised as <see cref="CallerMemberNameAttribute"/>]
        ///     </param>
        /// <returns>   
        ///     return ture if set to a new value, and raise a property changed event
        /// </returns>
        public bool Set<T>(ref T target, T value, [CallerMemberName]string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(target, value))
                return false;

            // 如果确实是一个新的值
            target = value;
            RaisePropertyChanged(propertyName);
            return true;
        }

    }
}
