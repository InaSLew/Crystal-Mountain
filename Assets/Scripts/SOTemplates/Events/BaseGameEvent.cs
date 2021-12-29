using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A base class from which game event of different types derives
/// </summary>
/// <typeparam name="T">Game event type</typeparam>
public abstract class BaseGameEvent<T> : ScriptableObject
{
    private readonly List<IGameEventListener<T>> listeners = new();

    public void Raise(T value)
    {
        for (var i = listeners.Count - 1; i >= 0; i--)
        {
            listeners[i].OnEventRaised(value);
        }
    }

    public void RegisterListener(IGameEventListener<T> listener)
    {
        if (!listeners.Contains(listener)) listeners.Add(listener);
    }
    
    public void UnregisterListener(IGameEventListener<T> listener)
    {
        if (listeners.Contains(listener)) listeners.Remove(listener);
    }
}
