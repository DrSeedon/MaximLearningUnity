using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DoTweenScript : MonoBehaviour
{
    public Transform obj;
    public Transform obj2;
    public Color color;
    public Tweener tweener;
    void Start()
    {
        Material mat = obj.gameObject.GetComponent<Renderer>().material;
        obj.DOMove(new Vector3(0, 7, 0), 10).SetLoops(-1, LoopType.Yoyo);
        obj.DORotate(new Vector3(0, 90, 0), 2).SetRelative().SetEase(Ease.Linear).SetLoops(-1, LoopType.Incremental);
        tweener = mat.DOColor(RandomColor(), 2).SetLoops(-1, LoopType.Yoyo).OnStepComplete(() => {
                tweener.ChangeEndValue(RandomColor(), true);
        });

        Material mat2 = obj2.gameObject.GetComponent<Renderer>().material;
        mat2.DOColor(new Color(0, 0, 0, 0), 1);




    }

    void Update()
    {

    }

    Color RandomColor()
    {
        color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 1);
        return color;
    }
}
