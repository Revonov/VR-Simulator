using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Attachment : MonoBehaviour
{
    [SerializeField] private GameObject previous_step;   //First
    [SerializeField] private GameObject detail;   //Rod
    [SerializeField] private GameObject next_step;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == detail.name)
        {
            Vector3 positions = previous_step.transform.localPosition;
            positions.y += 0.1f;
            Quaternion rotation = previous_step.transform.localRotation;

            Destroy(previous_step);
            Destroy(detail);

            /*if(next_step.transform.tag == "Bug")
            {
                rotation.x = previous_step.transform.localRotation.x - 0;
                next_step.transform.localRotation = rotation;
                Debug.Log("Yep");

            }
            else next_step.transform.localRotation = rotation; */

            next_step.transform.localRotation = rotation;

            next_step.transform.localPosition = positions;

            next_step.transform.localScale = new Vector3(200f, 200f, 200f);

            next_step.GetComponent<Rigidbody>().isKinematic = false;
            
        }
    }
}
