using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// перемещать скрол в определенную позицию
/// </summary>
public class ScrollController : MonoBehaviour
{
    public static Vector3 newPose;
    public static bool SelectMove;
    public Transform scrollContainer;
    public float lerpTime;

    private void Update()
    {
        if(scrollContainer.position != newPose && SelectMove)
        {
            scrollContainer.position = Vector3.Lerp(scrollContainer.position, newPose, lerpTime * Time.deltaTime);
        }
        if(Vector3.Distance(scrollContainer.position, newPose) < .01f)
        {
            scrollContainer.position = newPose;
            SelectMove = false;
        }
        if (Input.GetMouseButton(0))
        {
            SelectMove = false;
        }
    }
}
