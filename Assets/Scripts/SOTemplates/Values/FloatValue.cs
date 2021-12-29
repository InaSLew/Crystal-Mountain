using UnityEngine;

/// <summary>
/// Scriptable object to store a value of Float
/// </summary>
[CreateAssetMenu(fileName = "FloatValue", menuName = "Value/FloatValue")]
public class FloatValue : ScriptableObject
{
    [SerializeField] private float floatValue;
    public float Float { get => floatValue; set => floatValue = value; }
}
