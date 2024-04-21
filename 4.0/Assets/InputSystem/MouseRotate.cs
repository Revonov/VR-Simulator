using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class MouseRotate : MonoBehaviour
{
    [SerializeField] private float _sensitivity = 1.0f;

    private Vector3 pointScreen;
    private Vector3 offset;
    private Vector3 Rotate;

    private Quaternion Obj_Rotation;

    private Rigidbody Rb;

    private float scroll = Input.GetAxis("Mouse ScrollWheel");
    private float scrollbuff = 0;

    private bool onAlt = false;
    private bool onShift = false;
    private bool onCtrl = false;

    private void OnMouseDown()
    {
        pointScreen = Camera.main.WorldToScreenPoint(transform.position);
        offset = transform.position - 
            Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, pointScreen.z));
        Obj_Rotation = transform.localRotation;
    }

    private void OnMouseUp()
    {
        gameObject.GetComponent<Rigidbody>().isKinematic = true;
        gameObject.GetComponent<Rigidbody>().isKinematic = false;

        scroll = 0f;
        scrollbuff = 0f;
    }


    private void OnMouseDrag()
    {
        scroll = Input.GetAxis("Mouse ScrollWheel");

        Vector3 curScreenPoint = new(Input.mousePosition.x,
            Input.mousePosition.y,
            pointScreen.z);

        if (Input.GetKeyDown(KeyCode.LeftAlt)) onAlt = true;
        else if (Input.GetKeyUp(KeyCode.LeftAlt)) onAlt = false ;

        if (Input.GetKeyDown(KeyCode.LeftShift)) onShift = true;
        else if (Input.GetKeyUp(KeyCode.LeftShift)) onShift = false;
        
        if (Input.GetKeyDown(KeyCode.LeftControl)) onCtrl = true;
        else if (Input.GetKeyUp(KeyCode.LeftControl)) onCtrl = false;

        if (onAlt)
        {
            Obj_Rotation.x += scroll;
            curScreenPoint = new Vector3
            (Input.mousePosition.x + (scrollbuff * _sensitivity),
            Input.mousePosition.y,
            pointScreen.z + (scrollbuff * _sensitivity));
        }

        else if (onShift)
        {
            Obj_Rotation.z += scroll;
            curScreenPoint = new Vector3
            (Input.mousePosition.x + (scrollbuff * _sensitivity),
            Input.mousePosition.y,
            pointScreen.z + (scrollbuff * _sensitivity));
        }

        else if (onCtrl)
        {
            Obj_Rotation.y += scroll;
            curScreenPoint = new Vector3
            (Input.mousePosition.x + (scrollbuff * _sensitivity),
            Input.mousePosition.y,
            pointScreen.z + (scrollbuff * _sensitivity));
        }

        else
        {
            scrollbuff += scroll;
            curScreenPoint = new Vector3
            (Input.mousePosition.x + (scrollbuff * _sensitivity),
            Input.mousePosition.y,
            pointScreen.z + (scrollbuff * _sensitivity));
        }

        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint);

        transform.position = curPosition;
        transform.localRotation = Obj_Rotation;

        
    }
}
