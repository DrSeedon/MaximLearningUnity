using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MovingCube : MonoBehaviour
{
    public Tweener tweener;
    void Start()
    {
        Vector3 pos = new Vector3(transform.position.x + 100, transform.position.y, transform.position.z);
        tweener = transform.DOMove(pos, 2).SetLoops(3, LoopType.Restart).SetEase(Ease.Linear).Pause().SetDelay(2)
            .OnComplete(() =>
            {
                Debug.Log("complete");
            })
            .OnStepComplete(() =>
            {
                Debug.Log("step complete");
            })
            .OnStart(() =>
            {
                Debug.Log("start");
            });
        tweener.Play();
    }

    void Update()
    {
        
    }
}
