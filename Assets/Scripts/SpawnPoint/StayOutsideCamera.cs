using UnityEngine;

public class StayOutsideCamera : MonoBehaviour
{
    private Vector3 offset;
    private void Awake()
    {
        var mainCam = Camera.main;
        offset = transform.position - mainCam.transform.position;
    }

    private void LateUpdate()
    {
        transform.position = Camera.main.transform.position + offset;
    }
}
