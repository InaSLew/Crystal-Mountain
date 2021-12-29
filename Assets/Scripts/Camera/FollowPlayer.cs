using UnityEngine;

/// <summary>
/// A basic camera follow script with adjustable smooth speed through editor
/// </summary>
public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private float smoothSpeed;
    private GameObject player;
    private Vector3 offset;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        offset = transform.position - player.transform.position;
    }

    private void LateUpdate()
    {
        var targetPosition = player.transform.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed);
    }
}
