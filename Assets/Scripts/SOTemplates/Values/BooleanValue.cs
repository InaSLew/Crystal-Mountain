using UnityEngine;

/// <summary>
/// Scriptable object to store a value of Boolean
/// </summary>
[CreateAssetMenu(fileName = "BooleanValue", menuName = "Value/BooleanValue")]
public class BooleanValue : ScriptableObject
{
    [SerializeField] private bool boolValue;
    public bool BoolValue { get => boolValue; set => boolValue = value; }
}
