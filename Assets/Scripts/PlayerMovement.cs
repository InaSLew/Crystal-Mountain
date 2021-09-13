using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float Speed = 8f;

    // void Start()
    // {
    //     
    // }

    void Update()
    {
        transform.Translate(Speed * Time.deltaTime, 0, 0);
    }
}
