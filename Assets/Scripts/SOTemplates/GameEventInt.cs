using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A GameEvent that emits int value upon raised
/// </summary>
[CreateAssetMenu(fileName = "IntEvent", menuName = "Game/Event/IntEvent")]
public class GameEventInt : ScriptableObject
{
    private List<GameEventIntListener> listeners = new ();
    public void Raise(int value)
    {
        for (var i = listeners.Count - 1; i >= 0; i--)
        {
            listeners[i].OnEventRaised(value);
        }
    }

    public void RegisterListener(GameEventIntListener listener) => listeners.Add(listener);
    public void UnregisterListener(GameEventIntListener listener) => listeners.Remove(listener);
    
}
