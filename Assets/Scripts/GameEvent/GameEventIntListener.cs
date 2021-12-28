using UnityEngine;
using UnityEngine.Events;

public class GameEventIntListener : MonoBehaviour
{
    public GameEventInt intEvent;
    public UnityEvent<int> Response;

    private void OnEnable() => intEvent.RegisterListener(this);
    private void OnDisable() => intEvent.UnregisterListener(this);
    public void OnEventRaised(int value) => Response.Invoke(value);
}
