using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class DoTweenScriptUI : MonoBehaviour
{
    public Transform obj;

    public Tweener slideTweener;
    public Tweener fadeTweener;
    public Tweener scaleTweener;
    public Tweener rotateTweener;

    public bool slideRepeat = false;
    public bool fadeRepeat = false;
    public bool scaleRepeat = false;
    public bool rotateRepeat = false;

    public bool slideBool = true;
    public bool fadeBool = true;
    public bool scaleBool = true;
    public bool rotateBool = true;

    public Vector3 vecSlide;
    public Vector3 vecSlide2;
    public Vector3 vecScale;
    public Vector3 vecScale2;
    public Vector3 vecRotate;
    public Vector3 vecRotate2;
    public Ease ease;
    public float duration = 2;
    public bool isPaused = false;
    void Start()
    {
        slideTweener = obj.DOMove(vecSlide2, duration).SetAutoKill(false).SetEase(ease);
        fadeTweener = obj.gameObject.GetComponent<RawImage>().DOColor(new Color(1, 1, 1, 1), duration).SetAutoKill(false);
        scaleTweener = obj.DOScale(vecScale2, duration).SetAutoKill(false).SetEase(ease);
        rotateTweener = obj.DORotate(vecRotate2, duration).SetAutoKill(false).SetEase(ease);
    }

    void Update()
    {
        if (!isPaused)
        {
            if (slideRepeat)
            {
                if (slideTweener.IsComplete())
                {
                    ToggleSlide();
                }
            }
            if (fadeRepeat)
            {
                if (fadeTweener.IsComplete())
                {
                    ToggleFade();
                }
            }
            if (scaleRepeat)
            {
                if (scaleTweener.IsComplete())
                {
                    ToggleScale();
                }
            }
            if (rotateRepeat)
            {
                if (rotateTweener.IsComplete())
                {
                    ToggleRotate();
                }
            }
        }
    }
    public void ToggleSlide()
    {
        if (slideBool)
        {
            slideTweener = obj.DOMove(vecSlide, duration).SetAutoKill(false).SetEase(ease);
        }
        else
        {
            slideTweener = obj.DOMove(vecSlide2, duration).SetAutoKill(false).SetEase(ease);
        }
        slideBool = !slideBool;
    }

    public void ToggleFade()
    {
        if (fadeBool)
        {
            fadeTweener = obj.gameObject.GetComponent<RawImage>().DOColor(new Color(0, 0, 0, 0), duration).SetAutoKill(false);
        }
        else
        {
            fadeTweener = obj.gameObject.GetComponent<RawImage>().DOColor(new Color(1, 1, 1, 1), duration).SetAutoKill(false);
        }
        fadeBool = !fadeBool;
    }

    public void ToggleScale()
    {
        if (scaleBool)
        {
            scaleTweener = obj.DOScale(vecScale, duration).SetAutoKill(false).SetEase(ease);
        }
        else
        {
            scaleTweener = obj.DOScale(vecScale2, duration).SetAutoKill(false).SetEase(ease);
        }
        scaleBool = !scaleBool;
    }

    public void ToggleRotate()
    {
        if (rotateBool)
        {
            rotateTweener = obj.DORotate(vecRotate, duration).SetAutoKill(false).SetEase(ease);
        }
        else
        {
            rotateTweener = obj.DORotate(vecRotate2, duration).SetAutoKill(false).SetEase(ease);
        }
        rotateBool = !rotateBool;
    }
    public void AutoSlide()
    {
        slideRepeat = !slideRepeat;
    }
    public void AutoFade()
    {
        fadeRepeat = !fadeRepeat;
    }
    public void AutoScale()
    {
        scaleRepeat = !scaleRepeat;
    }
    public void AutoRotate()
    {
        rotateRepeat = !rotateRepeat;
    }
    public void PauseToggle()
    {
        isPaused = !isPaused;
    }
}
