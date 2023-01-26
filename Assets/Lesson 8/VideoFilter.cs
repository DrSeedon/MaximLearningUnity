using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Video;

public class VideoFilter : MonoBehaviour
{
    public string URLAbsolute;
    public string URLDataPath;
    public string URLStrAssets;
    public VideoPlayer videoPl;
    public bool video1 = false;
    public bool video2 = false;
    public bool video3 = false;
    

    void Start()
    {
        if (video1) LoadVideoAbslPAth(URLAbsolute);
        if (video2) LoadVideoDataPath(URLDataPath);
        if (video3) LoadVideoStrAssets(URLStrAssets);

    }

    void Update()
    {
        if (videoPl.url == "") return;

    }
    public void LoadVideoDataPath(string path)
    {
        string temp = Application.dataPath + path;
        videoPl.url = temp;
        videoPl.Prepare();

    }
    public void LoadVideoStrAssets(string path)
    {
        string temp = Application.streamingAssetsPath + path;
        videoPl.url = temp;
        videoPl.Prepare();


    }
    public void LoadVideoAbslPAth(string path)
    {
        videoPl.url = path;
        videoPl.Prepare();
        videoPl.waitForFirstFrame = true;

    }

}
