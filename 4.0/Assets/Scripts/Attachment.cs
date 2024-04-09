using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Attachment : MonoBehaviour
{
    [SerializeField] private GameObject obj1;   //Piston
    [SerializeField] private GameObject obj2;   //Rod
    [SerializeField] private GameObject obj3;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Rod")
        {
           
            Vector3 positions = obj1.transform.localPosition;
            Quaternion rotation = obj1.transform.localRotation;


            Destroy(obj1);
            Destroy(obj2);
            Instantiate(obj3, positions, rotation);
            obj3.transform.localScale = new Vector3(10000f, 10000f, 10000f);
            
        }
    }
}
