using UnityEngine;

[CreateAssetMenu(fileName = "Vector3Value", menuName = "Value/Vector3Value")]
public class Vector3Value : ScriptableObject
{
    [SerializeField] private Vector3 vector3Value;
    public Vector3 Vector3 { get => vector3Value; set => vector3Value = value; }
}
