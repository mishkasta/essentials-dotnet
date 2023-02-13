using System;
using System.Threading;

namespace Mishkasta.Common.Event
{
    public static class EventHandlerExtensions
    {
        public static void RaiseEvent(this EventHandler eventHandler, object sender)
        {
            var handler = Volatile.Read(ref eventHandler);
            handler?.Invoke(sender, EventArgs.Empty);
        }

        public static void RaiseEvent<T>(this EventHandler<T> eventHandler, object sender, T e) where T : EventArgs
        {
            var handler = Volatile.Read(ref eventHandler);
            handler?.Invoke(sender, e);
        }
    }
}