using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private GameObject spawnPoint;
    private Vector3 camOffset;
    private Vector3 spawnOffset;

    private void Awake()
    {
        var position = transform.position;
        camOffset = position - player.transform.position;
    }

    private void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, player.transform.position + camOffset, .1f);
        // might be an overkill but consider Vector3.SmoothDamp
    }
}
