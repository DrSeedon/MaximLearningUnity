using SFB;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoController : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    public static VideoController instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != null)
        {
            Destroy(gameObject);
        }
    }
    public VideoPlayer videoPlayer;
    public string[] path;
    public GameObject objVideo;
    public Transform objList;
    public Transform objListInQueue;
    public int objCount = 0;
    public int objCountInQueue = 0;
    public TextMeshProUGUI videoInfoText;
    public List<ObjectQueueScript> queueList = new List<ObjectQueueScript>();

    public int playingIndex;

    public string[] extensions = { "*.png", "*.jpg" };
    public string dir;
    public string[] dirVideos;

    public Image progress;
    public Image progress2;
    public bool slide = true;
    public Camera cam;
    void Start()
    {
        videoPlayer.loopPointReached += EndReached;
        //videoPlayer.started затемнение при воспроизведении
    }

    void Update()
    {
        if (videoPlayer.frameCount > 0 && slide)
        {
            progress.fillAmount = (float)videoPlayer.frame / (float)videoPlayer.frameCount;
            progress2.fillAmount = (float)videoPlayer.frame / (float)videoPlayer.frameCount;
        }
    }

    public void Play()
    {
        videoPlayer.Play();
    }

    public void Pause()
    {
        videoPlayer.Pause();
    }

    public void Stop()
    {
        videoPlayer.Stop();
    }

    public void RefreshQueue()
    {
        for (int i = 0; i < objListInQueue.childCount; i++)
        {
            objListInQueue.GetChild(i).GetComponent<ObjectQueueScript>().index = i;
        }
    }

    public void NextVideo()
    {
        RefreshQueue();
        if (playingIndex == queueList.Count - 1)
        {
            queueList[0].PlayVideoButton();
        }
        else
        {
            queueList[playingIndex + 1].PlayVideoButton();
        }
    }

    public void PreviousVideo()
    {
        RefreshQueue();
        if (playingIndex == 0)
        {
            queueList[queueList.Count - 1].PlayVideoButton();
        }
        else
        {
            queueList[playingIndex - 1].PlayVideoButton();
        }
    }
    void EndReached(VideoPlayer vp)
    {
        NextVideo();
    }
    public void LoadVideoButton()
    {
        path = StandaloneFileBrowser.OpenFilePanel("Open video file", "", "mp4", true);
        LoadVideo(path);
    }

    public void FindInFolderButton()
    {

        path = StandaloneFileBrowser.OpenFolderPanel("Open video folder", "", true);

        dirVideos = FilesFilter.instance.FilterFilesByExtension(path, extensions);

        LoadVideo(dirVideos);

    }

    public void OnPointerDown(PointerEventData data)
    {
        TrySkip(data);
        videoPlayer.Pause();
    }
    public void OnPointerUp(PointerEventData data)
    {
        slide = true;
        videoPlayer.Play();
    }

    public void OnDrag(PointerEventData data)
    {
        TrySkip(data);
        videoPlayer.Pause();

    }
    public void TrySkip(PointerEventData eventdata)
    {
        Vector2 localpoint;
        var a = eventdata.pointerCurrentRaycast.screenPosition;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(progress2.rectTransform, eventdata.position, cam, out localpoint))
        {
            float minRectX = progress2.rectTransform.rect.xMin;
            float maxRectX = progress2.rectTransform.rect.xMax;
            float prsnt = Mathf.InverseLerp(minRectX, maxRectX, a.x - 960);
            GoToFrame(prsnt);
        }


    }
    public void GoToFrame(float persent)
    {
        var frame = videoPlayer.frameCount * persent;
        videoPlayer.frame = (long)frame;
        progress.fillAmount = (float)frame / (float)videoPlayer.frameCount;
        progress2.fillAmount = (float)frame / (float)videoPlayer.frameCount;
        slide = false;


    }

    public void LoadVideo(string[] path)
    {
        for (int i = 0; i < path.Length; i++)
        {
            GameObject obj = Instantiate(objVideo, objList);
            objCount++;
            if (objCount > 4)
            {
                objList.gameObject.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, objList.gameObject.GetComponent<RectTransform>().rect.height + 230);
            }
            ObjectVideoScript objScript = obj.GetComponent<ObjectVideoScript>();
            objScript.path = path[i];
            objScript.text.text = Path.GetFileName(path[i]);
        }
    }

    public void PlayVideoByPath(string path)
    {
        if (path.Length != 0)
        {
            videoPlayer.url = path;
            videoPlayer.Prepare();
            videoPlayer.waitForFirstFrame = true;
            videoInfoText.text = Path.GetFileName(path);
        }
    }

    public void ExitApplication()
    {
        Application.Quit();
    }
}
