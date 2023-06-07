namespace Moonstone.Core.Architecture.Events;

public interface IDispatchable { }

public static class DispatchableExtensions
{
    public static void Dispatch<T>(this IDispatchable dispatchable, EventHandler<T>? eventHandler, T args) where T : EventArgs
    {
        eventHandler?.Invoke(dispatchable, args);
    }
}
