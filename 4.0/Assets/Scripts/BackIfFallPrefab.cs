using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackIfFallPrefab : MonoBehaviour
{
    [SerializeField] GameObject Respawn;
    private float obj_x;
    private float obj_y;
    private float obj_z;
    private Vector3 Respawn_coord;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Respawn")
        {
            Respawn_coord = Respawn.transform.position;
            obj_x = 0.6f;
            obj_y = 0.4f;
            obj_z = -0.56f;
            
            transform.position = Respawn_coord;
           // transform.position = new Vector3(obj_x, obj_y, obj_z);
            
        }
    }
}
