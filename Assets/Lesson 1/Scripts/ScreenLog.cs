using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenLog : MonoBehaviour
{
    public Transform target;
    Camera cam;
    void Start()
    {
        cam = GetComponent<Camera>();
    }

    void Update()
    {
        Vector3 screenPos = cam.WorldToScreenPoint(target.position);
        Debug.Log("target is WorldToScreenPoint " + screenPos);

        Vector3 viewportPos = cam.WorldToViewportPoint(target.position);
        Debug.Log("target is WorldToViewportPoint " + viewportPos);

        Vector3 myScreenPos = cam.WorldToScreenPoint(target.position);
        if (Input.GetMouseButton(0))
        {
            target.position = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, myScreenPos.z));
        }


    }


}
