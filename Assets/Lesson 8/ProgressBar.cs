using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.Events;

public delegate void DelVideoCompleted();


public class ProgressBar : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    public void OnPointerDown(PointerEventData data)
    {
        Debug.Log("down");

        VideoController.instance.TrySkip(data);
        VideoController.instance.videoPlayer.Pause();
    }

    public void OnPointerUp(PointerEventData data)
    {
        Debug.Log("up");
        VideoController.instance.slide = true;
        VideoController.instance.videoPlayer.Play();
    }

    public void OnDrag(PointerEventData data)
    {
        Debug.Log("drag");
        VideoController.instance.TrySkip(data);
        VideoController.instance.videoPlayer.Pause();

    }
}



