using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// максимальная скорость мыши на экране
/// </summary>
public class DeltaPos : MonoBehaviour
{
    Vector2 lastMousepos;
    public float topSpeedX;
    public float topSpeedY;
    void Start()
    {
        lastMousepos = Input.mousePosition;
    }

    // Update is called once per frame
    void Update()
    {
        float AxisX = ((Input.mousePosition.x - lastMousepos.x) / Time.deltaTime) / Screen.width;
        float AxisY = ((Input.mousePosition.y - lastMousepos.y) / Time.deltaTime) / Screen.height;
        lastMousepos = Input.mousePosition;
        Vector2 deltaPos = new Vector2(AxisX, AxisY);

        if (topSpeedX < AxisX)
            topSpeedX = AxisX;
        if (topSpeedY < AxisY)
            topSpeedY = AxisY;
        
        Debug.Log("deltaPos = " + deltaPos);

    }
}
