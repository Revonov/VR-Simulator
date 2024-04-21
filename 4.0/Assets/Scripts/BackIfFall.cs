using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackIfFall : MonoBehaviour
{
    Vector3 StartPosition;

    private void Start()
    {
        StartPosition = transform.position;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Respawn") 
        {
            transform.position = StartPosition;
        }
    }
}
