using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A GameEvent that emits boolean value upon raised
/// </summary>
[CreateAssetMenu(fileName = "BoolEvent", menuName = "Game/Event/BoolEvent")]
public class GameEventBool : ScriptableObject
{
    private List<GameEventBoolListener> listeners = new ();
    public void Raise(bool value)
    {
        for (var i = listeners.Count - 1; i >= 0; i--)
        {
            listeners[i].OnEventRaised(value);
        }
    }

    public void RegisterListener(GameEventBoolListener listener) => listeners.Add(listener);
    public void UnregisterListener(GameEventBoolListener listener) => listeners.Remove(listener);
    
}
