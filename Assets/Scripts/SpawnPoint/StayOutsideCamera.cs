using UnityEngine;

/// <summary>
/// Makes the spike spawn stay close to and outside of game view
/// </summary>
public class StayOutsideCamera : MonoBehaviour
{
    private Vector3 offsetOnX;
    private float defaultValueOnY;
    private void Awake()
    {
        var mainCam = Camera.main;
        var camToSpawn = transform.position - mainCam.transform.position;
        offsetOnX = new Vector3(camToSpawn.x, 0 , camToSpawn.z);
        defaultValueOnY = transform.position.y;
    }

    private void LateUpdate()
    {
        var mainCamPosition = Camera.main.transform.position;
        transform.position = new Vector3(mainCamPosition.x, defaultValueOnY, mainCamPosition.z) + offsetOnX;
    }
}
