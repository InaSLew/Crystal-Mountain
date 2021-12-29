using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// A base class from which game event listener of different types derives
/// </summary>
/// <typeparam name="T">Game event type</typeparam>
/// <typeparam name="E">Game event of type T</typeparam>
/// <typeparam name="UER">Unity event response</typeparam>
public abstract class BaseGameEventListener<T, E, UER> : MonoBehaviour, IGameEventListener<T> 
    where E: BaseGameEvent<T> where UER: UnityEvent<T>
{
    [SerializeField] private E gameEvent;
    [SerializeField] private UER unityEventResponse;
    
    public E GameEvent { get => gameEvent; set => gameEvent = value; }
    public void OnEventRaised(T value) => unityEventResponse?.Invoke(value);
    
    private void OnEnable()
    {
        if (gameEvent == null) return;
        GameEvent.RegisterListener(this);
    }

    private void OnDisable()
    {
        if (gameEvent == null) return;
        GameEvent.UnregisterListener(this);
    }
}
