using System;
using System.Linq;
using System.Threading.Tasks;

namespace Mishkasta.Common.Event
{
    public static class AsyncEventHandlerExtensions
    {
        public static async Task RaiseEventAsync<TEventArgs>(this AsyncEventHandler<TEventArgs> asyncEventHandler, object sender, TEventArgs eventArgs) where TEventArgs : EventArgs
        {
            var callbackTasks = asyncEventHandler.GetInvocationList()
                .Cast<AsyncEventHandler<TEventArgs>>()
                .Select(callback => callback(sender, eventArgs));
            await Task.WhenAll(callbackTasks);
        }
    }
}