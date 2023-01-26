using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEditor;

public class ChangeImage : MonoBehaviour
{
    public Texture[] textures;
    public Texture[] texturesAlready;
    public GameObject original;
    Texture2D tex;


    void Start()
    {
        for (int i = 0; i < texturesAlready.Length; i++)
        {
            GameObject obj = Instantiate(original, transform);
            obj.transform.SetParent(transform);
            obj.GetComponent<RawImage>().texture = texturesAlready[i];
            obj.GetComponent<RawImage>().SetNativeSize();
            obj.SetActive(true);
        }
        string path = Application.streamingAssetsPath;
        Debug.Log(path);
        var dir = Directory.GetFiles(path,"*.png");
        foreach (var item in dir)
        {
            Debug.Log(item);
            byte[] pngBytes = File.ReadAllBytes(item);
            tex = new Texture2D(2, 2);
            tex.LoadImage(pngBytes);
            GameObject obj = Instantiate(original, transform);
            obj.transform.SetParent(transform);
            obj.GetComponent<RawImage>().texture = tex;
            obj.GetComponent<RawImage>().SetNativeSize();
            obj.SetActive(true);
        }

        StartCoroutine(GetText("https://cdn.pixabay.com/photo/2016/11/04/21/34/beach-1799006_960_720.jpg"));
        StartCoroutine(GetText("https://cdn.pixabay.com/photo/2017/08/30/01/05/milky-way-2695569_960_720.jpg"));
        StartCoroutine(GetText("https://cdn.pixabay.com/photo/2017/09/12/11/56/universe-2742113_960_720.jpg"));
    }


    IEnumerator GetText(string url)
    {
        using UnityWebRequest uwr = UnityWebRequestTexture.GetTexture(url);
        yield return uwr.SendWebRequest();

        if (uwr.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(uwr.error);
        }
        else
        {
            var texture = DownloadHandlerTexture.GetContent(uwr);
            GameObject obj = Instantiate(original, transform);
            obj.transform.SetParent(transform);
            obj.GetComponent<RawImage>().texture = texture;
            obj.GetComponent<RawImage>().SetNativeSize();
            obj.SetActive(true);
        }
    }
    public void AddImage()
    {
        GameObject obj = Instantiate(original, transform);
        obj.transform.SetParent(transform);
        obj.GetComponent<RawImage>().texture = textures[Random.Range(0, 3)];
        obj.GetComponent<RawImage>().SetNativeSize();
        obj.SetActive(true);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
