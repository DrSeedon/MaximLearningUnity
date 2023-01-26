using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// поворот пивота камеры к объекту
/// </summary>
public class CameraRotate : MonoBehaviour
{
    Vector2 lastMousepos;
    public bool xInverted = true;
    public bool yInverted = true;
    public bool xLock = false;
    public bool yLock = false;
    float AxisX;
    float AxisY;
    void Start()
    {
        lastMousepos = Input.mousePosition;
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (!xLock)
            {
                AxisX = ((Input.mousePosition.x - lastMousepos.x) / Time.deltaTime) / Screen.width;
            }
            if (!yLock)
            {
                AxisY = ((Input.mousePosition.y - lastMousepos.y) / Time.deltaTime) / Screen.height;
            }

            lastMousepos = Input.mousePosition;

            if (xInverted)
            {
                AxisX = -AxisX;
            }
            
            if (yInverted)
            {
                AxisY = -AxisY;
            }

            transform.eulerAngles += new Vector3(AxisY, AxisX, 0);
        }
        lastMousepos = Input.mousePosition;
    }
}
