using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    private Vector3 _offset;

    private void Start()
    {
        _offset = gameObject.transform.position;
    }

    private void FixedUpdate()
    {
        transform.position = player.transform.position + _offset;
    }
}
