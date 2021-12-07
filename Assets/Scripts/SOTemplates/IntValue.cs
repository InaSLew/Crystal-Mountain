using UnityEngine;

[CreateAssetMenu(fileName = "IntValue", menuName = "Value/IntValue")]
public class IntValue : ScriptableObject
{
    [SerializeField] private int intValue;
    public int Int { get => intValue; set => intValue = value; }
}