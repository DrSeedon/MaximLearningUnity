using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ObjectQueueScript : MonoBehaviour
{
    public string path;
    public int index;
    public TextMeshProUGUI text;
    public Color readyColor;
    public Color unreadyColor;
    public Image image;
    void Start()
    {
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayVideoButton()
    {
        VideoController.instance.PlayVideoByPath(path);
        foreach (var item in VideoController.instance.queueList)
        {
            item.StoppedPlayed();
        }
        image.color = readyColor;
        VideoController.instance.playingIndex = index;
    }
    public void DeletFromListButton()
    {
        VideoController.instance.queueList.Remove(this);
        Destroy(gameObject);
        VideoController.instance.objCountInQueue--;
        VideoController.instance.RefreshQueue();
    }

    public void StoppedPlayed()
    {
        image.color = unreadyColor;
    }

}
