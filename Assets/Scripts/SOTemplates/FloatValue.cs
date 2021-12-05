using UnityEngine;

[CreateAssetMenu(fileName = "FloatValue", menuName = "Value/FloatValue")]
public class FloatValue : ScriptableObject
{
    [SerializeField] private float floatValue;
    public float Float { get => floatValue; set => floatValue = value; }
}
