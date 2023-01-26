using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// крен рыскание и тангаж
/// </summary>
public class Plane : MonoBehaviour
{
    [Header("Roll Крен")]
    public float xAngle;
    [Header("Yaw Рыскание")]
    public float yAngle;
    [Header("Pitch Тангаж")]
    public float zAngle;
    public bool isLocal = false;

    void Update()
    {
        if (isLocal)
        {
            transform.Rotate(xAngle, yAngle, zAngle, Space.Self);
        }
        else
        {
            transform.Rotate(xAngle, yAngle, zAngle, Space.World);
        }
    }

}
