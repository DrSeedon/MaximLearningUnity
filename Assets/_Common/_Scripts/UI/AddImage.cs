using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using DG.Tweening;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class AddImage : MonoBehaviour
{
    public GameObject prefab;
    public ImageFilter imageFilter;
    public int count = 60;
    public int horizontalCount = 12;
    public bool isNotRepeating;

    private int _oldCount;
    [SerializeField] private int createImageObj = 600;

    private GridLayoutGroup _grid;
    [SerializeField] private List<RawImage> _images = new List<RawImage>();

    void Start()
    {
        _grid = GetComponent<GridLayoutGroup>();
        CreateArrayImage();

        SendCreateImage();
    }

    private float _oldhorizontalCount;

    private void Update()
    {
        ChangeSize();
        count = horizontalCount * horizontalCount;
        if (_oldhorizontalCount != horizontalCount)
        {
            _oldhorizontalCount = horizontalCount;
            SendCreateImage();
        }
    }

    private void ChangeSize()
    {
        _grid.cellSize = new Vector2((float) Screen.width / horizontalCount, (float) Screen.height / horizontalCount);
    }

    public void SendCreateImage()
    {
        CreateImages(isNotRepeating);
    }

    public void CreateImages(bool notRepeating)
    {
        if (notRepeating)
        {
            var textures = RandomNotRepeating();
            int maxTexturesCount = textures.Count;
            int j = 0;
            for (int i = 0; i < count; i++)
            {
                if (j >= maxTexturesCount)
                {
                    j = 0;
                    textures = RandomNotRepeating();
                }

                ChangeImage(i, textures[j++]);
            }
        }
        else
        {
            for (int i = 0; i < count; i++)
            {
                var tex = RandomImage();
                ChangeImage(i, tex);
            }
        }
    }

    public Tweener tweener;

    private async void ChangeImage(int index, Texture2D tex)
    {
        var texture = _images[index];
        
        texture.transform.DOScale(0.5f, 1);
        texture.transform.DORotate(new Vector3(0, 0, 10), 1);
        await texture.DOFade(0, 1).AsyncWaitForCompletion();
        
        texture.texture = tex;
        
        tweener = texture.DOFade(1, 1);
        texture.transform.DOScale(1f, 1);
        texture.transform.DORotate(new Vector3(0, 0, 0), 1);
    }

    private void CreateArrayImage()
    {
        for (int i = 0; i < createImageObj; i++)
        {
            var obj = Instantiate(prefab, transform);
            obj.transform.SetParent(transform);
            _images.Add(obj.GetComponent<RawImage>());
        }
    }

    private Texture2D RandomImage()
    {
        return imageFilter.textures[Random.Range(0, imageFilter.textures.Count)];
    }

    private List<Texture2D> RandomNotRepeating()
    {
        var a = new List<Texture2D>(imageFilter.textures);
        Shuffle(ref a);
        return a;
    }

    private void Shuffle<T>(ref List<T> list)
    {
        RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();
        int n = list.Count;
        while (n > 1)
        {
            byte[] box = new byte[1];
            do provider.GetBytes(box);
            while (!(box[0] < n * (Byte.MaxValue / n)));
            int k = (box[0] % n);
            n--;
            (list[k], list[n]) = (list[n], list[k]);
        }
    }
}