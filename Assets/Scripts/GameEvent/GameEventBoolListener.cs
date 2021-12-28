using UnityEngine;
using UnityEngine.Events;

public class GameEventBoolListener : MonoBehaviour
{
    public GameEventBool voidEvent;
    public UnityEvent<bool> Response;

    private void OnEnable() => voidEvent.RegisterListener(this);
    private void OnDisable() => voidEvent.UnregisterListener(this);
    public void OnEventRaised(bool value) => Response.Invoke(value);
}
