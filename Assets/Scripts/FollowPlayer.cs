using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    private Vector3 _offset;

    private void Start()
    {
        _offset = gameObject.transform.position;
    }

    private void LateUpdate()
    {
        transform.position = player.transform.position + _offset;
    }
}
