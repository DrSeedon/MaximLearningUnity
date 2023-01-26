using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// поворот объекта
/// </summary>
public class LocalRotation : MonoBehaviour
{
    private float x;
    private float z;
    private bool rotateX;
    private float rotationSpeed;
    public bool isLocal = false;

    void Start()
    {
        x = transform.rotation.x;
        z = transform.rotation.z;
        rotateX = true;
        rotationSpeed = 75.0f;
    }

    void FixedUpdate()
    {
        if (rotateX == true)
        {
            x += Time.deltaTime * rotationSpeed;

            if (x > 360.0f)
            {
                x = 0.0f;
                rotateX = false;
            }
        }
        else
        {
            z += Time.deltaTime * rotationSpeed;

            if (z > 360.0f)
            {
                z = 0.0f;
                rotateX = true;
            }
        }
        if (isLocal)
        {
            transform.localRotation = Quaternion.Euler(x, 0, z);
        }
        else
        {
            transform.rotation = Quaternion.Euler(x, 0, z);
        }
    }
}
