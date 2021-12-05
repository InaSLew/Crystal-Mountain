using UnityEngine;

[CreateAssetMenu(fileName = "BooleanValue", menuName = "Value/BooleanValue")]
public class BooleanValue : ScriptableObject
{
    [SerializeField] private bool boolValue;
    public bool BoolValue { get => boolValue; set => boolValue = value; }
}
