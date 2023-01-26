using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ObjectVideoScript : MonoBehaviour
{
    public string path;
    public TextMeshProUGUI text;
    public RawImage image;
    public GameObject objVideo;
    public int objCount = 0;
    void Start()
    {
        
    }

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
        VideoController.instance.playingIndex = VideoController.instance.queueList.Count - 1;
    }

    public void OrderInQueueButton()
    {
        GameObject obj = Instantiate(objVideo, VideoController.instance.objListInQueue);
        VideoController.instance.objCountInQueue++;
        if (VideoController.instance.objCountInQueue > 5)
        {
            VideoController.instance.objListInQueue.gameObject.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, VideoController.instance.objListInQueue.gameObject.GetComponent<RectTransform>().rect.height + 50);
        }
        VideoController.instance.queueList.Add(obj.GetComponent<ObjectQueueScript>());
        VideoController.instance.queueList[VideoController.instance.objCountInQueue - 1].path = path;
        VideoController.instance.RefreshQueue();
        VideoController.instance.queueList[VideoController.instance.objCountInQueue - 1].text.text = Path.GetFileName(path);
    }

    public void DeletFromListButton()
    {
        Destroy(gameObject);
        VideoController.instance.objCount--;
    }


}
