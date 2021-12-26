using UnityEngine;
using UnityEngine.Events;

public class GameEventListener : MonoBehaviour
{
    public GameEventVoid eventVoid;
    public UnityEvent Response;

    private void OnEnable() => eventVoid.RegisterListener(this);
    private void OnDisable() => eventVoid.UnregisterListener(this);
    public void OnEventRaised() => Response.Invoke();
}