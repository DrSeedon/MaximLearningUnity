using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyLog : MonoBehaviour
{
    public bool mousePos = false;
    void Update()
    {
        if (mousePos)
        {
            Debug.Log(Input.mousePosition);

        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Space нажал");
        }
        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("Space зажал");
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            Debug.Log("Space отжал");
        }

        if(Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.C))
        {
            Debug.Log("Control + C");
        }

        if(Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.V))
        {
            Debug.Log("Control + V");
        }
    }
}
