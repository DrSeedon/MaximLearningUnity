using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TimeManager : MonoBehaviour
{
    public float maxCount;
    public float count;
    public UnityEvent Event;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        count -= Time.fixedDeltaTime;
        if (count <= 0)
        {
            Event.Invoke();
            count = maxCount;
        }
    }
}
