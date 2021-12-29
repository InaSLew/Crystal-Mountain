using UnityEngine;

/// <summary>
/// Scriptable object to store a value of Int
/// </summary>
[CreateAssetMenu(fileName = "IntValue", menuName = "Value/IntValue")]
public class IntValue : ScriptableObject
{
    [SerializeField] private int intValue;
    public int Int { get => intValue; set => intValue = value; }
}